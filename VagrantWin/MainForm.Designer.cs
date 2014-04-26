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
            this.vagrantDataGridView = new System.Windows.Forms.DataGridView();
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.vagrantfileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.commandGroupBox = new System.Windows.Forms.GroupBox();
            this.statusButton = new System.Windows.Forms.Button();
            this.vagrantDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.providerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataGridView)).BeginInit();
            this.commandGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vagrantfileTextBox
            // 
            this.vagrantfileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vagrantfileTextBox.Location = new System.Drawing.Point(12, 12);
            this.vagrantfileTextBox.Name = "vagrantfileTextBox";
            this.vagrantfileTextBox.ReadOnly = true;
            this.vagrantfileTextBox.Size = new System.Drawing.Size(517, 19);
            this.vagrantfileTextBox.TabIndex = 0;
            // 
            // readButton
            // 
            this.readButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readButton.AutoSize = true;
            this.readButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.readButton.Location = new System.Drawing.Point(535, 9);
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
            this.upButton.Location = new System.Drawing.Point(60, 17);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(29, 22);
            this.upButton.TabIndex = 2;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // haltButton
            // 
            this.haltButton.AutoSize = true;
            this.haltButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.haltButton.Enabled = false;
            this.haltButton.Location = new System.Drawing.Point(95, 17);
            this.haltButton.Name = "haltButton";
            this.haltButton.Size = new System.Drawing.Size(36, 22);
            this.haltButton.TabIndex = 3;
            this.haltButton.Text = "Halt";
            this.haltButton.UseVisualStyleBackColor = true;
            this.haltButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // destroyButton
            // 
            this.destroyButton.AutoSize = true;
            this.destroyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.destroyButton.Enabled = false;
            this.destroyButton.Location = new System.Drawing.Point(205, 17);
            this.destroyButton.Name = "destroyButton";
            this.destroyButton.Size = new System.Drawing.Size(55, 22);
            this.destroyButton.TabIndex = 4;
            this.destroyButton.Text = "Destroy";
            this.destroyButton.UseVisualStyleBackColor = true;
            this.destroyButton.Click += new System.EventHandler(this.destroyButton_Click);
            // 
            // provisionButton
            // 
            this.provisionButton.AutoSize = true;
            this.provisionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.provisionButton.Enabled = false;
            this.provisionButton.Location = new System.Drawing.Point(137, 17);
            this.provisionButton.Name = "provisionButton";
            this.provisionButton.Size = new System.Drawing.Size(62, 22);
            this.provisionButton.TabIndex = 5;
            this.provisionButton.Text = "Provision";
            this.provisionButton.UseVisualStyleBackColor = true;
            this.provisionButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // vagrantDataGridView
            // 
            this.vagrantDataGridView.AllowUserToAddRows = false;
            this.vagrantDataGridView.AllowUserToDeleteRows = false;
            this.vagrantDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vagrantDataGridView.AutoGenerateColumns = false;
            this.vagrantDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vagrantDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.providerDataGridViewTextBoxColumn});
            this.vagrantDataGridView.DataSource = this.vagrantDataBindingSource;
            this.vagrantDataGridView.Location = new System.Drawing.Point(12, 88);
            this.vagrantDataGridView.Name = "vagrantDataGridView";
            this.vagrantDataGridView.RowTemplate.Height = 21;
            this.vagrantDataGridView.Size = new System.Drawing.Size(556, 97);
            this.vagrantDataGridView.TabIndex = 6;
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleTextBox.Location = new System.Drawing.Point(12, 191);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleTextBox.Size = new System.Drawing.Size(556, 193);
            this.consoleTextBox.TabIndex = 1;
            this.consoleTextBox.WordWrap = false;
            // 
            // vagrantfileOpenFileDialog
            // 
            this.vagrantfileOpenFileDialog.FileName = "openFileDialog1";
            this.vagrantfileOpenFileDialog.Filter = "Vagrantfileファイル|Vagrantfile";
            this.vagrantfileOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.vagrantfileOpenFileDialog_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 387);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(580, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // commandGroupBox
            // 
            this.commandGroupBox.Controls.Add(this.statusButton);
            this.commandGroupBox.Controls.Add(this.destroyButton);
            this.commandGroupBox.Controls.Add(this.upButton);
            this.commandGroupBox.Controls.Add(this.haltButton);
            this.commandGroupBox.Controls.Add(this.provisionButton);
            this.commandGroupBox.Location = new System.Drawing.Point(12, 37);
            this.commandGroupBox.Name = "commandGroupBox";
            this.commandGroupBox.Size = new System.Drawing.Size(268, 45);
            this.commandGroupBox.TabIndex = 9;
            this.commandGroupBox.TabStop = false;
            this.commandGroupBox.Text = "command";
            // 
            // statusButton
            // 
            this.statusButton.AutoSize = true;
            this.statusButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statusButton.Enabled = false;
            this.statusButton.Location = new System.Drawing.Point(6, 17);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(48, 22);
            this.statusButton.TabIndex = 6;
            this.statusButton.Text = "Status";
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // vagrantDataBindingSource
            // 
            this.vagrantDataBindingSource.DataSource = typeof(VagrantWin.VagrantData);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // providerDataGridViewTextBoxColumn
            // 
            this.providerDataGridViewTextBoxColumn.DataPropertyName = "Provider";
            this.providerDataGridViewTextBoxColumn.HeaderText = "Provider";
            this.providerDataGridViewTextBoxColumn.Name = "providerDataGridViewTextBoxColumn";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 409);
            this.Controls.Add(this.commandGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.vagrantDataGridView);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.vagrantfileTextBox);
            this.Name = "MainForm";
            this.Text = "VagrantWin";
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataGridView)).EndInit();
            this.commandGroupBox.ResumeLayout(false);
            this.commandGroupBox.PerformLayout();
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
        private System.Windows.Forms.DataGridView vagrantDataGridView;
        private System.Windows.Forms.TextBox consoleTextBox;
        private System.Windows.Forms.OpenFileDialog vagrantfileOpenFileDialog;
        private System.Windows.Forms.BindingSource vagrantDataBindingSource;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox commandGroupBox;
        private System.Windows.Forms.Button statusButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn providerDataGridViewTextBoxColumn;
    }
}

