using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using VagrantWin.Properties;

namespace VagrantWin
{
    public partial class MainForm : Form, IWindowMessageHook
    {
        private readonly BindingList<VagrantData> _vagrantDatas = new BindingList<VagrantData>();
        private readonly BindingList<VagrantBoxData> _vagrantBoxDatas = new BindingList<VagrantBoxData>();
        private readonly VagrantWrapper _vagrantWrapper = new VagrantWrapper();
        //vagrantDirectoryTextBox.Textはディレクトリ、VagrantFilePathはファイル
        private string VagrantFilePath { set; get; }

        private readonly MessageBoxReplacer _replacer;

        private const string BAR = "----------------------------------------------------------------------------------";

        WebClient _downloadClient = null;

        public MainForm()
        {
            InitializeComponent();
            vagrantDataBindingSource.DataSource = _vagrantDatas;
            vagrantBoxDataBindingSource.DataSource = _vagrantBoxDatas;

            _vagrantWrapper.OutputMessageReceived += VagrantWrapper_OnOutputMessageReceived;

            _vagrantWrapper.ErrorMessageReceived += VagrantWrapper_OnErrorMessageReceived;

            _vagrantWrapper.VagrantProcessStarted += VagrantWrapper_OnVagrantProcessStarted;

            _vagrantWrapper.VagrantProcessCompleted += VagrantWrapper_OnVagrantProcessCompleted;

            _replacer = new MessageBoxReplacer(this);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.IsUpgrade == false)
            {
                Settings.Default.Upgrade();
                Settings.Default.IsUpgrade = true;
                Settings.Default.Save();
            }
            if (Directory.Exists(Settings.Default.VagrantPath))
            {
                vagrantDirectoryTextBox.Text = Settings.Default.VagrantPath;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.VagrantPath = vagrantDirectoryTextBox.Text;
            Settings.Default.Save();
        }


