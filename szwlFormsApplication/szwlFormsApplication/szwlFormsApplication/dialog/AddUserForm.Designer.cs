namespace szwlFormsApplication.dialog
{
	partial class AddUserForm
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
			this.userClassComboBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.prompt = new System.Windows.Forms.Label();
			this.ensure = new System.Windows.Forms.Button();
			this.password = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.username = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// userClassComboBox
			// 
			this.userClassComboBox.FormattingEnabled = true;
			this.userClassComboBox.Location = new System.Drawing.Point(153, 141);
			this.userClassComboBox.Name = "userClassComboBox";
			this.userClassComboBox.Size = new System.Drawing.Size(174, 20);
			this.userClassComboBox.TabIndex = 15;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(71, 148);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 12);
			this.label3.TabIndex = 14;
			this.label3.Text = "用户类型:";
			// 
			// prompt
			// 
			this.prompt.AutoSize = true;
			this.prompt.ForeColor = System.Drawing.Color.Red;
			this.prompt.Location = new System.Drawing.Point(166, 61);
			this.prompt.Name = "prompt";
			this.prompt.Size = new System.Drawing.Size(131, 12);
			this.prompt.TabIndex = 13;
			this.prompt.Text = "不允许命名为‘admin’";
			// 
			// ensure
			// 
			this.ensure.Location = new System.Drawing.Point(252, 200);
			this.ensure.Name = "ensure";
			this.ensure.Size = new System.Drawing.Size(75, 23);
			this.ensure.TabIndex = 12;
			this.ensure.Text = "确定";
			this.ensure.UseVisualStyleBackColor = true;
			this.ensure.Click += new System.EventHandler(this.ensure_Click);
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(153, 90);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(174, 21);
			this.password.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(83, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 12);
			this.label2.TabIndex = 10;
			this.label2.Text = "  密码:";
			// 
			// username
			// 
			this.username.Location = new System.Drawing.Point(153, 36);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(174, 21);
			this.username.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(83, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 12);
			this.label1.TabIndex = 8;
			this.label1.Text = "用户名:";
			// 
			// AddUserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(422, 262);
			this.Controls.Add(this.userClassComboBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.prompt);
			this.Controls.Add(this.ensure);
			this.Controls.Add(this.password);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.username);
			this.Controls.Add(this.label1);
			this.Name = "AddUserForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "添加用户";
			this.Load += new System.EventHandler(this.AddUserForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox userClassComboBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Button ensure;
		private System.Windows.Forms.Label prompt;
	}
}