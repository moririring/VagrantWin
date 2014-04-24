namespace VagrantWin
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.vagrantfileTextBox = new System.Windows.Forms.TextBox();
            this.readButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.haltButton = new System.Windows.Forms.Button();
            this.destroyButton = new System.Windows.Forms.Button();
            this.provisionButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.vagrantfileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.checkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.providerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sshDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.vagrantDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vagrantfileTextBox
            // 
            this.vagrantfileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vagrantfileTextBox.Location = new System.Drawing.Point(12, 12);
            this.vagrantfileTextBox.Name = "vagrantfileTextBox";
            this.vagrantfileTextBox.Size = new System.Drawing.Size(513, 19);
            this.vagrantfileTextBox.TabIndex = 0;
            // 
            // readButton
            // 
            this.readButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readButton.AutoSize = true;
            this.readButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.readButton.Location = new System.Drawing.Point(531, 9);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(41, 22);
            this.readButton.TabIndex = 1;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // upButton
            // 
            this.upButton.AutoSize = true;
            this.upButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.upButton.Enabled = false;
            this.upButton.Location = new System.Drawing.Point(12, 37);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(29, 22);
            this.upButton.TabIndex = 2;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // haltButton
            // 
            this.haltButton.AutoSize = true;
            this.haltButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.haltButton.Enabled = false;
            this.haltButton.Location = new System.Drawing.Point(47, 37);
            this.haltButton.Name = "haltButton";
            this.haltButton.Size = new System.Drawing.Size(36, 22);
            this.haltButton.TabIndex = 3;
            this.haltButton.Text = "Halt";
            this.haltButton.UseVisualStyleBackColor = true;
            // 
            // destroyButton
            // 
            this.destroyButton.AutoSize = true;
            this.destroyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.destroyButton.Enabled = false;
            this.destroyButton.Location = new System.Drawing.Point(89, 37);
            this.destroyButton.Name = "destroyButton";
            this.destroyButton.Size = new System.Drawing.Size(55, 22);
            this.destroyButton.TabIndex = 4;
            this.destroyButton.Text = "Destroy";
            this.destroyButton.UseVisualStyleBackColor = true;
            // 
            // provisionButton
            // 
            this.provisionButton.AutoSize = true;
            this.provisionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.provisionButton.Enabled = false;
            this.provisionButton.Location = new System.Drawing.Point(150, 37);
            this.provisionButton.Name = "provisionButton";
            this.provisionButton.Size = new System.Drawing.Size(62, 22);
            this.provisionButton.TabIndex = 5;
            this.provisionButton.Text = "Provision";
            this.provisionButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkDataGridViewCheckBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.providerDataGridViewTextBoxColumn,
            this.sshDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.vagrantDataBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(552, 78);
            this.dataGridView1.TabIndex = 6;
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleTextBox.Location = new System.Drawing.Point(12, 149);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.Size = new System.Drawing.Size(552, 219);
            this.consoleTextBox.TabIndex = 7;
            // 
            // vagrantfileOpenFileDialog
            // 
            this.vagrantfileOpenFileDialog.FileName = "openFileDialog1";
            this.vagrantfileOpenFileDialog.Filter = "Vagrantfileファイル|Vagrantfile";
            this.vagrantfileOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.vagrantfileOpenFileDialog_FileOk);
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            this.checkDataGridViewCheckBoxColumn.DataPropertyName = "check";
            this.checkDataGridViewCheckBoxColumn.HeaderText = "check";
            this.checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // providerDataGridViewTextBoxColumn
            // 
            this.providerDataGridViewTextBoxColumn.DataPropertyName = "provider";
            this.providerDataGridViewTextBoxColumn.HeaderText = "provider";
            this.providerDataGridViewTextBoxColumn.Name = "providerDataGridViewTextBoxColumn";
            // 
            // sshDataGridViewTextBoxColumn
            // 
            this.sshDataGridViewTextBoxColumn.DataPropertyName = "ssh";
            this.sshDataGridViewTextBoxColumn.HeaderText = "ssh";
            this.sshDataGridViewTextBoxColumn.Name = "sshDataGridViewTextBoxColumn";
            this.sshDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sshDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // vagrantDataBindingSource
            // 
            this.vagrantDataBindingSource.DataSource = typeof(VagrantWin.VagrantData);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 380);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.provisionButton);
            this.Controls.Add(this.destroyButton);
            this.Controls.Add(this.haltButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.vagrantfileTextBox);
            this.Name = "MainForm";
            this.Text = "VagrantWin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox vagrantfileTextBox;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button haltButton;
        private System.Windows.Forms.Button destroyButton;
        private System.Windows.Forms.Button provisionButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox consoleTextBox;
        private System.Windows.Forms.OpenFileDialog vagrantfileOpenFileDialog;
        private System.Windows.Forms.BindingSource vagrantDataBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn providerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn sshDataGridViewTextBoxColumn;
    }
}

