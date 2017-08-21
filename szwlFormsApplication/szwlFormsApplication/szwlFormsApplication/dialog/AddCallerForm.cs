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
		public AddCallerForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				this.DialogResult = DialogResult.OK;
				Caller caller = new Caller();
				if (InitData.list_caller != null && InitData.list_caller.Count != 0 && InitData.list_caller.Any(c => c.callerNum == callerNum.Text))
				{
					MessageBox.Show("该呼叫器编号已存在，不能新增！");
					return;
				}
				caller.callerNum = callerNum.Text;
				var zone = -1;
				string zonename = null;
				if (InitData.list_zone != null && InitData.list_zone.Count > 0)
				{
					DataRowView tmpdata = (DataRowView)callerArea.SelectedItem;
					zone = Convert.ToInt32(tmpdata.Row[0]);
					zonename = tmpdata.Row[1].ToString();
				}

				if (InitData.list_caller.Any(c => c.callZone == zone))
				{
					MessageBox.Show("该呼叫区域已绑定，不能新增！");
					return;
				}
				caller.callZone = zone;
				caller.callerZoneName = zonename;
				if (InitData.employees == null || InitData.employees.Count == 0)
				{
					caller.employeeNum = -1;
				}
				else
				{
					caller.employeeNum = InitData.employees[worker.SelectedIndex].employeeNum;
				}

				if (InitData.list_caller == null)
					InitData.list_caller = new List<Caller>();
				if (szwlForm.mainForm.dm.insertCaller(caller))
				{
					InitData.list_caller = szwlForm.mainForm.dm.selectCaller();
					MessageBox.Show("该呼叫器添加成功！");
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					MessageBox.Show("呼叫器添加失败,请重试！");
				}
			}
			catch(Exception  ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error,ex.ToString());
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Hide();
		}

		private void AddCallerForm_Load(object sender, EventArgs e)
		{
			if (Common.isRFID)
			{
				//list_employee = dm.selectEmployeeRFID();
				worker.Hide();
				label3.Hide();
			}
			else
			{
				initWorker();
			}
			initArea();

		}

		private void initArea()
		{
			DataTable dt = new DataTable();//创建一个数据集
			dt.Columns.Add("id", typeof(String));
			dt.Columns.Add("val", typeof(String));
			foreach (var item in InitData.list_zone)
			{
				DataRow dr = dt.NewRow();
				dr[0] = item.Id;
				dr[1] =item.name;

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
			foreach (var item in InitData.employees)
			{
				DataRow dr = dt.NewRow();
				dr[0] = item.employeeNum;
				dr[1] = item.employeeNum + "号 " + item.name; ;

				dt.Rows.Add(dr);
			}
			worker.DataSource = dt;
			worker.DisplayMember = "val";
			worker.ValueMember = "id";
		}
	}
}
