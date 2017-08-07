namespace szwlFormsApplication
{
	partial class userForm
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userAddbtn = new System.Windows.Forms.Button();
			this.userUpdatebtn = new System.Windows.Forms.Button();
			this.userDeletebtn = new System.Windows.Forms.Button();
			this.userAuhtoritybtn = new System.Windows.Forms.Button();
			this.userUpdatePwbtn = new System.Windows.Forms.Button();
			this.userclearDatabtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.password});
			this.dataGridView1.Location = new System.Drawing.Point(3, 1);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(244, 519);
			this.dataGridView1.TabIndex = 0;
			// 
			// UserName
			// 
			this.UserName.HeaderText = "用户名";
			this.UserName.Name = "UserName";
			// 
			// password
			// 
			this.password.HeaderText = "密码";
			this.password.Name = "password";
			// 
			// userAddbtn
			// 
			this.userAddbtn.Location = new System.Drawing.Point(325, 63);
			this.userAddbtn.Name = "userAddbtn";
			this.userAddbtn.Size = new System.Drawing.Size(75, 23);
			this.userAddbtn.TabIndex = 1;
			this.userAddbtn.Text = "添加用户";
			this.userAddbtn.UseVisualStyleBackColor = true;
			// 
			// userUpdatebtn
			// 
			this.userUpdatebtn.Location = new System.Drawing.Point(325, 120);
			this.userUpdatebtn.Name = "userUpdatebtn";
			this.userUpdatebtn.Size = new System.Drawing.Size(75, 23);
			this.userUpdatebtn.TabIndex = 2;
			this.userUpdatebtn.Text = "修改用户";
			this.userUpdatebtn.UseVisualStyleBackColor = true;
			// 
			// userDeletebtn
			// 
			this.userDeletebtn.Location = new System.Drawing.Point(325, 181);
			this.userDeletebtn.Name = "userDeletebtn";
			this.userDeletebtn.Size = new System.Drawing.Size(75, 23);
			this.userDeletebtn.TabIndex = 3;
			this.userDeletebtn.Text = "删除用户";
			this.userDeletebtn.UseVisualStyleBackColor = true;
			// 
			// userAuhtoritybtn
			// 
			this.userAuhtoritybtn.Location = new System.Drawing.Point(325, 248);
			this.userAuhtoritybtn.Name = "userAuhtoritybtn";
			this.userAuhtoritybtn.Size = new System.Drawing.Size(75, 23);
			this.userAuhtoritybtn.TabIndex = 4;
			this.userAuhtoritybtn.Text = "权限";
			this.userAuhtoritybtn.UseVisualStyleBackColor = true;
			// 
			// userUpdatePwbtn
			// 
			this.userUpdatePwbtn.Location = new System.Drawing.Point(325, 322);
			this.userUpdatePwbtn.Name = "userUpdatePwbtn";
			this.userUpdatePwbtn.Size = new System.Drawing.Size(75, 23);
			this.userUpdatePwbtn.TabIndex = 5;
			this.userUpdatePwbtn.Text = "修改密码";
			this.userUpdatePwbtn.UseVisualStyleBackColor = true;
			// 
			// userclearDatabtn
			// 
			this.userclearDatabtn.Location = new System.Drawing.Point(325, 399);
			this.userclearDatabtn.Name = "userclearDatabtn";
			this.userclearDatabtn.Size = new System.Drawing.Size(75, 23);
			this.userclearDatabtn.TabIndex = 6;
			this.userclearDatabtn.Text = "清除数据";
			this.userclearDatabtn.UseVisualStyleBackColor = true;
			// 
			// userForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 520);
			this.Controls.Add(this.userclearDatabtn);
			this.Controls.Add(this.userUpdatePwbtn);
			this.Controls.Add(this.userAuhtoritybtn);
			this.Controls.Add(this.userDeletebtn);
			this.Controls.Add(this.userUpdatebtn);
			this.Controls.Add(this.userAddbtn);
			this.Controls.Add(this.dataGridView1);
			this.Name = "userForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "用户管理";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
		private System.Windows.Forms.DataGridViewTextBoxColumn password;
		private System.Windows.Forms.Button userAddbtn;
		private System.Windows.Forms.Button userUpdatebtn;
		private System.Windows.Forms.Button userDeletebtn;
		private System.Windows.Forms.Button userAuhtoritybtn;
		private System.Windows.Forms.Button userUpdatePwbtn;
		private System.Windows.Forms.Button userclearDatabtn;
	}
}