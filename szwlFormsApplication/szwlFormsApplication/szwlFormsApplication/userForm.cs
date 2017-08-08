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
using szwlFormsApplication.Models;

namespace szwlFormsApplication
{
	public partial class userForm : Form
	{
		List<Admin> list;
		DBManager dm;

		public userForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void userForm_Load(object sender, EventArgs e)
		{
			dm = new DBManager();
			list = dm.seletUser();

			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.DataSource = list;
			this.dataGridView1.Refresh();
		}

		private void userAddbtn_Click(object sender, EventArgs e)
		{
			AddUserForm form = new AddUserForm();
			DialogResult rt = form.ShowDialog();
			if(rt == DialogResult.OK)
			{
				list = dm.seletUser();

				this.dataGridView1.AutoGenerateColumns = false;
				this.dataGridView1.DataSource = list;
				this.dataGridView1.Refresh();
			}
		}

		private void userUpdatebtn_Click(object sender, EventArgs e)
		{
			ChangeUser form = new ChangeUser();
			Admin admin = list[dataGridView1.CurrentRow.Index];
			form.admin = admin;
			DialogResult rt = form.ShowDialog();
			if (rt == DialogResult.OK)
			{
				list = dm.seletUser();

				this.dataGridView1.AutoGenerateColumns = false;
				this.dataGridView1.DataSource = list;
				this.dataGridView1.Refresh();
			}
		}

		private void userDeletebtn_Click(object sender, EventArgs e)
		{
			Admin admin = list[dataGridView1.CurrentRow.Index];
			if (admin.name.Equals("admin"))
			{
				DialogResult dr = MessageBox.Show("超级管理员用户不能被删除！",
								 " 提示",
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
				DialogResult dr = MessageBox.Show(" 你确定删除用户：" + admin.name + "？",
								 " 提示",
								MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes)
				{
					if (dm.deleteUser(admin))
					{
						list = dm.seletUser();
						this.dataGridView1.AutoGenerateColumns = false;
						this.dataGridView1.DataSource = list;
						this.dataGridView1.Refresh();
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

		}

		private void userUpdatePwbtn_Click(object sender, EventArgs e)
		{
			UpdatePassForm form = new UpdatePassForm();
			form.ShowDialog();
		}

		private void userclearDatabtn_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("是否清楚这些数据？",
								 " 提示",
								MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{

			}
		}
	}
}
