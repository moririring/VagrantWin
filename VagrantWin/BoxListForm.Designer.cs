namespace VagrantWin
{
    partial class BoxListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoxListForm));
            this.vagrantBoxDataGridView = new System.Windows.Forms.DataGridView();
            this.Download = new System.Windows.Forms.DataGridViewButtonColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.providerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vagrantBoxDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.vagrantBoxDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantBoxDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vagrantBoxDataGridView
            // 
            this.vagrantBoxDataGridView.AllowUserToAddRows = false;
            this.vagrantBoxDataGridView.AllowUserToDeleteRows = false;
            this.vagrantBoxDataGridView.AutoGenerateColumns = false;
            this.vagrantBoxDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vagrantBoxDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Download,
            this.nameDataGridViewTextBoxColumn,
            this.Url,
            this.providerDataGridViewTextBoxColumn});
            this.vagrantBoxDataGridView.DataSource = this.vagrantBoxDataBindingSource;
            this.vagrantBoxDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vagrantBoxDataGridView.Location = new System.Drawing.Point(0, 0);
            this.vagrantBoxDataGridView.Name = "vagrantBoxDataGridView";
            this.vagrantBoxDataGridView.RowTemplate.Height = 21;
            this.vagrantBoxDataGridView.Size = new System.Drawing.Size(345, 482);
            this.vagrantBoxDataGridView.TabIndex = 0;
            this.vagrantBoxDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vagrantBoxDataGridView_CellContentClick);
            // 
            // Download
            // 
            this.Download.DataPropertyName = "Name";
            this.Download.HeaderText = "Download";
            this.Download.Name = "Download";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Visible = false;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "Url";
            this.Url.Name = "Url";
            this.Url.Visible = false;
            // 
            // providerDataGridViewTextBoxColumn
            // 
            this.providerDataGridViewTextBoxColumn.DataPropertyName = "Provider";
            this.providerDataGridViewTextBoxColumn.HeaderText = "Provider";
            this.providerDataGridViewTextBoxColumn.Name = "providerDataGridViewTextBoxColumn";
            // 
            // vagrantBoxDataBindingSource
            // 
            this.vagrantBoxDataBindingSource.DataSource = typeof(VagrantWin.VagrantBoxData);
            // 
            // BoxListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 482);
            this.Controls.Add(this.vagrantBoxDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BoxListForm";
            this.Text = "BoxListForm";
            this.Load += new System.EventHandler(this.BoxListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vagrantBoxDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantBoxDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView vagrantBoxDataGridView;
        private System.Windows.Forms.BindingSource vagrantBoxDataBindingSource;
        private System.Windows.Forms.DataGridViewButtonColumn Download;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn providerDataGridViewTextBoxColumn;
    }
}