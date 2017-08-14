using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
			if (ConfigurationManager.AppSettings["isRFID"] == null)
			{
				ChangeAppConfig.ChangeConfig("isRFID", "0");
			}
			int index = int.Parse(ConfigurationManager.AppSettings["isRFID"]);
			isRFIDBox.SelectedIndex = index;
			if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count > 0)
			{
				updateemployee.Enabled = true;
				deleteemployee.Enabled = true;
			}
			else
			{
				updateemployee.Enabled = false;
				deleteemployee.Enabled = false;
			}
			refresh();
		}

		private void employeeSettingsForm_Load(object sender, EventArgs e)
		{
		}

		private void refresh()
		{
			if (Common.isRFID)
			{
				list = szwlForm.mainForm.dm.selectEmployeeRFID();
			}
			else
			{
				list = szwlForm.mainForm.dm.selectEmployee();
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
			if (this.dataGridView1.SelectedRows == null || this.dataGridView1.SelectedRows.Count == 0)
				return;
			EditEmployeeForm form = new EditEmployeeForm();
			form.employee = list[dataGridView1.CurrentRow.Index];
			DialogResult dr = form.ShowDialog();
			if (dr == DialogResult.OK)
			{
				refresh();
			}
		}

		private void deleteemployee_Click(object sender, EventArgs e)
		{
			if (this.dataGridView1.SelectedRows == null || this.dataGridView1.SelectedRows.Count == 0)
				return;
			int index = dataGridView1.CurrentRow.Index;
			Employee emp = list[index];
			DialogResult dr = MessageBox.Show("您确定想删除区域：" + emp.employeeNum + "号员工吗？",
								 " 提示",
								MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				if (Common.isRFID)
				{
					szwlForm.mainForm.dm.deleteEmployeeRFID(emp);
				}
				else
				{
					szwlForm.mainForm.dm.deleteEmployee(emp);
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
					szwlForm.mainForm.dm.deleteAllEmployeeRFID();
				}
				else
				{
					szwlForm.mainForm.dm.deleteAllEmployee();
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
					ChangeAppConfig.ChangeConfig("isRFID", "0");
					addemployee.Enabled = true;
					break;

				case 1:
					Common.isRFID = true;
					ChangeAppConfig.ChangeConfig("isRFID", "1");
					addemployee.Enabled = false;
					break;
			}
			refresh();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count > 0)
			{
				updateemployee.Enabled = true;
				deleteemployee.Enabled = true;
			}
			else
			{
				updateemployee.Enabled = false;
				deleteemployee.Enabled = false;
			}
		}
		
		private void DataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count > 0)
			{
				updateemployee.Enabled = true;
				deleteemployee.Enabled = true;
			}
			else
			{
				updateemployee.Enabled = false;
				deleteemployee.Enabled = false;
			}
		}
	}
}
