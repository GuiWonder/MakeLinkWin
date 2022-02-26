namespace MakeLink
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCreate = new System.Windows.Forms.TextBox();
            this.textBoxPointTo = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonTo = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCMD = new System.Windows.Forms.TextBox();
            this.buttonShowCMD = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.buttonRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "创建目标";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "指向位置";
            // 
            // textBoxCreate
            // 
            this.textBoxCreate.Location = new System.Drawing.Point(15, 61);
            this.textBoxCreate.Name = "textBoxCreate";
            this.textBoxCreate.Size = new System.Drawing.Size(549, 23);
            this.textBoxCreate.TabIndex = 1;
            // 
            // textBoxPointTo
            // 
            this.textBoxPointTo.Location = new System.Drawing.Point(15, 117);
            this.textBoxPointTo.Name = "textBoxPointTo";
            this.textBoxPointTo.Size = new System.Drawing.Size(549, 23);
            this.textBoxPointTo.TabIndex = 3;
            // 
            // buttonCreate
            // 
            this.buttonCreate.AutoSize = true;
            this.buttonCreate.Location = new System.Drawing.Point(521, 30);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(43, 25);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "选择";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonTo
            // 
            this.buttonTo.AutoSize = true;
            this.buttonTo.Location = new System.Drawing.Point(521, 89);
            this.buttonTo.Name = "buttonTo";
            this.buttonTo.Size = new System.Drawing.Size(43, 25);
            this.buttonTo.TabIndex = 4;
            this.buttonTo.Text = "选择";
            this.buttonTo.UseVisualStyleBackColor = true;
            this.buttonTo.Click += new System.EventHandler(this.buttonPointTo_Click);
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "文件符号链接",
            "目录符号链接",
            "文件硬链接",
            "目录联接"});
            this.comboBox.Location = new System.Drawing.Point(51, 6);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(167, 23);
            this.comboBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "类型";
            // 
            // textBoxCMD
            // 
            this.textBoxCMD.BackColor = System.Drawing.Color.Black;
            this.textBoxCMD.ForeColor = System.Drawing.Color.White;
            this.textBoxCMD.Location = new System.Drawing.Point(15, 182);
            this.textBoxCMD.Multiline = true;
            this.textBoxCMD.Name = "textBoxCMD";
            this.textBoxCMD.ReadOnly = true;
            this.textBoxCMD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCMD.Size = new System.Drawing.Size(549, 230);
            this.textBoxCMD.TabIndex = 7;
            this.textBoxCMD.Visible = false;
            // 
            // buttonShowCMD
            // 
            this.buttonShowCMD.AutoSize = true;
            this.buttonShowCMD.Location = new System.Drawing.Point(12, 151);
            this.buttonShowCMD.Name = "buttonShowCMD";
            this.buttonShowCMD.Size = new System.Drawing.Size(552, 25);
            this.buttonShowCMD.TabIndex = 6;
            this.buttonShowCMD.Text = "显示命令行>>";
            this.buttonShowCMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonShowCMD.UseVisualStyleBackColor = true;
            this.buttonShowCMD.Click += new System.EventHandler(this.buttonShowCMD_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(317, 6);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 5;
            this.buttonRun.Text = "执行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(581, 191);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.textBoxCMD);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.buttonShowCMD);
            this.Controls.Add(this.buttonTo);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxPointTo);
            this.Controls.Add(this.textBoxCreate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MakeLink";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCreate;
        private System.Windows.Forms.TextBox textBoxPointTo;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonTo;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCMD;
        private System.Windows.Forms.Button buttonShowCMD;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button buttonRun;
    }
}

