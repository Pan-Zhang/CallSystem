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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(callHistoriesSummaryForm));
			this.historyRecordsgroupBox = new System.Windows.Forms.GroupBox();
			this.historyRecordsdataGridView = new System.Windows.Forms.DataGridView();
			this.historySummarygroupBox = new System.Windows.Forms.GroupBox();
			this.total = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.historyOptiongroupBox = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
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
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			resources.ApplyResources(this.historyRecordsgroupBox, "historyRecordsgroupBox");
			this.historyRecordsgroupBox.Name = "historyRecordsgroupBox";
			this.historyRecordsgroupBox.TabStop = false;
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
			resources.ApplyResources(this.historyRecordsdataGridView, "historyRecordsdataGridView");
			this.historyRecordsdataGridView.Name = "historyRecordsdataGridView";
			this.historyRecordsdataGridView.RowTemplate.Height = 23;
			// 
			// historySummarygroupBox
			// 
			this.historySummarygroupBox.CausesValidation = false;
			this.historySummarygroupBox.Controls.Add(this.total);
			this.historySummarygroupBox.Controls.Add(this.label8);
			this.historySummarygroupBox.Controls.Add(this.chart2);
			resources.ApplyResources(this.historySummarygroupBox, "historySummarygroupBox");
			this.historySummarygroupBox.Name = "historySummarygroupBox";
			this.historySummarygroupBox.TabStop = false;
			// 
			// total
			// 
			resources.ApplyResources(this.total, "total");
			this.total.Name = "total";
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// chart2
			// 
			chartArea1.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea1);
			legend1.Enabled = false;
			legend1.Name = "Legend1";
			this.chart2.Legends.Add(legend1);
			resources.ApplyResources(this.chart2, "chart2");
			this.chart2.Name = "chart2";
			this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
			dataPoint1.IsValueShownAsLabel = true;
			series1.Points.Add(dataPoint1);
			this.chart2.Series.Add(series1);
			// 
			// historyOptiongroupBox
			// 
			this.historyOptiongroupBox.Controls.Add(this.label13);
			this.historyOptiongroupBox.Controls.Add(this.label4);
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
			resources.ApplyResources(this.historyOptiongroupBox, "historyOptiongroupBox");
			this.historyOptiongroupBox.Name = "historyOptiongroupBox";
			this.historyOptiongroupBox.TabStop = false;
			// 
			// label13
			// 
			resources.ApplyResources(this.label13, "label13");
			this.label13.Name = "label13";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// button2
			// 
			resources.ApplyResources(this.button2, "button2");
			this.button2.Name = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// statusBox
			// 
			this.statusBox.FormattingEnabled = true;
			this.statusBox.Items.AddRange(new object[] {
            resources.GetString("statusBox.Items"),
            resources.GetString("statusBox.Items1"),
            resources.GetString("statusBox.Items2"),
            resources.GetString("statusBox.Items3")});
			resources.ApplyResources(this.statusBox, "statusBox");
			this.statusBox.Name = "statusBox";
			// 
			// typeBox
			// 
			this.typeBox.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("typeBox.AutoCompleteCustomSource"),
            resources.GetString("typeBox.AutoCompleteCustomSource1"),
            resources.GetString("typeBox.AutoCompleteCustomSource2"),
            resources.GetString("typeBox.AutoCompleteCustomSource3"),
            resources.GetString("typeBox.AutoCompleteCustomSource4"),
            resources.GetString("typeBox.AutoCompleteCustomSource5"),
            resources.GetString("typeBox.AutoCompleteCustomSource6"),
            resources.GetString("typeBox.AutoCompleteCustomSource7"),
            resources.GetString("typeBox.AutoCompleteCustomSource8"),
            resources.GetString("typeBox.AutoCompleteCustomSource9"),
            resources.GetString("typeBox.AutoCompleteCustomSource10"),
            resources.GetString("typeBox.AutoCompleteCustomSource11"),
            resources.GetString("typeBox.AutoCompleteCustomSource12"),
            resources.GetString("typeBox.AutoCompleteCustomSource13"),
            resources.GetString("typeBox.AutoCompleteCustomSource14")});
			this.typeBox.FormattingEnabled = true;
			this.typeBox.Items.AddRange(new object[] {
            resources.GetString("typeBox.Items"),
            resources.GetString("typeBox.Items1"),
            resources.GetString("typeBox.Items2"),
            resources.GetString("typeBox.Items3"),
            resources.GetString("typeBox.Items4"),
            resources.GetString("typeBox.Items5"),
            resources.GetString("typeBox.Items6"),
            resources.GetString("typeBox.Items7"),
            resources.GetString("typeBox.Items8"),
            resources.GetString("typeBox.Items9"),
            resources.GetString("typeBox.Items10"),
            resources.GetString("typeBox.Items11"),
            resources.GetString("typeBox.Items12"),
            resources.GetString("typeBox.Items13"),
            resources.GetString("typeBox.Items14"),
            resources.GetString("typeBox.Items15")});
			resources.ApplyResources(this.typeBox, "typeBox");
			this.typeBox.Name = "typeBox";
			// 
			// callArea
			// 
			this.callArea.FormattingEnabled = true;
			resources.ApplyResources(this.callArea, "callArea");
			this.callArea.Name = "callArea";
			this.callArea.SelectedIndexChanged += new System.EventHandler(this.callArea_SelectedIndexChanged);
			// 
			// date_end
			// 
			resources.ApplyResources(this.date_end, "date_end");
			this.date_end.Name = "date_end";
			// 
			// date_start
			// 
			resources.ApplyResources(this.date_start, "date_start");
			this.date_start.Name = "date_start";
			// 
			// label6
			// 
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.historyOptiongroupBox);
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox1);
			resources.ApplyResources(this.tabPage2, "tabPage2");
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label14);
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
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// label14
			// 
			resources.ApplyResources(this.label14, "label14");
			this.label14.Name = "label14";
			// 
			// button7
			// 
			resources.ApplyResources(this.button7, "button7");
			this.button7.Name = "button7";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			resources.ApplyResources(this.button8, "button8");
			this.button8.Name = "button8";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2"),
            resources.GetString("comboBox1.Items3")});
			resources.ApplyResources(this.comboBox1, "comboBox1");
			this.comboBox1.Name = "comboBox1";
			// 
			// worker
			// 
			this.worker.FormattingEnabled = true;
			resources.ApplyResources(this.worker, "worker");
			this.worker.Name = "worker";
			this.worker.SelectedIndexChanged += new System.EventHandler(this.worker_SelectedIndexChanged);
			// 
			// dateTimePicker1
			// 
			resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
			this.dateTimePicker1.Name = "dateTimePicker1";
			// 
			// dateTimePicker2
			// 
			resources.ApplyResources(this.dateTimePicker2, "dateTimePicker2");
			this.dateTimePicker2.Name = "dateTimePicker2";
			// 
			// label7
			// 
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			// 
			// label10
			// 
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			// 
			// label11
			// 
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			// 
			// label12
			// 
			resources.ApplyResources(this.label12, "label12");
			this.label12.Name = "label12";
			// 
			// id
			// 
			this.id.DataPropertyName = "Id";
			resources.ApplyResources(this.id, "id");
			this.id.Name = "id";
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "time";
			resources.ApplyResources(this.Column2, "Column2");
			this.Column2.Name = "Column2";
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "callerNum";
			resources.ApplyResources(this.Column1, "Column1");
			this.Column1.Name = "Column1";
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "employeeNum";
			resources.ApplyResources(this.Column3, "Column3");
			this.Column3.Name = "Column3";
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "type";
			resources.ApplyResources(this.Column4, "Column4");
			this.Column4.Name = "Column4";
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "status";
			resources.ApplyResources(this.Column5, "Column5");
			this.Column5.Name = "Column5";
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "isRFID";
			resources.ApplyResources(this.Column6, "Column6");
			this.Column6.Name = "Column6";
			// 
			// callHistoriesSummaryForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.historySummarygroupBox);
			this.Controls.Add(this.historyRecordsgroupBox);
			this.Name = "callHistoriesSummaryForm";
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
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox1;
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
		private System.Windows.Forms.Label total;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
	}
}