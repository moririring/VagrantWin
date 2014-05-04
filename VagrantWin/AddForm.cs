using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VagrantWin
{
    public partial class AddForm : Form
    {
        public string _name { set; get; }
        public string _url { set; get; }

        public AddForm()
        {
            InitializeComponent();
        }

        private void bentoButton_Click(object sender, EventArgs e)
        {
            var form = new BoxListForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                nameTextBox.Text = Path.GetFileNameWithoutExtension(form.SelectUrl);
                urlTextBox.Text = form.SelectUrl;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _name = nameTextBox.Text;
            _url = urlTextBox.Text;

        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(urlTextBox.Text))
            {
                boxFileOpenFileDialog.InitialDirectory = Path.GetDirectoryName(urlTextBox.Text);
                boxFileOpenFileDialog.FileName = urlTextBox.Text;
            }
            boxFileOpenFileDialog.ShowDialog();
        }

        private void boxFileOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            urlTextBox.Text = boxFileOpenFileDialog.FileName;
            nameTextBox.Text = Path.GetFileNameWithoutExtension(urlTextBox.Text);
        }
    }
}
