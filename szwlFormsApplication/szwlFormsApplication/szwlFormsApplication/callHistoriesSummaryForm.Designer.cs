﻿namespace szwlFormsApplication
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.historyRecordsgroupBox = new System.Windows.Forms.GroupBox();
			this.historySummarygroupBox = new System.Windows.Forms.GroupBox();
			this.historyOptiongroupBox = new System.Windows.Forms.GroupBox();
			this.historyRecordsdataGridView = new System.Windows.Forms.DataGridView();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.historyRecordsgroupBox.SuspendLayout();
			this.historySummarygroupBox.SuspendLayout();
			this.historyOptiongroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.historyRecordsdataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
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
			// historySummarygroupBox
			// 
			this.historySummarygroupBox.Controls.Add(this.chart2);
			this.historySummarygroupBox.Controls.Add(this.chart1);
			this.historySummarygroupBox.Location = new System.Drawing.Point(7, 278);
			this.historySummarygroupBox.Name = "historySummarygroupBox";
			this.historySummarygroupBox.Size = new System.Drawing.Size(795, 503);
			this.historySummarygroupBox.TabIndex = 1;
			this.historySummarygroupBox.TabStop = false;
			this.historySummarygroupBox.Text = "统计结果";
			// 
			// historyOptiongroupBox
			// 
			this.historyOptiongroupBox.Controls.Add(this.button4);
			this.historyOptiongroupBox.Controls.Add(this.button3);
			this.historyOptiongroupBox.Controls.Add(this.button2);
			this.historyOptiongroupBox.Controls.Add(this.button1);
			this.historyOptiongroupBox.Controls.Add(this.comboBox4);
			this.historyOptiongroupBox.Controls.Add(this.comboBox3);
			this.historyOptiongroupBox.Controls.Add(this.comboBox2);
			this.historyOptiongroupBox.Controls.Add(this.comboBox1);
			this.historyOptiongroupBox.Controls.Add(this.dateTimePicker2);
			this.historyOptiongroupBox.Controls.Add(this.dateTimePicker1);
			this.historyOptiongroupBox.Controls.Add(this.label6);
			this.historyOptiongroupBox.Controls.Add(this.label5);
			this.historyOptiongroupBox.Controls.Add(this.label4);
			this.historyOptiongroupBox.Controls.Add(this.label3);
			this.historyOptiongroupBox.Controls.Add(this.label2);
			this.historyOptiongroupBox.Controls.Add(this.label1);
			this.historyOptiongroupBox.Location = new System.Drawing.Point(808, 13);
			this.historyOptiongroupBox.Name = "historyOptiongroupBox";
			this.historyOptiongroupBox.Size = new System.Drawing.Size(350, 768);
			this.historyOptiongroupBox.TabIndex = 1;
			this.historyOptiongroupBox.TabStop = false;
			this.historyOptiongroupBox.Text = "查询选项";
			// 
			// historyRecordsdataGridView
			// 
			this.historyRecordsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.historyRecordsdataGridView.Location = new System.Drawing.Point(7, 21);
			this.historyRecordsdataGridView.Name = "historyRecordsdataGridView";
			this.historyRecordsdataGridView.RowTemplate.Height = 23;
			this.historyRecordsdataGridView.Size = new System.Drawing.Size(782, 232);
			this.historyRecordsdataGridView.TabIndex = 0;
			// 
			// chart1
			// 
			chartArea3.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea3);
			legend3.Name = "Legend1";
			this.chart1.Legends.Add(legend3);
			this.chart1.Location = new System.Drawing.Point(19, 134);
			this.chart1.Name = "chart1";
			series3.ChartArea = "ChartArea1";
			series3.Legend = "Legend1";
			series3.Name = "Series1";
			this.chart1.Series.Add(series3);
			this.chart1.Size = new System.Drawing.Size(300, 300);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// chart2
			// 
			chartArea4.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea4);
			legend4.Name = "Legend1";
			this.chart2.Legends.Add(legend4);
			this.chart2.Location = new System.Drawing.Point(352, 134);
			this.chart2.Name = "chart2";
			series4.ChartArea = "ChartArea1";
			series4.Legend = "Legend1";
			series4.Name = "Series1";
			this.chart2.Series.Add(series4);
			this.chart2.Size = new System.Drawing.Size(300, 300);
			this.chart2.TabIndex = 1;
			this.chart2.Text = "chart2";
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(41, 109);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "结束时间";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(41, 174);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "呼叫区域";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(41, 232);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 3;
			this.label4.Text = "员工";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(41, 293);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 4;
			this.label5.Text = "服务类型";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(41, 358);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 12);
			this.label6.TabIndex = 5;
			this.label6.Text = "服务状态";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(133, 45);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
			this.dateTimePicker1.TabIndex = 6;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(133, 100);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(200, 21);
			this.dateTimePicker2.TabIndex = 7;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(133, 165);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(200, 20);
			this.comboBox1.TabIndex = 8;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(133, 229);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(200, 20);
			this.comboBox2.TabIndex = 9;
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(133, 285);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(200, 20);
			this.comboBox3.TabIndex = 10;
			// 
			// comboBox4
			// 
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Location = new System.Drawing.Point(133, 350);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(200, 20);
			this.comboBox4.TabIndex = 11;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(173, 420);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "确定";
			this.button1.UseVisualStyleBackColor = true;
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
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(173, 524);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 14;
			this.button3.Text = "清除数据";
			this.button3.UseVisualStyleBackColor = true;
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
			// callHistoriesSummaryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1170, 784);
			this.Controls.Add(this.historyOptiongroupBox);
			this.Controls.Add(this.historySummarygroupBox);
			this.Controls.Add(this.historyRecordsgroupBox);
			this.Name = "callHistoriesSummaryForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "查询呼叫历史记录";
			this.historyRecordsgroupBox.ResumeLayout(false);
			this.historySummarygroupBox.ResumeLayout(false);
			this.historyOptiongroupBox.ResumeLayout(false);
			this.historyOptiongroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.historyRecordsdataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox historyRecordsgroupBox;
		private System.Windows.Forms.DataGridView historyRecordsdataGridView;
		private System.Windows.Forms.GroupBox historySummarygroupBox;
		private System.Windows.Forms.GroupBox historyOptiongroupBox;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}