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
	public partial class ChangeUser : Form
	{
		public User admin { get; set; }

		public ChangeUser()
		{
			InitializeComponent();
			userClassComboBox.Items.Add(User.UserClass.Admin.ToString());
			userClassComboBox.Items.Add(User.UserClass.normal.ToString());
			changeLanguage();
		}

		private void ensure_Click(object sender, EventArgs e)
		{
			admin.name = username.Text;
			admin.pass = password.Text;
			admin.userClass = (User.UserClass)userClassComboBox.SelectedIndex;
			new UserProgram(admin);
			if (InitData.users == null)
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.user_no_exist);
			}
			else if (username.Text.Equals("Admin")&&admin.id!=1)
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.admin_forbid);
			}
 			else 
			{
				if (InitData.users.Any(u => u.name == admin.name))
				{
					if (szwlForm.mainForm.dm.updateUser(admin))
					{
						this.DialogResult = DialogResult.OK;
						InitData.users = InitData.users.Select(u => u.name == admin.name ? admin : u).ToList();
						dialog.MessageBox.Show(GlobalData.GlobalLanguage.set_succe);
						this.Hide();
					}
				}
				else
				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.user_no_exist);
				}
			}
		}

		private void cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Hide();
		}

		private void ChangeUser_Load(object sender, EventArgs e)
		{
			username.Text = admin.name;
			password.Text = admin.pass;
			userClassComboBox.SelectedIndex = (int)admin.userClass;
			if (admin.name.Equals("Admin"))
			{
				username.Enabled = false;
				prompt.Show();
			}
			else
			{
				prompt.Hide();
			}
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.change_user;
			label1.Text = GlobalData.GlobalLanguage.username;
			label2.Text = GlobalData.GlobalLanguage.password;
			label3.Text = GlobalData.GlobalLanguage.type;
			ensure.Text = GlobalData.GlobalLanguage.ensure;
			cancel.Text = GlobalData.GlobalLanguage.cancel;
			prompt.Text = GlobalData.GlobalLanguage.admin_forbid_edit;
		}
	}
}
