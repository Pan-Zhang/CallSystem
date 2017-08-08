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

			int status = statusBox.SelectedIndex;

			List<DataMessage> list = dm.selectMess();
			List<DataMessage> tem_list = new List<DataMessage>();
			foreach(DataMessage mess in list)
			{
				if(mess.time<end && mess.time>start && mess.callerNum==callerNum && mess.workerNum==worknum && mess.type==Models.Type.CALL && mess.status == STATUS.FINISH)
				{
					tem_list.Add(mess);
				}
			}
			this.historyRecordsdataGridView.AutoGenerateColumns = false;
			this.historyRecordsdataGridView.DataSource = tem_list;
			this.historyRecordsdataGridView.Refresh();
		}
	}
}
