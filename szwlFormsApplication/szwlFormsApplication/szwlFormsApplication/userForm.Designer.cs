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
			this.userAddbtn = new System.Windows.Forms.Button();
			this.userUpdatebtn = new System.Windows.Forms.Button();
			this.userDeletebtn = new System.Windows.Forms.Button();
			this.userAuhtoritybtn = new System.Windows.Forms.Button();
			this.userUpdatePwbtn = new System.Windows.Forms.Button();
			this.userclearDatabtn = new System.Windows.Forms.Button();
			this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.pass,
            this.userClass});
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridView1.Location = new System.Drawing.Point(3, 1);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(345, 582);
			this.dataGridView1.TabIndex = 0;
			// 
			// userAddbtn
			// 
			this.userAddbtn.Location = new System.Drawing.Point(436, 91);
			this.userAddbtn.Name = "userAddbtn";
			this.userAddbtn.Size = new System.Drawing.Size(75, 23);
			this.userAddbtn.TabIndex = 1;
			this.userAddbtn.Text = "添加用户";
			this.userAddbtn.UseVisualStyleBackColor = true;
			this.userAddbtn.Click += new System.EventHandler(this.userAddbtn_Click);
			// 
			// userUpdatebtn
			// 
			this.userUpdatebtn.Location = new System.Drawing.Point(436, 148);
			this.userUpdatebtn.Name = "userUpdatebtn";
			this.userUpdatebtn.Size = new System.Drawing.Size(75, 23);
			this.userUpdatebtn.TabIndex = 2;
			this.userUpdatebtn.Text = "修改用户";
			this.userUpdatebtn.UseVisualStyleBackColor = true;
			this.userUpdatebtn.Click += new System.EventHandler(this.userUpdatebtn_Click);
			// 
			// userDeletebtn
			// 
			this.userDeletebtn.Location = new System.Drawing.Point(436, 209);
			this.userDeletebtn.Name = "userDeletebtn";
			this.userDeletebtn.Size = new System.Drawing.Size(75, 23);
			this.userDeletebtn.TabIndex = 3;
			this.userDeletebtn.Text = "删除用户";
			this.userDeletebtn.UseVisualStyleBackColor = true;
			this.userDeletebtn.Click += new System.EventHandler(this.userDeletebtn_Click);
			// 
			// userAuhtoritybtn
			// 
			this.userAuhtoritybtn.Location = new System.Drawing.Point(436, 276);
			this.userAuhtoritybtn.Name = "userAuhtoritybtn";
			this.userAuhtoritybtn.Size = new System.Drawing.Size(75, 23);
			this.userAuhtoritybtn.TabIndex = 4;
			this.userAuhtoritybtn.Text = "权限";
			this.userAuhtoritybtn.UseVisualStyleBackColor = true;
			this.userAuhtoritybtn.Click += new System.EventHandler(this.userAuhtoritybtn_Click);
			// 
			// userUpdatePwbtn
			// 
			this.userUpdatePwbtn.Location = new System.Drawing.Point(436, 350);
			this.userUpdatePwbtn.Name = "userUpdatePwbtn";
			this.userUpdatePwbtn.Size = new System.Drawing.Size(75, 23);
			this.userUpdatePwbtn.TabIndex = 5;
			this.userUpdatePwbtn.Text = "修改密码";
			this.userUpdatePwbtn.UseVisualStyleBackColor = true;
			this.userUpdatePwbtn.Click += new System.EventHandler(this.userUpdatePwbtn_Click);
			// 
			// userclearDatabtn
			// 
			this.userclearDatabtn.Location = new System.Drawing.Point(436, 427);
			this.userclearDatabtn.Name = "userclearDatabtn";
			this.userclearDatabtn.Size = new System.Drawing.Size(75, 23);
			this.userclearDatabtn.TabIndex = 6;
			this.userclearDatabtn.Text = "清除数据";
			this.userclearDatabtn.UseVisualStyleBackColor = true;
			this.userclearDatabtn.Click += new System.EventHandler(this.userclearDatabtn_Click);
			// 
			// name
			// 
			this.name.DataPropertyName = "name";
			this.name.HeaderText = "用户名";
			this.name.Name = "name";
			// 
			// pass
			// 
			this.pass.DataPropertyName = "pass";
			this.pass.HeaderText = "密码";
			this.pass.Name = "pass";
			// 
			// userClass
			// 
			this.userClass.DataPropertyName = "userClass";
			this.userClass.HeaderText = "用户类型";
			this.userClass.Name = "userClass";
			// 
			// userForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(590, 588);
			this.Controls.Add(this.userclearDatabtn);
			this.Controls.Add(this.userUpdatePwbtn);
			this.Controls.Add(this.userAuhtoritybtn);
			this.Controls.Add(this.userDeletebtn);
			this.Controls.Add(this.userUpdatebtn);
			this.Controls.Add(this.userAddbtn);
			this.Controls.Add(this.dataGridView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "userForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "用户管理";
			this.Load += new System.EventHandler(this.userForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button userAddbtn;
		private System.Windows.Forms.Button userUpdatebtn;
		private System.Windows.Forms.Button userDeletebtn;
		private System.Windows.Forms.Button userAuhtoritybtn;
		private System.Windows.Forms.Button userUpdatePwbtn;
		private System.Windows.Forms.Button userclearDatabtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn userClass;
		private System.Windows.Forms.DataGridViewTextBoxColumn pass;
		private System.Windows.Forms.DataGridViewTextBoxColumn name;
	}
}