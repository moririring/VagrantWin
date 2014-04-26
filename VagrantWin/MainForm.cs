using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VagrantWin
{
    public partial class MainForm : Form
    {
        readonly BindingList<VagrantData> _vagrantDatas = new BindingList<VagrantData>(); 
        public MainForm()
        {
            InitializeComponent();
            vagrantDataBindingSource.DataSource = _vagrantDatas;
        }
        async private void ComSpecLines(string command)
        {
            if (string.IsNullOrWhiteSpace(vagrantfileTextBox.Text)) return;
            consoleTextBox.Focus();
            consoleTextBox.Select(consoleTextBox.Text.Length, 0);
            commandGroupBox.Enabled = false;
            //Processオブジェクトを作成
            var p = new Process
            {
                StartInfo =
                {
                    FileName = Environment.GetEnvironmentVariable("ComSpec"),
                    WorkingDirectory = Path.GetDirectoryName(vagrantfileTextBox.Text),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true,
                    Arguments = "/c vagrant " + command,
                }
            };
            //文字列を一行ずつ取得
            p.OutputDataReceived += (s, e) =>
            {
                if (e.Data == null) return;
                Invoke(new Action(() =>
                {
                    consoleTextBox.HideSelection = false;
                    consoleTextBox.AppendText(e.Data + Environment.NewLine);
                    var vagrantData = VagrantData.GetVagrantDataParseLine(e.Data);
                    if (vagrantData != null)
                    {
                        UpdaetVagrantData(vagrantData);
                        commandGroupBox.Enabled = true;
                    }
                }));
            };
            //実行
            await Task.Run(() =>
            {
                p.Start();
                p.BeginOutputReadLine();
                p.WaitForExit();
                p.Close();
            });
            //終了待ちしてstatus
            consoleTextBox.HideSelection = false;
            consoleTextBox.AppendText("----------------------------------------------------------------------------------" + Environment.NewLine);
            if (command != "status")
            {
                ComSpecLines("status");
            }
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
            vagrantfileTextBox.Text = vagrantfileOpenFileDialog.FileName;
            ComSpecLines("status");
            readButton.Enabled = true;
        }
        private void statusButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                ComSpecLines(button.Text.ToLower());
            }
        }
        private void destroyButton_Click(object sender, EventArgs e)
        {
            PostMessage(Handle, WM_APP_CENTERMSG, 0, IntPtr.Zero);
            if (MessageBox.Show("Are you sure to destroy it?", "destroy", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ComSpecLines(destroyButton.Text.ToLower() + " -f");
            }
        }
        [DllImport("user32.dll", EntryPoint = "PostMessageA")]
        static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);
        [DllImport("user32.dll")]
        static extern int MoveWindow(
        IntPtr hWnd, int x, int y, int w, int h, int repaint);
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutVagrantWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutVagrantWinBox();
            form.ShowDialog();
        }
    }
}
