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
	public partial class BatchUpdateForm : Form
	{
		List<Employee> list;
		public BatchUpdateForm()
		{
			InitializeComponent();
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.batch_update;
			label1.Text = GlobalData.GlobalLanguage.choose_employee;
			button1.Text = GlobalData.GlobalLanguage.ensure;
			button2.Text = GlobalData.GlobalLanguage.cancel;
		}

		private void BatchUpdateForm_Load(object sender, EventArgs e)
		{
			changeLanguage();
			if (Common.isRFID)
			{
				list = InitData.employeeRFID;
				int i = 0;
				foreach(Employee employee in list)
				{
					comboBox1.Items[i] = string.Format(GlobalData.GlobalLanguage.employee_select, employee.employeeNum, employee.name);
				}
				i++;
			}
			else
			{
				list = InitData.employees;
				List<string> strings = new List<string>();
				int i = 0;
				foreach (Employee employee in list)
				{
					try
					{
						strings.Add(string.Format(GlobalData.GlobalLanguage.employee_select, employee.employeeNum, employee.name));
					}
					catch(Exception ex)
					{
						
					}
				}
				comboBox1.DataSource = strings;
				i++;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex == -1)
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.no_employee_coose);
			}
			else
			{
				settingsForm.employee = list[comboBox1.SelectedIndex];
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
