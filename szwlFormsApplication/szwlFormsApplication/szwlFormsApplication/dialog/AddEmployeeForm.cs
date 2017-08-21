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
	public partial class AddEmployeeForm : Form
	{
		public AddEmployeeForm()
		{
			InitializeComponent();
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
				this.DialogResult = DialogResult.OK;
				if (InitData.employees == null)
					InitData.employees = new List<Employee>();
				if (InitData.employees.Any(em=> em.employeeNum == num))
				{
					MessageBox.Show("员工编号已存在,不能新增！");
					return;
				}
				else
				{
					if (szwlForm.mainForm.dm.insertEmployee(employee))
					{
						InitData.employees = szwlForm.mainForm.dm.selectEmployee();
						MessageBox.Show("员工新增成功！");
						this.Hide();
					}
				}
			}
			else
			{
				MessageBox.Show("员工编号不为数字类型,不能新增！");
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
	}
}
