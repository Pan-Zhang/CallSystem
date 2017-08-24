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

namespace szwlFormsApplication
{
	public partial class aboutForm : Form
	{
		public aboutForm()
		{
			InitializeComponent();
			changeLanguage();
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.about_setting;
			label1.Text = GlobalData.GlobalLanguage.wireles_system;
			label2.Text = GlobalData.GlobalLanguage.Version;
			label3.Text = GlobalData.GlobalLanguage.right;
			label4.Text = GlobalData.GlobalLanguage.Copyright;
		}
	}
}
