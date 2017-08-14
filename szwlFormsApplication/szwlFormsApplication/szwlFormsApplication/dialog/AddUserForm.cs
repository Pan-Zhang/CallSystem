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
	public partial class AddUserForm : Form
	{
		DBManager dm;

		public AddUserForm()
		{
			InitializeComponent();
			this.userClassComboBox.Items.Add(User.UserClass.Admin.ToString());
			this.userClassComboBox.Items.Add(User.UserClass.normal.ToString());
		}

		private void AddUserForm_Load(object sender, EventArgs e)
		{
			prompt.Hide();
		}

		private void ensure_Click(object sender, EventArgs e)
		{
			User admin = new User();
			admin.name = username.Text;
			admin.pass = password.Text;
			admin.userClass = (User.UserClass)userClassComboBox.SelectedIndex;
			if (username.Text.Equals("admin"))
			{
				prompt.Show();
			}
			else if (szwlForm.mainForm.dm.insertUser(admin))
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}
