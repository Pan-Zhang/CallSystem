﻿using System;
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
	public partial class AddUserForm : Form
	{
		DBManager dm;

		public AddUserForm()
		{
			InitializeComponent();
		}

		private void AddUserForm_Load(object sender, EventArgs e)
		{
			dm = new DBManager();
			prompt.Hide();
		}

		private void ensure_Click(object sender, EventArgs e)
		{
			Admin admin = new Admin();
			admin.name = username.Text;
			admin.pass = password.Text;
			if (username.Text.Equals("admin"))
			{
				prompt.Show();
			}
			else if (dm.insertUser(admin))
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}