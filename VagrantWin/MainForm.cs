using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VagrantWin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            //Processオブジェクトを作成
            var p = new Process();

            //ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
            p.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            //出力を読み取れるようにする
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;
            //ウィンドウを表示しないようにする
            p.StartInfo.CreateNoWindow = true;
            //コマンドラインを指定（"/c"は実行後閉じるために必要）
            p.StartInfo.Arguments = string.Format(@"/c dir {0} /w", vagrantfileTextBox.Text);

            //起動
            p.Start();

            //出力を読み取る
            string results = p.StandardOutput.ReadToEnd();

            //プロセス終了まで待機する
            //WaitForExitはReadToEndの後である必要がある
            //(親プロセス、子プロセスでブロック防止のため)
            p.WaitForExit();
            p.Close();

            //出力された結果を表示
            consoleTextBox.Text = results;
        }
    }
}
