using System;
using System.Windows.Forms;

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
			this.isRFIDBox = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.name,
            this.mobile,
            this.remark,
            this.sex});
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridView1.Enabled = false;
			this.dataGridView1.Location = new System.Drawing.Point(0, 1);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(545, 657);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_RowEnter);
			// 
			// UserName
			// 
			this.UserName.DataPropertyName = "employeeNum";
			this.UserName.HeaderText = "员工编号";
			this.UserName.Name = "UserName";
			// 
			// name
			// 
			this.name.DataPropertyName = "name";
			this.name.HeaderText = "姓名";
			this.name.Name = "name";
			// 
			// mobile
			// 
			this.mobile.DataPropertyName = "phonenum";
			this.mobile.HeaderText = "电话";
			this.mobile.Name = "mobile";
			// 
			// remark
			// 
			this.remark.DataPropertyName = "remarks";
			this.remark.HeaderText = "备注";
			this.remark.Name = "remark";
			// 
			// sex
			// 
			this.sex.DataPropertyName = "sex";
			this.sex.HeaderText = "性别";
			this.sex.Name = "sex";
			// 
			// addemployee
			// 
			this.addemployee.Location = new System.Drawing.Point(612, 149);
			this.addemployee.Name = "addemployee";
			this.addemployee.Size = new System.Drawing.Size(75, 23);
			this.addemployee.TabIndex = 1;
			this.addemployee.Text = "添加";
			this.addemployee.UseVisualStyleBackColor = true;
			this.addemployee.Click += new System.EventHandler(this.addemployee_Click);
			// 
			// updateemployee
			// 
			this.updateemployee.Location = new System.Drawing.Point(612, 227);
			this.updateemployee.Name = "updateemployee";
			this.updateemployee.Size = new System.Drawing.Size(75, 23);
			this.updateemployee.TabIndex = 2;
			this.updateemployee.Text = "修改";
			this.updateemployee.UseVisualStyleBackColor = true;
			this.updateemployee.Click += new System.EventHandler(this.updateemployee_Click);
			// 
			// deleteemployee
			// 
			this.deleteemployee.Location = new System.Drawing.Point(612, 301);
			this.deleteemployee.Name = "deleteemployee";
			this.deleteemployee.Size = new System.Drawing.Size(75, 23);
			this.deleteemployee.TabIndex = 3;
			this.deleteemployee.Text = "删除";
			this.deleteemployee.UseVisualStyleBackColor = true;
			this.deleteemployee.Click += new System.EventHandler(this.deleteemployee_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(612, 368);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "确定";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// clearemployee
			// 
			this.clearemployee.Location = new System.Drawing.Point(612, 479);
			this.clearemployee.Name = "clearemployee";
			this.clearemployee.Size = new System.Drawing.Size(75, 23);
			this.clearemployee.TabIndex = 5;
			this.clearemployee.Text = "清除数据";
			this.clearemployee.UseVisualStyleBackColor = true;
			this.clearemployee.Click += new System.EventHandler(this.clearemployee_Click);
			// 
			// isRFIDBox
			// 
			this.isRFIDBox.FormattingEnabled = true;
			this.isRFIDBox.Items.AddRange(new object[] {
            "按钮模式",
            "RFID模式"});
			this.isRFIDBox.Location = new System.Drawing.Point(612, 59);
			this.isRFIDBox.Name = "isRFIDBox";
			this.isRFIDBox.Size = new System.Drawing.Size(121, 20);
			this.isRFIDBox.TabIndex = 6;
			this.isRFIDBox.SelectedIndexChanged += new System.EventHandler(this.isRFIDBox_SelectedIndexChanged);
			// 
			// employeeSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(773, 658);
			this.Controls.Add(this.isRFIDBox);
			this.Controls.Add(this.clearemployee);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.deleteemployee);
			this.Controls.Add(this.updateemployee);
			this.Controls.Add(this.addemployee);
			this.Controls.Add(this.dataGridView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "employeeSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "员工信息设置";
			this.Load += new System.EventHandler(this.employeeSettingsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}



		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button addemployee;
		private System.Windows.Forms.Button updateemployee;
		private System.Windows.Forms.Button deleteemployee;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button clearemployee;
		private System.Windows.Forms.ComboBox isRFIDBox;
		private DataGridViewTextBoxColumn sex;
		private DataGridViewTextBoxColumn remark;
		private DataGridViewTextBoxColumn mobile;
		private DataGridViewTextBoxColumn name;
		private DataGridViewTextBoxColumn UserName;
	}
}