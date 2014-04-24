using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
            column.UseColumnTextForButtonValue = true;
            column.Text = "ssh";
            vagrantDataGridView.Columns.Add(column);
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            vagrantfileOpenFileDialog.ShowDialog();
        }

        private void vagrantfileOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            vagrantfileTextBox.Text = vagrantfileOpenFileDialog.FileName;
            upButton.Enabled = true;
            destroyButton.Enabled = true;

            //Processオブジェクトを作成
            var p = new Process();

            //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
            p.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(vagrantfileTextBox.Text);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;
            //ウィンドウを表示しないようにする
            p.StartInfo.CreateNoWindow = true;
            //コマンドラインを指定（"/c"は実行後閉じるために必要）
            p.StartInfo.Arguments = @"/c vagrant status";
            //p.StartInfo.Arguments = "vagrant status";

            //起動
            p.Start();

            //出力を読み取る
            string results = p.StandardOutput.ReadToEnd();

            //プロセス終了まで待機する
            //WaitForExitはReadToEndの後である必要がある
            //(親プロセス、子プロセスでブロック防止のため)
            p.WaitForExit();
            p.Close();

            //default                   poweroff (virtualbox)
            var lines = results.Replace("\r\n", "\n").Split('\n')[2];

            var vagrantData = new VagrantData();
            vagrantData.check = true;
            vagrantData.name = lines.Substring(0, lines.IndexOf(' '));
            vagrantData.status = lines.Substring(lines.IndexOf(' '), lines.LastIndexOf(' ') - lines.IndexOf(' ')).Trim();
            vagrantData.provider = lines.Substring(lines.IndexOf('(') + 1, lines.IndexOf(')') - lines.IndexOf('(') - 1);

            _vagrantDatas.Add(vagrantData);
            vagrantDataBindingSource.DataSource = _vagrantDatas;

            vagrantDataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void upButton_Click(object sender, EventArgs e)
        {
        }
    }
}
