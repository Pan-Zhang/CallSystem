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
using szwlFormsApplication.Language;
using szwlFormsApplication.Models;
using static szwlFormsApplication.CommonFunc.Common;

namespace szwlFormsApplication
{
	public partial class systemSettingForm : Form
	{
		public systemSettingForm()
		{
			InitializeComponent();
			companyNametextBox.Text = ChangeAppConfig.getValueFromKey("CompanyName");
			//string[] comNums = Common.MulGetHardwareInfo(HardwareEnum.Win32_SerialPort, "Name");
			
			List<string> COMs = SerialPort.GetPortNames().ToList();
			List<int> databytes = new List<int>() { 5, 6, 7, 8 };
			List<int> bundRates = new List<int>() { 2400, 4800, 9600, 19200, 38400 };
			List<double> stopbytes = new List<double>() { 1, 1.5, 2 };
			List<int> duration = new List<int>() { 5, 10 };
			if (!COMs.Contains(InitData.com.COMID))
				COMs.Add(InitData.com.COMID);
			COMcomboBox.DataSource = COMs;
			if (InitData.com.COMID==null && COMs.Count>0)
			{
				COMcomboBox.SelectedIndex = 0;
			}
			else
			{
				COMcomboBox.SelectedItem = InitData.com.COMID;
			}
			
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

			changeLanguage();
			string unit = ChangeAppConfig.getValueFromKey("TimeUnit");
			if (unit.Equals("S") || unit.Equals("秒"))
			{
				unit_box.SelectedIndex = 0;
			}
			else if (unit.Equals("M") || unit.Equals("分"))
			{
				unit_box.SelectedIndex = 1;
			}
			else
			{
				unit_box.SelectedIndex = 2;
			}
		}

		private void ssOkBtn_Click(object sender, EventArgs e)
		{
			if (this.SSControl.SelectedIndex == 0)//公司名称设置
			{
				if (String.IsNullOrWhiteSpace(companyNametextBox.Text))
				{
					companyNametextBox.Text = ChangeAppConfig.getValueFromKey("CompanyName");
				}
				else
				{
					ChangeAppConfig.ChangeConfig("CompanyName", companyNametextBox.Text);
				}
				szwlForm.mainForm.Text = string.Format("{0}"+GlobalData.GlobalLanguage.Wireless_calling_system, companyNametextBox.Text);

				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.set_succe);
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
				szwlForm.mainForm._server.open(InitData.com);
				if (InitData.SetComInfo())
				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.set_succe);
					this.Close();
				}
				else
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.set_fail);
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
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.set_succe);
					this.Close();
				}
				else
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.set_fail);
			}
			else if (this.SSControl.SelectedIndex == 3)//呼叫按钮功能设置
			{
				InitData.timecolor.WaitTime = wait_btn.BackColor.ToArgb();
				InitData.timecolor.FinishedTime = finish_btn.BackColor.ToArgb();
				InitData.timecolor.TimeOutTime = timeout_btn.BackColor.ToArgb();
				InitData.orderby.ordertype = (OrderBy.OrderType)(ASCradioButton.Checked ? 0 : 1);
				if (InitData.SetTimeColor() && InitData.SetOrdreBy())
				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.set_succe);
					this.Close();
				}
				else
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.set_fail);
			}
			else
			{
				InitData.TimeOut = trackBar3.Value;
				if (InitData.SetTimeOut())
				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.set_succe);
					this.Close();
				}
				else
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.set_fail);
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

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.system_setting;

			SSControl.TabPages[0].Text = GlobalData.GlobalLanguage.company_name;
			SSControl.TabPages[1].Text = GlobalData.GlobalLanguage.com_setting;
			SSControl.TabPages[2].Text = GlobalData.GlobalLanguage.button_function;
			SSControl.TabPages[3].Text = GlobalData.GlobalLanguage.record_show;
			SSControl.TabPages[4].Text = GlobalData.GlobalLanguage.effective_time;

			companyNamelabel.Text = GlobalData.GlobalLanguage.name;
			ssOkBtn.Text = GlobalData.GlobalLanguage.ensure;
			label1.Text = GlobalData.GlobalLanguage.SerialPort;
			label2.Text = GlobalData.GlobalLanguage.data_bits;
			label3.Text = GlobalData.GlobalLanguage.baud_rate;
			label4.Text = GlobalData.GlobalLanguage.stop_bit;

			callOrderBygroupBox.Text = GlobalData.GlobalLanguage.sort;
			ASCradioButton.Text = GlobalData.GlobalLanguage.Ascending;
			DESradioButton.Text = GlobalData.GlobalLanguage.Descending;
			callInfoColorgroupBox.Text = GlobalData.GlobalLanguage.color;
			undolabel.Text = GlobalData.GlobalLanguage.waiting;
			completelabel.Text = GlobalData.GlobalLanguage.finish;
			timeOutlabel.Text = GlobalData.GlobalLanguage.overtime;
			undoBtn.Text = GlobalData.GlobalLanguage.setting;
			timeOutBtn.Text = GlobalData.GlobalLanguage.setting;
			completeBtn.Text = GlobalData.GlobalLanguage.setting;

			label12.Text = GlobalData.GlobalLanguage.Set_timeout;
			unit_box.Items[0] = GlobalData.GlobalLanguage.second;
			unit_box.Items[1] = GlobalData.GlobalLanguage.minute;
			unit_box.Items[2] = GlobalData.GlobalLanguage.hour;

			if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("A")))
			{
				AtextBox.Text = GlobalData.GlobalLanguage.Order;
			}
			if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("B")))
			{
				BtextBox.Text = GlobalData.GlobalLanguage.Call;
			}
			if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("C")))
			{
				CtextBox.Text = GlobalData.GlobalLanguage.CheckOut;
			}
			if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("D")))
			{
				DtextBox.Text = GlobalData.GlobalLanguage.Satisfied;
			}
			if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("E")))
			{
				EtextBox.Text = GlobalData.GlobalLanguage.Dissatisfied;
			}
			if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("F")))
			{
				FtextBox.Text = GlobalData.GlobalLanguage.other;
			}	
		}

		private void unit_box_SelectedIndexChanged(object sender, EventArgs e)
		{
			ChangeAppConfig.ChangeConfig("TimeUnit", unit_box.Text);
		}
	}
}
