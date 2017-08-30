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
	public partial class ChangeUserAuthor : Form
	{
		public User user { get; set; }
		public ChangeUserAuthor()
		{
			InitializeComponent();
			changeLanguage();
		}
		private void cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Hide();
		}

		private void ChangeUserAuthor_Load(object sender, EventArgs e)
		{
			if (user.programs == null)
			{
				var tmp = new UserProgram(user);
				user.programs = tmp.programs;
			}
			checkedListBox1.Items.Clear();
			var tmpp =new UserProgram(new User { userClass = User.UserClass.Admin });
			foreach (var p in tmpp.programs)
			{
				checkedListBox1.Items.Add(UserProgram.DisplayProgram(p));
			}
			foreach (var p in user.programs)
			{
				checkedListBox1.SetItemChecked(p,true);
			}
			if (user.name.Equals("Admin"))
			{
				checkedListBox1.Enabled = false;
				prompt.Show();
			}
			else
			{
				prompt.Hide();
			}
		}

		private void ensure_Click(object sender, EventArgs e)
		{
			if (!checkedListBox1.GetItemChecked(0))
				checkedListBox1.SetItemChecked(0, true);
			user.programs = new List<int>();
		
			for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
				if (checkedListBox1.GetItemChecked(i))
				{
					user.programs.Add(i);
				}
			}
			
			if (InitData.users == null)
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.user_not_exist);
			}
			else
			{
				if (InitData.users.Any(u => u.name == user.name))
				{
					new UserProgram(user);
					if (szwlForm.mainForm.dm.updateUser(user))
					{
						InitData.users = InitData.users.Select(u => u.name == user.name ? user : u).ToList();
						this.DialogResult = DialogResult.OK;
						dialog.MessageBox.Show(GlobalData.GlobalLanguage.set_succe);
						this.Close();
					}
				}
				else
				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.user_not_exist);
				}
			}
		}
		
		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.edit_user_permission;
			label1.Text = GlobalData.GlobalLanguage.permission;
			prompt.Text = GlobalData.GlobalLanguage.admin_permission_cannot_change;
			ensure.Text = GlobalData.GlobalLanguage.ensure;
			cancel.Text = GlobalData.GlobalLanguage.cancel;
		}
	}
}
