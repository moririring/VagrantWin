using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VagrantWin
{
    public partial class MainForm : Form
    {
        BindingList<VagrantData> _vagrantDatas = new BindingList<VagrantData>(); 
        public MainForm()
        {
            InitializeComponent();

            var column = new DataGridViewButtonColumn();
            column.Name = "ssh";
            column.Text = "ssh";
            column.UseColumnTextForButtonValue = true;
            vagrantDataGridView.Columns.Add(column);
            vagrantDataBindingSource.DataSource = _vagrantDatas;
        }
        async private void ComSpecLines(string command)
        {
            //Processオブジェクトを作成
            var p = new Process
            {
                StartInfo =
                {
                    FileName = Environment.GetEnvironmentVariable("ComSpec"),
                    WorkingDirectory = Path.GetDirectoryName(vagrantfileTextBox.Text),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = false,
                    CreateNoWindow = true,
                    //コマンドラインを指定（"/c"は実行後閉じるために必要）
                    Arguments = @"/c vagrant " + command,
                }
            };
            //
            p.OutputDataReceived += (s, e) => Task.Run(() =>
            {
                var line = e.Data;
                if (line == null) return;
                Invoke(new Action(() =>
                {
                    consoleTextBox.Text += line + Environment.NewLine;
                    var vagrantData = GetVagrantDataFromLine(line);
                    if (vagrantData != null)
                    {
                        SetVagrantData(vagrantData);
                    }
                }));
            });
            p.Start();
            p.BeginOutputReadLine();
            await Task.Run(() =>
            {
                p.WaitForExit();
                p.Close();
            });
            consoleTextBox.Text += "----------------------------------------------------------------------------------" + Environment.NewLine;
            if (command != "status")
            {
                ComSpecLines("status");
            }
        }

        private void SetVagrantData(VagrantData vagrantData)
        {
            var status = "";
            var hit = _vagrantDatas.SingleOrDefault(v => v.name == vagrantData.name);
            if (hit != null)
            {
                hit.status = vagrantData.status;
                hit.provider = vagrantData.provider;
                status = hit.status;
            }
            else
            {
                _vagrantDatas.Add(vagrantData);
                status = vagrantData.status;
            }
            vagrantDataGridView.Invalidate();
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
            commandGroupBox.Enabled = true;
        }

        private VagrantData GetVagrantDataFromLine(string line)
        {
            //parseの条件式はこれでOKなの？
            if (!line.Contains(' ')) return null;
            if (!line.Contains('(')) return null;
            if (!line.Contains(')')) return null;
            var preSpace = line.IndexOf(' ');
            var postSpace = line.LastIndexOf(' ');
            var preBracket = line.IndexOf('(');
            var postBracket = line.IndexOf(')');
            var name = line.Substring(0, preSpace);
            var status = line.Substring(preSpace, postSpace - preSpace).Trim();
            var provider = line.Substring(preBracket + 1, postBracket - preBracket - 1);

            if (string.IsNullOrWhiteSpace(name)) return null;
            if (string.IsNullOrWhiteSpace(status)) return null;
            if (string.IsNullOrWhiteSpace(provider)) return null;

            var vagrantData = new VagrantData
            {
                check = true,
                name = name,
                status = status,
                provider = provider
            };
            return vagrantData;
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            vagrantfileOpenFileDialog.ShowDialog();
        }

        private void vagrantfileOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            vagrantfileTextBox.Text = vagrantfileOpenFileDialog.FileName;
            commandGroupBox.Enabled = false;
            ComSpecLines("status");
        }
        private void upButton_Click(object sender, EventArgs e)
        {
            commandGroupBox.Enabled = false;
            ComSpecLines("up");
        }
        private void haltButton_Click(object sender, EventArgs e)
        {
            commandGroupBox.Enabled = false;
            ComSpecLines("halt");
        }

        private void destroyButton_Click(object sender, EventArgs e)
        {
            commandGroupBox.Enabled = false;
            ComSpecLines("destroy");
        }

        private void provisionButton_Click(object sender, EventArgs e)
        {
            commandGroupBox.Enabled = false;
            ComSpecLines("provision");
        }
    }
}
