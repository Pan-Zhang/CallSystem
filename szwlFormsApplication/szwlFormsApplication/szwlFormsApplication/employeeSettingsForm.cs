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
using szwlFormsApplication.Language;
using szwlFormsApplication.Models;

namespace szwlFormsApplication
{
	public partial class employeeSettingsForm : Form
	{
		List<Employee> list;

		public employeeSettingsForm()
		{
			InitializeComponent();
			changeLanguage();
			if (ChangeAppConfig.getValueFromKey("isRFID") == null)
			{
				ChangeAppConfig.ChangeConfig("isRFID", "0");
			}
			
			this.dataGridView1.Columns[0].HeaderCell.Value = Employee.DisplayemployeeNum();
			this.dataGridView1.Columns[1].HeaderCell.Value = Employee.Displayname();
			this.dataGridView1.Columns[2].HeaderCell.Value = Employee.Displaysex();
			this.dataGridView1.Columns[3].HeaderCell.Value = Employee.Displayphonenum();
			this.dataGridView1.Columns[4].HeaderCell.Value = Employee.Displayremarks();
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
			if (Common.isRFID)
			{
				list = InitData.employeeRFID;
			}
			else
			{
				list = InitData.employees;
			}
			isRFIDBox.SelectedIndex = Common.isRFID ? 1 : 0;
		}

		private void refresh()
		{
			
			isRFIDBox.SelectedIndex = Common.isRFID ? 1 : 0;

			if (Common.isRFID)
			{
				list = InitData.employeeRFID = szwlForm.mainForm.dm.selectEmployeeRFID();
			}
			else
			{
				list = InitData.employees = szwlForm.mainForm.dm.selectEmployee();
			}

			//InitData.AddData(dataGridView1, list);
			if (!Common.isRFID)
			{
				if (list != null && list.Count > 0)
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
			else if (list != null && list.Count > 0)
			{
				updateemployee.Enabled = true;
				deleteemployee.Enabled = true;
			}
			else
			{
				updateemployee.Enabled = false;
				deleteemployee.Enabled = false;
			}
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.DataSource = null;
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
			DialogResult dr = dialog.MessageBox.Show(GlobalData.GlobalLanguage.want_delete_employee + emp.employeeNum + "？",
								 GlobalData.GlobalLanguage.prompt,
								MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				if (Common.isRFID)
				{
					if (InitData.employeeRFID == null || InitData.employeeRFID.Count == 0)
					{
						dialog.MessageBox.Show(GlobalData.GlobalLanguage.employee_not_exist);
						return;
					}
					else
					{
						if (InitData.employeeRFID.Any(em => em.employeeNum == emp.employeeNum))
						{
							szwlForm.mainForm.dm.deleteEmployeeRFID(emp);
							InitData.employeeRFID.RemoveAll(em => em.employeeNum == emp.employeeNum);

							dialog.MessageBox.Show(GlobalData.GlobalLanguage.delete_succe);
						}
						else
						{
							dialog.MessageBox.Show(GlobalData.GlobalLanguage.employee_not_exist);
							return;
						}
					}
				}
				else
				{
					if (InitData.employees == null || InitData.employees.Count == 0)
					{
						dialog.MessageBox.Show(GlobalData.GlobalLanguage.employee_not_exist);
						return;
					}
					else
					{
						if (InitData.employees.Any(em => em.employeeNum == emp.employeeNum))
						{
							szwlForm.mainForm.dm.deleteEmployee(emp);
							InitData.employees.RemoveAll(em => em.employeeNum == emp.employeeNum);

							dialog.MessageBox.Show(GlobalData.GlobalLanguage.delete_succe);
						}
						else
						{
							dialog.MessageBox.Show(GlobalData.GlobalLanguage.employee_not_exist);
							return;
						}
					}
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
			DialogResult dr = dialog.MessageBox.Show(GlobalData.GlobalLanguage.delete_employee,
								 GlobalData.GlobalLanguage.prompt,
								MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				if (Common.isRFID)
				{
					szwlForm.mainForm.dm.deleteAllEmployeeRFID();
					InitData.employeeRFID = null;
				}
				else
				{
					szwlForm.mainForm.dm.deleteAllEmployee();
					InitData.employees = null;
				}
				dataGridView1.DataSource = null;
				//dataGridView1.Refresh();
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
					break;

				case 1:
					Common.isRFID = true;
					ChangeAppConfig.ChangeConfig("isRFID", "1");
					break;
			}
			refresh();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			//if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count > 0)
			//{
			//	updateemployee.Enabled = true;
			//	deleteemployee.Enabled = true;
			//}
			//else
			//{
			//	updateemployee.Enabled = false;
			//	deleteemployee.Enabled = false;
			//}
		}

		private void DataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			//if (this.dataGridView1.SelectedRows != null && this.dataGridView1.SelectedRows.Count > 0)
			//{
			//	updateemployee.Enabled = true;
			//	deleteemployee.Enabled = true;
			//}
			//else
			//{
			//	updateemployee.Enabled = false;
			//	deleteemployee.Enabled = false;
			//}
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.employee_setting;

			//dataGridView1.Columns[0].HeaderText = GlobalData.GlobalLanguage.employee_num;
			//dataGridView1.Columns[1].HeaderText = GlobalData.GlobalLanguage.name;
			//dataGridView1.Columns[2].HeaderText = GlobalData.GlobalLanguage.telephone;
			//dataGridView1.Columns[3].HeaderText = GlobalData.GlobalLanguage.remarks;
			//dataGridView1.Columns[4].HeaderText = GlobalData.GlobalLanguage.gender;

			isRFIDBox.Items[0] = GlobalData.GlobalLanguage.button_mode;
			isRFIDBox.Items[1] = GlobalData.GlobalLanguage.rfid_mode;
			addemployee.Text = GlobalData.GlobalLanguage.callAreaAddbtn;
			updateemployee.Text = GlobalData.GlobalLanguage.callAreaUpdatebtn;
			deleteemployee.Text = GlobalData.GlobalLanguage.callAreaDeletebtn;
			button3.Text = GlobalData.GlobalLanguage.callAreaOKbtn;
			clearemployee.Text = GlobalData.GlobalLanguage.callAreaclearDatabtn;
		}
	}
}
