using System;
using szwlFormsApplication.Models;
using szwlFormsApplication.CommonFunc;
using szwlFormsApplication.Language;
using System.Linq;
using System.Configuration;
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
			InitData.Clear();
			if (String.IsNullOrWhiteSpace(username.Text) || String.IsNullOrWhiteSpace(password.Text))
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.empty_warn, GlobalData.GlobalLanguage.prompt);
				clear();
				return;
			}
			var result = ValidUser(username.Text, password.Text);
			if (result.Item1)
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.welcome, GlobalData.GlobalLanguage.prompt);
				this.Hide();
				szwlForm.mainForm.Init();
				szwlForm.mainForm.ShowInTaskbar = true;
				szwlForm.mainForm.Show();
			}
			else
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.login_error, GlobalData.GlobalLanguage.prompt);
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
						return Tuple.Create(false, GlobalData.GlobalLanguage.password_wrong);
					}
				}
				else
				{
					return Tuple.Create(false, GlobalData.GlobalLanguage.user_not_exist);
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
			if (ChangeAppConfig.getValueFromKey(GlobalData.LANGUAGE).Equals(GlobalData.ENGLISH))
			{
				comboBox1.SelectedIndex = 0;
			}
			else
			{
				comboBox1.SelectedIndex = 1;
			}
			changeLanguage();
		}

		public const int WM_SYSCOMMAND = 0x0112;
		//winuser.h文件中有SC_...的定义
		public const int SC_CLOSE = 0xF060;
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == WM_SYSCOMMAND && ((int)m.WParam == SC_CLOSE))
			{
				szwlForm.mainForm.isStop = true;
				szwlForm.mainForm.closeCom();
				Application.Exit();
			}
			base.WndProc(ref m);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex == 0)
			{
				ChangeAppConfig.ChangeConfig(GlobalData.LANGUAGE, GlobalData.ENGLISH);
			}
			else
			{
				ChangeAppConfig.ChangeConfig(GlobalData.LANGUAGE, GlobalData.CHINESE);
			}
			GlobalData.CHANGE = true;
			changeLanguage();
		}
	}
}
