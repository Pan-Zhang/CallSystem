﻿using LogHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using szwlFormsApplication.CommonFunc;
using szwlFormsApplication.dialog;
using szwlFormsApplication.Language;
using szwlFormsApplication.Models;
using szwlFormsApplication.Properties;

namespace szwlFormsApplication
{
	public partial class szwlForm : Form, RefreshInterface
	{
		private string logDirectory = string.Empty;
		private string LogDirectory
		{
			get
			{
				if (string.IsNullOrEmpty(logDirectory))
				{
					string loglocation = ChangeAppConfig.getValueFromKey("LogDirectory");
					StringBuilder fullpath = new StringBuilder();

					if (string.IsNullOrEmpty(loglocation))
					{
						fullpath.Append(".");
					}
					else
					{
						loglocation.Replace("\\", "/");
						fullpath.Append(loglocation);
						if (string.Compare(loglocation.Substring(loglocation.Length - 1, 1), "/") == 0)
						{
							fullpath.Remove(loglocation.Length - 1, 1);
						}
					}
					logDirectory = fullpath.ToString();
				}

				return logDirectory;
			}
		}
		public static szwlForm mainForm = null;//创建一个自身的静态对象
		public DBManager dm = null;
		public Server _server;
		public List<DataMessage> messages { get; set; }
		public List<DataMessage> newmsg { get; set; }
		public bool isStop;
		public int addCol;
		private static object obj = new object();//锁
		public szwlForm()
		{
			string basePath = Common.basePath;
			if (!Directory.Exists(basePath))
			{
				Directory.CreateDirectory(basePath);
			}
			string path = basePath + "\\App.config";
			if (!File.Exists(path))
			{
				byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Resources.App);
				FileStream outputExcelFile = new FileStream(path, FileMode.Create, FileAccess.Write);
				outputExcelFile.Write(bytes, 0, bytes.Length);
				outputExcelFile.Close();
			}
			path = basePath + "\\help_ch.doc";
			if (!File.Exists(path))
			{
				byte[] bytes = Resources.help_ch;
				FileStream outputExcelFile = new FileStream(path, FileMode.Create, FileAccess.Write);
				outputExcelFile.Write(bytes, 0, bytes.Length);
				outputExcelFile.Close();
			}
			path = basePath + "\\help_en.doc";
			if (!File.Exists(path))
			{
				byte[] bytes = Resources.help_en;
				FileStream outputExcelFile = new FileStream(path, FileMode.Create, FileAccess.Write);
				outputExcelFile.Write(bytes, 0, bytes.Length);
				outputExcelFile.Close();
			}
			LibraryLogger.Instance.Init(basePath, "szwlFormsApplication", Encoding.Default, LibraryLogger.libLogLevel.Info);
			InitializeComponent();
			Common.isRFID = ChangeAppConfig.getValueFromKey("isRFID").Equals("1");
			dm = new DBManager();
			mainForm = this;
			_server = new Server();
			_server.refreshInterface = this;
			SetTableHeader();

			//皮肤问题后面再处理
			//string skinpath = ChangeAppConfig.getValueFromKey("packagepath"] + "\\Skin\\SSK皮肤\\MSN\\MSN.ssk";
			//skinEngine1.SkinFile = skinpath;
		}

