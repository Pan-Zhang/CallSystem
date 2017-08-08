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
			this.label1 = new System.Windows.Forms.Label();
			this.username = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.password = new System.Windows.Forms.TextBox();
			this.ensure = new System.Windows.Forms.Button();
			this.prompt = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(86, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "用户名:";
			// 
			// username
			// 
			this.username.Location = new System.Drawing.Point(194, 58);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(174, 21);
			this.username.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(86, 122);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "密码:";
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(194, 119);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(174, 21);
			this.password.TabIndex = 3;
			// 
			// ensure
			// 
			this.ensure.Location = new System.Drawing.Point(293, 214);
			this.ensure.Name = "ensure";
			this.ensure.Size = new System.Drawing.Size(75, 23);
			this.ensure.TabIndex = 4;
			this.ensure.Text = "确定";
			this.ensure.UseVisualStyleBackColor = true;
			this.ensure.Click += new System.EventHandler(this.ensure_Click);
			// 
			// prompt
			// 
			this.prompt.AutoSize = true;
			this.prompt.ForeColor = System.Drawing.Color.Red;
			this.prompt.Location = new System.Drawing.Point(208, 82);
			this.prompt.Name = "prompt";
			this.prompt.Size = new System.Drawing.Size(131, 12);
			this.prompt.TabIndex = 5;
			this.prompt.Text = "不允许命名为‘admin’";
			// 
			// AddUserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(422, 262);
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

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Button ensure;
		private System.Windows.Forms.Label prompt;
	}
}