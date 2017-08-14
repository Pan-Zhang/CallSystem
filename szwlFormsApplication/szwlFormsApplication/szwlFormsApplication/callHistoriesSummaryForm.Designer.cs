namespace szwlFormsApplication
{
	partial class callHistoriesSummaryForm
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
			this.historyRecordsgroupBox = new System.Windows.Forms.GroupBox();
			this.historyRecordsdataGridView = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.historySummarygroupBox = new System.Windows.Forms.GroupBox();
			this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.historyOptiongroupBox = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.statusBox = new System.Windows.Forms.ComboBox();
			this.typeBox = new System.Windows.Forms.ComboBox();
			this.callArea = new System.Windows.Forms.ComboBox();
			this.date_end = new System.Windows.Forms.DateTimePicker();
			this.date_start = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.worker = new System.Windows.Forms.ComboBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.total = new System.Windows.Forms.Label();
			this.historyRecordsgroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.historyRecordsdataGridView)).BeginInit();
			this.historySummarygroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
			this.historyOptiongroupBox.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// historyRecordsgroupBox
			// 
			this.historyRecordsgroupBox.Controls.Add(this.historyRecordsdataGridView);
			this.historyRecordsgroupBox.Location = new System.Drawing.Point(7, 13);
			this.historyRecordsgroupBox.Name = "historyRecordsgroupBox";
			this.historyRecordsgroupBox.Size = new System.Drawing.Size(795, 259);
			this.historyRecordsgroupBox.TabIndex = 0;
			this.historyRecordsgroupBox.TabStop = false;
			this.historyRecordsgroupBox.Text = "查询结果";
			// 
			// historyRecordsdataGridView
			// 
			this.historyRecordsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.historyRecordsdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
			this.historyRecordsdataGridView.Location = new System.Drawing.Point(7, 21);
			this.historyRecordsdataGridView.Name = "historyRecordsdataGridView";
			this.historyRecordsdataGridView.RowTemplate.Height = 23;
			this.historyRecordsdataGridView.Size = new System.Drawing.Size(782, 232);
			this.historyRecordsdataGridView.TabIndex = 0;
			// 
			// id
			// 
			this.id.DataPropertyName = "Id";
			this.id.HeaderText = "id";
			this.id.Name = "id";
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "time";
			this.Column2.HeaderText = "时间";
			this.Column2.Name = "Column2";
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "callerNum";
			this.Column1.HeaderText = "呼叫号码";
			this.Column1.Name = "Column1";
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "employeeNum";
			this.Column3.HeaderText = "服务号码";
			this.Column3.Name = "Column3";
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "type";
			this.Column4.HeaderText = "类型";
			this.Column4.Name = "Column4";
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "status";
			this.Column5.HeaderText = "状态";
			this.Column5.Name = "Column5";
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "isRFID";
			this.Column6.HeaderText = "isRFID";
			this.Column6.Name = "Column6";
			// 
			// historySummarygroupBox
			// 
			this.historySummarygroupBox.CausesValidation = false;
			this.historySummarygroupBox.Controls.Add(this.total);
			this.historySummarygroupBox.Controls.Add(this.label8);
			this.historySummarygroupBox.Controls.Add(this.chart2);
			this.historySummarygroupBox.Location = new System.Drawing.Point(7, 278);
			this.historySummarygroupBox.Name = "historySummarygroupBox";
			this.historySummarygroupBox.Size = new System.Drawing.Size(795, 503);
			this.historySummarygroupBox.TabIndex = 1;
			this.historySummarygroupBox.TabStop = false;
			this.historySummarygroupBox.Text = "统计结果";
			// 
			// chart2
			// 
			chartArea2.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea2);
			legend2.Enabled = false;
			legend2.Name = "Legend1";
			this.chart2.Legends.Add(legend2);
			this.chart2.Location = new System.Drawing.Point(38, 32);
			this.chart2.Name = "chart2";
			this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			series2.Legend = "Legend1";
			series2.Name = "Series1";
			series2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
			dataPoint2.IsValueShownAsLabel = true;
			series2.Points.Add(dataPoint2);
			this.chart2.Series.Add(series2);
			this.chart2.Size = new System.Drawing.Size(719, 416);
			this.chart2.TabIndex = 1;
			this.chart2.Text = "chart2";
			// 
			// historyOptiongroupBox
			// 
			this.historyOptiongroupBox.Controls.Add(this.label13);
			this.historyOptiongroupBox.Controls.Add(this.label4);
			this.historyOptiongroupBox.Controls.Add(this.button4);
			this.historyOptiongroupBox.Controls.Add(this.button3);
			this.historyOptiongroupBox.Controls.Add(this.button2);
			this.historyOptiongroupBox.Controls.Add(this.button1);
			this.historyOptiongroupBox.Controls.Add(this.statusBox);
			this.historyOptiongroupBox.Controls.Add(this.typeBox);
			this.historyOptiongroupBox.Controls.Add(this.callArea);
			this.historyOptiongroupBox.Controls.Add(this.date_end);
			this.historyOptiongroupBox.Controls.Add(this.date_start);
			this.historyOptiongroupBox.Controls.Add(this.label6);
			this.historyOptiongroupBox.Controls.Add(this.label5);
			this.historyOptiongroupBox.Controls.Add(this.label3);
			this.historyOptiongroupBox.Controls.Add(this.label2);
			this.historyOptiongroupBox.Controls.Add(this.label1);
			this.historyOptiongroupBox.Location = new System.Drawing.Point(3, 6);
			this.historyOptiongroupBox.Name = "historyOptiongroupBox";
			this.historyOptiongroupBox.Size = new System.Drawing.Size(350, 712);
			this.historyOptiongroupBox.TabIndex = 1;
			this.historyOptiongroupBox.TabStop = false;
			this.historyOptiongroupBox.Text = "查询选项";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(131, 225);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(17, 12);
			this.label13.TabIndex = 17;
			this.label13.Text = "无";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(41, 225);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 16;
			this.label4.Text = "员工信息";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(173, 579);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 15;
			this.button4.Text = "打印";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(173, 524);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 14;
			this.button3.Text = "清除数据";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(173, 472);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 13;
			this.button2.Text = "导出";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(173, 420);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "确定";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// statusBox
			// 
			this.statusBox.FormattingEnabled = true;
			this.statusBox.Items.AddRange(new object[] {
            "所有",
            "等待",
            "完成",
            "超时"});
			this.statusBox.Location = new System.Drawing.Point(133, 339);
			this.statusBox.Name = "statusBox";
			this.statusBox.Size = new System.Drawing.Size(200, 20);
			this.statusBox.TabIndex = 11;
			// 
			// typeBox
			// 
			this.typeBox.AutoCompleteCustomSource.AddRange(new string[] {
            "所有",
            "Cannel",
            "Order",
            "Call",
            "CheckOut",
            "ChangeMedication",
            "Emergency Call",
            "PulingNeedle",
            "Need Service",
            "Want to pay",
            "Need Nurses",
            "Satisfied",
            "Dissatisfied",
            "Low Power",
            "Tamper"});
			this.typeBox.FormattingEnabled = true;
			this.typeBox.Items.AddRange(new object[] {
            "所有",
            "Cannel",
            "Order",
            "Call",
            "CheckOut",
            "ChangeMedication",
            "Emergency Call",
            "PulingNeedle",
            "Need Service",
            "Need Water",
            "Want to pay",
            "Need Nurses",
            "Satisfied",
            "Dissatisfied",
            "Low Power",
            "Tamper"});
			this.typeBox.Location = new System.Drawing.Point(133, 275);
			this.typeBox.Name = "typeBox";
			this.typeBox.Size = new System.Drawing.Size(200, 20);
			this.typeBox.TabIndex = 10;
			// 
			// callArea
			// 
			this.callArea.FormattingEnabled = true;
			this.callArea.Location = new System.Drawing.Point(133, 165);
			this.callArea.Name = "callArea";
			this.callArea.Size = new System.Drawing.Size(200, 20);
			this.callArea.TabIndex = 8;
			this.callArea.SelectedIndexChanged += new System.EventHandler(this.callArea_SelectedIndexChanged);
			// 
			// date_end
			// 
			this.date_end.Location = new System.Drawing.Point(133, 100);
			this.date_end.Name = "date_end";
			this.date_end.Size = new System.Drawing.Size(200, 21);
			this.date_end.TabIndex = 7;
			// 
			// date_start
			// 
			this.date_start.Location = new System.Drawing.Point(133, 45);
			this.date_start.Name = "date_start";
			this.date_start.Size = new System.Drawing.Size(200, 21);
			this.date_start.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(41, 342);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 12);
			this.label6.TabIndex = 5;
			this.label6.Text = "服务状态";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(41, 278);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 4;
			this.label5.Text = "服务类型";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(41, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "呼叫区域";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(41, 109);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "结束时间";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(41, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "开始时间";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(809, 34);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(357, 747);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.historyOptiongroupBox);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(349, 721);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "区域查询";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(349, 721);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "员工查询";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Controls.Add(this.button7);
			this.groupBox1.Controls.Add(this.button8);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.worker);
			this.groupBox1.Controls.Add(this.dateTimePicker1);
			this.groupBox1.Controls.Add(this.dateTimePicker2);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Location = new System.Drawing.Point(0, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(343, 709);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "查询选项";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(41, 198);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(53, 12);
			this.label14.TabIndex = 16;
			this.label14.Text = "对应区域";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(173, 579);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 15;
			this.button5.Text = "打印";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(173, 524);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 14;
			this.button6.Text = "清除数据";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(173, 472);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 13;
			this.button7.Text = "导出";
			this.button7.UseVisualStyleBackColor = true;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(173, 420);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 23);
			this.button8.TabIndex = 12;
			this.button8.Text = "确定";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "所有",
            "等待",
            "完成",
            "超时"});
			this.comboBox1.Location = new System.Drawing.Point(133, 268);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(200, 20);
			this.comboBox1.TabIndex = 11;
			// 
			// worker
			// 
			this.worker.FormattingEnabled = true;
			this.worker.Location = new System.Drawing.Point(133, 162);
			this.worker.Name = "worker";
			this.worker.Size = new System.Drawing.Size(200, 20);
			this.worker.TabIndex = 9;
			this.worker.SelectedIndexChanged += new System.EventHandler(this.worker_SelectedIndexChanged);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(133, 100);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
			this.dateTimePicker1.TabIndex = 7;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(133, 45);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(200, 21);
			this.dateTimePicker2.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(41, 271);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 12);
			this.label7.TabIndex = 5;
			this.label7.Text = "服务状态";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(148, 198);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(17, 12);
			this.label9.TabIndex = 3;
			this.label9.Text = "无";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(41, 165);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(41, 12);
			this.label10.TabIndex = 2;
			this.label10.Text = "员工号";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(41, 109);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(53, 12);
			this.label11.TabIndex = 1;
			this.label11.Text = "结束时间";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(41, 51);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(53, 12);
			this.label12.TabIndex = 0;
			this.label12.Text = "开始时间";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(51, 422);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(41, 12);
			this.label8.TabIndex = 2;
			this.label8.Text = "总计：";
			// 
			// total
			// 
			this.total.AutoSize = true;
			this.total.Location = new System.Drawing.Point(85, 422);
			this.total.Name = "total";
			this.total.Size = new System.Drawing.Size(47, 12);
			this.total.TabIndex = 3;
			this.total.Text = "label15";
			// 
			// callHistoriesSummaryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1170, 784);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.historySummarygroupBox);
			this.Controls.Add(this.historyRecordsgroupBox);
			this.Name = "callHistoriesSummaryForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "查询呼叫历史记录";
			this.Load += new System.EventHandler(this.callHistoriesSummaryForm_Load);
			this.historyRecordsgroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.historyRecordsdataGridView)).EndInit();
			this.historySummarygroupBox.ResumeLayout(false);
			this.historySummarygroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
			this.historyOptiongroupBox.ResumeLayout(false);
			this.historyOptiongroupBox.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox historyRecordsgroupBox;
		private System.Windows.Forms.DataGridView historyRecordsdataGridView;
		private System.Windows.Forms.GroupBox historySummarygroupBox;
		private System.Windows.Forms.GroupBox historyOptiongroupBox;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox statusBox;
		private System.Windows.Forms.ComboBox typeBox;
		private System.Windows.Forms.ComboBox callArea;
		private System.Windows.Forms.DateTimePicker date_end;
		private System.Windows.Forms.DateTimePicker date_start;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox worker;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.Label total;
		private System.Windows.Forms.Label label8;
	}
}