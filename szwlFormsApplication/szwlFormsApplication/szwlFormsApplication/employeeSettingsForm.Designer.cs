namespace szwlFormsApplication
{
	partial class employeeSettingsForm
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
			this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.addemployee = new System.Windows.Forms.Button();
			this.updateemployee = new System.Windows.Forms.Button();
			this.deleteemployee = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.clearemployee = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.name,
            this.mobile,
            this.remark,
            this.sex});
			this.dataGridView1.Location = new System.Drawing.Point(0, 1);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(545, 657);
			this.dataGridView1.TabIndex = 0;
			// 
			// UserName
			// 
			this.UserName.HeaderText = "员工编号";
			this.UserName.Name = "UserName";
			// 
			// name
			// 
			this.name.HeaderText = "姓名";
			this.name.Name = "name";
			// 
			// mobile
			// 
			this.mobile.HeaderText = "电话";
			this.mobile.Name = "mobile";
			// 
			// remark
			// 
			this.remark.HeaderText = "备注";
			this.remark.Name = "remark";
			// 
			// sex
			// 
			this.sex.HeaderText = "性别";
			this.sex.Name = "sex";
			// 
			// addemployee
			// 
			this.addemployee.Location = new System.Drawing.Point(612, 75);
			this.addemployee.Name = "addemployee";
			this.addemployee.Size = new System.Drawing.Size(75, 23);
			this.addemployee.TabIndex = 1;
			this.addemployee.Text = "添加";
			this.addemployee.UseVisualStyleBackColor = true;
			// 
			// updateemployee
			// 
			this.updateemployee.Location = new System.Drawing.Point(612, 137);
			this.updateemployee.Name = "updateemployee";
			this.updateemployee.Size = new System.Drawing.Size(75, 23);
			this.updateemployee.TabIndex = 2;
			this.updateemployee.Text = "修改";
			this.updateemployee.UseVisualStyleBackColor = true;
			// 
			// deleteemployee
			// 
			this.deleteemployee.Location = new System.Drawing.Point(612, 201);
			this.deleteemployee.Name = "deleteemployee";
			this.deleteemployee.Size = new System.Drawing.Size(75, 23);
			this.deleteemployee.TabIndex = 3;
			this.deleteemployee.Text = "删除";
			this.deleteemployee.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(612, 270);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "添加";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// clearemployee
			// 
			this.clearemployee.Location = new System.Drawing.Point(612, 391);
			this.clearemployee.Name = "clearemployee";
			this.clearemployee.Size = new System.Drawing.Size(75, 23);
			this.clearemployee.TabIndex = 5;
			this.clearemployee.Text = "清除数据";
			this.clearemployee.UseVisualStyleBackColor = true;
			// 
			// employeeSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(773, 658);
			this.Controls.Add(this.clearemployee);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.deleteemployee);
			this.Controls.Add(this.updateemployee);
			this.Controls.Add(this.addemployee);
			this.Controls.Add(this.dataGridView1);
			this.Name = "employeeSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "员工信息设置";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
		private System.Windows.Forms.DataGridViewTextBoxColumn name;
		private System.Windows.Forms.DataGridViewTextBoxColumn mobile;
		private System.Windows.Forms.DataGridViewTextBoxColumn remark;
		private System.Windows.Forms.DataGridViewTextBoxColumn sex;
		private System.Windows.Forms.Button addemployee;
		private System.Windows.Forms.Button updateemployee;
		private System.Windows.Forms.Button deleteemployee;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button clearemployee;
	}
}