namespace szwlFormsApplication
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
			this.comboBox1.FormattingEnabled = true;
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
			// 
			// dataMaintainSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 85);
			this.Controls.Add(this.dataInitOK);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.dataInitLabel);
			this.Name = "dataMaintainSetting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "数据维护";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label dataInitLabel;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button dataInitOK;
	}
}