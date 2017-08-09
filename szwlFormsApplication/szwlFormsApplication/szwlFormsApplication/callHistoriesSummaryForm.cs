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
			}
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
				dr[1] = list_employee[i].num;

				dt.Rows.Add(dr);
			}
			worker.DataSource = dt;
			worker.DisplayMember = "val";
			worker.ValueMember = "id";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DateTime start = date_start.Value.Date;
			DateTime end = date_end.Value.Date;
			int area = callArea.SelectedIndex;
			Callzone zone = list_zone[area];

			int callerNum = 0;
			foreach(Caller call in list_caller)
			{
				if(call.callZone == zone.Id)
				{
					callerNum = call.callerNum;
				}
			}
			int worknum = worker.SelectedIndex;
			worknum = list_employee[worknum].num;
			int type = typeBox.SelectedIndex;
			Models.Type tp = Models.Type.CANCEL; ;
			switch(type){
				case 0:
					tp = Models.Type.CANCEL;
					break;

				case 1:
					tp = Models.Type.ORDER;
					break;

				case 2:
					tp = Models.Type.CALL;
					break;

				case 3:
					tp = Models.Type.CHECK_OUT;
					break;

				case 4:
					tp = Models.Type.CHANGE_MEDICATION;
					break;

				case 5:
					tp = Models.Type.EMERGENCY_CALL;
					break;

				case 6:
					tp = Models.Type.PULING_NEEDLE;
					break;

				case 7:
					tp = Models.Type.NEED_SERVICE;
					break;

				case 8:
					tp = Models.Type.NEED_WATER;
					break;

				case 9:
					tp = Models.Type.WANT_TO_PAY;
					break;

				case 10:
					tp = Models.Type.NEED_NURSES;
					break;

				case 11:
					tp = Models.Type.SATISFIED;
					break;

				case 12:
					tp = Models.Type.DISSATISFIED;
					break;

				case 13:
					tp = Models.Type.LOW_POWER;
					break;

				case 14:
					tp = Models.Type.TAMPER;
					break;
			}

			int status = statusBox.SelectedIndex;
			STATUS st = STATUS.FINISH;
			switch (status)
			{
				case 0:
					st = STATUS.WAITING;
					break;

				case 1:
					st = STATUS.FINISH;
					break;

				case 2:
					st = STATUS.OVERTIME;
					break;
			}

			List<DataMessage> list = dm.selectMess();
			List<DataMessage> tem_list = new List<DataMessage>();
			foreach(DataMessage mess in list)
			{
				if (!Common.isRFID)
				{
					if (mess.time < end && mess.time > start && mess.callerNum == callerNum && mess.workerNum == worknum && mess.type == tp && mess.status == st)
					{
						tem_list.Add(mess);
					}
				}
				else
				{

				}	
			}
			this.historyRecordsdataGridView.AutoGenerateColumns = false;
			this.historyRecordsdataGridView.DataSource = tem_list;
			this.historyRecordsdataGridView.Refresh();
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
					if(caller.waiterNum == -1)
					{
						label13.Text = "无";
						break;
					}
					Employee tem_emp = null;
					if (list_employee != null)
					{
						foreach (Employee emp in list_employee)
						{
							if (emp.num == caller.waiterNum)
							{
								tem_emp = emp;
								break;
							}
						}
					}
					if (tem_emp == null)
					{
						label13.Text = caller.waiterNum + "号";
					}
					else
					{
						label13.Text = caller.waiterNum + "号  姓名：" + tem_emp.name;
					}
					break;
				}
			}
		}

		private void worker_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = worker.SelectedIndex;
			Employee emp = list_employee[index];

			foreach(Caller caller in list_caller)
			{
				if(caller.waiterNum == emp.num)
				{
					Callzone tem_zone = null;
					foreach(Callzone zone in list_zone)
					{
						if(zone.Id == caller.callZone)
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
	}
}
