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
            this.vagrantDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.readButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.haltButton = new System.Windows.Forms.Button();
            this.destroyButton = new System.Windows.Forms.Button();
            this.provisionButton = new System.Windows.Forms.Button();
            this.vagrantDataGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.providerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vagrantDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.boxFileToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.boxFileNameToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.boxFileToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.boxFileCancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.commandTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.boxCommandGroupBox = new System.Windows.Forms.GroupBox();
            this.listButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.initButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.vagrantBoxDataGridView = new System.Windows.Forms.DataGridView();
            this.checkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.providerDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vagrantBoxDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.commandGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.commandTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.boxCommandGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantBoxDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantBoxDataBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // vagrantDirectoryTextBox
            // 
            this.vagrantDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vagrantDirectoryTextBox.Location = new System.Drawing.Point(12, 33);
            this.vagrantDirectoryTextBox.Name = "vagrantDirectoryTextBox";
            this.vagrantDirectoryTextBox.ReadOnly = true;
            this.vagrantDirectoryTextBox.Size = new System.Drawing.Size(517, 19);
            this.vagrantDirectoryTextBox.TabIndex = 0;
            this.vagrantDirectoryTextBox.TextChanged += new System.EventHandler(this.vagrantfileTextBox_TextChanged);
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
            this.vagrantDataGridView.Location = new System.Drawing.Point(6, 63);
            this.vagrantDataGridView.Name = "vagrantDataGridView";
            this.vagrantDataGridView.RowTemplate.Height = 21;
            this.vagrantDataGridView.Size = new System.Drawing.Size(536, 97);
            this.vagrantDataGridView.TabIndex = 6;
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
            // consoleTextBox
            // 
            this.consoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleTextBox.Location = new System.Drawing.Point(12, 256);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleTextBox.Size = new System.Drawing.Size(556, 128);
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
            // boxFileToolStripProgressBar
            // 
            this.boxFileToolStripProgressBar.Name = "boxFileToolStripProgressBar";
            this.boxFileToolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.boxFileToolStripProgressBar.Visible = false;
            // 
            // boxFileNameToolStripStatusLabel
            // 
            this.boxFileNameToolStripStatusLabel.Name = "boxFileNameToolStripStatusLabel";
            this.boxFileNameToolStripStatusLabel.Size = new System.Drawing.Size(62, 17);
            this.boxFileNameToolStripStatusLabel.Text = "download";
            this.boxFileNameToolStripStatusLabel.Visible = false;
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
            // 
            // boxFileCancelToolStripMenuItem
            // 
            this.boxFileCancelToolStripMenuItem.Name = "boxFileCancelToolStripMenuItem";
            this.boxFileCancelToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.boxFileCancelToolStripMenuItem.Text = "Cancel";
            this.boxFileCancelToolStripMenuItem.Click += new System.EventHandler(this.boxFileCancelToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // commandGroupBox
            // 
            this.commandGroupBox.Controls.Add(this.statusButton);
            this.commandGroupBox.Controls.Add(this.destroyButton);
            this.commandGroupBox.Controls.Add(this.upButton);
            this.commandGroupBox.Controls.Add(this.haltButton);
            this.commandGroupBox.Controls.Add(this.provisionButton);
            this.commandGroupBox.Location = new System.Drawing.Point(6, 6);
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
            this.cancelButton.Location = new System.Drawing.Point(280, 23);
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
            this.boxButton.Location = new System.Drawing.Point(465, 23);
            this.boxButton.Name = "boxButton";
            this.boxButton.Size = new System.Drawing.Size(64, 22);
            this.boxButton.TabIndex = 12;
            this.boxButton.Text = "Download";
            this.boxButton.UseVisualStyleBackColor = true;
            this.boxButton.Click += new System.EventHandler(this.boxButton_Click);
            // 
            // commandTabControl
            // 
            this.commandTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandTabControl.Controls.Add(this.tabPage1);
            this.commandTabControl.Controls.Add(this.tabPage2);
            this.commandTabControl.Location = new System.Drawing.Point(12, 58);
            this.commandTabControl.Name = "commandTabControl";
            this.commandTabControl.SelectedIndex = 0;
            this.commandTabControl.Size = new System.Drawing.Size(556, 192);
            this.commandTabControl.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.boxCommandGroupBox);
            this.tabPage1.Controls.Add(this.vagrantBoxDataGridView);
            this.tabPage1.Controls.Add(this.boxButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(548, 166);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "box";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // boxCommandGroupBox
            // 
            this.boxCommandGroupBox.Controls.Add(this.listButton);
            this.boxCommandGroupBox.Controls.Add(this.addButton);
            this.boxCommandGroupBox.Controls.Add(this.initButton);
            this.boxCommandGroupBox.Controls.Add(this.removeButton);
            this.boxCommandGroupBox.Location = new System.Drawing.Point(6, 6);
            this.boxCommandGroupBox.Name = "boxCommandGroupBox";
            this.boxCommandGroupBox.Size = new System.Drawing.Size(191, 45);
            this.boxCommandGroupBox.TabIndex = 14;
            this.boxCommandGroupBox.TabStop = false;
            this.boxCommandGroupBox.Text = "command";
            // 
            // listButton
            // 
            this.listButton.AutoSize = true;
            this.listButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.listButton.Enabled = false;
            this.listButton.Location = new System.Drawing.Point(6, 17);
            this.listButton.Name = "listButton";
            this.listButton.Size = new System.Drawing.Size(34, 22);
            this.listButton.TabIndex = 6;
            this.listButton.Text = "List";
            this.listButton.UseVisualStyleBackColor = true;
            this.listButton.Click += new System.EventHandler(this.listButton_Click);
            // 
            // addButton
            // 
            this.addButton.AutoSize = true;
            this.addButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(46, 17);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(35, 22);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // initButton
            // 
            this.initButton.AutoSize = true;
            this.initButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.initButton.Enabled = false;
            this.initButton.Location = new System.Drawing.Point(149, 17);
            this.initButton.Name = "initButton";
            this.initButton.Size = new System.Drawing.Size(31, 22);
            this.initButton.TabIndex = 3;
            this.initButton.Text = "Init";
            this.initButton.UseVisualStyleBackColor = true;
            this.initButton.Click += new System.EventHandler(this.initButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.AutoSize = true;
            this.removeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(87, 17);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(56, 22);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // vagrantBoxDataGridView
            // 
            this.vagrantBoxDataGridView.AllowUserToAddRows = false;
            this.vagrantBoxDataGridView.AllowUserToDeleteRows = false;
            this.vagrantBoxDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vagrantBoxDataGridView.AutoGenerateColumns = false;
            this.vagrantBoxDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vagrantBoxDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkDataGridViewCheckBoxColumn,
            this.nameDataGridViewTextBoxColumn1,
            this.urlDataGridViewTextBoxColumn,
            this.providerDataGridViewTextBoxColumn1});
            this.vagrantBoxDataGridView.DataSource = this.vagrantBoxDataBindingSource;
            this.vagrantBoxDataGridView.Location = new System.Drawing.Point(6, 63);
            this.vagrantBoxDataGridView.Name = "vagrantBoxDataGridView";
            this.vagrantBoxDataGridView.RowTemplate.Height = 21;
            this.vagrantBoxDataGridView.Size = new System.Drawing.Size(536, 97);
            this.vagrantBoxDataGridView.TabIndex = 13;
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            this.checkDataGridViewCheckBoxColumn.DataPropertyName = "Check";
            this.checkDataGridViewCheckBoxColumn.HeaderText = "Check";
            this.checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // urlDataGridViewTextBoxColumn
            // 
            this.urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
            this.urlDataGridViewTextBoxColumn.HeaderText = "Url";
            this.urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
            this.urlDataGridViewTextBoxColumn.Visible = false;
            // 
            // providerDataGridViewTextBoxColumn1
            // 
            this.providerDataGridViewTextBoxColumn1.DataPropertyName = "Provider";
            this.providerDataGridViewTextBoxColumn1.HeaderText = "Provider";
            this.providerDataGridViewTextBoxColumn1.Name = "providerDataGridViewTextBoxColumn1";
            // 
            // vagrantBoxDataBindingSource
            // 
            this.vagrantBoxDataBindingSource.DataSource = typeof(VagrantWin.VagrantBoxData);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.vagrantDataGridView);
            this.tabPage2.Controls.Add(this.cancelButton);
            this.tabPage2.Controls.Add(this.commandGroupBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(548, 166);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "virtual";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 409);
            this.Controls.Add(this.commandTabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.vagrantDirectoryTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "VagrantWin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantDataBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.commandGroupBox.ResumeLayout(false);
            this.commandGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.commandTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.boxCommandGroupBox.ResumeLayout(false);
            this.boxCommandGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantBoxDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vagrantBoxDataBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox vagrantDirectoryTextBox;
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
        private System.Windows.Forms.TabControl commandTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox boxCommandGroupBox;
        private System.Windows.Forms.Button listButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button initButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.DataGridView vagrantBoxDataGridView;
        private System.Windows.Forms.BindingSource vagrantBoxDataBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn providerDataGridViewTextBoxColumn1;
    }
}

