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
using szwlFormsApplication.dialog;
using szwlFormsApplication.Models;

namespace szwlFormsApplication
{
	public partial class employeeSettingsForm : Form
	{
		List<Employee> list;
		DBManager dm;

		public employeeSettingsForm()
		{
			InitializeComponent();
		}

		private void employeeSettingsForm_Load(object sender, EventArgs e)
		{
			dm = new DBManager();
			refresh();

			int index = int.Parse(AppConfig.GetValue("isRFID"));
			isRFIDBox.SelectedIndex = index;
		}

		private void refresh()
		{
			if (Common.isRFID)
			{
				list = dm.selectEmployeeRFID();
			}
			else
			{
				list = dm.selectEmployee();
			}

			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.DataSource = list;
			this.dataGridView1.Refresh();
		}

		private void addemployee_Click(object sender, EventArgs e)
		{
			AddEmployeeForm form = new AddEmployeeForm();
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
				refresh();
			}
		}

		private void updateemployee_Click(object sender, EventArgs e)
		{
			EditEmployeeForm form = new EditEmployeeForm();
			form.employee = list[dataGridView1.CurrentRow.Index];
			DialogResult dr = form.ShowDialog();
			if(dr == DialogResult.OK)
			{
				refresh();
			}
		}

		private void deleteemployee_Click(object sender, EventArgs e)
		{
			int index = dataGridView1.CurrentRow.Index;
			Employee emp = list[index];
			DialogResult dr = MessageBox.Show("您确定想删除区域：" + emp.num + "号员工吗？",
								 " 提示",
								MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				if (Common.isRFID)
				{
					dm.deleteEmployeeRFID(emp);
				}
				else
				{
					dm.deleteEmployee(emp);
				}
				refresh();
			}
			
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void clearemployee_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("您确定想所有员工数据吗？",
								 " 提示",
								MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				if (Common.isRFID)
				{
					dm.deleteAllEmployeeRFID();
				}
				else
				{
					dm.deleteAllEmployee();
				}
				refresh();
			}
		}

		private void isRFIDBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = isRFIDBox.SelectedIndex;
			switch (index)
			{
				case 0:
					Common.isRFID = false;
					AppConfig.SetValue("isRFID", "0");
					addemployee.Enabled = true;
					break;

				case 1:
					Common.isRFID = true;
					AppConfig.SetValue("isRFID", "1");
					addemployee.Enabled = false;
					break;
			}
			refresh();
		}
	}
}
