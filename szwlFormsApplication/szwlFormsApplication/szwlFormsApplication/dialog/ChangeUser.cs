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
	public partial class ChangeUser : Form
	{
		public User admin { get; set; }

		public ChangeUser()
		{
			InitializeComponent();
			userClassComboBox.Items.Add(User.UserClass.Admin.ToString());
			userClassComboBox.Items.Add(User.UserClass.normal.ToString());
		}

		private void ensure_Click(object sender, EventArgs e)
		{
			admin.name = username.Text;
			admin.pass = password.Text;
			admin.userClass = (User.UserClass)userClassComboBox.SelectedIndex;
			new UserProgram(admin);
			this.DialogResult = DialogResult.OK;
			if (InitData.users == null)
			{
				MessageBox.Show("该用户不存在不能修改！");
			}
 			else 
			{
				if (InitData.users.Any(u => u.name == admin.name))
				{
					if (szwlForm.mainForm.dm.updateUser(admin))
					{
						InitData.users = InitData.users.Select(u => u.name == admin.name ? admin : u).ToList();
						MessageBox.Show("该用户修改成功！");
						this.Hide();
					}
				}
				else
				{
					MessageBox.Show("该用户不存在不能修改！");
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
	}
}
