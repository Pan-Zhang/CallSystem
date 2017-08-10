using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szwlFormsApplication.CommonFunc;
using szwlFormsApplication.Models;
using static szwlFormsApplication.CommonFunc.Common;

namespace szwlFormsApplication
{
	public partial class systemSettingForm : Form
	{
		public systemSettingForm()
		{
			InitializeComponent();
			companyNametextBox.Text = ConfigurationManager.AppSettings["CompanyName"];
			//string[] comNums = Common.MulGetHardwareInfo(HardwareEnum.Win32_SerialPort, "Name");
			string[] comNums = System.IO.Ports.SerialPort.GetPortNames();
			COMcomboBox.DataSource = comNums;

			List<int> databytes = new List<int>();
			for (int i = 0; i < 10; i++)
			{
				databytes.Add(i);
			}
			dataComboBox.DataSource = databytes;
			List<int> bundRates = new List<int>();
			for (int i = 0; i < 10; i++)
			{
				bundRates.Add(i);
			}
			bundRateComboBox.DataSource = bundRates;
			List<int> stopbytes = new List<int>();
			for (int i = 0; i < 10; i++)
			{
				stopbytes.Add(i);
			}
			stopComboBox.DataSource = stopbytes;
			List<int> duration = new List<int>() { 5, 10 };
			TimeSpancomboBox.DataSource = duration;
		}


		private void ssOkBtn_Click(object sender, EventArgs e)
		{
			if (this.SSControl.SelectedIndex == 0)//公司名称设置
			{
				if (String.IsNullOrWhiteSpace(companyNametextBox.Text))
				{
					companyNametextBox.Text = ConfigurationManager.AppSettings["CompanyName"];
				}
				else
				{
					ChangeAppConfig.ChangeConfig("CompanyName", companyNametextBox.Text);
				}
				szwlForm.mainForm.Text = string.Format("{0}无线呼叫系统", companyNametextBox.Text);
				MessageBox.Show("设置成功！");
			}
			else if (this.SSControl.SelectedIndex == 1)//串口设置
			{
				InitData.com.COMID = COMcomboBox.SelectedValue.ToString();
				InitData.com.DataBytes = Convert.ToInt32(dataComboBox.SelectedValue.ToString());
				InitData.com.BaudRate = Convert.ToInt32(bundRateComboBox.SelectedValue.ToString());
				InitData.com.StopByte = Convert.ToInt32(stopComboBox.SelectedValue.ToString());
				InitData.com.duration = Convert.ToInt32(TimeSpancomboBox.SelectedValue.ToString());
				MessageBox.Show("设置成功！");
			}
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
	}
}
