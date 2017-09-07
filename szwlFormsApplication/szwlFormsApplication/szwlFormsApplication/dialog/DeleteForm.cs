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
	public partial class DeleteForm : Form
	{
		public DeleteForm()
		{
			InitializeComponent();
		}

		private void DeleteForm_Load(object sender, EventArgs e)
		{
			radioButton1.Text = GlobalData.GlobalLanguage.delete_this_line;
			radioButton2.Text = GlobalData.GlobalLanguage.delete_all_line;
			this.Text = GlobalData.GlobalLanguage.prompt;
			button1.Text = GlobalData.GlobalLanguage.ensure;
			button2.Text = GlobalData.GlobalLanguage.cancel;
			radioButton1.Checked = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				this.DialogResult = DialogResult.Retry;
			}
			else
			{
				this.DialogResult = DialogResult.Ignore;
			}
			
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
