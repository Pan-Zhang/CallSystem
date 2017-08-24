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
using szwlFormsApplication.Language;
using szwlFormsApplication.Models;

namespace szwlFormsApplication.dialog
{
	public partial class EditCallerForm : Form
	{
		public Caller caller { get; set; }

		public EditCallerForm()
		{
			InitializeComponent();
			changeLanguage();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (InitData.list_caller == null || InitData.list_caller.Count == 0)
			{
				MessageBox.Show(GlobalData.GlobalLanguage.no_caller_to_edit);
				return;
			}
			if (InitData.list_caller.Any(c=> c.callerNum == textBox1.Text && c.ID != caller.ID))
			{
				DialogResult dr = MessageBox.Show(GlobalData.GlobalLanguage.caller_exist);
				return;
			}
			else
			{
				var zone = -1;
				string zonename = null;
				if (InitData.list_zone != null && InitData.list_zone.Count > 0)
				{
					DataRowView tmpdata = (DataRowView)comboBox1.SelectedItem;
					zone = Convert.ToInt32(tmpdata.Row[0]);
					zonename = tmpdata.Row[1].ToString();
				}

				if (InitData.list_caller.Any(c => c.callZone == zone && c.ID != caller.ID))
				{
					MessageBox.Show(GlobalData.GlobalLanguage.zone_bound);
					return;
				}
				caller.callZone = zone;
				caller.callerZoneName = zonename;
				caller.callerNum = textBox1.Text;
				if (!Common.isRFID)
				{
					caller.employeeNum = InitData.employees[comboBox2.SelectedIndex].employeeNum;
				}
				if (szwlForm.mainForm.dm.updateCaller(caller))
				{
					this.DialogResult = DialogResult.OK;
					InitData.list_caller = InitData.list_caller.Select(c => c.callerNum == caller.callerNum ? caller : c).ToList();
					MessageBox.Show(GlobalData.GlobalLanguage.update_success);
					this.Close();
				}
				else
				{
					MessageBox.Show(GlobalData.GlobalLanguage.edit_failed);
					return;
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void EditCallerForm_Load(object sender, EventArgs e)
		{
			textBox1.Text = caller.callerNum.ToString();
			if (Common.isRFID)
			{
				label3.Hide();
				comboBox2.Hide();
			}
			initZone();
			if (!Common.isRFID)
			{
				initWorker();
			}
		}

		private void initZone()
		{
			if (InitData.list_zone != null && InitData.list_zone.Count > 0)
			{
				int index = 0;
				DataTable dt = new DataTable();//创建一个数据集
				dt.Columns.Add("id", typeof(String));
				dt.Columns.Add("val", typeof(String));
				var i = 0;
				foreach (var item in InitData.list_zone)
				{
					DataRow dr = dt.NewRow();
					dr[0] = item.Id;
					dr[1] = item.name;
					if (dr[1].Equals(caller.callerZoneName))
					{
						index = i;
					}
					i++;
					dt.Rows.Add(dr);
				}
				comboBox1.DataSource = dt;
				comboBox1.DisplayMember = "val";
				comboBox1.ValueMember = "id";
				comboBox1.SelectedIndex = index;
			}
		}

		private void initWorker()
		{
			if (InitData.employees != null && InitData.employees.Count > 0)
			{
				DataTable dt = new DataTable();//创建一个数据集
				dt.Columns.Add("id", typeof(String));
				dt.Columns.Add("val", typeof(String));
				for (int i = 0; i < InitData.employees.Count; i++)
				{
					DataRow dr = dt.NewRow();
					dr[0] = i;
					dr[1] = InitData.employees[i].employeeNum + "号 " + InitData.employees[i].name;

					dt.Rows.Add(dr);
				}
				comboBox2.DataSource = dt;
				comboBox2.DisplayMember = "val";
				comboBox2.ValueMember = "id";
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if (InitData.list_zone != null && InitData.list_zone.Count > 0)
			//{
			//	int index = comboBox1.SelectedIndex;
			//	Callzone zone = InitData.list_zone[index];
			//	caller.callZone = zone.Id;
			//}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if (InitData.employees != null && InitData.employees.Count > 0)
			//{
			//	int index = comboBox2.SelectedIndex;
			//	Employee emp = InitData.employees[index];
			//	caller.employeeNum = emp.employeeNum;
			//}
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.edit_caller;
			label1.Text = GlobalData.GlobalLanguage.Caller_number;
			label2.Text = GlobalData.GlobalLanguage.Caller_zone;
			label3.Text = GlobalData.GlobalLanguage.employee_num;
			button1.Text = GlobalData.GlobalLanguage.ensure;
			button2.Text = GlobalData.GlobalLanguage.cancel;
		}
	}
}
