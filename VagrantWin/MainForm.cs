using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

//            var column = new DataGridViewButtonColumn();
//            column.Name = "ssh";
//            column.Text = "ssh";
//            column.UseColumnTextForButtonValue = true;
//            vagrantDataGridView.Columns.Add(column);
            vagrantDataBindingSource.DataSource = _vagrantDatas;
        }
        async private void ComSpecLines(string command)
        {
            if (string.IsNullOrWhiteSpace(vagrantfileTextBox.Text)) return;
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
                    //コマンドラインを指定（"/c"は実行後閉じるために必要）
                    Arguments = (command != "destroy") ? @"/c vagrant " + command : "/v:on /e:off /k vagrant " + command,
                    //Arguments = (command != "destroy") ? @"/c vagrant " + command : "",
                }
            };
            //文字列を非同期で一行ずつ取得
            if (command != "destroy")
            {
                p.OutputDataReceived += (s, e) => Task.Run(() =>
                {
                    var line = e.Data;
                    if (line == null) return;
                    Invoke(new Action(() =>
                    {
                        consoleTextBox.HideSelection = false;
                        consoleTextBox.AppendText(line + Environment.NewLine);
                        var vagrantData = VagrantData.GetVagrantDataParseLine(line);
                        if (vagrantData != null)
                        {
                            UpdaetVagrantData(vagrantData);
                            commandGroupBox.Enabled = true;
                        }

                    }));
                });
            }
            //実行
            await Task.Run(() =>
            {
                p.Start();
                if (command == "destroy")
                {
                    using (var sw = p.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            //sw.WriteLine("N");
                        }
                        p.StandardInput.Close();
                    }
                    var all = p.StandardOutput.ReadToEnd();
                    Invoke(new Action(() =>
                    {
                        consoleTextBox.HideSelection = false;
                        consoleTextBox.AppendText(all + Environment.NewLine);
                    }));
                }
                else
                {
                    p.BeginOutputReadLine();
                }
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
            //名前があれば更新、なければ追加
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
            if (status == "poweroff")
            {
                upButton.Enabled = true;
                destroyButton.Enabled = true;
                haltButton.Enabled = false;
                provisionButton.Enabled = false;
            }
            else if (status == "running")
            {
                haltButton.Enabled = true;
                provisionButton.Enabled = true;
                upButton.Enabled = false;
                destroyButton.Enabled = false;
            }
            statusButton.Enabled = true;
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            vagrantfileOpenFileDialog.ShowDialog();
        }

        private void vagrantfileOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            vagrantfileTextBox.Text = vagrantfileOpenFileDialog.FileName;
            consoleTextBox.Focus();
            consoleTextBox.Select(consoleTextBox.Text.Length, 0);
            ComSpecLines("status");
        }
        private void statusButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                consoleTextBox.Focus();
                consoleTextBox.Select(consoleTextBox.Text.Length, 0);
                ComSpecLines(button.Text.ToLower());
            }
        }
    }
}
