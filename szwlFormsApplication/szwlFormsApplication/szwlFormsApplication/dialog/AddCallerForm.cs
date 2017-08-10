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

namespace szwlFormsApplication.dialog
{
	public partial class AddCallerForm : Form
	{
		DBManager dm;
		List<Callzone> list_zone;
		List<Employee> list_employee;
		public AddCallerForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			Caller caller = new Caller();
			caller.callerNum = int.Parse(callerNum.Text);
			if(list_zone==null || list_zone.Count == 0)
			{
				caller.callZone = -1;
			}
			else
			{
				caller.callZone = list_zone[callerArea.SelectedIndex].Id;
			}
			if(list_employee==null || list_employee.Count == 0)
			{
				caller.employeeNum = -1;
			}
			else
			{
				caller.employeeNum = list_employee[worker.SelectedIndex].employeeNum;
			}
			if (dm.insertCaller(caller))
			{
				this.Hide();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Hide();
		}

		private void AddCallerForm_Load(object sender, EventArgs e)
		{
			dm = new DBManager();
			list_zone = dm.selectZone();

			if (Common.isRFID)
			{
				//list_employee = dm.selectEmployeeRFID();
				worker.Hide();
				label3.Hide();
			}
			else
			{
				list_employee = dm.selectEmployee();
				initWorker();
			}
			initArea();
			
		}

		private void initArea()
		{
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
			callerArea.DataSource = dt;
			callerArea.DisplayMember = "val";
			callerArea.ValueMember = "id";
		}

		private void initWorker()
		{
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
	}
}
