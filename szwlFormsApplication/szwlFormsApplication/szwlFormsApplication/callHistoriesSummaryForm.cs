using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szwlFormsApplication.CommonFunc;
using szwlFormsApplication.Models;

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
		}

		private void callHistoriesSummaryForm_Load(object sender, EventArgs e)
		{
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
			list_allmess = dm.selectMess();
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
			for (int i = 0; i < list_zone.Count; i++)
			{
				DataRow dr = dt.NewRow();
				dr[0] = i;
				dr[1] = list_zone[i].name;

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
				dr[1] = list_employee[i].employeeNum + "号 " + list_employee[i].name;

				dt.Rows.Add(dr);
			}
			worker.DataSource = dt;
			worker.DisplayMember = "val";
			worker.ValueMember = "id";
		}

		private void callArea_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = callArea.SelectedIndex;
			Callzone zone = list_zone[index];
			label13.Text = "无";
			foreach (Caller caller in list_caller)
			{
				if (caller.callZone == zone.Id)
				{
					if (caller.employeeNum == -1)
					{
						label13.Text = "无";
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
						label13.Text = caller.employeeNum + "号";
					}
					else
					{
						label13.Text = caller.employeeNum + "号  姓名：" + tem_emp.name;
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
						label9.Text = "无";
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
			DateTime end = date_end.Value.Date;//结束时间

			Callzone zone = list_zone[callArea.SelectedIndex];//区域
															  //查找对应呼叫器编号
			int callerNum = 0;
			foreach (Caller caller in list_caller)
			{
				if (caller.callZone == zone.Id)
				{
					callerNum = caller.callerNum;
					break;
				}
			}

			int _type = typeBox.SelectedIndex;//服务类型

			int _status = statusBox.SelectedIndex; //服务状态

			if (_type == 0 && _status == 0)//某区域所有呼叫记录
			{
				foreach (DataMessage mess in list_allmess)
				{
					if (mess.time>start && mess.time<end && mess.callerNum == callerNum)
					{
						tem_list.Add(mess);
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

					if (mess.time > start && mess.time < end && mess.callerNum == callerNum && _status == status)
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
					if (message.time > start && message.time < end && message.callerNum == callerNum && type == (_type - 1))
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
					if (message.time > start && message.time < end && message.callerNum == callerNum && type == (_type - 1) && status == _status)
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
			DateTime end = dateTimePicker1.Value.Date;//结束时间

			Employee employ = list_employee[worker.SelectedIndex];

			if (Common.isRFID)
			{
				foreach (DataMessage message in list_allmess)
				{
					if (message.time > start && message.time < end && message.employeeNum == employ.employeeNum)
					{
						tem_list.Add(message);
					}
				}
				makeChartRFID();
			}
			else
			{
				int callerNum = -2;
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
						if (message.time > start && message.time < end && message.callerNum == callerNum)
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
						if (message.time > start && message.time < end && message.callerNum == callerNum && status == _status)
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
				xData.Add("完成(" + finish + ")");
			}
			if (timeover > 0)
			{
				yData.Add(timeover);
				xData.Add("超时(" + timeover + ")");
			}
			if (unsatisfy > 0)
			{
				yData.Add(unsatisfy);
				xData.Add("不满意(" + unsatisfy + ")");
			}
			if (satisfy > 0)
			{
				yData.Add(satisfy);
				xData.Add("满意(" + satisfy + ")");
			}
			if (waiting > 0)
			{
				yData.Add(waiting);
				xData.Add("等待(" + waiting + ")");
			}
			chart2.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
			chart2.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
			chart2.Series[0].Points.DataBindXY(xData, yData);

			total.Text = tem_list.Count + "条记录";
		}

		private void makeChartRFID()
		{
			Dictionary<int, int> dic = new Dictionary<int, int>();

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
			foreach (KeyValuePair<int, int> kvp in dic)
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
				xData.Add(name+"("+kvp.Value+"次)");
			}
			chart2.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
			chart2.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
			chart2.Series[0].Points.DataBindXY(xData, yData);

			total.Text = tem_list.Count + "条记录";
		}
	}
}
