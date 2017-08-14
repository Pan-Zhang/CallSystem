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

namespace szwlFormsApplication
{
	public partial class dataMaintainSettingForm : Form
	{
		DBManager dm;
		public dataMaintainSettingForm()
		{
			InitializeComponent();
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
					mess = "您确定希望删除所有信息？";
					break;

				case 1:
					mess = "您确定希望删除所有呼叫器信息？";
					break;

				case 2:
					mess = "您确定希望删除所有区域信息？";
					break;

				case 3:
					mess = "您确定希望删除所有员工信息？";
					break;

				case 4:
					mess = "您确定希望删除所有用户信息？";
					break;

				case 5:
					mess = "您确定希望删除所有呼叫记录？";
					break;

				case 6:
					mess = "您确定希望删除所有表头信息？";
					break;

				default:
					this.Hide();
					return;
			}

			DialogResult dr = MessageBox.Show(mess, "提示", MessageBoxButtons.OKCancel);
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
	}
}