		public void SetTableHeader()
		{
			this.waitingDataGridView.Columns[1].HeaderCell.Value = DataMessage.Displaytime();
			this.waitingDataGridView.Columns[2].HeaderCell.Value = DataMessage.DisplaycallerNum();
			this.waitingDataGridView.Columns[3].HeaderCell.Value = DataMessage.DisplayemployeeNum();
			this.waitingDataGridView.Columns[4].HeaderCell.Value = DataMessage.Displaytype();

			this.allDataGridView.Columns[1].HeaderCell.Value = DataMessage.Displaytime();
			this.allDataGridView.Columns[2].HeaderCell.Value = DataMessage.DisplaycallerNum();
			this.allDataGridView.Columns[3].HeaderCell.Value = DataMessage.DisplayemployeeNum();
			this.allDataGridView.Columns[4].HeaderCell.Value = DataMessage.Displaytype();
			this.allDataGridView.Columns[5].HeaderCell.Value = DataMessage.Displaystatus();
		}
		private void szwlForm_Load(object sender, EventArgs e)
		{
			this.timer1.Interval = 1000;
			this.timer1.Start();
			string dateStr = ChangeAppConfig.getValueFromKey("Permission_overtime");
			DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
			dtFormat.ShortDatePattern = "yyyy/MM/dd";
			DateTime date = Convert.ToDateTime(dateStr, dtFormat);
			if (DateTime.Now.Date > date)
			{
				this.Invoke((EventHandler)(delegate
				{
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.product_overtime);
				}));
			}
			if (LogOnForm.currentUser == null)
			{
				mainForm.Hide();
				mainForm.ShowInTaskbar = false;
				LogOnForm.loginform.Show();
				return;
			}
		}
		public void Init()
		{
			changeLanguage();
			foreach (ToolBarButton btn in menutoolBar.Buttons)
			{
				btn.Visible = false;
			}
			InitData.Init();
			if (InitData.program != null && InitData.program.programs != null && InitData.program.programs.Count > 0)
			{
				foreach (var p in InitData.program.programs)
				{
					menutoolBar.Buttons[p].Visible = true;
				}
			}
			openCom();
			//测试代码，正式环境请注释掉
			//_server.open();

			messages = _server.selectMess(DateTime.Now.Date.ToFileTime());//只查询当天的数据
			newmsg = messages.Where(m => m.status == STATUS.WAITING).ToList();
			isStop = false;
			new Thread(CheckTimeOut).Start();
			new Thread(checkUnFinish).Start();
			refresh(0);
		}

		private void CheckTimeOut()
		{
			while (!isStop)
			{
				lock (obj)
				{
					bool needRefresh = false;
					foreach (DataMessage message in newmsg)
					{
						string unit = ChangeAppConfig.getValueFromKey("TimeUnit");
						if (unit.Equals("H") || unit.Equals("时"))
						{
							if (DateTime.Compare(message.timeConvert().AddHours(InitData.GetTimeOut()), DateTime.Now) < 0)
							{
								message.status = STATUS.OVERTIME;
								message.isOverTime = true;
								_server.updateMessTimeOut(message);
								needRefresh = true;
							}
						}
						else if (unit.Equals("M") || unit.Equals("分"))
						{
							if (DateTime.Compare(message.timeConvert().AddMinutes(InitData.GetTimeOut()), DateTime.Now) < 0)
							{
								message.status = STATUS.OVERTIME;
								message.isOverTime = true;
								_server.updateMessTimeOut(message);
								needRefresh = true;
							}
						}
						else
						{
							if (DateTime.Compare(message.timeConvert().AddSeconds(InitData.GetTimeOut()), DateTime.Now) < 0)
							{
								message.status = STATUS.OVERTIME;
								message.isOverTime = true;
								_server.updateMessTimeOut(message);
								needRefresh = true;
							}
						}

					}
					if (needRefresh)
					{
						newmsg = messages.Where(m => m.status == STATUS.WAITING).ToList();
						if (this.components == null || IsDisposed || !IsHandleCreated)
						{
							isStop = true;
							return;
						}
						this.Invoke((EventHandler)(delegate
						{
							refresh(0);
						}));
					}
				}
				Thread.Sleep(10000);
			}
		}

		private void checkUnFinish()
		{
			while (!isStop)
			{
				lock (obj)
				{
					bool needRefresh = false;
					List<DataMessage> overTime_list = messages.Where(m => m.status == STATUS.OVERTIME).ToList();
					foreach(DataMessage message in overTime_list)
					{
						string unit = ChangeAppConfig.getValueFromKey("UnFinishUnit");
						if (unit.Equals("H") || unit.Equals("时"))
						{
							if (DateTime.Compare(message.timeConvert().AddHours(InitData.GetUnFinish()), DateTime.Now) < 0)
							{
								message.status = STATUS.UNFINISH;
								_server.updateMessUnfinish(message);
								needRefresh = true;
							}
						}
						else if (unit.Equals("M") || unit.Equals("分"))
						{
							if (DateTime.Compare(message.timeConvert().AddMinutes(InitData.GetUnFinish()), DateTime.Now) < 0)
							{
								message.status = STATUS.UNFINISH;
								_server.updateMessUnfinish(message);
								needRefresh = true;
							}
						}
						else
						{
							if (DateTime.Compare(message.timeConvert().AddSeconds(InitData.GetUnFinish()), DateTime.Now) < 0)
							{
								message.status = STATUS.UNFINISH;
								_server.updateMessUnfinish(message);
								needRefresh = true;
							}
						}
					}
					if (needRefresh)
					{
						newmsg = messages.Where(m => m.status == STATUS.WAITING).ToList();
						if (this.components == null || IsDisposed || !IsHandleCreated)
						{
							isStop = true;
							return;
						}
						this.Invoke((EventHandler)(delegate
						{
							refresh(0);
						}));
					}
				}
				Thread.Sleep(10000);
			}
		}

		public void changeLanguage()
		{
			SetTableHeader();

			menutoolBar.Buttons[0].Text = GlobalData.GlobalLanguage.login_setting;
			menutoolBar.Buttons[1].Text = GlobalData.GlobalLanguage.system_setting;
			menutoolBar.Buttons[2].Text = GlobalData.GlobalLanguage.user_setting;
			menutoolBar.Buttons[3].Text = GlobalData.GlobalLanguage.employee_setting;
			menutoolBar.Buttons[4].Text = GlobalData.GlobalLanguage.caller_setting;
			menutoolBar.Buttons[5].Text = GlobalData.GlobalLanguage.header_setting;
			menutoolBar.Buttons[6].Text = GlobalData.GlobalLanguage.summary_setting;
			menutoolBar.Buttons[7].Text = GlobalData.GlobalLanguage.data_setting;
			menutoolBar.Buttons[8].Text = GlobalData.GlobalLanguage.help;
			menutoolBar.Buttons[9].Text = GlobalData.GlobalLanguage.about_setting;

			menutoolBar.Buttons[0].ToolTipText = GlobalData.GlobalLanguage.login_setting;
			menutoolBar.Buttons[1].ToolTipText = GlobalData.GlobalLanguage.system_setting;
			menutoolBar.Buttons[2].ToolTipText = GlobalData.GlobalLanguage.user_setting;
			menutoolBar.Buttons[3].ToolTipText = GlobalData.GlobalLanguage.employee_setting;
			menutoolBar.Buttons[4].ToolTipText = GlobalData.GlobalLanguage.caller_setting;
			menutoolBar.Buttons[5].ToolTipText = GlobalData.GlobalLanguage.header_setting;
			menutoolBar.Buttons[6].ToolTipText = GlobalData.GlobalLanguage.summary_setting;
			menutoolBar.Buttons[7].ToolTipText = GlobalData.GlobalLanguage.data_setting;
			menutoolBar.Buttons[8].ToolTipText = GlobalData.GlobalLanguage.help;
			menutoolBar.Buttons[9].ToolTipText = GlobalData.GlobalLanguage.about_setting;

			if (ChangeAppConfig.getValueFromKey(GlobalData.LANGUAGE).Equals(GlobalData.ENGLISH))
			{
				helpProvider1.HelpNamespace = Common.basePath +　"\\help_en.doc";
			}
			else
			{
				helpProvider1.HelpNamespace = Common.basePath + "\\help_ch.doc";
			}
			helpProvider1.SetShowHelp(this, true);


			this.toolStripStatusLabel1.Text = GlobalData.GlobalLanguage.current_user + LogOnForm.currentUser.name;
			this.toolStripStatusLabel2.Text = GlobalData.GlobalLanguage.current_com + (InitData.com==null?"":InitData.com.COMID);
			this.toolStripStatusLabel3.Text = GlobalData.GlobalLanguage.current_time + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

			this.Text = string.Format("{0}" + GlobalData.GlobalLanguage.Wireless_calling_system, ChangeAppConfig.getValueFromKey("CompanyName"));
		}

		public const int WM_DEVICE_CHANGE = 0x219;
		public const int DBT_DEVICEARRIVAL = 0x8000;
		public const int DBT_DEVICE_REMOVE_COMPLETE = 0x8004;
		public const UInt32 DBT_DEVTYP_PORT = 0x00000003;
		public const int WM_SYSCOMMAND = 0x0112;
		//winuser.h文件中有SC_...的定义
		public const int SC_CLOSE = 0xF060;

		[StructLayout(LayoutKind.Sequential)]
		struct DEV_BROADCAST_HDR
		{
			public UInt32 dbch_size;
			public UInt32 dbch_devicetype;
			public UInt32 dbch_reserved;
		}

		[StructLayout(LayoutKind.Sequential)]
		protected struct DEV_BROADCAST_PORT_Fixed
		{
			public uint dbcp_size;
			public uint dbcp_devicetype;
			public uint dbcp_reserved;
			// Variable?length field dbcp_name is declared here in the C header file.
		}

		/// <summary>
		/// 检测USB串口的拔插
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == WM_DEVICE_CHANGE)        // 捕获USB设备的拔出消息WM_DEVICECHANGE
			{
				switch (m.WParam.ToInt32())
				{
					case DBT_DEVICE_REMOVE_COMPLETE:    // USB拔出     
						DEV_BROADCAST_HDR dbhdr0 = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
						if (dbhdr0.dbch_devicetype == DBT_DEVTYP_PORT)
						{
							string portName = Marshal.PtrToStringUni((IntPtr)(m.LParam.ToInt32() + Marshal.SizeOf(typeof(DEV_BROADCAST_PORT_Fixed))));
							LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, "串口掉线，串口号:" + portName);
						}
						break;
					case DBT_DEVICEARRIVAL:             // USB插入获取对应串口名称
						DEV_BROADCAST_HDR dbhdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
						if (dbhdr.dbch_devicetype == DBT_DEVTYP_PORT)
						{
							string portName = Marshal.PtrToStringUni((IntPtr)(m.LParam.ToInt32() + Marshal.SizeOf(typeof(DEV_BROADCAST_PORT_Fixed))));
							LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, "串口接入，串口号:" + portName);
						}
						break;
				}
			}
			if (m.Msg == WM_SYSCOMMAND && ((int)m.WParam == SC_CLOSE))
			{
				// 点击winform右上关闭按钮 f
				// 加入想要的逻辑处理
				ExitForm exit = new ExitForm();
				DialogResult dr = exit.ShowDialog();
				if(dr == DialogResult.OK)
				{
					isStop = true;
					closeCom();
					timer1.Stop();
					Application.Exit();
				}
				else if(dr == DialogResult.Yes)
				{
					// 改关闭效果为最小化
					this.WindowState = FormWindowState.Minimized;
					this.Hide();
					return;
				}
				else if(dr == DialogResult.Cancel)
				{
					return;
				}
			}
			base.WndProc(ref m);
		}
		private void menutoolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{

			if (e.Button.Name == "logonbtn")
			{
				closeCom();
				mainForm.Hide();
				LogOnForm.loginform.Show();
			}
			else if (e.Button.Name == "systemsettingsbtn")
			{
				systemSettingForm systemSettingform = new systemSettingForm();
				DialogResult dr = systemSettingform.ShowDialog();
				refresh(0);
				this.toolStripStatusLabel2.Text = GlobalData.GlobalLanguage.current_com + (InitData.com == null ? "" : InitData.com.COMID);
			}
			else if (e.Button.Name == "userbtn")
			{
				userForm userform = new userForm();
				userform.ShowDialog();
			}
			else if (e.Button.Name == "settingsbtn")
			{
				settingsForm settingform = new settingsForm();
				settingform.ShowDialog();
			}
			else if (e.Button.Name == "employeesettingsbtn")
			{
				employeeSettingsForm employeesettingform = new employeeSettingsForm();
				employeesettingform.ShowDialog();
			}
			else if (e.Button.Name == "datamaintainbtn")
			{
				dataMaintainSettingForm datamaintainsettingform = new dataMaintainSettingForm();
				datamaintainsettingform.ShowDialog();
				newmsg = messages.Where(m => m.status == STATUS.WAITING).ToList();
				refresh(0);
			}
			else if (e.Button.Name == "tablesettingsbtn")
			{
				tableSettingsForm tablesettingform = new tableSettingsForm();
				tablesettingform.ShowDialog();
			}
			else if (e.Button.Name == "searchbtn")
			{
				callHistoriesSummaryForm callhistorysumform = new callHistoriesSummaryForm();
				callhistorysumform.ShowDialog();
			}
			else if (e.Button.Name == "aboutbtn")
			{
				aboutForm aboutform = new aboutForm();
				aboutform.ShowDialog();
			}
			else if(e.Button.Name == "help")
			{
				if (ChangeAppConfig.getValueFromKey(GlobalData.LANGUAGE).Equals(GlobalData.ENGLISH))
				{
					System.Diagnostics.Process.Start(Common.basePath + "\\help_en.doc");
				}
				else
				{
					System.Diagnostics.Process.Start(Common.basePath + "\\help_ch.doc");
				}
			}
		}
		private void openCom()
		{
			
			COM com =InitData.com;
			InitData.com = com;
			if (string.IsNullOrEmpty(com.COMID))
			{
				DialogResult dr = dialog.MessageBox.Show(GlobalData.GlobalLanguage.no_device,
								 GlobalData.GlobalLanguage.prompt,
								MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes)
				{
					this.Hide();
				}
				else
				{
					//do nothing
				}
			}
			else
			{
				var opencomresult=_server.open(com);
				if (!opencomresult.Item1)
					dialog.MessageBox.Show(opencomresult.Item2);
			}
		}

		//请调用此处关闭方法，不然可能产生死锁的问题
		public void closeCom()
		{
			//根据当前串口对象，来判断操作  
			if (_server!=null && _server.com!=null && _server.com.IsOpen)
			{
				_server.Closing = true;
				while (_server.Listening) Application.DoEvents();
				//打开时点击，则关闭串口  
				_server.com.Close();
				_server.Closing = false;
			}
		}

		//这里是回调哦，你要更新UI就在这里做哈，我的建议是在这里维护你的list，这样就不用每次都查询数据库啦
		void RefreshInterface.refresh(DataMessage mess, bool canRefresh)
		{
			lock (obj)
			{
				if (canRefresh)
				{
					newmsg = messages.Where(m => m.status == STATUS.WAITING).ToList();
					if (this.components == null || IsDisposed || !IsHandleCreated)
					{
						isStop = true;
						return;
					}
					//更新组件
					this.Invoke((EventHandler)(delegate
					{
						refresh(addCol);
						addCol = 0;//这里
					}));
				}
				else
				{
					string num = mess.callerNum;
					if (mess.status == STATUS.FINISH)
					{
						Debug.WriteLine(num + "号桌完成服务");
					}
					else
					{
						Debug.WriteLine(num + "号桌呼叫服务");
					}
					if (mess.type == Models.Type.CANCEL)
					{
						foreach (DataMessage message in messages)
						{
							if (message.callerNum == mess.callerNum && (message.status == STATUS.WAITING || message.status == STATUS.OVERTIME))
							{
								message.employeeNum = mess.employeeNum;
								message.status = STATUS.FINISH;
								message.time = mess.time;
								message.isRFID = mess.isRFID;
							}
						}
					}
					else
					{
						if(messages!=null && messages.Count > 0)
						{
							mess.Id = messages[0].Id + 1;
						}
						else
						{
							mess = dm.selectMessLast();
						}
						messages.Insert(0, mess);
						addCol++;//说明有插入数据
					}
				}
			}
		}

		private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal)
			{
				this.WindowState = FormWindowState.Minimized;

				this.Hide();
			}
			else if (this.WindowState == FormWindowState.Minimized)
			{
				this.Show();
				this.WindowState = FormWindowState.Normal;
				this.Activate();
			}
		}

		public void refresh(int addColNum)
		{
			if (messages == null)
				messages = new List<DataMessage>();
			//var newmsg = messages.Where(m => m.status == STATUS.WAITING);
			int num = newmsg.Count();
			if (newmsg.Count() > 5)
			{
				this.waitingDataGridView.AutoGenerateColumns = false;
				this.waitingDataGridView.DataSource = new BindingList<DataMessage>(newmsg.Skip(5).ToList());
				this.waitingDataGridView.Refresh();
			}
			else
			{
				this.waitingDataGridView.AutoGenerateColumns = false;
				this.waitingDataGridView.DataSource = new BindingList<DataMessage>(newmsg.Skip(5).ToList());
				this.waitingDataGridView.Refresh();
			}
			this.label1.Text = GlobalData.GlobalLanguage.no_quest;
			this.label2.Text = GlobalData.GlobalLanguage.no_quest;
			this.label3.Text = GlobalData.GlobalLanguage.no_quest;
			this.label4.Text = GlobalData.GlobalLanguage.no_quest;
			this.label5.Text = GlobalData.GlobalLanguage.no_quest;
			this.label6.Text = GlobalData.GlobalLanguage.no_quest;
			this.label7.Text = GlobalData.GlobalLanguage.no_quest;
			this.label8.Text = GlobalData.GlobalLanguage.no_quest;
			this.label9.Text = GlobalData.GlobalLanguage.no_quest;
			this.label10.Text = GlobalData.GlobalLanguage.no_quest;
			this.label11.Text = GlobalData.GlobalLanguage.no_quest;
			this.label12.Text = GlobalData.GlobalLanguage.no_quest;
			this.label13.Text = GlobalData.GlobalLanguage.no_quest;
			this.label14.Text = GlobalData.GlobalLanguage.no_quest;
			this.label15.Text = GlobalData.GlobalLanguage.no_quest;
			this.label16.Text = GlobalData.GlobalLanguage.no_quest;
			this.label17.Text = GlobalData.GlobalLanguage.no_quest;
			this.label18.Text = GlobalData.GlobalLanguage.no_quest;
			this.label19.Text = GlobalData.GlobalLanguage.no_quest;
			this.label20.Text = GlobalData.GlobalLanguage.no_quest;
			this.label21.Text = GlobalData.GlobalLanguage.no_quest;
			this.label22.Text = GlobalData.GlobalLanguage.no_quest;
			this.label23.Text = GlobalData.GlobalLanguage.no_quest;
			this.label24.Text = GlobalData.GlobalLanguage.no_quest;
			this.label25.Text = GlobalData.GlobalLanguage.no_quest;

			if (newmsg.Count() >= 1)
			{
				this.label1.Text = newmsg.ElementAt(0).callerNum;
				this.label6.Text = getType(newmsg.ElementAt(0));
				label6.Left = label1.Left + label1.Width + 5;
				this.label7.Text = newmsg.ElementAt(0).getZoneName();
				this.label8.Text = newmsg.ElementAt(0).timeConvert().ToString("yyyy MM dd");
				this.label9.Text = newmsg.ElementAt(0).timeConvert().TimeOfDay.ToString();
			}
			if (newmsg.Count() >= 2)
			{
				this.label2.Text = newmsg.ElementAt(1).callerNum;
				this.label10.Text = getType(newmsg.ElementAt(1));
				label10.Left = label2.Left + label2.Width + 5;
				this.label11.Text = newmsg.ElementAt(1).getZoneName();
				this.label12.Text = newmsg.ElementAt(1).timeConvert().ToString("yyyy MM dd");
				this.label13.Text = newmsg.ElementAt(1).timeConvert().TimeOfDay.ToString();
			}
			if (newmsg.Count() >= 3)
			{
				this.label3.Text = newmsg.ElementAt(2).callerNum;
				this.label18.Text = getType(newmsg.ElementAt(2));
				label18.Left = label3.Left + label3.Width + 5;
				this.label19.Text = newmsg.ElementAt(2).getZoneName();
				this.label20.Text = newmsg.ElementAt(2).timeConvert().ToString("yyyy MM dd");
				this.label21.Text = newmsg.ElementAt(2).timeConvert().TimeOfDay.ToString();
			}
			if (newmsg.Count() >= 4)
			{
				this.label4.Text = newmsg.ElementAt(3).callerNum;
				this.label14.Text = getType(newmsg.ElementAt(3));
				label14.Left = label4.Left + label4.Width + 5;
				this.label15.Text = newmsg.ElementAt(3).getZoneName();
				this.label16.Text = newmsg.ElementAt(3).timeConvert().ToString("yyyy MM dd");
				this.label17.Text = newmsg.ElementAt(3).timeConvert().TimeOfDay.ToString();
			}
			if (newmsg.Count() >= 5)
			{
				this.label5.Text = newmsg.ElementAt(4).callerNum;
				this.label22.Text = getType(newmsg.ElementAt(4));
				label22.Left = label5.Left + label5.Width + 5;
				this.label23.Text = newmsg.ElementAt(4).getZoneName();
				this.label24.Text = newmsg.ElementAt(4).timeConvert().ToString("yyyy MM dd");
				this.label25.Text = newmsg.ElementAt(4).timeConvert().TimeOfDay.ToString();
			}

			//if (addColNum > 0)
			//{
			//	for(int i=0; i< addColNum; i++)
			//	{
			//		this.allDataGridView.DataSource = null;
			//		this.allDataGridView.Rows.Add();
			//	}
			//}

			//InitData.AddData(allDataGridView, messages);
			this.allDataGridView.AutoGenerateColumns = false;
			this.allDataGridView.DataSource = null;
			this.allDataGridView.DataBindingComplete += dataBindCompleted;
			this.allDataGridView.DataSource = new BindingList<DataMessage>(messages);
			//this.allDataGridView.Refresh();
		}

		private void dataBindCompleted(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			int i = 0;
			foreach(DataMessage mess in messages)
			{ 
				if(mess.status == STATUS.UNFINISH)
				{
					allDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(InitData.timecolor.WaitTime);
				}
				else if(mess.status == STATUS.OVERTIME)
				{
					allDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(InitData.timecolor.TimeOutTime);
				}
				else if(mess.status == STATUS.FINISH)
				{
					allDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(InitData.timecolor.FinishedTime);
				}
				else
				{
					allDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
				}
				i++;
			}
		}

		private string getType(DataMessage message)
		{
			string type;
			switch (message.type)
			{
				case Models.Type.ORDER:
					if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("A")))
					{
						type = GlobalData.GlobalLanguage.Order;
					}else
					{
						type = ChangeAppConfig.getValueFromKey("A");
					}
					break;

				case Models.Type.CALL:
					if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("B")))
					{
						type = GlobalData.GlobalLanguage.Call;
					}
					else
					{
						type = ChangeAppConfig.getValueFromKey("B");
					}
					break;

				case Models.Type.CHECK_OUT:
					if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("C")))
					{
						type = GlobalData.GlobalLanguage.CheckOut;
					}
					else
					{
						type = ChangeAppConfig.getValueFromKey("C");
					}
					break;

				case Models.Type.SATISFIED:
					if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("D")))
					{
						type = GlobalData.GlobalLanguage.Satisfied;
					}
					else
					{
						type = ChangeAppConfig.getValueFromKey("D");
					}
					break;

				case Models.Type.DISSATISFIED:
					if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("E")))
					{
						type = GlobalData.GlobalLanguage.Dissatisfied;
					}
					else
					{
						type = ChangeAppConfig.getValueFromKey("E");
					}
					break;

				default:
					if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("F")))
					{
						type = message.type.ToString();
					}
					else
					{
						type = ChangeAppConfig.getValueFromKey("F");
					}
					break;
			}
			return type;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.toolStripStatusLabel3.Text = GlobalData.GlobalLanguage.current_time + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
		}

		private void allDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				lock (obj)
				{
					if (messages == null || messages.Count == 0)
					{
						return;
					}
					DeleteForm form = new DeleteForm();
					DialogResult dr = form.ShowDialog();
					if (dr == DialogResult.Retry)
					{
						if (dm.deleteMess(messages[e.RowIndex]))
						{
							messages.RemoveAt(e.RowIndex);
							newmsg = messages.Where(m => m.status == STATUS.WAITING).ToList();
						}
					}
					else if (dr == DialogResult.Ignore)
					{
						dm.deleteRecordToday();
						messages.Clear();
						newmsg.Clear();
					}
					refresh(0);
				}
			}
		}

		private void waitingDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				lock (obj)
				{
					if (newmsg==null || newmsg.Count == 0)
					{
						return;
					}
					DeleteForm form = new DeleteForm();
					DialogResult dr = form.ShowDialog();
					if (dr == DialogResult.Retry)
					{
						DataMessage message = newmsg[e.RowIndex + 5];
						dm.deleteMess(message);
						newmsg.Remove(message);
						messages.Remove(message);
					}
					else if (dr == DialogResult.Ignore)
					{
						dm.deleteRecordWaitting();
						foreach (DataMessage mess in newmsg)
						{
							messages.Remove(mess);
						}
						newmsg.Clear();
					}
					refresh(0);
				}
			}
		}
	}
}
