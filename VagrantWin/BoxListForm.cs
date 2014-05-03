using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VagrantWin
{
    public partial class BoxListForm : Form
    {
        readonly BindingList<VagrantBoxData> _vagrantBoxDatasDatas = new BindingList<VagrantBoxData>();
        public BoxListForm()
        {
            InitializeComponent();
            vagrantBoxDataBindingSource.DataSource = _vagrantBoxDatasDatas;

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
                                Url = line.Substring(line.IndexOf("(") + 1, line.IndexOf(")") - line.IndexOf("(") - 1)
                            };
                            _vagrantBoxDatasDatas.Add(data);
                        }
                    }
                }
            }
        }

        private void vagrantBoxDataBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
