﻿namespace szwlFormsApplication
{
	partial class dataMaintainSettingForm
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
			this.dataInitLabel = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.dataInitOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// dataInitLabel
			// 
			this.dataInitLabel.AutoSize = true;
			this.dataInitLabel.Location = new System.Drawing.Point(70, 34);
			this.dataInitLabel.Name = "dataInitLabel";
			this.dataInitLabel.Size = new System.Drawing.Size(65, 12);
			this.dataInitLabel.TabIndex = 0;
			this.dataInitLabel.Text = "数据初始化";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "所有信息",
            "呼叫器信息",
            "区域信息",
            "员工信息",
            "用户信息",
            "呼叫记录信息",
            "表头信息"});
			this.comboBox1.Location = new System.Drawing.Point(179, 31);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(208, 20);
			this.comboBox1.TabIndex = 1;
			// 
			// dataInitOK
			// 
			this.dataInitOK.Location = new System.Drawing.Point(428, 28);
			this.dataInitOK.Name = "dataInitOK";
			this.dataInitOK.Size = new System.Drawing.Size(75, 23);
			this.dataInitOK.TabIndex = 2;
			this.dataInitOK.Text = "确定";
			this.dataInitOK.UseVisualStyleBackColor = true;
			this.dataInitOK.Click += new System.EventHandler(this.dataInitOK_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(207, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(137, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "请谨慎使用该功能！！！";
			// 
			// dataMaintainSettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(631, 120);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataInitOK);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.dataInitLabel);
			this.MaximizeBox = false;
			this.Name = "dataMaintainSettingForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "数据维护";
			this.Load += new System.EventHandler(this.dataMaintainSettingForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label dataInitLabel;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button dataInitOK;
		private System.Windows.Forms.Label label1;
	}
}