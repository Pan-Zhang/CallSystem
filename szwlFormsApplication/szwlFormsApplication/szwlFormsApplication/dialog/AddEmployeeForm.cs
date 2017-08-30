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
	public partial class AddEmployeeForm : Form
	{
		public AddEmployeeForm()
		{
			InitializeComponent();
			changeLanguage();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (int.TryParse(textBox1.Text.Trim(), out num))
			{
				Employee employee = new Employee();
				employee.employeeNum = num;
				employee.name = textBox4.Text;
				employee.phonenum = textBox2.Text;
				employee.remarks = textBox3.Text;
				if (radioButton1.Checked)
				{
					employee.sex = Sex.MALE;
				}
				else
				{
					employee.sex = Sex.FEMALE;
				}
				
				if (InitData.employees == null)
					InitData.employees = new List<Employee>();
				if (InitData.employees.Any(em=> em.employeeNum == num))
				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.employee_exist);
					return;
				}
				else
				{
					if (szwlForm.mainForm.dm.insertEmployee(employee))
					{
						InitData.employees = szwlForm.mainForm.dm.selectEmployee();
						this.DialogResult = DialogResult.OK;
						dialog.MessageBox.Show(GlobalData.GlobalLanguage.add_success);
						this.Hide();
					}
				}
			}
			else
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.employeenum_number_type);
				return;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void AddEmployeeForm_Load(object sender, EventArgs e)
		{
			radioButton1.Checked = true;
		}

		private void changeLanguage()
		{
			label1.Text = GlobalData.GlobalLanguage.employee_num;
			label3.Text = GlobalData.GlobalLanguage.Name;
			label2.Text = GlobalData.GlobalLanguage.telephone;
			label5.Text = GlobalData.GlobalLanguage.gender;
			radioButton1.Text = GlobalData.GlobalLanguage.male;
			radioButton2.Text = GlobalData.GlobalLanguage.female;
			label4.Text = GlobalData.GlobalLanguage.remarks;
			button1.Text = GlobalData.GlobalLanguage.ensure;
			button2.Text = GlobalData.GlobalLanguage.cancel;
		}
	}
}
