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
	public partial class EditEmployeeForm : Form
	{
		public Employee employee { get; set; }
		public EditEmployeeForm()
		{
			InitializeComponent();
			changeLanguage();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			employee.name = textBox5.Text;
			employee.employeeNum = int.Parse(textBox1.Text);
			employee.phonenum = textBox4.Text;
			employee.remarks = textBox3.Text;
			employee.sex = radioButton1.Checked ? Sex.MALE : Sex.FEMALE;
			
			if (Common.isRFID)
			{
				if (InitData.employeeRFID == null)
				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.employee_not_exist);
					return;
				}
				else
				{
					if (InitData.employeeRFID.Any(em => em.employeeNum == employee.employeeNum))
					{
						if (szwlForm.mainForm.dm.updateEmployeeRFID(employee))
						{
							InitData.employeeRFID = InitData.employeeRFID.Select(em => em.employeeNum == employee.employeeNum ? employee : em).ToList();
							this.DialogResult = DialogResult.OK;
							dialog.MessageBox.Show(GlobalData.GlobalLanguage.update_success);
							this.Hide();
						}
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
				if (InitData.employees == null)
				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.employee_not_exist);
					return;
				}
				else
				{
					if (InitData.employees.Any(em => em.employeeNum == employee.employeeNum))
					{
						if (szwlForm.mainForm.dm.updateEmployee(employee))
						{
							InitData.employees = InitData.employees.Select(em => em.employeeNum == employee.employeeNum ? employee : em).ToList();
							this.DialogResult = DialogResult.OK;
							dialog.MessageBox.Show(GlobalData.GlobalLanguage.update_success);
							this.Hide();
						}
					}
					else
					{
						dialog.MessageBox.Show(GlobalData.GlobalLanguage.employee_not_exist);
						return;
					}
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void EditEmployeeForm_Load(object sender, EventArgs e)
		{
			textBox1.Text = employee.employeeNum.ToString();
			textBox5.Text = employee.name;
			textBox4.Text = employee.phonenum;
			switch (employee.sex)
			{
				case Sex.FEMALE:
					radioButton2.Checked = true;
					break;

				case Sex.MALE:
					radioButton1.Checked = true;
					break;
			}
			textBox3.Text = employee.remarks;
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.edit_employee;
			label1.Text = GlobalData.GlobalLanguage.employee_num;
			label5.Text = GlobalData.GlobalLanguage.name;
			label3.Text = GlobalData.GlobalLanguage.telephone;
			label4.Text = GlobalData.GlobalLanguage.gender;
			label2.Text = GlobalData.GlobalLanguage.remarks;
			radioButton1.Text = GlobalData.GlobalLanguage.male;
			radioButton2.Text = GlobalData.GlobalLanguage.female;
			button1.Text = GlobalData.GlobalLanguage.ensure;
			button2.Text = GlobalData.GlobalLanguage.cancel;
		}
	}
}
