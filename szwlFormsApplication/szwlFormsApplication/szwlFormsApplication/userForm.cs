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
using szwlFormsApplication.dialog;
using szwlFormsApplication.Language;
using szwlFormsApplication.Models;

namespace szwlFormsApplication
{
	public partial class userForm : Form
	{
		public userForm()
		{
			InitializeComponent();
			changeLanguage();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void userForm_Load(object sender, EventArgs e)
		{
			InitData.AddData(dataGridView1, InitData.users);
			//this.dataGridView1.AutoGenerateColumns = false;
			//this.dataGridView1.DataSource = InitData.users;
			//this.dataGridView1.Refresh();
		}

		private void userAddbtn_Click(object sender, EventArgs e)
		{
			AddUserForm form = new AddUserForm();
			DialogResult rt = form.ShowDialog();
			if (rt == DialogResult.OK)
			{
				InitData.AddData(dataGridView1, InitData.users);
				//this.dataGridView1.AutoGenerateColumns = false;
				//this.dataGridView1.DataSource = InitData.users;
				//this.dataGridView1.Refresh();
			}
		}

		private void userUpdatebtn_Click(object sender, EventArgs e)
		{
			ChangeUser form = new ChangeUser();
			User admin = InitData.users[dataGridView1.CurrentRow.Index];
			form.admin = admin;
			DialogResult rt = form.ShowDialog();
			if (rt == DialogResult.OK)
			{
				InitData.AddData(dataGridView1, InitData.users);
				//this.dataGridView1.AutoGenerateColumns = false;
				//this.dataGridView1.DataSource = InitData.users;
				//this.dataGridView1.Refresh();
			}
		}
		private void userDeletebtn_Click(object sender, EventArgs e)
		{
			User admin = InitData.users[dataGridView1.CurrentRow.Index];
			if (admin == null)
			{
				MessageBox.Show(GlobalData.GlobalLanguage.not_choose);
				return;
			}
			if (InitData.users == null && InitData.users.Count == 0)
			{
				MessageBox.Show(GlobalData.GlobalLanguage.user_no_exist);
				return;
			}

			if (admin.id==1)
			{
				DialogResult dr = MessageBox.Show(GlobalData.GlobalLanguage.Admin_cannot_delete,
								 GlobalData.GlobalLanguage.prompt,
								MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes)
				{

				}
				else
				{
					//do nothing
				}
			}
			else
			{
				DialogResult dr = MessageBox.Show(GlobalData.GlobalLanguage.want_delete_user + admin.name + "？",
								 GlobalData.GlobalLanguage.prompt,
								MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes)
				{
					if (InitData.users.Any(u => u.name == admin.name))
					{
						if (szwlForm.mainForm.dm.deleteUser(admin))
						{
							InitData.users.RemoveAll(u=>u.name== admin.name);
							InitData.AddData(dataGridView1, InitData.users);
							//this.dataGridView1.AutoGenerateColumns = false;
							//this.dataGridView1.DataSource = InitData.users;
							//this.dataGridView1.Refresh();
							MessageBox.Show(GlobalData.GlobalLanguage.delete_succe);
						}
					}
					else
					{
						MessageBox.Show(GlobalData.GlobalLanguage.user_not_exist);
						return;
					}
				}
				else
				{
					//do nothing

				}
			}
		}

		private void userAuhtoritybtn_Click(object sender, EventArgs e)
		{
			ChangeUserAuthor form = new ChangeUserAuthor();
			User user = InitData.users[dataGridView1.CurrentRow.Index];
			form.user = user;
			DialogResult rt = form.ShowDialog();
			if (rt == DialogResult.OK)
			{
				InitData.AddData(dataGridView1, InitData.users);
				//this.dataGridView1.AutoGenerateColumns = false;
				//this.dataGridView1.DataSource = InitData.users;
				//this.dataGridView1.Refresh();
			}
		}

		private void userUpdatePwbtn_Click(object sender, EventArgs e)
		{
			UpdatePassForm form = new UpdatePassForm();
			form.ShowDialog();
		}

		private void userclearDatabtn_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show(GlobalData.GlobalLanguage.want_to_clear,
								 GlobalData.GlobalLanguage.prompt,
								MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				szwlForm.mainForm.dm.clearUser();
				MessageBox.Show(GlobalData.GlobalLanguage.clear_success);
				InitData.ClearData(this.dataGridView1, InitData.users);
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.user_setting;

			dataGridView1.Columns[0].HeaderText = GlobalData.GlobalLanguage._username;
			dataGridView1.Columns[1].HeaderText = GlobalData.GlobalLanguage._password;
			dataGridView1.Columns[2].HeaderText = GlobalData.GlobalLanguage.user_type;

			userAddbtn.Text = GlobalData.GlobalLanguage.add_user;
			userUpdatebtn.Text = GlobalData.GlobalLanguage.edit_user;
			userDeletebtn.Text = GlobalData.GlobalLanguage.del_user;
			userAuhtoritybtn.Text = GlobalData.GlobalLanguage.authority;
			userUpdatePwbtn.Text = GlobalData.GlobalLanguage.update_pwd;
			userclearDatabtn.Text = GlobalData.GlobalLanguage.clear_data;
		}
	}
}
