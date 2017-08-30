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
	public partial class EditAreaForm : Form
	{
		public Callzone zone { get; set; }
		public EditAreaForm()
		{
			InitializeComponent();
			changeLanguage();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(oldareaname.Text))
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.not_choose);
				return;
			}

			if (InitData.list_zone == null || InitData.list_zone.Count == 0)
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.no_data_to_edit);
				return;
			}
			if (InitData.list_zone.Any(z => z.Id == zone.Id))
			{
				if (textBox1.Text == oldareaname.Text)
					return;
				if (InitData.list_zone.Where(z=>z.name!=oldareaname.Text).Any(z => z.name == textBox1.Text))
				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.caller_exist);
					return;
				}
				zone.name = textBox1.Text;
				if (szwlForm.mainForm.dm.updateZone(zone))
				{
					this.DialogResult = DialogResult.OK;
					InitData.list_zone = InitData.list_zone.Select(z => z.Id == zone.Id ? zone : z).ToList();
					this.Hide();
				}
				else
				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.edit_failed);
					return;
				}
			}
			else
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.zone_eixst);
				return;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void EditAreaForm_Load(object sender, EventArgs e)
		{
			oldareaname.Text=textBox1.Text = zone.name;
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.edit_zone;
			label1.Text = GlobalData.GlobalLanguage.Caller_zone;
			button1.Text = GlobalData.GlobalLanguage.ensure;
			button2.Text = GlobalData.GlobalLanguage.cancel;
		}
	}
}
