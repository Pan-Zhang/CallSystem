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

namespace szwlFormsApplication
{
	public partial class employeeSettingsForm : Form
	{
		List<Employee> list;

		public employeeSettingsForm()
		{
			InitializeComponent();
		}

		private void employeeSettingsForm_Load(object sender, EventArgs e)
		{
			DBManager dm = new DBManager();
			list = dm.selectEmployeeRFID();

			Employee employee = new Employee();
			employee.name = "zhangsan";
			employee.num = 123;
			employee.remarks = "多谢关注";
			employee.phonenum = "123456789";
			employee.sex = Sex.FEMALE;
			employee.Id = 0;
			list.Add(employee);

			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.DataSource = list;
			this.dataGridView1.Refresh();
		}
	}
}
