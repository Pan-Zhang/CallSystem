namespace szwlFormsApplication.dialog
{
	partial class ChangeUserAuthor
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
			this.label1 = new System.Windows.Forms.Label();
			this.cancel = new System.Windows.Forms.Button();
			this.ensure = new System.Windows.Forms.Button();
			this.prompt = new System.Windows.Forms.Label();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(56, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 0;
			this.label1.Tag = "用户权限";
			this.label1.Text = "用户权限";
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(265, 313);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 20;
			this.cancel.Text = "取消";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// ensure
			// 
			this.ensure.Location = new System.Drawing.Point(157, 313);
			this.ensure.Name = "ensure";
			this.ensure.Size = new System.Drawing.Size(75, 23);
			this.ensure.TabIndex = 19;
			this.ensure.Text = "确定";
			this.ensure.UseVisualStyleBackColor = true;
			this.ensure.Click += new System.EventHandler(this.ensure_Click);
			// 
			// prompt
			// 
			this.prompt.AutoSize = true;
			this.prompt.ForeColor = System.Drawing.Color.Red;
			this.prompt.Location = new System.Drawing.Point(190, 266);
			this.prompt.Name = "prompt";
			this.prompt.Size = new System.Drawing.Size(125, 12);
			this.prompt.TabIndex = 21;
			this.prompt.Text = "管理员权限不允许修改";
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.CheckOnClick = true;
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Items.AddRange(new object[] {
            "用户登录",
            "系统设置",
            "用户",
            "员工设置",
            "呼叫器设置",
            "表头设置",
            "数据统计",
            "出厂设置",
            "帮助",
            "关于"});
			this.checkedListBox1.Location = new System.Drawing.Point(127, 64);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(261, 196);
			this.checkedListBox1.TabIndex = 22;
			// 
			// ChangeUserAuthor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(499, 372);
			this.Controls.Add(this.checkedListBox1);
			this.Controls.Add(this.prompt);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ensure);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ChangeUserAuthor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Tag = "修改用户权限";
			this.Text = "修改用户权限";
			this.Load += new System.EventHandler(this.ChangeUserAuthor_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button ensure;
		private System.Windows.Forms.Label prompt;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
	}
}