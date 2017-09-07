using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szwlFormsApplication.Language;
using szwlFormsApplication.Models;

namespace szwlFormsApplication.dialog
{
	public partial class UpdatePassForm : Form
	{
		public User user { get; set; }
		public UpdatePassForm()
		{
			InitializeComponent();
			changeLanguage();
		}

		private void ensure_Click(object sender, EventArgs e)
		{
			if (!oldpw.Text.Equals(user.pass))
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.old_pwd_wrong);
			}
			else
			{
				user.pass = newpw.Text;
				if (szwlForm.mainForm.dm.updateUser(user))
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
		}

		private void cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void UpdatePassForm_Load(object sender, EventArgs e)
		{
			
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.update_pwd;
			label1.Text = GlobalData.GlobalLanguage.old_pwd;
			label2.Text = GlobalData.GlobalLanguage.new_pwd;
			ensure.Text = GlobalData.GlobalLanguage.ensure;
			cancel.Text = GlobalData.GlobalLanguage.cancel;
		}
	}
}
