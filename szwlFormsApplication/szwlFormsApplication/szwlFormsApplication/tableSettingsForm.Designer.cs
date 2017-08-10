namespace szwlFormsApplication
{
	partial class tableSettingsForm
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
			this.choosegroupBox = new System.Windows.Forms.GroupBox();
			this.employeeInfotable = new System.Windows.Forms.Label();
			this.callInfotable = new System.Windows.Forms.Label();
			this.columnSetgroupBox = new System.Windows.Forms.GroupBox();
			this.choosegroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// choosegroupBox
			// 
			this.choosegroupBox.Controls.Add(this.employeeInfotable);
			this.choosegroupBox.Controls.Add(this.callInfotable);
			this.choosegroupBox.Location = new System.Drawing.Point(2, 12);
			this.choosegroupBox.Name = "choosegroupBox";
			this.choosegroupBox.Size = new System.Drawing.Size(225, 680);
			this.choosegroupBox.TabIndex = 0;
			this.choosegroupBox.TabStop = false;
			this.choosegroupBox.Text = "选择表";
			// 
			// employeeInfotable
			// 
			this.employeeInfotable.AutoSize = true;
			this.employeeInfotable.Location = new System.Drawing.Point(11, 57);
			this.employeeInfotable.Name = "employeeInfotable";
			this.employeeInfotable.Size = new System.Drawing.Size(65, 12);
			this.employeeInfotable.TabIndex = 1;
			this.employeeInfotable.Text = "员工信息表";
			// 
			// callInfotable
			// 
			this.callInfotable.AutoSize = true;
			this.callInfotable.Location = new System.Drawing.Point(11, 28);
			this.callInfotable.Name = "callInfotable";
			this.callInfotable.Size = new System.Drawing.Size(65, 12);
			this.callInfotable.TabIndex = 0;
			this.callInfotable.Text = "呼叫信息表";
			// 
			// columnSetgroupBox
			// 
			this.columnSetgroupBox.Location = new System.Drawing.Point(233, 12);
			this.columnSetgroupBox.Name = "columnSetgroupBox";
			this.columnSetgroupBox.Size = new System.Drawing.Size(522, 680);
			this.columnSetgroupBox.TabIndex = 1;
			this.columnSetgroupBox.TabStop = false;
			this.columnSetgroupBox.Text = "列别名设置";
			// 
			// tableSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(767, 693);
			this.Controls.Add(this.columnSetgroupBox);
			this.Controls.Add(this.choosegroupBox);
			this.MaximizeBox = false;
			this.Name = "tableSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "表头设置";
			this.choosegroupBox.ResumeLayout(false);
			this.choosegroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox choosegroupBox;
		private System.Windows.Forms.Label employeeInfotable;
		private System.Windows.Forms.Label callInfotable;
		private System.Windows.Forms.GroupBox columnSetgroupBox;
	}
}