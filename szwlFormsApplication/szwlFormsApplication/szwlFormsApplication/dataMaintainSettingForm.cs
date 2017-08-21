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

namespace szwlFormsApplication
{
	public partial class dataMaintainSettingForm : Form
	{
		DBManager dm;
		public dataMaintainSettingForm()
		{
			InitializeComponent();
			changeLanguage();
		}

		private void dataMaintainSettingForm_Load(object sender, EventArgs e)
		{
			dm = new DBManager();
		}

		private void dataInitOK_Click(object sender, EventArgs e)
		{
			int index = comboBox1.SelectedIndex;
			string mess = "";
			switch (index)
			{
				case 0:
					mess = GlobalData.GlobalLanguage.delete_all;
					break;

				case 1:
					mess = GlobalData.GlobalLanguage.delete_caller;
					break;

				case 2:
					mess = GlobalData.GlobalLanguage.delete_zone;
					break;

				case 3:
					mess = GlobalData.GlobalLanguage.delete_employee;
					break;

				case 4:
					mess = GlobalData.GlobalLanguage.delete_user;
					break;

				case 5:
					mess = GlobalData.GlobalLanguage.delete_record;
					break;

				case 6:
					mess = GlobalData.GlobalLanguage.delete_header;
					break;

				default:
					this.Hide();
					return;
			}

			DialogResult dr = MessageBox.Show(mess, GlobalData.GlobalLanguage.prompt, MessageBoxButtons.OKCancel);
			if (dr == DialogResult.OK)
			{
				switch (index)
				{
					case 0:
						dm.clearAll();
						break;

					case 1:
						dm.clearCaller();
						break;

					case 2:
						dm.clearZone();
						break;

					case 3:
						dm.clearEmployee();
						break;

					case 4:
						dm.clearUser();
						break;

					case 5:
						dm.clearRecodrd();
						break;

					case 6:
						dm.clearTableHead();
						break;
				}
			}
			this.Hide();
		}

		private void changeLanguage()
		{
			dataInitLabel.Text = GlobalData.GlobalLanguage.Data_initialization;
			dataInitOK.Text = GlobalData.GlobalLanguage.ensure;
			this.Text = GlobalData.GlobalLanguage.about_setting;
			label1.Text = GlobalData.GlobalLanguage.watch_out;

			comboBox1.Items[0] = GlobalData.GlobalLanguage.all_message;
			comboBox1.Items[1] = GlobalData.GlobalLanguage.all_caller;
			comboBox1.Items[2] = GlobalData.GlobalLanguage.all_zone;
			comboBox1.Items[3] = GlobalData.GlobalLanguage.all_employee;
			comboBox1.Items[4] = GlobalData.GlobalLanguage.all_user;
			comboBox1.Items[5] = GlobalData.GlobalLanguage.all_record;
			comboBox1.Items[6] = GlobalData.GlobalLanguage.all_header;


		}
	}
}