        private void VagrantWrapper_OnOutputMessageReceived(object _, VagrantMessageEventHandler e)
        {
            this.SafeInvoke(() =>
            {
                if (string.IsNullOrEmpty(e.Message))
                {
                    return;
                }

                //非同期なのでWaitForExitが終わってからここが書かれるケースもある
                consoleTextBox.HideSelection = false;
                consoleTextBox.AppendText(e.Message + Environment.NewLine);

                var vagrantData = new VagrantData();
                if (vagrantData.GetVagrantDataParseCommandLine(e.Message))
                {
                    UpdaetVagrantData(vagrantData);
                }
                var vagrantBoxData = new VagrantBoxData();
                if (vagrantBoxData.GetVagrantBoxDataParseCommandLine(e.Message))
                {
                    UpdaetVagrantBoxData(vagrantBoxData);
                }
                removeButton.Enabled = (_vagrantBoxDatas.Count > 0);
                initButton.Enabled = (_vagrantBoxDatas.Count > 0);
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
            boxCommandGroupBox.Enabled = false;
            cancelButton.Visible = true;
            cancelButton.Enabled = (_vagrantWrapper.CurrentCommand != VagrantCommand.Status);
            consoleTextBox.Focus();
            consoleTextBox.Select(consoleTextBox.Text.Length, 0);
        }

        private void VagrantWrapper_OnVagrantProcessCompleted(object _, EventArgs __)
        {
            consoleTextBox.HideSelection = false;
            consoleTextBox.AppendText(Resources.CommandLineEOF + Environment.NewLine);
            commandGroupBox.Enabled = true;
            boxCommandGroupBox.Enabled = true;
            cancelButton.Visible = false;
            if (_vagrantWrapper.CurrentCommand == VagrantCommand.Init)
            {
                CheckVagrantFile();
            }
        }

        private void UpdaetVagrantBoxData(VagrantBoxData vagrantBoxData)
        {
            //既に名前があれば更新、なければ追加
            var hit = _vagrantBoxDatas.SingleOrDefault(v => v.Name == vagrantBoxData.Name);
            if (hit != null)
            {
                hit.Provider = vagrantBoxData.Provider;
            }
            else
            {
                _vagrantBoxDatas.Add(vagrantBoxData);
            }
            vagrantBoxDataGridView.Invalidate();
            vagrantBoxDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void UpdaetVagrantData(VagrantData vagrantData)
        {
            //既に名前があれば更新、なければ追加
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
        private void CheckVagrantFile()
        {
            var vagrantfile = Path.Combine(vagrantDirectoryTextBox.Text, "vagrantfile");
            if (File.Exists(vagrantfile))
            {
                readButton.Enabled = false;
                commandTabControl.SelectedIndex = 1;
                VagrantFilePath = vagrantfile;
                _vagrantWrapper.ExecuteVagrantCommandAsync(VagrantFilePath,VagrantCommand.Status);
                readButton.Enabled = true;
            }
            //
            boxButton.Enabled = true;
            addButton.Enabled = true;
            listButton.Enabled = true;
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            consoleTextBox.Focus();
            consoleTextBox.Select(consoleTextBox.Text.Length, 0);
            if (Directory.Exists(vagrantDirectoryTextBox.Text))
            {
                vagrantfileFolderBrowserDialog.SelectedPath = vagrantDirectoryTextBox.Text;
            }
            if (vagrantfileFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                vagrantDirectoryTextBox.Text = vagrantfileFolderBrowserDialog.SelectedPath;
            }
        }

        private void vagrantfileTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(vagrantDirectoryTextBox.Text))
            {
                CheckVagrantFile();
            }
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var commandName = button.Text.ToLower();
                _vagrantWrapper.ExecuteVagrantCommandAsync(VagrantFilePath, VagrantWrapper.ToCommand(commandName));
            }
        }
        private void destroyButton_Click(object sender, EventArgs e)
        {
            _replacer.ReplaceNextMessageBoxPosition();
            if (MessageBox.Show(Resources.DestroyMessage, @"destroy", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.OK)
            {
                var commandName = destroyButton.Text.ToLower();
                _vagrantWrapper.ExecuteVagrantCommandAsync(VagrantFilePath, VagrantWrapper.ToCommand(commandName));
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


        private void boxButton_Click(object sender, EventArgs e)
        {
            boxButton.Enabled = false;
            var form = new BoxListForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var fileName = Path.Combine(vagrantDirectoryTextBox.Text, Path.GetFileName(form.SelectUrl));
                var uri = new Uri(form.SelectUrl);

                boxFileNameToolStripStatusLabel.Visible = true;
                boxFileToolStripSplitButton.Visible = true;
                boxFileToolStripProgressBar.Visible = true;
                boxFileNameToolStripStatusLabel.Text = Path.GetFileName(form.SelectUrl);
                boxFileToolStripSplitButton.Text = string.Format("0/0Mbyte");

                _downloadClient = new WebClient();
                _downloadClient.DownloadProgressChanged += (s, ea) =>
                {
                    boxFileToolStripSplitButton.Text = string.Format("{0}/{1}Mbyte", ea.BytesReceived / 1024 / 1024, ea.TotalBytesToReceive / 1024 / 1024);
                    boxFileToolStripProgressBar.Value = (int)ea.ProgressPercentage;
                };
                _downloadClient.DownloadFileCompleted += (s, ea) =>
                {
                    if (ea.Error != null)
                        Console.WriteLine("エラー:{0}", ea.Error.Message);
                    else if (ea.Cancelled)
                        Console.WriteLine("キャンセルされました。");
                    else
                        Console.WriteLine("ダウンロードが完了しました。");

                    boxFileNameToolStripStatusLabel.Visible = false;
                    boxFileToolStripSplitButton.Visible = false;
                    boxFileToolStripProgressBar.Visible = false;
                    boxButton.Enabled = true;
                };
                _downloadClient.DownloadFileAsync(uri, fileName);
            }
            else
            {
                boxButton.Enabled = true;
            }
        }
        private void boxFileCancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _downloadClient.CancelAsync();
        }
        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(vagrantDirectoryTextBox.Text))
            {
                Process.Start(vagrantDirectoryTextBox.Text);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var form = new AddForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _vagrantWrapper.AddBoxAsync(vagrantDirectoryTextBox.Text,  form._name, form._url);
            }
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            _vagrantWrapper.ListBoxAsync(vagrantDirectoryTextBox.Text);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (var boxData in _vagrantBoxDatas.Where(x => x.Check))
            {
                _vagrantWrapper.RemoveBoxAsync(vagrantDirectoryTextBox.Text, boxData.Name);
            }
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            foreach (var boxData in _vagrantBoxDatas.Where(x => x.Check))
            {
                _vagrantWrapper.InitWithBoxNameAsync(vagrantDirectoryTextBox.Text, boxData.Name);
            }
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
