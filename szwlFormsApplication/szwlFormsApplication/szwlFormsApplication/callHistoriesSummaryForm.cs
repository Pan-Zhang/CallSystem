using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using szwlFormsApplication.CommonFunc;
using szwlFormsApplication.dialog;
using szwlFormsApplication.Language;
using szwlFormsApplication.Models;
using Spire.Xls;
using System.Drawing.Printing;
using System.Configuration;

namespace szwlFormsApplication
{
	public partial class callHistoriesSummaryForm : Form
	{
		DBManager dm;
		List<Callzone> list_zone;
		List<Employee> list_employee;
		List<Caller> list_caller;
		List<DataMessage> list_allmess;
		List<DataMessage> tem_list;
		public callHistoriesSummaryForm()
		{
			InitializeComponent();
			Common.SetTableHeader(historyRecordsdataGridView);
			list_allmess = new List<DataMessage>();
		}

		private void callHistoriesSummaryForm_Load(object sender, EventArgs e)
		{
			changeLanguage();
			dm = new DBManager();
			list_caller = dm.selectCaller();
			initZone();
			initWorker();
			if (Common.isRFID)
			{
				label4.Hide();
				label9.Hide();
				label14.Hide();
				label13.Hide();
				label7.Hide();
				comboBox1.Hide();
			}
			typeBox.SelectedIndex = 0;
			statusBox.SelectedIndex = 0;
			comboBox1.SelectedIndex = 0;
		}

		private void initZone()
		{
			list_zone = dm.selectZone();

			DataTable dt = new DataTable();//创建一个数据集
			dt.Columns.Add("id", typeof(String));
			dt.Columns.Add("val", typeof(String));
			for (int i = 0; i < list_zone.Count + 1; i++)
			{
				DataRow dr = dt.NewRow();
				dr[0] = i;
				if (i == 0)
				{
					dr[1] = GlobalData.GlobalLanguage.all;
				}
				else
				{
					dr[1] = list_zone[i-1].name;
				}
				

				dt.Rows.Add(dr);
			}
			callArea.DataSource = dt;
			callArea.DisplayMember = "val";
			callArea.ValueMember = "id";
		}

		private void initWorker()
		{
			if (Common.isRFID)
			{
				list_employee = dm.selectEmployeeRFID();
			}
			else
			{
				list_employee = dm.selectEmployee();
			}

			DataTable dt = new DataTable();//创建一个数据集
			dt.Columns.Add("id", typeof(String));
			dt.Columns.Add("val", typeof(String));
			for (int i = 0; i < list_employee.Count; i++)
			{
				DataRow dr = dt.NewRow();
				dr[0] = i;
				dr[1] = string.Format(GlobalData.GlobalLanguage.employee_select, list_employee[i].employeeNum, list_employee[i].name);

				dt.Rows.Add(dr);
			}
			worker.DataSource = dt;
			worker.DisplayMember = "val";
			worker.ValueMember = "id";
		}

		private void callArea_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = callArea.SelectedIndex;
			if (index == 0)
			{
				label13.Text = "";
				return;
			}
			Callzone zone = list_zone[index-1];
			label13.Text = GlobalData.GlobalLanguage.nothing;
			foreach (Caller caller in list_caller)
			{
				if (caller.callZone == zone.Id)
				{
					if (caller.employeeNum == -1)
					{
						label13.Text = GlobalData.GlobalLanguage.nothing;
						break;
					}
					Employee tem_emp = null;
					if (list_employee != null)
					{
						foreach (Employee emp in list_employee)
						{
							if (emp.employeeNum == caller.employeeNum)
							{
								tem_emp = emp;
								break;
							}
						}
					}
					if (tem_emp == null)
					{
						label13.Text = caller.employeeNum + GlobalData.GlobalLanguage.number;
					}
					else
					{
						label13.Text = string.Format(GlobalData.GlobalLanguage.employee_select, tem_emp.employeeNum, tem_emp.name);
					}
					break;
				}
			}
		}

		private void worker_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = worker.SelectedIndex;
			Employee emp = list_employee[index];

