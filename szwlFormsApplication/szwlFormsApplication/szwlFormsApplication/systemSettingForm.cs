using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
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

			//List<string> COMs = Common.GetComNum().Select(c => string.Format("COM{0}", c)).ToList();
			List<string> COMs = SerialPort.GetPortNames().ToList();
			List<int> databytes = new List<int>() { 5, 6, 7, 8 };
			List<int> bundRates = new List<int>() { 2400, 4800, 9600, 19200, 38400 };
			List<double> stopbytes = new List<double>() { 1, 1.5, 2 };
			List<int> duration = new List<int>() { 5, 10 };
			if (!COMs.Contains(InitData.com.COMID))
				COMs.Add(InitData.com.COMID);
			COMcomboBox.DataSource = COMs;
			COMcomboBox.SelectedItem = InitData.com.COMID;
			if (!databytes.Contains(InitData.com.DataBits))
				databytes.Add(InitData.com.DataBits);
			dataComboBox.DataSource = databytes;
			dataComboBox.SelectedItem = InitData.com.DataBits;
			if (!bundRates.Contains(InitData.com.BaudRate))
				bundRates.Add(InitData.com.BaudRate);
			bundRateComboBox.DataSource = bundRates;
			bundRateComboBox.SelectedItem = InitData.com.BaudRate;
			if (!stopbytes.Contains(InitData.com.StopBit))
				stopbytes.Add(InitData.com.StopBit);
			stopComboBox.DataSource = stopbytes;
			stopComboBox.SelectedItem = InitData.com.StopBit;
			if (!duration.Contains(InitData.com.duration))
				duration.Add(InitData.com.duration);
			TimeSpancomboBox.DataSource = duration;
			TimeSpancomboBox.SelectedItem = InitData.com.duration;

			if (InitData.callbtnsetting != null && InitData.callbtnsetting.callBtnSettings != null)
			{
				if (InitData.callbtnsetting.callBtnSettings.ContainsKey(CallBtnSetting.CallBtnType.A))
					AtextBox.Text = InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.A];
				if (InitData.callbtnsetting.callBtnSettings.ContainsKey(CallBtnSetting.CallBtnType.B))
					BtextBox.Text = InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.B];
				if (InitData.callbtnsetting.callBtnSettings.ContainsKey(CallBtnSetting.CallBtnType.C))
					CtextBox.Text = InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.C];
				if (InitData.callbtnsetting.callBtnSettings.ContainsKey(CallBtnSetting.CallBtnType.D))
					DtextBox.Text = InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.D];
				if (InitData.callbtnsetting.callBtnSettings.ContainsKey(CallBtnSetting.CallBtnType.E))
					EtextBox.Text = InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.E];
				if (InitData.callbtnsetting.callBtnSettings.ContainsKey(CallBtnSetting.CallBtnType.F))
					FtextBox.Text = InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.F];
			}
			if (InitData.timecolor != null)
			{
				Color c = Color.FromArgb(InitData.timecolor.WaitTime);
				wait_btn.BackColor = c;
				c = Color.FromArgb(InitData.timecolor.TimeOutTime);
				timeout_btn.BackColor = c;
				c = Color.FromArgb(InitData.timecolor.FinishedTime);
				finish_btn.BackColor = c;
			}
			if (InitData.orderby != null)
			{
				if (InitData.orderby.ordertype == OrderBy.OrderType.ASC)
					ASCradioButton.Checked = true;
				else
					DESradioButton.Checked = true;
			}
			trackBar3.Value = InitData.TimeOut;
			number.Text = trackBar3.Value.ToString();
			trackBar3.Update();
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

				{
					MessageBox.Show("设置成功！");
					this.Close();
				}
			}
			else if (this.SSControl.SelectedIndex == 1)//串口设置
			{
				szwlForm.mainForm.closeCom();
				InitData.com.COMID = COMcomboBox.SelectedValue.ToString();
				InitData.com.DataBits = Convert.ToInt32(dataComboBox.SelectedValue.ToString());
				InitData.com.BaudRate = Convert.ToInt32(bundRateComboBox.SelectedValue.ToString());
				InitData.com.StopBit = Convert.ToDouble(stopComboBox.SelectedValue.ToString());
				InitData.com.duration = Convert.ToInt32(TimeSpancomboBox.SelectedValue.ToString());
				szwlForm.mainForm._server.open(InitData.com);
				if (InitData.SetComInfo())
				{
					MessageBox.Show("设置成功！");
					this.Close();
				}
				else
					MessageBox.Show("设置失败！");
			}
			else if (this.SSControl.SelectedIndex == 2)//呼叫按钮功能设置
			{
				InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.A] = AtextBox.Text;
				InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.B] = BtextBox.Text;
				InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.C] = CtextBox.Text;
				InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.D] = DtextBox.Text;
				InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.E] = EtextBox.Text;
				InitData.callbtnsetting.callBtnSettings[CallBtnSetting.CallBtnType.F] = FtextBox.Text;
				if (InitData.SetCallBtnSetting())
				{
					MessageBox.Show("设置成功！");
					this.Close();
				}
				else
					MessageBox.Show("设置失败！");
			}
			else if (this.SSControl.SelectedIndex == 3)//呼叫按钮功能设置
			{
				InitData.timecolor.WaitTime = wait_btn.BackColor.ToArgb();
				InitData.timecolor.FinishedTime = finish_btn.BackColor.ToArgb();
				InitData.timecolor.TimeOutTime = timeout_btn.BackColor.ToArgb();
				InitData.orderby.ordertype = (OrderBy.OrderType)(ASCradioButton.Checked ? 0 : 1);
				if (InitData.SetTimeColor() && InitData.SetOrdreBy())
				{
					MessageBox.Show("设置成功！");
					this.Close();
				}
				else
					MessageBox.Show("设置失败！");
			}
			else
			{
				InitData.TimeOut = trackBar3.Value;
				if (InitData.SetTimeOut())
				{
					MessageBox.Show("设置成功！");
					this.Close();
				}
				else
					MessageBox.Show("设置失败！");
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
