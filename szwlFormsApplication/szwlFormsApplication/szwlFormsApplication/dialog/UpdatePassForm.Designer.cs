namespace szwlFormsApplication.dialog
{
	partial class UpdatePassForm
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
			this.oldpw = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.newpw = new System.Windows.Forms.TextBox();
			this.ensure = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(62, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "原密码";
			// 
			// oldpw
			// 
			this.oldpw.Location = new System.Drawing.Point(159, 46);
			this.oldpw.Name = "oldpw";
			this.oldpw.Size = new System.Drawing.Size(223, 21);
			this.oldpw.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(62, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "新密码";
			// 
			// newpw
			// 
			this.newpw.Location = new System.Drawing.Point(159, 103);
			this.newpw.Name = "newpw";
			this.newpw.Size = new System.Drawing.Size(223, 21);
			this.newpw.TabIndex = 3;
			// 
			// ensure
			// 
			this.ensure.Location = new System.Drawing.Point(183, 165);
			this.ensure.Name = "ensure";
			this.ensure.Size = new System.Drawing.Size(75, 23);
			this.ensure.TabIndex = 4;
			this.ensure.Text = "确定";
			this.ensure.UseVisualStyleBackColor = true;
			this.ensure.Click += new System.EventHandler(this.ensure_Click);
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(307, 165);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 5;
			this.cancel.Text = "取消";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// UpdatePassForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(474, 224);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ensure);
			this.Controls.Add(this.newpw);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.oldpw);
			this.Controls.Add(this.label1);
			this.Name = "UpdatePassForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "修改密码";
			this.Load += new System.EventHandler(this.UpdatePassForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox oldpw;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox newpw;
		private System.Windows.Forms.Button ensure;
		private System.Windows.Forms.Button cancel;
	}
}