			foreach (Caller caller in list_caller)
			{
				if (caller.employeeNum == emp.employeeNum)
				{
					Callzone tem_zone = null;
					foreach (Callzone zone in list_zone)
					{
						if (zone.Id == caller.callZone)
						{
							tem_zone = zone;
							break;
						}
					}
					if (tem_zone == null)
					{
						label9.Text = GlobalData.GlobalLanguage.nothing;
					}
					else
					{
						label9.Text = tem_zone.name;
					}
					break;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			tem_list = new List<DataMessage>();
			DateTime start = date_start.Value.Date;//开始时间
			DateTime end = date_end.Value.Date.AddDays(1).AddMilliseconds(-1);//结束时间

			string callerNum = "";
			if (callArea.SelectedIndex == 0)
			{

			}
			else if(callArea.SelectedIndex>0)
			{
				callerNum = "-1";
				Callzone zone = list_zone[callArea.SelectedIndex-1];//区域
																  //查找对应呼叫器编号
				foreach (Caller caller in list_caller)
				{
					if (caller.callZone == zone.Id)
					{
						callerNum = caller.callerNum;
						break;
					}
				}
			}
			
			int _type = typeBox.SelectedIndex;//服务类型

			int _status = statusBox.SelectedIndex; //服务状态

			list_allmess = dm.selectMess(start.ToFileTime());

			if (callerNum.Equals(""))//所有区域
			{
				if(_type == 0 && _status == 0)//所有呼叫记录
				{
					foreach (DataMessage mess in list_allmess)
					{
						try
						{
							if (mess.timeConvert() > start && mess.timeConvert() < end)
							{
								tem_list.Add(mess);
							}
							LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, (tem_list == null ? 0 : tem_list.Count).ToString());
						}
						catch (Exception ex)
						{
							LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
							return;
						}

					}
				}
				else if (_type == 0 && _status != 0)//特定状态的记录
				{
					foreach (DataMessage mess in list_allmess)
					{
						int status = 0;
						switch (mess.status)
						{
							case STATUS.WAITING:
								status = 1;
								break;

							case STATUS.FINISH:
								status = 2;
								break;

							case STATUS.OVERTIME:
								status = 3;
								break;
						}

						if (mess.timeConvert() > start && mess.timeConvert() < end && _status == status)
						{
							tem_list.Add(mess);
						}
					}
				}
				else if(_type != 0 && _status == 0)//特定类型的记录
				{
					foreach (DataMessage message in list_allmess)
					{
						int type = 0;
						switch (message.type)
						{
							case Models.Type.CANCEL:
								type = 0;
								break;

							case Models.Type.ORDER:
								type = 1;
								break;

							case Models.Type.CALL:
								type = 2;
								break;

							case Models.Type.CHECK_OUT:
								type = 3;
								break;

							case Models.Type.CHANGE_MEDICATION:
								type = 4;
								break;

							case Models.Type.EMERGENCY_CALL:
								type = 5;
								break;

							case Models.Type.PULING_NEEDLE:
								type = 6;
								break;

							case Models.Type.NEED_SERVICE:
								type = 7;
								break;

							case Models.Type.NEED_WATER:
								type = 8;
								break;

							case Models.Type.WANT_TO_PAY:
								type = 9;
								break;

							case Models.Type.NEED_NURSES:
								type = 10;
								break;

							case Models.Type.SATISFIED:
								type = 11;
								break;

							case Models.Type.DISSATISFIED:
								type = 12;
								break;

							case Models.Type.LOW_POWER:
								type = 13;
								break;

							case Models.Type.TAMPER:
								type = 14;
								break;
						}
						if (message.timeConvert() > start && message.timeConvert() < end && type == (_type - 1))
						{
							tem_list.Add(message);
						}
					}
				}
				else//特定状态特定类型的记录
				{
					foreach (DataMessage message in list_allmess)
					{
						int status = 0;
						switch (message.status)
						{
							case STATUS.WAITING:
								status = 1;
								break;

							case STATUS.FINISH:
								status = 2;
								break;

							case STATUS.OVERTIME:
								status = 3;
								break;
						}

						int type = 0;
						switch (message.type)
						{
							case Models.Type.CANCEL:
								type = 0;
								break;

							case Models.Type.ORDER:
								type = 1;
								break;

							case Models.Type.CALL:
								type = 2;
								break;

							case Models.Type.CHECK_OUT:
								type = 3;
								break;

							case Models.Type.CHANGE_MEDICATION:
								type = 4;
								break;

							case Models.Type.EMERGENCY_CALL:
								type = 5;
								break;

							case Models.Type.PULING_NEEDLE:
								type = 6;
								break;

							case Models.Type.NEED_SERVICE:
								type = 7;
								break;

							case Models.Type.NEED_WATER:
								type = 8;
								break;

							case Models.Type.WANT_TO_PAY:
								type = 9;
								break;

							case Models.Type.NEED_NURSES:
								type = 10;
								break;

							case Models.Type.SATISFIED:
								type = 11;
								break;

							case Models.Type.DISSATISFIED:
								type = 12;
								break;

							case Models.Type.LOW_POWER:
								type = 13;
								break;

							case Models.Type.TAMPER:
								type = 14;
								break;
						}
						if (message.timeConvert() > start && message.timeConvert() < end && type == (_type - 1) && status == _status)
						{
							tem_list.Add(message);
						}
					}
				}
			}
			else if (_type == 0 && _status == 0)//某区域所有呼叫记录
			{
				foreach (DataMessage mess in list_allmess)
				{
					try
					{
						if (mess.timeConvert() > start && mess.timeConvert() < end && mess.callerNum == callerNum)
						{
							tem_list.Add(mess);
						}
						LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error,(tem_list == null ? 0 : tem_list.Count).ToString());
					}
					catch(Exception ex)
					{
						LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error,ex.ToString());
						return;
					}
				}
			}
			else if (_type == 0 && _status != 0)//某区域特定状态的所有记录
			{
				foreach (DataMessage mess in list_allmess)
				{
					int status = 0;
					switch (mess.status)
					{
						case STATUS.WAITING:
							status = 1;
							break;

						case STATUS.FINISH:
							status = 2;
							break;

						case STATUS.OVERTIME:
							status = 3;
							break;
					}

					if (mess.timeConvert() > start && mess.timeConvert() < end && mess.callerNum == callerNum && _status == status)
					{
						tem_list.Add(mess);
					}
				}
			}
			else if (_type != 0 && _status == 0)//某区域特定类型的所有记录
			{
				foreach (DataMessage message in list_allmess)
				{
					int type = 0;
					switch (message.type)
					{
						case Models.Type.CANCEL:
							type = 0;
							break;

						case Models.Type.ORDER:
							type = 1;
							break;

						case Models.Type.CALL:
							type = 2;
							break;

						case Models.Type.CHECK_OUT:
							type = 3;
							break;

						case Models.Type.CHANGE_MEDICATION:
							type = 4;
							break;

						case Models.Type.EMERGENCY_CALL:
							type = 5;
							break;

						case Models.Type.PULING_NEEDLE:
							type = 6;
							break;

						case Models.Type.NEED_SERVICE:
							type = 7;
							break;

						case Models.Type.NEED_WATER:
							type = 8;
							break;

						case Models.Type.WANT_TO_PAY:
							type = 9;
							break;

						case Models.Type.NEED_NURSES:
							type = 10;
							break;

						case Models.Type.SATISFIED:
							type = 11;
							break;

						case Models.Type.DISSATISFIED:
							type = 12;
							break;

						case Models.Type.LOW_POWER:
							type = 13;
							break;

						case Models.Type.TAMPER:
							type = 14;
							break;
					}
					if (message.timeConvert() > start && message.timeConvert() < end && message.callerNum.Equals(callerNum) && type == (_type - 1))
					{
						tem_list.Add(message);
					}
				}
			}
			else//某区域特定类型及特定状态的所有记录
			{
				foreach (DataMessage message in list_allmess)
				{
					int status = 0;
					switch (message.status)
					{
						case STATUS.WAITING:
							status = 1;
							break;

						case STATUS.FINISH:
							status = 2;
							break;

						case STATUS.OVERTIME:
							status = 3;
							break;
					}

					int type = 0;
					switch (message.type)
					{
						case Models.Type.CANCEL:
							type = 0;
							break;

						case Models.Type.ORDER:
							type = 1;
							break;

						case Models.Type.CALL:
							type = 2;
							break;

						case Models.Type.CHECK_OUT:
							type = 3;
							break;

						case Models.Type.CHANGE_MEDICATION:
							type = 4;
							break;

						case Models.Type.EMERGENCY_CALL:
							type = 5;
							break;

						case Models.Type.PULING_NEEDLE:
							type = 6;
							break;

						case Models.Type.NEED_SERVICE:
							type = 7;
							break;

						case Models.Type.NEED_WATER:
							type = 8;
							break;

						case Models.Type.WANT_TO_PAY:
							type = 9;
							break;

						case Models.Type.NEED_NURSES:
							type = 10;
							break;

						case Models.Type.SATISFIED:
							type = 11;
							break;

						case Models.Type.DISSATISFIED:
							type = 12;
							break;

						case Models.Type.LOW_POWER:
							type = 13;
							break;

						case Models.Type.TAMPER:
							type = 14;
							break;
					}
					if (message.timeConvert() > start && message.timeConvert() < end && message.callerNum.Equals(callerNum) && type == (_type - 1) && status == _status)
					{
						tem_list.Add(message);
					}
				}
			}
			makeChart();
			this.historyRecordsdataGridView.AutoGenerateColumns = false;
			this.historyRecordsdataGridView.DataSource = tem_list;
			this.historyRecordsdataGridView.Refresh();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			tem_list = new List<DataMessage>();
			DateTime start = dateTimePicker2.Value.Date;//开始时间
			DateTime end = dateTimePicker1.Value.Date.AddDays(1).AddMilliseconds(-1);//结束时间

			if (worker.SelectedIndex == -1)
			{
				return;
			}
			Employee employ = list_employee[worker.SelectedIndex];
			list_allmess = dm.selectMess(start.ToFileTime());
			if (Common.isRFID)
			{
				foreach (DataMessage message in list_allmess)
				{
					if (message.timeConvert() > start && message.timeConvert() < end && message.employeeNum == employ.employeeNum)
					{
						tem_list.Add(message);
					}
				}
				makeChartRFID();
			}
			else
			{
				string callerNum = "";
				foreach (Caller caller in list_caller)
				{
					if (caller.employeeNum == employ.employeeNum)
					{
						callerNum = caller.callerNum;
						break;
					}
				}

				int _status = comboBox1.SelectedIndex;

				if (_status == 0)
				{
					foreach (DataMessage message in list_allmess)
					{
						if (message.timeConvert() > start && message.timeConvert() < end && message.callerNum.Equals(callerNum))
						{
							tem_list.Add(message);
						}
					}
				}
				else
				{
					foreach (DataMessage message in list_allmess)
					{
						int status = 0;
						switch (message.status)
						{
							case STATUS.WAITING:
								status = 1;
								break;

							case STATUS.FINISH:
								status = 2;
								break;

							case STATUS.OVERTIME:
								status = 3;
								break;
						}
						if (message.timeConvert() > start && message.timeConvert() < end && message.callerNum.Equals(callerNum) && status == _status)
						{
							tem_list.Add(message);
						}
					}
				}
				makeChart();
			}

			this.historyRecordsdataGridView.AutoGenerateColumns = false;
			this.historyRecordsdataGridView.DataSource = tem_list;
			this.historyRecordsdataGridView.Refresh();
		}

		private void makeChart()
		{
			int finish = 0;
			int timeover = 0;
			int unsatisfy = 0;
			int satisfy = 0;
			int waiting = 0;
			foreach (DataMessage mess in tem_list)//生成图表
			{
				if (mess.status == STATUS.FINISH && mess.type!=Models.Type.SATISFIED && mess.type!=Models.Type.DISSATISFIED)
				{
					finish++;
				}
				if (mess.status == STATUS.OVERTIME)
				{
					timeover++;
				}
				if (mess.type == Models.Type.DISSATISFIED)
				{
					unsatisfy++;
				}
				if (mess.type == Models.Type.SATISFIED)
				{
					satisfy++;
				}
				if(mess.status == STATUS.WAITING)
				{
					waiting++;
				}
			}
			
			List<int> yData = new List<int>();
			List<string> xData = new List<string>();
			if (finish > 0)
			{
				yData.Add(finish);
				xData.Add(GlobalData.GlobalLanguage.finish + "(" + finish + ")");
			}
			if (timeover > 0)
			{
				yData.Add(timeover);
				xData.Add(GlobalData.GlobalLanguage.overtime + "(" + timeover + ")");
			}
			if (unsatisfy > 0)
			{
				yData.Add(unsatisfy);
				xData.Add(GlobalData.GlobalLanguage.unsatisfy + "(" + unsatisfy + ")");
			}
			if (satisfy > 0)
			{
				yData.Add(satisfy);
				xData.Add(GlobalData.GlobalLanguage.satisfy + "(" + satisfy + ")");
			}
			if (waiting > 0)
			{
				yData.Add(waiting);
				xData.Add(GlobalData.GlobalLanguage.waiting + "(" + waiting + ")");
			}
			chart2.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
			chart2.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
			chart2.Series[0].Points.DataBindXY(xData, yData);

			total.Text = tem_list.Count + GlobalData.GlobalLanguage.records;
		}

		private void makeChartRFID()
		{
			Dictionary<string, int> dic = new Dictionary<string, int>();

			foreach (DataMessage mess in tem_list)
			{
				if (dic.ContainsKey(mess.callerNum))
				{
					int value = dic[mess.callerNum] + 1;
					dic[mess.callerNum] = value;
				}
				else
				{
					dic.Add(mess.callerNum, 1);
				}
			}
			List<int> yData = new List<int>();
			List<string> xData = new List<string>();
			foreach (KeyValuePair<string, int> kvp in dic)
			{
				yData.Add(kvp.Value);
				string name = "";
				foreach(Caller caller in list_caller)
				{
					if (caller.callerNum == kvp.Key)
					{
						foreach(Callzone zone in list_zone)
						{
							if(zone.Id== caller.callZone)
							{
								name = zone.name;
								break;
							}
						}
						break;
					}
				}
				xData.Add(name+"("+kvp.Value+")");
			}
			chart2.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
			chart2.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
			chart2.Series[0].Points.DataBindXY(xData, yData);

			total.Text = tem_list.Count + GlobalData.GlobalLanguage.time;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MakeExcel();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			MakeExcel();
		}

		private void MakeExcel()
		{
			if(tem_list==null || tem_list.Count == 0)
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.record_null, GlobalData.GlobalLanguage.prompt, MessageBoxButtons.OK);
			}
			else
			{
				FolderBrowserDialog FDialog = new FolderBrowserDialog();
				FDialog.Description = GlobalData.GlobalLanguage.choose_file;
				if (FDialog.ShowDialog() == DialogResult.OK)
				{
					string foldPath = FDialog.SelectedPath;
					string path = "";
					ExcelFile.makeExcel(tem_list, foldPath, out path);
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.save_path + path, GlobalData.GlobalLanguage.export_succ, MessageBoxButtons.OK);
				}
			}
		}

		public void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.summary_setting;

			historySummarygroupBox.Text = GlobalData.GlobalLanguage.summary_result;
			label8.Text = GlobalData.GlobalLanguage.total;
			historyRecordsgroupBox.Text = GlobalData.GlobalLanguage.sreach_result;

			tabControl1.TabPages[0].Text = GlobalData.GlobalLanguage.zone_search;
			tabControl1.TabPages[1].Text = GlobalData.GlobalLanguage.employee_search;
			tabControl1.TabPages[2].Text = GlobalData.GlobalLanguage.Summary_statistics;
			historyOptiongroupBox.Text = GlobalData.GlobalLanguage.option;
			groupBox1.Text = GlobalData.GlobalLanguage.option;
			label1.Text = GlobalData.GlobalLanguage.start;
			label2.Text = GlobalData.GlobalLanguage.end;
			label3.Text = GlobalData.GlobalLanguage.zone;
			label4.Text = GlobalData.GlobalLanguage.employee;
			label5.Text = GlobalData.GlobalLanguage.type;
			label6.Text = GlobalData.GlobalLanguage.status;

			button1.Text = GlobalData.GlobalLanguage.ensure;
			button2.Text = GlobalData.GlobalLanguage.export;

			label12.Text = GlobalData.GlobalLanguage.start;
			label11.Text = GlobalData.GlobalLanguage.end;
			label10.Text = GlobalData.GlobalLanguage.employee;
			label14.Text = GlobalData.GlobalLanguage.zone;
			label7.Text = GlobalData.GlobalLanguage.status;
			button8.Text = GlobalData.GlobalLanguage.ensure;
			button7.Text = GlobalData.GlobalLanguage.export;

			label15.Text = GlobalData.GlobalLanguage.start;
			label16.Text = GlobalData.GlobalLanguage.end;
			radioButton1.Text = GlobalData.GlobalLanguage.satisfied_rank;
			radioButton2.Text = GlobalData.GlobalLanguage.dissatisfied_rank;
			radioButton3.Text = GlobalData.GlobalLanguage.finish_rank;
			radioButton4.Text = GlobalData.GlobalLanguage.unfinish_rank;
			radioButton5.Text = GlobalData.GlobalLanguage.overtime_rank;
			radioButton6.Text = GlobalData.GlobalLanguage.overtime_total;
			radioButton7.Text = GlobalData.GlobalLanguage.satisfied_totla;
			radioButton8.Text = GlobalData.GlobalLanguage.dissatisfied_total;

			button3.Text = GlobalData.GlobalLanguage.ensure;
			button6.Text = GlobalData.GlobalLanguage.print;
			button9.Text = GlobalData.GlobalLanguage.print;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			tem_list = new List<DataMessage>();
			DateTime start = dateTimePicker3.Value.Date;//开始时间
			DateTime end = dateTimePicker4.Value.Date.AddDays(1).AddMilliseconds(-1);//结束时间
			list_allmess = dm.selectMess(start.ToFileTime());
			Dictionary<string, int> dic = new Dictionary<string, int>();
			if (radioButton1.Checked)//满意次数排名
			{
				foreach(DataMessage mess in list_allmess)
				{
					if(mess.type == Models.Type.SATISFIED)
					{
						if (dic.ContainsKey(mess.callerNum))
						{
							int value;
							dic.TryGetValue(mess.callerNum, out value);
							value++;
							dic[mess.callerNum] = value;
						}
						else
						{
							dic.Add(mess.callerNum, 1);
						}
					}
				}
				summary(dic, GlobalData.GlobalLanguage.satisfied_rank);
			}
			if (radioButton2.Checked)//不满意次数排名
			{
				foreach (DataMessage mess in list_allmess)
				{
					if (mess.type == Models.Type.DISSATISFIED)
					{
						if (dic.ContainsKey(mess.callerNum))
						{
							int value;
							dic.TryGetValue(mess.callerNum, out value);
							value++;
							dic[mess.callerNum] = value;
						}
						else
						{
							dic.Add(mess.callerNum, 1);
						}
					}
				}
				summary(dic, GlobalData.GlobalLanguage.dissatisfied_rank);
			}
			if (radioButton3.Checked)//完成次数排名
			{
				foreach (DataMessage mess in list_allmess)
				{
					if (mess.status == STATUS.FINISH)
					{
						if (dic.ContainsKey(mess.callerNum))
						{
							int value;
							dic.TryGetValue(mess.callerNum, out value);
							value++;
							dic[mess.callerNum] = value;
						}
						else
						{
							dic.Add(mess.callerNum, 1);
						}
					}
				}
				summary(dic, GlobalData.GlobalLanguage.finish_rank);
			}
			if (radioButton4.Checked)//未完成次数排名
			{
				foreach (DataMessage mess in list_allmess)
				{
					if (mess.status == STATUS.WAITING)
					{
						if (dic.ContainsKey(mess.callerNum))
						{
							int value;
							dic.TryGetValue(mess.callerNum, out value);
							value++;
							dic[mess.callerNum] = value;
						}
						else
						{
							dic.Add(mess.callerNum, 1);
						}
					}
				}

				summary(dic, GlobalData.GlobalLanguage.unfinish_rank);
			}
			if (radioButton5.Checked)//超时次数排名
			{
				foreach (DataMessage mess in list_allmess)
				{
					if (mess.status == STATUS.OVERTIME)
					{
						if (dic.ContainsKey(mess.callerNum))
						{
							int value;
							dic.TryGetValue(mess.callerNum, out value);
							value++;
							dic[mess.callerNum] = value;
						}
						else
						{
							dic.Add(mess.callerNum, 1);
						}
					}
				}
				summary(dic, GlobalData.GlobalLanguage.overtime_rank);
			}
			if (radioButton6.Checked)//超时与总次数占比排名
			{
				Dictionary<string, Summary> dictionary = new Dictionary<string, Summary>();
				foreach (DataMessage mess in list_allmess)
				{
					if (dictionary.ContainsKey(mess.callerNum))
					{
						Summary value = null;
						dictionary.TryGetValue(mess.callerNum, out value);
						value.total++;
						if (mess.status == STATUS.OVERTIME)
						{
							value.count++;
						}
					}
					else
					{
						Summary summary = new Summary();
						summary.callerNum = mess.callerNum;
						foreach(Caller caller in InitData.list_caller)
						{
							if(caller.callerNum == mess.callerNum)
							{
								foreach (Callzone zone in InitData.list_zone)
								{
									if (zone.Id == caller.callZone)
									{
										summary.zoneName = zone.name;
										break;
									}
								}
								if (Common.isRFID)
								{
									foreach (Employee emp in InitData.employeeRFID)
									{
										if (emp.employeeNum == caller.employeeNum)
										{
											summary.employeeNum = emp.employeeNum;
											summary.employeeName = emp.name;
											break;
										}
									}
								}
								else
								{
									foreach (Employee emp in InitData.employees)
									{
										if (emp.employeeNum == caller.employeeNum)
										{
											summary.employeeNum = emp.employeeNum;
											summary.employeeName = emp.name;
											break;
										}
									}
								}
								break;
							}
						}
						if(mess.status == STATUS.OVERTIME)
						{
							summary.count = 1;
						}
						else
						{
							summary.count = 0;
						}
						summary.total = 1;
						dictionary.Add(mess.callerNum, summary);
					}
				}
				Dictionary<string, Summary> dic1_SortedByValue = dictionary.OrderByDescending(o => o.Value.count * 100/o.Value.total).ToDictionary(p => p.Key, o => o.Value);
				List<Summary> list_sum = dic1_SortedByValue.Values.ToList();

				PercentForm form = new PercentForm();
				form.title = GlobalData.GlobalLanguage.overtime_total;
				form.type = 1;
				form.list = list_sum;
				form.ShowDialog();
			}
			if (radioButton7.Checked)//满意与总次数占比排名
			{
				Dictionary<string, Summary> dictionary = new Dictionary<string, Summary>();
				foreach (DataMessage mess in list_allmess)
				{
					if (dictionary.ContainsKey(mess.callerNum))
					{
						Summary value = null;
						dictionary.TryGetValue(mess.callerNum, out value);
						value.total++;
						if (mess.type == Models.Type.SATISFIED)
						{
							value.count++;
						}
					}
					else
					{
						Summary summary = new Summary();
						summary.callerNum = mess.callerNum;
						foreach (Caller caller in InitData.list_caller)
						{
							if (caller.callerNum == mess.callerNum)
							{
								foreach (Callzone zone in InitData.list_zone)
								{
									if (zone.Id == caller.callZone)
									{
										summary.zoneName = zone.name;
										break;
									}
								}
								if (Common.isRFID)
								{
									foreach (Employee emp in InitData.employeeRFID)
									{
										if (emp.employeeNum == caller.employeeNum)
										{
											summary.employeeNum = emp.employeeNum;
											summary.employeeName = emp.name;
											break;
										}
									}
								}
								else
								{
									foreach (Employee emp in InitData.employees)
									{
										if (emp.employeeNum == caller.employeeNum)
										{
											summary.employeeNum = emp.employeeNum;
											summary.employeeName = emp.name;
											break;
										}
									}
								}
								break;
							}
						}
						if (mess.type == Models.Type.SATISFIED)
						{
							summary.count = 1;
						}
						else
						{
							summary.count = 0;
						}
						summary.total = 1;
						dictionary.Add(mess.callerNum, summary);
					}
				}
				Dictionary<string, Summary> dic1_SortedByValue = dictionary.OrderByDescending(o => o.Value.count * 100 / o.Value.total).ToDictionary(p => p.Key, o => o.Value);
				List<Summary> list_sum = dic1_SortedByValue.Values.ToList();

				PercentForm form = new PercentForm();
				form.title = GlobalData.GlobalLanguage.satisfied_totla;
				form.type = 2;
				form.list = list_sum;
				form.ShowDialog();
			}
			if (radioButton8.Checked)//不满意与总次数占比排名
			{
				Dictionary<string, Summary> dictionary = new Dictionary<string, Summary>();
				foreach (DataMessage mess in list_allmess)
				{
					if (dictionary.ContainsKey(mess.callerNum))
					{
						Summary value = null;
						dictionary.TryGetValue(mess.callerNum, out value);
						value.total++;
						if (mess.type == Models.Type.DISSATISFIED)
						{
							value.count++;
						}
					}
					else
					{
						Summary summary = new Summary();
						summary.callerNum = mess.callerNum;
						foreach (Caller caller in InitData.list_caller)
						{
							if (caller.callerNum == mess.callerNum)
							{
								foreach (Callzone zone in InitData.list_zone)
								{
									if (zone.Id == caller.callZone)
									{
										summary.zoneName = zone.name;
										break;
									}
								}
								if (Common.isRFID)
								{
									foreach (Employee emp in InitData.employeeRFID)
									{
										if (emp.employeeNum == caller.employeeNum)
										{
											summary.employeeNum = emp.employeeNum;
											summary.employeeName = emp.name;
											break;
										}
									}
								}
								else
								{
									foreach (Employee emp in InitData.employees)
									{
										if (emp.employeeNum == caller.employeeNum)
										{
											summary.employeeNum = emp.employeeNum;
											summary.employeeName = emp.name;
											break;
										}
									}
								}
								break;
							}
						}
						if (mess.type == Models.Type.DISSATISFIED)
						{
							summary.count = 1;
						}
						else
						{
							summary.count = 0;
						}
						summary.total = 1;
						dictionary.Add(mess.callerNum, summary);
					}
				}
				Dictionary<string, Summary> dic1_SortedByValue = dictionary.OrderByDescending(o => o.Value.count * 100 / o.Value.total).ToDictionary(p => p.Key, o => o.Value);
				List<Summary> list_sum = dic1_SortedByValue.Values.ToList();

				PercentForm form = new PercentForm();
				form.title = GlobalData.GlobalLanguage.dissatisfied_total;
				form.type = 3;
				form.list = list_sum;
				form.ShowDialog();
			}
		}

		private void summary(Dictionary<string, int> dic, string title)
		{
			Dictionary<string, int> dic1_SortedByValue = dic.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
			List<Summary> list_sum = new List<Summary>();
			foreach (KeyValuePair<string, int> item in dic1_SortedByValue)
			{
				Summary summary = new Summary();
				summary.callerNum = item.Key;
				summary.count = item.Value;
				foreach (Caller caller in InitData.list_caller)
				{
					if (caller.callerNum == item.Key)
					{
						summary.employeeNum = caller.employeeNum;
						foreach (Callzone zone in InitData.list_zone)
						{
							if (zone.Id == caller.callZone)
							{
								summary.zoneName = zone.name;
								break;
							}
						}
						if (Common.isRFID)
						{
							foreach (Employee emp in InitData.employeeRFID)
							{
								if (emp.employeeNum == caller.employeeNum)
								{
									summary.employeeName = emp.name;
									break;
								}
							}
						}
						else
						{
							foreach (Employee emp in InitData.employees)
							{
								if (emp.employeeNum == caller.employeeNum)
								{
									summary.employeeName = emp.name;
									break;
								}
							}
						}
						break;
					}
				}
				list_sum.Add(summary);
			}
			SummaryForm form = new SummaryForm();
			form.list = list_sum;
			form.title = title;
			form.ShowDialog();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			print();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			print();
		}

		private void print()
		{
			string path;
			ExcelFile.makeExcel(tem_list, ChangeAppConfig.getValueFromKey("tem_file"), out path);

			Workbook workbook = new Workbook();
			workbook.LoadFromFile(path);

			Worksheet sheet = workbook.Worksheets[0];
			sheet.PageSetup.PrintArea = "A7:T8";
			sheet.PageSetup.PrintTitleRows = "$1:$1";
			sheet.PageSetup.FitToPagesWide = 1;
			sheet.PageSetup.FitToPagesTall = 1;
			//sheet.PageSetup.Orientation = PageOrientationType.Landscape;
			//sheet.PageSetup.PaperSize = PaperSizeType.PaperA3;

			PrintDialog dialog = new PrintDialog();
			dialog.AllowPrintToFile = true;
			dialog.AllowCurrentPage = true;
			dialog.AllowSomePages = true;
			dialog.AllowSelection = true;
			dialog.UseEXDialog = true;
			dialog.PrinterSettings.Duplex = Duplex.Simplex;
			dialog.PrinterSettings.FromPage = 0;
			dialog.PrinterSettings.ToPage = 8;
			dialog.PrinterSettings.PrintRange = PrintRange.SomePages;
			workbook.PrintDialog = dialog;
			PrintDocument pd = workbook.PrintDocument;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				pd.Print();
			}
		}
	}
}
