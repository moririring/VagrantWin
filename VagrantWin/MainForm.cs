﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VagrantWin.Properties;

namespace VagrantWin
{
    public partial class MainForm : Form
    {
        private readonly BindingList<VagrantData> _vagrantDatas = new BindingList<VagrantData>();
        private readonly BindingList<VagrantBoxData> _vagrantBoxDatas = new BindingList<VagrantBoxData>();
        private readonly VagratWrapper _vagrantWrapper = new VagratWrapper();
        //vagrantDirectoryTextBox.Textはディレクトリ、VagrantFilePathはファイル
        private string VagrantFilePath { set; get; }

//        private string VagrantFilePath
//        {
//            get { return vagrantPathTextBox.Text; }
//            set { vagrantPathTextBox.Text = value; }
//        }
        public MainForm()
        {
            InitializeComponent();
            vagrantDataBindingSource.DataSource = _vagrantDatas;
            vagrantBoxDataBindingSource.DataSource = _vagrantBoxDatas;

            _vagrantWrapper.OutputMessageReceived += VagrantWrapper_OnOutputMessageReceived;

            _vagrantWrapper.ErrorMessageReceived += VagrantWrapper_OnErrorMessageReceived;

            _vagrantWrapper.VagrantProcessStarted += VagrantWrapper_OnVagrantProcessStarted;

            _vagrantWrapper.VagrantProcessCompleted += VagrantWrapper_OnVagrantProcessCompleted;
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
            cancelButton.Enabled = (_vagrantWrapper.CurrentCommand != "status");
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
            if (_vagrantWrapper.CurrentCommand.Contains("init"))
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
                _vagrantWrapper.StartVagrantProcessAsync(VagrantFilePath, "status");
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


        WebClient downloadClient = null;
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

                downloadClient = new WebClient();
                downloadClient.DownloadProgressChanged += (s, ea) =>
                {
                    boxFileToolStripSplitButton.Text = string.Format("{0}/{1}Mbyte", ea.BytesReceived / 1024 / 1024, ea.TotalBytesToReceive / 1024 / 1024);
                    boxFileToolStripProgressBar.Value = (int)ea.ProgressPercentage;
                };
                downloadClient.DownloadFileCompleted += (s, ea) =>
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
                downloadClient.DownloadFileAsync(uri, fileName);
            }
            else
            {
                boxButton.Enabled = true;
            }
        }
        private void boxFileCancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            downloadClient.CancelAsync();
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
                _vagrantWrapper.StartVagrantProcessAsync(vagrantDirectoryTextBox.Text, string.Format("box add {0} {1}", form._name, form._url));
            }
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            _vagrantWrapper.StartVagrantProcessAsync(vagrantDirectoryTextBox.Text, "box list");
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (var boxData in _vagrantBoxDatas.Where(x => x.Check))
            {
                _vagrantWrapper.StartVagrantProcessAsync(vagrantDirectoryTextBox.Text, "box remove " + boxData.Name);
            }
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            foreach (var boxData in _vagrantBoxDatas.Where(x => x.Check))
            {
                _vagrantWrapper.StartVagrantProcessAsync(vagrantDirectoryTextBox.Text, "init " + boxData.Name);
            }
        }

    }
}
