namespace szwlFormsApplication
{
	partial class systemSettingForm
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
			this.ssOkBtn = new System.Windows.Forms.Button();
			this.SSControl = new System.Windows.Forms.TabControl();
			this.companyName = new System.Windows.Forms.TabPage();
			this.companyNametextBox = new System.Windows.Forms.TextBox();
			this.companyNamelabel = new System.Windows.Forms.Label();
			this.COMSetting = new System.Windows.Forms.TabPage();
			this.stopComboBox = new System.Windows.Forms.ComboBox();
			this.bundRateComboBox = new System.Windows.Forms.ComboBox();
			this.dataComboBox = new System.Windows.Forms.ComboBox();
			this.COMcomboBox = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.callBtnSetting = new System.Windows.Forms.TabPage();
			this.FtextBox = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.EtextBox = new System.Windows.Forms.TextBox();
			this.BtextBox = new System.Windows.Forms.TextBox();
			this.CtextBox = new System.Windows.Forms.TextBox();
			this.DtextBox = new System.Windows.Forms.TextBox();
			this.AtextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.callRecordSetting = new System.Windows.Forms.TabPage();
			this.callInfoColorgroupBox = new System.Windows.Forms.GroupBox();
			this.finish_btn = new System.Windows.Forms.Button();
			this.timeout_btn = new System.Windows.Forms.Button();
			this.wait_btn = new System.Windows.Forms.Button();
			this.completeBtn = new System.Windows.Forms.Button();
			this.timeOutBtn = new System.Windows.Forms.Button();
			this.undoBtn = new System.Windows.Forms.Button();
			this.timeOutlabel = new System.Windows.Forms.Label();
			this.completelabel = new System.Windows.Forms.Label();
			this.undolabel = new System.Windows.Forms.Label();
			this.callOrderBygroupBox = new System.Windows.Forms.GroupBox();
			this.DESradioButton = new System.Windows.Forms.RadioButton();
			this.ASCradioButton = new System.Windows.Forms.RadioButton();
			this.useableTime = new System.Windows.Forms.TabPage();
			this.unit_box = new System.Windows.Forms.ComboBox();
			this.number = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.trackBar3 = new System.Windows.Forms.TrackBar();
			this.UndocolorDialog = new System.Windows.Forms.ColorDialog();
			this.timeOutcolorDialog = new System.Windows.Forms.ColorDialog();
			this.completeColorDialog = new System.Windows.Forms.ColorDialog();
			this.SSControl.SuspendLayout();
			this.companyName.SuspendLayout();
			this.COMSetting.SuspendLayout();
			this.callBtnSetting.SuspendLayout();
			this.callRecordSetting.SuspendLayout();
			this.callInfoColorgroupBox.SuspendLayout();
			this.callOrderBygroupBox.SuspendLayout();
			this.useableTime.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
			this.SuspendLayout();
			// 
			// ssOkBtn
			// 
			this.ssOkBtn.Location = new System.Drawing.Point(882, 616);
			this.ssOkBtn.Name = "ssOkBtn";
			this.ssOkBtn.Size = new System.Drawing.Size(75, 33);
			this.ssOkBtn.TabIndex = 2;
			this.ssOkBtn.Text = "确定";
			this.ssOkBtn.UseVisualStyleBackColor = true;
			this.ssOkBtn.Click += new System.EventHandler(this.ssOkBtn_Click);
			// 
			// SSControl
			// 
			this.SSControl.Controls.Add(this.companyName);
			this.SSControl.Controls.Add(this.COMSetting);
			this.SSControl.Controls.Add(this.callBtnSetting);
			this.SSControl.Controls.Add(this.callRecordSetting);
			this.SSControl.Controls.Add(this.useableTime);
			this.SSControl.Location = new System.Drawing.Point(39, 41);
			this.SSControl.Name = "SSControl";
			this.SSControl.SelectedIndex = 0;
			this.SSControl.Size = new System.Drawing.Size(918, 557);
			this.SSControl.TabIndex = 3;
			// 
			// companyName
			// 
			this.companyName.Controls.Add(this.companyNametextBox);
			this.companyName.Controls.Add(this.companyNamelabel);
			this.companyName.Location = new System.Drawing.Point(4, 22);
			this.companyName.Name = "companyName";
			this.companyName.Padding = new System.Windows.Forms.Padding(3);
			this.companyName.Size = new System.Drawing.Size(910, 531);
			this.companyName.TabIndex = 0;
			this.companyName.Text = "公司名称";
			this.companyName.ToolTipText = "公司名称";
			this.companyName.UseVisualStyleBackColor = true;
			// 
			// companyNametextBox
			// 
			this.companyNametextBox.Location = new System.Drawing.Point(218, 182);
			this.companyNametextBox.Name = "companyNametextBox";
			this.companyNametextBox.Size = new System.Drawing.Size(237, 21);
			this.companyNametextBox.TabIndex = 1;
			// 
			// companyNamelabel
			// 
			this.companyNamelabel.AutoSize = true;
			this.companyNamelabel.Location = new System.Drawing.Point(133, 185);
			this.companyNamelabel.Name = "companyNamelabel";
			this.companyNamelabel.Size = new System.Drawing.Size(53, 12);
			this.companyNamelabel.TabIndex = 0;
			this.companyNamelabel.Text = "公司名称";
			// 
			// COMSetting
			// 
			this.COMSetting.Controls.Add(this.stopComboBox);
			this.COMSetting.Controls.Add(this.bundRateComboBox);
			this.COMSetting.Controls.Add(this.dataComboBox);
			this.COMSetting.Controls.Add(this.COMcomboBox);
			this.COMSetting.Controls.Add(this.label4);
			this.COMSetting.Controls.Add(this.label3);
			this.COMSetting.Controls.Add(this.label2);
			this.COMSetting.Controls.Add(this.label1);
			this.COMSetting.Location = new System.Drawing.Point(4, 22);
			this.COMSetting.Name = "COMSetting";
			this.COMSetting.Padding = new System.Windows.Forms.Padding(3);
			this.COMSetting.Size = new System.Drawing.Size(910, 531);
			this.COMSetting.TabIndex = 1;
			this.COMSetting.Text = "串口设置";
			this.COMSetting.UseVisualStyleBackColor = true;
			// 
			// stopComboBox
			// 
			this.stopComboBox.FormattingEnabled = true;
			this.stopComboBox.Location = new System.Drawing.Point(241, 269);
			this.stopComboBox.Name = "stopComboBox";
			this.stopComboBox.Size = new System.Drawing.Size(176, 20);
			this.stopComboBox.TabIndex = 8;
			// 
			// bundRateComboBox
			// 
			this.bundRateComboBox.FormattingEnabled = true;
			this.bundRateComboBox.Location = new System.Drawing.Point(241, 216);
			this.bundRateComboBox.Name = "bundRateComboBox";
			this.bundRateComboBox.Size = new System.Drawing.Size(176, 20);
			this.bundRateComboBox.TabIndex = 7;
			// 
			// dataComboBox
			// 
			this.dataComboBox.FormattingEnabled = true;
			this.dataComboBox.Location = new System.Drawing.Point(241, 175);
			this.dataComboBox.Name = "dataComboBox";
			this.dataComboBox.Size = new System.Drawing.Size(176, 20);
			this.dataComboBox.TabIndex = 6;
			// 
			// COMcomboBox
			// 
			this.COMcomboBox.FormattingEnabled = true;
			this.COMcomboBox.Location = new System.Drawing.Point(241, 132);
			this.COMcomboBox.Name = "COMcomboBox";
			this.COMcomboBox.Size = new System.Drawing.Size(176, 20);
			this.COMcomboBox.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(154, 276);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 12);
			this.label4.TabIndex = 3;
			this.label4.Text = "停止位";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(154, 224);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "波特率";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(154, 183);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "数据位";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(154, 140);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "串口号";
			// 
			// callBtnSetting
			// 
			this.callBtnSetting.Controls.Add(this.FtextBox);
			this.callBtnSetting.Controls.Add(this.label11);
			this.callBtnSetting.Controls.Add(this.EtextBox);
			this.callBtnSetting.Controls.Add(this.BtextBox);
			this.callBtnSetting.Controls.Add(this.CtextBox);
			this.callBtnSetting.Controls.Add(this.DtextBox);
			this.callBtnSetting.Controls.Add(this.AtextBox);
			this.callBtnSetting.Controls.Add(this.label6);
			this.callBtnSetting.Controls.Add(this.label7);
			this.callBtnSetting.Controls.Add(this.label8);
			this.callBtnSetting.Controls.Add(this.label9);
			this.callBtnSetting.Controls.Add(this.label10);
			this.callBtnSetting.Location = new System.Drawing.Point(4, 22);
			this.callBtnSetting.Name = "callBtnSetting";
			this.callBtnSetting.Size = new System.Drawing.Size(910, 531);
			this.callBtnSetting.TabIndex = 2;
			this.callBtnSetting.Text = "呼叫按钮功能";
			this.callBtnSetting.UseVisualStyleBackColor = true;
			// 
			// FtextBox
			// 
			this.FtextBox.Location = new System.Drawing.Point(244, 348);
			this.FtextBox.Name = "FtextBox";
			this.FtextBox.Size = new System.Drawing.Size(236, 21);
			this.FtextBox.TabIndex = 21;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(167, 357);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(11, 12);
			this.label11.TabIndex = 20;
			this.label11.Text = "F";
			// 
			// EtextBox
			// 
			this.EtextBox.Location = new System.Drawing.Point(244, 297);
			this.EtextBox.Name = "EtextBox";
			this.EtextBox.Size = new System.Drawing.Size(236, 21);
			this.EtextBox.TabIndex = 19;
			// 
			// BtextBox
			// 
			this.BtextBox.Location = new System.Drawing.Point(244, 151);
			this.BtextBox.Name = "BtextBox";
			this.BtextBox.Size = new System.Drawing.Size(236, 21);
			this.BtextBox.TabIndex = 18;
			// 
			// CtextBox
			// 
			this.CtextBox.Location = new System.Drawing.Point(244, 192);
			this.CtextBox.Name = "CtextBox";
			this.CtextBox.Size = new System.Drawing.Size(236, 21);
			this.CtextBox.TabIndex = 17;
			// 
			// DtextBox
			// 
			this.DtextBox.Location = new System.Drawing.Point(244, 244);
			this.DtextBox.Name = "DtextBox";
			this.DtextBox.Size = new System.Drawing.Size(236, 21);
			this.DtextBox.TabIndex = 16;
			// 
			// AtextBox
			// 
			this.AtextBox.Location = new System.Drawing.Point(244, 108);
			this.AtextBox.Name = "AtextBox";
			this.AtextBox.Size = new System.Drawing.Size(236, 21);
			this.AtextBox.TabIndex = 15;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(167, 306);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(11, 12);
			this.label6.TabIndex = 14;
			this.label6.Text = "E";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(167, 253);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(11, 12);
			this.label7.TabIndex = 13;
			this.label7.Text = "D";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(167, 201);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(11, 12);
			this.label8.TabIndex = 12;
			this.label8.Text = "C";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(167, 160);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(11, 12);
			this.label9.TabIndex = 11;
			this.label9.Text = "B";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(167, 117);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(11, 12);
			this.label10.TabIndex = 10;
			this.label10.Text = "A";
			// 
			// callRecordSetting
			// 
			this.callRecordSetting.Controls.Add(this.callInfoColorgroupBox);
			this.callRecordSetting.Controls.Add(this.callOrderBygroupBox);
			this.callRecordSetting.Location = new System.Drawing.Point(4, 22);
			this.callRecordSetting.Name = "callRecordSetting";
			this.callRecordSetting.Size = new System.Drawing.Size(910, 531);
			this.callRecordSetting.TabIndex = 3;
			this.callRecordSetting.Text = "呼叫记录显示";
			this.callRecordSetting.UseVisualStyleBackColor = true;
			// 
			// callInfoColorgroupBox
			// 
			this.callInfoColorgroupBox.Controls.Add(this.finish_btn);
			this.callInfoColorgroupBox.Controls.Add(this.timeout_btn);
			this.callInfoColorgroupBox.Controls.Add(this.wait_btn);
			this.callInfoColorgroupBox.Controls.Add(this.completeBtn);
			this.callInfoColorgroupBox.Controls.Add(this.timeOutBtn);
			this.callInfoColorgroupBox.Controls.Add(this.undoBtn);
			this.callInfoColorgroupBox.Controls.Add(this.timeOutlabel);
			this.callInfoColorgroupBox.Controls.Add(this.completelabel);
			this.callInfoColorgroupBox.Controls.Add(this.undolabel);
			this.callInfoColorgroupBox.Location = new System.Drawing.Point(93, 214);
			this.callInfoColorgroupBox.Name = "callInfoColorgroupBox";
			this.callInfoColorgroupBox.Size = new System.Drawing.Size(655, 219);
			this.callInfoColorgroupBox.TabIndex = 2;
			this.callInfoColorgroupBox.TabStop = false;
			this.callInfoColorgroupBox.Text = "呼叫信息颜色";
			// 
			// finish_btn
			// 
			this.finish_btn.BackColor = System.Drawing.Color.Silver;
			this.finish_btn.FlatAppearance.BorderSize = 0;
			this.finish_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.finish_btn.Location = new System.Drawing.Point(212, 154);
			this.finish_btn.Name = "finish_btn";
			this.finish_btn.Size = new System.Drawing.Size(221, 23);
			this.finish_btn.TabIndex = 8;
			this.finish_btn.UseVisualStyleBackColor = false;
			// 
			// timeout_btn
			// 
			this.timeout_btn.BackColor = System.Drawing.Color.Yellow;
			this.timeout_btn.FlatAppearance.BorderSize = 0;
			this.timeout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.timeout_btn.Location = new System.Drawing.Point(212, 107);
			this.timeout_btn.Name = "timeout_btn";
			this.timeout_btn.Size = new System.Drawing.Size(221, 23);
			this.timeout_btn.TabIndex = 7;
			this.timeout_btn.UseVisualStyleBackColor = false;
			// 
			// wait_btn
			// 
			this.wait_btn.BackColor = System.Drawing.Color.Red;
			this.wait_btn.FlatAppearance.BorderSize = 0;
			this.wait_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.wait_btn.Location = new System.Drawing.Point(212, 58);
			this.wait_btn.Name = "wait_btn";
			this.wait_btn.Size = new System.Drawing.Size(221, 23);
			this.wait_btn.TabIndex = 6;
			this.wait_btn.UseVisualStyleBackColor = false;
			// 
			// completeBtn
			// 
			this.completeBtn.Location = new System.Drawing.Point(490, 154);
			this.completeBtn.Name = "completeBtn";
			this.completeBtn.Size = new System.Drawing.Size(75, 23);
			this.completeBtn.TabIndex = 5;
			this.completeBtn.Text = "设置";
			this.completeBtn.UseVisualStyleBackColor = true;
			this.completeBtn.Click += new System.EventHandler(this.completeBtn_Click);
			// 
			// timeOutBtn
			// 
			this.timeOutBtn.Location = new System.Drawing.Point(490, 107);
			this.timeOutBtn.Name = "timeOutBtn";
			this.timeOutBtn.Size = new System.Drawing.Size(75, 23);
			this.timeOutBtn.TabIndex = 4;
			this.timeOutBtn.Text = "设置";
			this.timeOutBtn.UseVisualStyleBackColor = true;
			this.timeOutBtn.Click += new System.EventHandler(this.timeOutBtn_Click);
			// 
			// undoBtn
			// 
			this.undoBtn.Location = new System.Drawing.Point(490, 58);
			this.undoBtn.Name = "undoBtn";
			this.undoBtn.Size = new System.Drawing.Size(75, 23);
			this.undoBtn.TabIndex = 3;
			this.undoBtn.Text = "设置";
			this.undoBtn.UseVisualStyleBackColor = true;
			this.undoBtn.Click += new System.EventHandler(this.undoBtn_Click);
			// 
			// timeOutlabel
			// 
			this.timeOutlabel.AutoSize = true;
			this.timeOutlabel.Location = new System.Drawing.Point(78, 112);
			this.timeOutlabel.Name = "timeOutlabel";
			this.timeOutlabel.Size = new System.Drawing.Size(29, 12);
			this.timeOutlabel.TabIndex = 2;
			this.timeOutlabel.Text = "超时";
			// 
			// completelabel
			// 
			this.completelabel.AutoSize = true;
			this.completelabel.Location = new System.Drawing.Point(80, 159);
			this.completelabel.Name = "completelabel";
			this.completelabel.Size = new System.Drawing.Size(29, 12);
			this.completelabel.TabIndex = 1;
			this.completelabel.Text = "完成";
			// 
			// undolabel
			// 
			this.undolabel.AutoSize = true;
			this.undolabel.Location = new System.Drawing.Point(80, 63);
			this.undolabel.Name = "undolabel";
			this.undolabel.Size = new System.Drawing.Size(29, 12);
			this.undolabel.TabIndex = 0;
			this.undolabel.Text = "等待";
			// 
			// callOrderBygroupBox
			// 
			this.callOrderBygroupBox.Controls.Add(this.DESradioButton);
			this.callOrderBygroupBox.Controls.Add(this.ASCradioButton);
			this.callOrderBygroupBox.Location = new System.Drawing.Point(93, 38);
			this.callOrderBygroupBox.Name = "callOrderBygroupBox";
			this.callOrderBygroupBox.Size = new System.Drawing.Size(655, 105);
			this.callOrderBygroupBox.TabIndex = 0;
			this.callOrderBygroupBox.TabStop = false;
			this.callOrderBygroupBox.Text = "呼叫记录排序";
			// 
			// DESradioButton
			// 
			this.DESradioButton.AutoSize = true;
			this.DESradioButton.Location = new System.Drawing.Point(386, 51);
			this.DESradioButton.Name = "DESradioButton";
			this.DESradioButton.Size = new System.Drawing.Size(47, 16);
			this.DESradioButton.TabIndex = 1;
			this.DESradioButton.Text = "降序";
			this.DESradioButton.UseVisualStyleBackColor = true;
			// 
			// ASCradioButton
			// 
			this.ASCradioButton.AutoSize = true;
			this.ASCradioButton.Checked = true;
			this.ASCradioButton.Location = new System.Drawing.Point(150, 51);
			this.ASCradioButton.Name = "ASCradioButton";
			this.ASCradioButton.Size = new System.Drawing.Size(47, 16);
			this.ASCradioButton.TabIndex = 0;
			this.ASCradioButton.TabStop = true;
			this.ASCradioButton.Text = "升序";
			this.ASCradioButton.UseVisualStyleBackColor = true;
			// 
			// useableTime
			// 
			this.useableTime.Controls.Add(this.unit_box);
			this.useableTime.Controls.Add(this.number);
			this.useableTime.Controls.Add(this.label12);
			this.useableTime.Controls.Add(this.trackBar3);
			this.useableTime.Location = new System.Drawing.Point(4, 22);
			this.useableTime.Name = "useableTime";
			this.useableTime.Size = new System.Drawing.Size(910, 531);
			this.useableTime.TabIndex = 4;
			this.useableTime.Text = "有效服务时间";
			this.useableTime.UseVisualStyleBackColor = true;
			// 
			// unit_box
			// 
			this.unit_box.FormattingEnabled = true;
			this.unit_box.Items.AddRange(new object[] {
            "秒",
            "分钟",
            "小时"});
			this.unit_box.Location = new System.Drawing.Point(778, 214);
			this.unit_box.Name = "unit_box";
			this.unit_box.Size = new System.Drawing.Size(72, 20);
			this.unit_box.TabIndex = 9;
			this.unit_box.Text = "分钟";
			this.unit_box.SelectedIndexChanged += new System.EventHandler(this.unit_box_SelectedIndexChanged);
			// 
			// number
			// 
			this.number.AutoSize = true;
			this.number.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.number.Location = new System.Drawing.Point(756, 215);
			this.number.Name = "number";
			this.number.Size = new System.Drawing.Size(17, 16);
			this.number.TabIndex = 8;
			this.number.Text = "5";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(17, 222);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(83, 12);
			this.label12.TabIndex = 7;
			this.label12.Text = "设置超时时间:";
			// 
			// trackBar3
			// 
			this.trackBar3.Location = new System.Drawing.Point(165, 207);
			this.trackBar3.Maximum = 59;
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new System.Drawing.Size(556, 45);
			this.trackBar3.TabIndex = 6;
			this.trackBar3.Value = 5;
			this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
			// 
			// systemSettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 676);
			this.Controls.Add(this.SSControl);
			this.Controls.Add(this.ssOkBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "systemSettingForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "系统设置";
			this.SSControl.ResumeLayout(false);
			this.companyName.ResumeLayout(false);
			this.companyName.PerformLayout();
			this.COMSetting.ResumeLayout(false);
			this.COMSetting.PerformLayout();
			this.callBtnSetting.ResumeLayout(false);
			this.callBtnSetting.PerformLayout();
			this.callRecordSetting.ResumeLayout(false);
			this.callInfoColorgroupBox.ResumeLayout(false);
			this.callInfoColorgroupBox.PerformLayout();
			this.callOrderBygroupBox.ResumeLayout(false);
			this.callOrderBygroupBox.PerformLayout();
			this.useableTime.ResumeLayout(false);
			this.useableTime.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button ssOkBtn;
		private System.Windows.Forms.TabControl SSControl;
		private System.Windows.Forms.TabPage companyName;
		private System.Windows.Forms.TabPage COMSetting;
		private System.Windows.Forms.TabPage callBtnSetting;
		private System.Windows.Forms.TabPage callRecordSetting;
		private System.Windows.Forms.TabPage useableTime;
		private System.Windows.Forms.TextBox companyNametextBox;
		private System.Windows.Forms.Label companyNamelabel;
		private System.Windows.Forms.ComboBox stopComboBox;
		private System.Windows.Forms.ComboBox bundRateComboBox;
		private System.Windows.Forms.ComboBox dataComboBox;
		private System.Windows.Forms.ComboBox COMcomboBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox FtextBox;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox EtextBox;
		private System.Windows.Forms.TextBox BtextBox;
		private System.Windows.Forms.TextBox CtextBox;
		private System.Windows.Forms.TextBox DtextBox;
		private System.Windows.Forms.TextBox AtextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox callOrderBygroupBox;
		private System.Windows.Forms.RadioButton DESradioButton;
		private System.Windows.Forms.RadioButton ASCradioButton;
		private System.Windows.Forms.ColorDialog UndocolorDialog;
		private System.Windows.Forms.ColorDialog timeOutcolorDialog;
		private System.Windows.Forms.ColorDialog completeColorDialog;
		private System.Windows.Forms.Button finish_btn;
		private System.Windows.Forms.Button timeout_btn;
		private System.Windows.Forms.Button wait_btn;
		private System.Windows.Forms.Label undolabel;
		private System.Windows.Forms.Label completelabel;
		private System.Windows.Forms.Label timeOutlabel;
		private System.Windows.Forms.Button undoBtn;
		private System.Windows.Forms.Button timeOutBtn;
		private System.Windows.Forms.Button completeBtn;
		private System.Windows.Forms.GroupBox callInfoColorgroupBox;
		private System.Windows.Forms.ComboBox unit_box;
		private System.Windows.Forms.Label number;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TrackBar trackBar3;
	}
}