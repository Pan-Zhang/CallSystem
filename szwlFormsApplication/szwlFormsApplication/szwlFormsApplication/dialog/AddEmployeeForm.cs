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
			Employee employee = new Employee();
			employee.employeeNum = int.Parse(textBox1.Text.Trim());
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
			if (szwlForm.mainForm.dm.insertEmployee(employee))
			{
				this.Hide();
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
