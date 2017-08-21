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

namespace szwlFormsApplication.dialog
{
	public partial class ExitForm : Form
	{
		public ExitForm()
		{
			
			InitializeComponent();
			changeLanguage();
			radioButton1.Checked = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				this.DialogResult = DialogResult.OK;
			}
			else
			{
				this.DialogResult = DialogResult.Yes;
			}
			
			this.Close();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.exist_app;
			label1.Text = GlobalData.GlobalLanguage.ensure_operation;
			radioButton1.Text = GlobalData.GlobalLanguage.exist_app;
			radioButton2.Text = GlobalData.GlobalLanguage.minimal;
			button1.Text = GlobalData.GlobalLanguage.ensure;
			button2.Text = GlobalData.GlobalLanguage.cancel;
		}
	}
}
