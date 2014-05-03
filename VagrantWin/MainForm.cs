﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VagrantWin.Properties;

namespace VagrantWin
{
    public partial class MainForm : Form
    {
        readonly BindingList<VagrantData> _vagrantDatas = new BindingList<VagrantData>();

        private readonly VagratWrapper _vagrantWrapper = new VagratWrapper();

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
            cancelButton.Enabled = (_vagrantWrapper.CurrentCommand != "status");
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

            _vagrantWrapper.StartVagrantProcessAsync(VagrantFilePath, "status");

            readButton.Enabled = true;
        }
        private void statusButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var commandName = button.Text.ToLower();
                _vagrantWrapper.StartVagrantProcessAsync(VagrantFilePath, commandName);
            }
        }

        private void destroyButton_Click(object sender, EventArgs e)
        {
            PostMessage(Handle, WM_APP_CENTERMSG, 0, IntPtr.Zero);
            if (MessageBox.Show(Resources.DestroyMessage, @"destroy", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.OK)
            {
                var commandName = destroyButton.Text.ToLower();
                _vagrantWrapper.StartVagrantProcessAsync(VagrantFilePath, commandName);
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

        #region MessageBoxHack

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport("user32.dll", EntryPoint = "PostMessageA")]
        static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport("user32.dll")]
        static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"),
         DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hWnd, int x, int y, int w, int h, int repaint);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        const int WM_APP = 0x8000;
        const int WM_APP_CENTERMSG = WM_APP;
        private const string BAR = "----------------------------------------------------------------------------------";

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_APP_CENTERMSG)
            {
                IntPtr hWnd = GetForegroundWindow();
                if (hWnd != this.Handle)
                {
                    var r = new RECT();
                    GetWindowRect(hWnd, ref r);
                    int w = r.right - r.left;
                    int h = r.bottom - r.top;
                    int x = Left + (Width - w) / 2;
                    int y = Top + (Height - h) / 2;
                    MoveWindow(hWnd, x, y, w, h, 0);
                }
            }
        }
        #endregion
    }
}
