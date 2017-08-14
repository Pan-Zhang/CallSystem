using System;
using szwlFormsApplication.Models;
using System.Windows.Forms;

namespace szwlFormsApplication
{
	public partial class LogOnForm : Form
	{
		public static User currentUser = null;
		public static LogOnForm loginform = new LogOnForm();
		public LogOnForm()
		{
			InitializeComponent();
		}

		private void submit_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(username.Text) || String.IsNullOrWhiteSpace(password.Text))
			{
				MessageBox.Show("信息禁止为空！","登录提示");
				clear();
				return;
			}
			if (ValidUser(username.Text, password.Text))
			{
				MessageBox.Show("欢迎登录本系统！", "消息提示");
				this.Hide();
				szwlForm.mainForm.Init();
				szwlForm.mainForm.ShowInTaskbar = true;
				szwlForm.mainForm.Show();
			}
			else
			{
				MessageBox.Show("用户名或密码不正确！", "消息提示");
				clear();
			}
		}
		private void cancel_Click(object sender, EventArgs e)
		{
			clear();
		}
		public bool ValidUser(string username, string password)
		{
			if (String.Equals(username, "Admin") && String.Equals(password, "123"))
			{
				currentUser = new User { name = "Admin", pass = "123" };
				return true;
			}
			return false;
		}
		public void clear()
		{
			username.Clear();
			password.Clear();
			username.Focus();
		}
	}
}
