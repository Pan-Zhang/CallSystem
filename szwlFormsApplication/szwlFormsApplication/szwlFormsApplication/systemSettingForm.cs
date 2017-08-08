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
using static szwlFormsApplication.CommonFunc.Common;

namespace szwlFormsApplication
{
	public partial class systemSettingForm : Form
	{
		public systemSettingForm()
		{
			InitializeComponent();

			//string[] comNums = Common.MulGetHardwareInfo(HardwareEnum.Win32_SerialPort, "Name");

			initCom();
		}

		private void COMcomboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void ssOkBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void initCom()
		{
			string[] comNums = System.IO.Ports.SerialPort.GetPortNames();
			DataTable dt = new DataTable();//创建一个数据集
			dt.Columns.Add("id", typeof(String));
			dt.Columns.Add("val", typeof(String));
			for (int i = 0; i < comNums.Length; i++)
			{
				DataRow dr = dt.NewRow();
				dr[0] = i;
				dr[1] = comNums[i];

				dt.Rows.Add(dr);
			}
			COMcomboBox.DataSource = dt;
			COMcomboBox.DisplayMember = "val";
			COMcomboBox.ValueMember = "id";
		}

		private void undoBtn_Click(object sender, EventArgs e)
		{
			UndocolorDialog.ShowDialog();
			Color c = UndocolorDialog.Color;
			wait_btn.BackColor = c;
		}

		private void timeOutBtn_Click(object sender, EventArgs e)
		{
			timeOutcolorDialog.ShowDialog();
			Color c = timeOutcolorDialog.Color;
			timeout_btn.BackColor = c;
		}

		private void completeBtn_Click(object sender, EventArgs e)
		{
			completeColorDialog.ShowDialog();
			Color c = completeColorDialog.Color;
			finish_btn.BackColor = c;
		}

		private void trackBar3_Scroll(object sender, EventArgs e)
		{
			string text = trackBar3.Value.ToString();
			number.Text = text;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
