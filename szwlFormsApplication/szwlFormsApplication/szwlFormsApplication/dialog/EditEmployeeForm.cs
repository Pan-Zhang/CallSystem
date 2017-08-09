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
		DBManager dm;
		public EditEmployeeForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			dm = new DBManager();
			employee.name = textBox5.Text;
			employee.num = int.Parse(textBox1.Text);
			employee.phonenum = textBox4.Text;
			employee.remarks = textBox3.Text;
			employee.sex = radioButton1.Checked ? Sex.MALE : Sex.FEMALE;
			this.DialogResult = DialogResult.OK;
			if (Common.isRFID)
			{
				if (dm.updateEmployeeRFID(employee))
				{
					this.Hide();
				}
			}
			else
			{
				if (dm.updateEmployee(employee))
				{
					this.Hide();
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void EditEmployeeForm_Load(object sender, EventArgs e)
		{
			textBox1.Text = employee.num.ToString();
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
