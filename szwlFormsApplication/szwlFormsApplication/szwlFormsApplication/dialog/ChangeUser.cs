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
		DBManager dm;

		public ChangeUser()
		{
			InitializeComponent();
		}

		private void ensure_Click(object sender, EventArgs e)
		{
			admin.name = username.Text;
			admin.pass = password.Text;
			this.DialogResult = DialogResult.OK;
			if(szwlForm.mainForm.dm.updateUser(admin)){
				this.Hide();
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
			if (admin.name.Equals("admin"))
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
