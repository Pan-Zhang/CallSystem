namespace szwlFormsApplication.dialog
{
	partial class ChangeUser
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
			this.ensure = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.username = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.password = new System.Windows.Forms.TextBox();
			this.cancel = new System.Windows.Forms.Button();
			this.prompt = new System.Windows.Forms.Label();
			this.userClassComboBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ensure
			// 
			this.ensure.Location = new System.Drawing.Point(229, 227);
			this.ensure.Name = "ensure";
			this.ensure.Size = new System.Drawing.Size(75, 23);
			this.ensure.TabIndex = 0;
			this.ensure.Text = "确定";
			this.ensure.UseVisualStyleBackColor = true;
			this.ensure.Click += new System.EventHandler(this.ensure_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(99, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "用户名:";
			// 
			// username
			// 
			this.username.Location = new System.Drawing.Point(172, 59);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(254, 21);
			this.username.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(99, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "密码:";
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(172, 121);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(254, 21);
			this.password.TabIndex = 4;
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(351, 227);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 5;
			this.cancel.Text = "取消";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// prompt
			// 
			this.prompt.AutoSize = true;
			this.prompt.ForeColor = System.Drawing.Color.Red;
			this.prompt.Location = new System.Drawing.Point(187, 83);
			this.prompt.Name = "prompt";
			this.prompt.Size = new System.Drawing.Size(125, 12);
			this.prompt.TabIndex = 6;
			this.prompt.Text = "管理员名称不允许修改";
			// 
			// userClassComboBox
			// 
			this.userClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.userClassComboBox.FormattingEnabled = true;
			this.userClassComboBox.Location = new System.Drawing.Point(172, 178);
			this.userClassComboBox.Name = "userClassComboBox";
			this.userClassComboBox.Size = new System.Drawing.Size(254, 20);
			this.userClassComboBox.TabIndex = 17;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(75, 186);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 12);
			this.label3.TabIndex = 16;
			this.label3.Text = "用户类型:";
			// 
			// ChangeUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 284);
			this.Controls.Add(this.userClassComboBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.prompt);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.password);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.username);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ensure);
			this.Name = "ChangeUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "修改用户信息";
			this.Load += new System.EventHandler(this.ChangeUser_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ensure;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Label prompt;
		private System.Windows.Forms.ComboBox userClassComboBox;
		private System.Windows.Forms.Label label3;
	}
}