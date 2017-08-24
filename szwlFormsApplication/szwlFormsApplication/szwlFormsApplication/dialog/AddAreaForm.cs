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
	public partial class AddAreaForm : Form
	{
		public AddAreaForm()
		{
			InitializeComponent();
			changeLanguage();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Callzone zone = new Callzone();
			zone.name = areaName.Text;
			if (string.IsNullOrWhiteSpace(zone.name))
			{
				MessageBox.Show(GlobalData.GlobalLanguage.zone_null);
				return;
			}

			if (InitData.list_zone == null)
				InitData.list_zone = new List<Callzone>();
			if (InitData.list_zone.Any(z => z.name == zone.name))
			{
				MessageBox.Show(GlobalData.GlobalLanguage.zone_had_exist);
				return;
			}
			if (szwlForm.mainForm.dm.insertZone(zone))
			{
				InitData.list_zone = szwlForm.mainForm.dm.selectZone();
				MessageBox.Show(GlobalData.GlobalLanguage.add_success);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Hide();
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.add_area;
			label1.Text = GlobalData.GlobalLanguage.Caller_zone;
			button1.Text = GlobalData.GlobalLanguage.ensure;
			button2.Text = GlobalData.GlobalLanguage.cancel;
		}
	}
}
