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
	public partial class AddUserForm : Form
	{
		public AddUserForm()
		{
			InitializeComponent();
			changeLanguage();
			userClassComboBox.Items.Add(User.UserClass.Admin.ToString());
			userClassComboBox.Items.Add(User.UserClass.normal.ToString());
			userClassComboBox.SelectedIndex = 0;
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
			var tmp = new UserProgram(admin);
			if (username.Text.Equals("Admin"))
			{
				prompt.Show();
			}
			else
			{
				if (InitData.users == null)
					InitData.users = new List<User>();
				if (InitData.users.Any(u => u.name == admin.name))
				{
					MessageBox.Show(GlobalData.GlobalLanguage.user_exist);
				}
				else if (szwlForm.mainForm.dm.insertUser(admin))
				{
					InitData.users=szwlForm.mainForm.dm.selectUser();
					MessageBox.Show(GlobalData.GlobalLanguage.add_success);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.add_user;
			label1.Text = GlobalData.GlobalLanguage.username;
			label2.Text = GlobalData.GlobalLanguage.password;
			label3.Text = GlobalData.GlobalLanguage.type;
			ensure.Text = GlobalData.GlobalLanguage.ensure;
			prompt.Text = GlobalData.GlobalLanguage.admin_forbid;
		}
	}
}
