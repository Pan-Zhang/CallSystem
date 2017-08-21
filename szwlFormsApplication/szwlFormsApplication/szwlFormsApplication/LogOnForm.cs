﻿using System;
using szwlFormsApplication.Models;
using System.Windows.Forms;
using szwlFormsApplication.CommonFunc;
using szwlFormsApplication.Language;
using System.Linq;

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
			InitData.Clear();
			if (String.IsNullOrWhiteSpace(username.Text) || String.IsNullOrWhiteSpace(password.Text))
			{
				MessageBox.Show(GlobalData.GlobalLanguage.empty_warn, GlobalData.GlobalLanguage.prompt);
				clear();
				return;
			}
			var result = ValidUser(username.Text, password.Text);
			if (result.Item1)
			{
				MessageBox.Show(GlobalData.GlobalLanguage.welcome, GlobalData.GlobalLanguage.prompt);
				this.Hide();
				szwlForm.mainForm.Init();
				szwlForm.mainForm.ShowInTaskbar = true;
				szwlForm.mainForm.Show();
			}
			else
			{
				MessageBox.Show(GlobalData.GlobalLanguage.login_error, GlobalData.GlobalLanguage.prompt);
				clear();
			}
		}
		private void cancel_Click(object sender, EventArgs e)
		{
			clear();
		}
		public Tuple<bool, string> ValidUser(string username, string password)
		{
			InitData.users = szwlForm.mainForm.dm.selectUser();
			if (InitData.users == null || InitData.users.Count == 0 || InitData.users.All(u => u.name != "Admin"))
			{
				szwlForm.mainForm.dm.insertUser(new User { name = "Admin", pass = "123", userClass = User.UserClass.Admin });
				InitData.users.Add(new User { name = "Admin", pass = "123", userClass = User.UserClass.Admin });

			}
			if (String.Equals(username, "Admin") && String.Equals(password, InitData.users.Where(u => u.name == "Admin").FirstOrDefault().pass))
			{
				currentUser = InitData.users.Where(u => u.name == "Admin").FirstOrDefault();
				return Tuple.Create(true, default(string));
			}
			else
			{
				if (InitData.users.Any(u => u.name == username))
				{
					if (InitData.users.Any(u => u.pass == password))
					{
						currentUser = InitData.users.Where(u => u.name == username).FirstOrDefault();
						return Tuple.Create(true, default(string));
					}
					else
					{
						return Tuple.Create(false, "用户密码不正确！");
					}
				}
				else
				{
					return Tuple.Create(false, "用户不存在！");
				}
			}
		}
		public void clear()
		{
			username.Clear();
			password.Clear();
			username.Focus();
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.welcome_use;
			groupBox1.Text = GlobalData.GlobalLanguage.user_login;
			label1.Text = GlobalData.GlobalLanguage.username;
			label2.Text = GlobalData.GlobalLanguage.password;
			submit.Text = GlobalData.GlobalLanguage.login;
			cancel.Text = GlobalData.GlobalLanguage.cancel;
		}

		private void LogOnForm_Load(object sender, EventArgs e)
		{
			changeLanguage();
		}
	}
}
