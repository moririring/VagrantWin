using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using VagrantWin.Properties;

namespace VagrantWin
{
    public partial class MainForm : Form, IWindowMessageHook
    {
        readonly BindingList<VagrantData> _vagrantDatas = new BindingList<VagrantData>();


        private readonly VagrantWrapper _vagrantWrapper = new VagrantWrapper();
        private readonly MessageBoxReplacer _replacer;

        private const string BAR = "----------------------------------------------------------------------------------";

        private string VagrantFilePath
        {
            get { return vagrantfileTextBox.Text; }
            set { vagrantfileTextBox.Text = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            vagrantDataBindingSource.DataSource = _vagrantDatas;

            _vagrantWrapper.OutputMessageReceived += VagrantWrapper_OnOutputMessageReceived;

            _vagrantWrapper.ErrorMessageReceived += VagrantWrapper_OnErrorMessageReceived;

            _vagrantWrapper.VagrantProcessStarted += VagrantWrapper_OnVagrantProcessStarted;

            _vagrantWrapper.VagrantProcessCompleted += VagrantWrapper_OnVagrantProcessCompleted;

            _replacer = new MessageBoxReplacer(this);
        }

        private void VagrantWrapper_OnOutputMessageReceived(object _, VagrantMessageEventHandler e)
        {
            this.SafeInvoke(() =>
            {
                if (string.IsNullOrEmpty(e.Message))
                {
                    return;
                }

                consoleTextBox.HideSelection = false;
                consoleTextBox.AppendText(e.Message + Environment.NewLine);
                var vagrantData = VagrantData.GetVagrantDataParseLine(e.Message);
                if (vagrantData != null)
                {
                    UpdaetVagrantData(vagrantData);
                }
            });
        }

        private void VagrantWrapper_OnErrorMessageReceived(object _, VagrantMessageEventHandler e)
        {
            this.SafeInvoke(() =>
            {
                if (string.IsNullOrEmpty(e.Message))
                {
                    return;
                }

                consoleTextBox.HideSelection = false;
                consoleTextBox.AppendText(e.Message + Environment.NewLine);
            });
        }

        private void VagrantWrapper_OnVagrantProcessStarted(object _, EventArgs __)
        {
            commandGroupBox.Enabled = false;
            cancelButton.Visible = true;
            cancelButton.Enabled = (_vagrantWrapper.CurrentCommand != VagrantCommand.Status);
            consoleTextBox.Focus();
            consoleTextBox.Select(consoleTextBox.Text.Length, 0);
        }

        private void VagrantWrapper_OnVagrantProcessCompleted(object _, EventArgs __)
        {
            consoleTextBox.HideSelection = false;
            consoleTextBox.AppendText(BAR + Environment.NewLine);
            commandGroupBox.Enabled = true;
            cancelButton.Visible = false;
        }


        private void UpdaetVagrantData(VagrantData vagrantData)
        {
            var hit = _vagrantDatas.SingleOrDefault(v => v.Name == vagrantData.Name);
            if (hit != null)
            {
                hit.Status = vagrantData.Status;
                hit.Provider = vagrantData.Provider;
                SetStatus(hit.Status);
            }
            else
            {
                _vagrantDatas.Add(vagrantData);
                SetStatus(vagrantData.Status);
            }
            vagrantDataGridView.Invalidate();
            vagrantDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void SetStatus(string status)
        {
            upButton.Enabled = false;
            haltButton.Enabled = false;
            provisionButton.Enabled = false;
            destroyButton.Enabled = false;
            if (status == "poweroff")
            {
                upButton.Enabled = true;
                destroyButton.Enabled = true;
            }
            else if (status == "running")
            {
                haltButton.Enabled = true;
                provisionButton.Enabled = true;
                destroyButton.Enabled = true;
            }
            else
            {
                upButton.Enabled = true;
            }
            statusButton.Enabled = true;
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            consoleTextBox.Focus();
            consoleTextBox.Select(consoleTextBox.Text.Length, 0);
            vagrantfileOpenFileDialog.ShowDialog();
        }

        private void vagrantfileOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            readButton.Enabled = false;
            VagrantFilePath = vagrantfileOpenFileDialog.FileName;

            _vagrantWrapper.StartVagrantProcessAsync(VagrantFilePath, VagrantCommand.Status);

            readButton.Enabled = true;
        }
        private void statusButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var commandName = button.Text.ToLower();
                _vagrantWrapper.StartVagrantProcessAsync(VagrantFilePath, VagrantWrapper.ToCommand(commandName));
            }

            MessageBox.Show("Called!");
        }

        private void destroyButton_Click(object sender, EventArgs e)
        {
            _replacer.ReplaceNextMessageBoxPosition();
            if (MessageBox.Show(Resources.DestroyMessage, @"destroy", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.OK)
            {
                var commandName = destroyButton.Text.ToLower();
                _vagrantWrapper.StartVagrantProcessAsync(VagrantFilePath, VagrantWrapper.ToCommand(commandName));
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutVagrantWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutVagrantWinBox();
            form.ShowDialog();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _vagrantWrapper.CancelCurrentVagrantProcess();
        }

        public event EventHandler<WindowMessageEventArgs> WindowMessageReceived;

        protected virtual void OnWindowMessageReceived(Message msg)
        {
            var handler = WindowMessageReceived;
            if (handler != null) handler(this, new WindowMessageEventArgs(msg, this));
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            OnWindowMessageReceived(m);
        }
    }
}
