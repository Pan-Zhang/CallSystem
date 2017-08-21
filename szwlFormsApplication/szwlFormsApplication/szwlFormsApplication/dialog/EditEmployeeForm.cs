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
	public partial class EditEmployeeForm : Form
	{
		public Employee employee { get; set; }
		public EditEmployeeForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			employee.name = textBox5.Text;
			employee.employeeNum = int.Parse(textBox1.Text);
			employee.phonenum = textBox4.Text;
			employee.remarks = textBox3.Text;
			employee.sex = radioButton1.Checked ? Sex.MALE : Sex.FEMALE;
			this.DialogResult = DialogResult.OK;
			if (Common.isRFID)
			{
				if (InitData.employeeRFID == null)
				{
					MessageBox.Show("员工不存在，不能修改！");
					return;
				}
				else
				{
					if (InitData.employeeRFID.Any(em => em.employeeNum == employee.employeeNum))
					{
						if (szwlForm.mainForm.dm.updateEmployeeRFID(employee))
						{
							InitData.employeeRFID = InitData.employeeRFID.Select(em => em.employeeNum == employee.employeeNum ? employee : em).ToList();
							MessageBox.Show("员工修改成功！");
							this.Hide();
						}
					}
					else
					{
						MessageBox.Show("员工不存在，不能修改！");
						return;
					}
				}
			}
			else
			{
				if (InitData.employees == null)
				{
					MessageBox.Show("员工不存在，不能修改！");
					return;
				}
				else
				{
					if (InitData.employees.Any(em => em.employeeNum == employee.employeeNum))
					{
						if (szwlForm.mainForm.dm.updateEmployee(employee))
						{
							InitData.employees = InitData.employees.Select(em => em.employeeNum == employee.employeeNum ? employee : em).ToList();
							MessageBox.Show("员工修改成功！");
							this.Hide();
						}
					}
					else
					{
						MessageBox.Show("员工不存在，不能修改！");
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
	}
}
