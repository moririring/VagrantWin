namespace VagrantWin
{
    partial class AddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bentoButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.fileButton = new System.Windows.Forms.Button();
            this.boxFileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 24);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(709, 19);
            this.nameTextBox.TabIndex = 1;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(12, 71);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(709, 19);
            this.urlTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Url";
            // 
            // bentoButton
            // 
            this.bentoButton.AutoSize = true;
            this.bentoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bentoButton.Location = new System.Drawing.Point(676, 96);
            this.bentoButton.Name = "bentoButton";
            this.bentoButton.Size = new System.Drawing.Size(45, 22);
            this.bentoButton.TabIndex = 13;
            this.bentoButton.Text = "Bento";
            this.bentoButton.UseVisualStyleBackColor = true;
            this.bentoButton.Click += new System.EventHandler(this.bentoButton_Click);
            // 
            // addButton
            // 
            this.addButton.AutoSize = true;
            this.addButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.Location = new System.Drawing.Point(355, 133);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(35, 22);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // fileButton
            // 
            this.fileButton.AutoSize = true;
            this.fileButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fileButton.Location = new System.Drawing.Point(636, 96);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(34, 22);
            this.fileButton.TabIndex = 15;
            this.fileButton.Text = "File";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // boxFileOpenFileDialog
            // 
            this.boxFileOpenFileDialog.DefaultExt = "box";
            this.boxFileOpenFileDialog.FileName = "openFileDialog1";
            this.boxFileOpenFileDialog.Filter = "box ファイル|*.box|すべてのファイル|*.*";
            this.boxFileOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.boxFileOpenFileDialog_FileOk);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 167);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.bentoButton);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bentoButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.OpenFileDialog boxFileOpenFileDialog;
    }
}