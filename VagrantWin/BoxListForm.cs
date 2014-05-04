using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using VagrantWin.Properties;

namespace VagrantWin
{
    public partial class BoxListForm : Form
    {
        readonly BindingList<VagrantBoxData> _vagrantBoxDatasDatas = new BindingList<VagrantBoxData>();
        public string SelectUrl { set; get; }

        public BoxListForm()
        {
            InitializeComponent();
            vagrantBoxDataBindingSource.DataSource = _vagrantBoxDatasDatas;
        }
        private void BoxListForm_Load(object sender, EventArgs e)
        {
            var rawText = "";
            Task.Run(() =>
            {
                using (var wc = new WebClient())
                {
                    try
                    {
                        using (var st = wc.OpenRead(Resources.BentoReadmeRawURL))
                        {
                            if (st == null) return;
                            using (var sr = new StreamReader(st))
                            {
                                rawText = sr.ReadToEnd();
                            }
                        }
                    }
                    //OpenRead失敗時のエラーメッセージ
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }).ContinueWith(t =>
            {
                if (rawText != "")
                {
                    var lines = rawText.Replace(Environment.NewLine, "\n").Split('\n');
                    foreach (var line in lines.Where(x => x.Contains("* ")))
                    {
                        var data = new VagrantBoxData();
                        if (data.GetVagrantBoxDataParseBentoFile(line))
                        {
                            _vagrantBoxDatasDatas.Add(data);
                        }
                    }
                    vagrantBoxDataGridView.Invalidate();
                    vagrantBoxDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void vagrantBoxDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null && dgv.Columns[e.ColumnIndex].Name == "Download")
            {
                SelectUrl = dgv["Url", e.RowIndex].Value.ToString();
                DialogResult = DialogResult.OK;
            }
        }

    }
}
