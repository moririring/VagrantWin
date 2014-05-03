using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VagrantWin
{
    public partial class BoxListForm : Form
    {
        readonly BindingList<VagrantBoxData> _vagrantBoxDatasDatas = new BindingList<VagrantBoxData>();
        public string _selectURL { set; get; }

        public BoxListForm()
        {
            InitializeComponent();
            vagrantBoxDataBindingSource.DataSource = _vagrantBoxDatasDatas;
        }

        private void BoxListForm_Load(object sender, EventArgs e)
        {
            var uiTask = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Run(() =>
            {
                using (var wc = new WebClient())
                {
                    using (var st = wc.OpenRead("https://raw.githubusercontent.com/opscode/bento/master/README.md"))
                    {
                        using (var sr = new StreamReader(st))
                        {
                            var html = sr.ReadToEnd();
                            var lines = html.Replace(Environment.NewLine, "\n").Split('\n').Where(x => x.Contains("* "));
                            foreach (var line in lines)
                            {
                                var data = new VagrantBoxData
                                {
                                    Name = line.Substring(line.IndexOf("[") + 1, line.IndexOf("]") - line.IndexOf("[") - 1),
                                    Url = line.Substring(line.IndexOf("(") + 1, line.IndexOf(")") - line.IndexOf("(") - 1),
                                };
                                if (line.Contains("virtualbox"))
                                {
                                    data.Provider = "VirtualBox";
                                }
                                else if (line.Contains("vmware"))
                                {
                                    data.Provider = "VMWare";
                                }
                                else
                                {
                                    continue;
                                }
                                new Task(() => _vagrantBoxDatasDatas.Add(data)).Start(uiTask);
                            }
                        }
                    }
                }
            }).ContinueWith(t =>
            {
                vagrantBoxDataGridView.Invalidate();
                vagrantBoxDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void vagrantBoxDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            //"Button"列ならば、ボタンがクリックされた
            if (dgv.Columns[e.ColumnIndex].Name == "Download")
            {
                _selectURL = dgv["Url", e.RowIndex].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

    }
}
