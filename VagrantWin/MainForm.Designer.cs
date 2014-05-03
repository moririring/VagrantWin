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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.vagrantPathTextBox = new System.Windows.Forms.TextBox();
            this.readButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.haltButton = new System.Windows.Forms.Button();
            this.destroyButton = new System.Windows.Forms.Button();
            this.provisionButton = new System.Windows.Forms.Button();
            this.vagrantDataGridView = new System.Windows.Forms.DataGridView();
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.commandGroupBox = new System.Windows.Forms.GroupBox();
            this.statusButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutVagrantWinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelButton = new System.Windows.Forms.Button();
            this.vagrantfileFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.boxButton = new System.Windows.Forms.Button();
            this.boxFileNameToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.boxFileToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.boxFileToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.providerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vagrantDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boxFileCancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.commandGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vagrantPathTextBox
            // 
            this.vagrantPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vagrantPathTextBox.Location = new System.Drawing.Point(12, 33);
            this.vagrantPathTextBox.Name = "vagrantPathTextBox";
            this.vagrantPathTextBox.ReadOnly = true;
            this.vagrantPathTextBox.Size = new System.Drawing.Size(517, 19);
            this.vagrantPathTextBox.TabIndex = 0;
            this.vagrantPathTextBox.TextChanged += new System.EventHandler(this.vagrantfileTextBox_TextChanged);
            // 
            // readButton
            // 
            this.readButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readButton.AutoSize = true;
            this.readButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.readButton.Location = new System.Drawing.Point(535, 30);
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
            this.haltButton.Location = new System.Drawing.Point(163, 17);
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
            this.provisionButton.Location = new System.Drawing.Point(95, 17);
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
            this.vagrantDataGridView.Location = new System.Drawing.Point(12, 109);
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
            this.consoleTextBox.Location = new System.Drawing.Point(12, 212);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleTextBox.Size = new System.Drawing.Size(556, 172);
            this.consoleTextBox.TabIndex = 1;
            this.consoleTextBox.WordWrap = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boxFileToolStripProgressBar,
            this.boxFileNameToolStripStatusLabel,
            this.boxFileToolStripSplitButton});
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
            this.commandGroupBox.Location = new System.Drawing.Point(12, 58);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(580, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutVagrantWinToolStripMenuItem});
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // aboutVagrantWinToolStripMenuItem
            // 
            this.aboutVagrantWinToolStripMenuItem.Name = "aboutVagrantWinToolStripMenuItem";
            this.aboutVagrantWinToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.aboutVagrantWinToolStripMenuItem.Text = "About VagrantWin";
            this.aboutVagrantWinToolStripMenuItem.Click += new System.EventHandler(this.aboutVagrantWinToolStripMenuItem_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.Location = new System.Drawing.Point(286, 75);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(50, 22);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // boxButton
            // 
            this.boxButton.AutoSize = true;
            this.boxButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.boxButton.Enabled = false;
            this.boxButton.Location = new System.Drawing.Point(518, 75);
            this.boxButton.Name = "boxButton";
            this.boxButton.Size = new System.Drawing.Size(35, 22);
            this.boxButton.TabIndex = 12;
            this.boxButton.Text = "Box";
            this.boxButton.UseVisualStyleBackColor = true;
            this.boxButton.Click += new System.EventHandler(this.boxButton_Click);
            // 
            // boxFileNameToolStripStatusLabel
            // 
            this.boxFileNameToolStripStatusLabel.Name = "boxFileNameToolStripStatusLabel";
            this.boxFileNameToolStripStatusLabel.Size = new System.Drawing.Size(62, 17);
            this.boxFileNameToolStripStatusLabel.Text = "download";
            this.boxFileNameToolStripStatusLabel.Visible = false;
            // 
            // boxFileToolStripProgressBar
            // 
            this.boxFileToolStripProgressBar.Name = "boxFileToolStripProgressBar";
            this.boxFileToolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.boxFileToolStripProgressBar.Visible = false;
            // 
            // boxFileToolStripSplitButton
            // 
            this.boxFileToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.boxFileToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boxFileCancelToolStripMenuItem,
            this.openFolderToolStripMenuItem});
            this.boxFileToolStripSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("boxFileToolStripSplitButton.Image")));
            this.boxFileToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boxFileToolStripSplitButton.Name = "boxFileToolStripSplitButton";
            this.boxFileToolStripSplitButton.Size = new System.Drawing.Size(61, 20);
            this.boxFileToolStripSplitButton.Text = "Cancel";
            this.boxFileToolStripSplitButton.Visible = false;
            this.boxFileToolStripSplitButton.ButtonClick += new System.EventHandler(this.boxFileToolStripSplitButton_ButtonClick);
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
            // vagrantDataBindingSource
            // 
            this.vagrantDataBindingSource.DataSource = typeof(VagrantWin.VagrantData);
            // 
            // boxFileCancelToolStripMenuItem
            // 
            this.boxFileCancelToolStripMenuItem.Name = "boxFileCancelToolStripMenuItem";
            this.boxFileCancelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.boxFileCancelToolStripMenuItem.Text = "Cancel";
            this.boxFileCancelToolStripMenuItem.Click += new System.EventHandler(this.boxFileCancelToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 409);
            this.Controls.Add(this.boxButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.commandGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.vagrantDataGridView);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.vagrantPathTextBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "VagrantWin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.commandGroupBox.ResumeLayout(false);
            this.commandGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox vagrantPathTextBox;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button haltButton;
        private System.Windows.Forms.Button destroyButton;
        private System.Windows.Forms.Button provisionButton;
        private System.Windows.Forms.DataGridView vagrantDataGridView;
        private System.Windows.Forms.TextBox consoleTextBox;
        private System.Windows.Forms.BindingSource vagrantDataBindingSource;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox commandGroupBox;
        private System.Windows.Forms.Button statusButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn providerDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutVagrantWinToolStripMenuItem;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FolderBrowserDialog vagrantfileFolderBrowserDialog;
        private System.Windows.Forms.Button boxButton;
        private System.Windows.Forms.ToolStripStatusLabel boxFileNameToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar boxFileToolStripProgressBar;
        private System.Windows.Forms.ToolStripSplitButton boxFileToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem boxFileCancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
    }
}

