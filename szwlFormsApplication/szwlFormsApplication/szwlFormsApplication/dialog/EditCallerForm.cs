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
	public partial class EditCallerForm : Form
	{
		List<Callzone> list_zone;
		List<Employee> list_employee;
		DBManager dm;
		public Caller caller { get; set; }

		public EditCallerForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			caller.callerNum = int.Parse(textBox1.Text);
			this.DialogResult = DialogResult.OK;
			if (dm.updateCaller(caller))
			{
				this.Hide();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void EditCallerForm_Load(object sender, EventArgs e)
		{
			dm = new DBManager();
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
			list_zone = dm.selectZone();
			int index = 0;
			DataTable dt = new DataTable();//创建一个数据集
			dt.Columns.Add("id", typeof(String));
			dt.Columns.Add("val", typeof(String));
			for (int i = 0; i < list_zone.Count; i++)
			{
				DataRow dr = dt.NewRow();
				dr[0] = i;
				dr[1] = list_zone[i].name;
				if (dr[1].Equals(caller.callerZoneName))
				{
					index = i;
				}

				dt.Rows.Add(dr);
			}
			comboBox1.DataSource = dt;
			comboBox1.DisplayMember = "val";
			comboBox1.ValueMember = "id";
			comboBox1.SelectedIndex = index;
		}

		private void initWorker()
		{
			list_employee = dm.selectEmployee();

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
			comboBox2.DataSource = dt;
			comboBox2.DisplayMember = "val";
			comboBox2.ValueMember = "id";
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = comboBox1.SelectedIndex;
			Callzone zone = list_zone[index];
			caller.callZone = zone.Id;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = comboBox2.SelectedIndex;
			Employee emp = list_employee[index];
			caller.employeeNum = emp.employeeNum;
		}
	}
}
