using LogHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
					string loglocation = ConfigurationManager.AppSettings["LogDirectory"];
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
		List<DataMessage> messages, newmsg;
		public bool isStop;
		public int addCol;
		private static object obj = new object();//锁
		public szwlForm()
		{
			LibraryLogger.Instance.Init(LogDirectory, "szwlFormsApplication", Encoding.Default, LibraryLogger.libLogLevel.Info);
			InitializeComponent();
			dm = new DBManager();
			mainForm = this;
			_server = new Server();
			_server.refreshInterface = this;
			SetTableHeader();
			
			this.Text = string.Format("{0}" + GlobalData.GlobalLanguage.Wireless_calling_system, ConfigurationManager.AppSettings["CompanyName"]);

			//皮肤问题后面再处理
			//string skinpath = ConfigurationManager.AppSettings["packagepath"] + "\\Skin\\SSK皮肤\\MSN\\MSN.ssk";
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
			changeLanguage();
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

			messages = _server.selectMess();
			newmsg = messages.Where(m => m.status == STATUS.WAITING).ToList();
			isStop = false;
			new Thread(CheckTimeOut).Start();
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
						if (DateTime.Compare(message.timeConvert().AddMinutes(InitData.TimeOut), DateTime.Now) < 0)
						{
							message.status = STATUS.OVERTIME;
							_server.updateMessTimeOut(message);
							needRefresh = true;
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
			menutoolBar.Buttons[0].Text = GlobalData.GlobalLanguage.login_setting;
			menutoolBar.Buttons[1].Text = GlobalData.GlobalLanguage.system_setting;
			menutoolBar.Buttons[2].Text = GlobalData.GlobalLanguage.user_setting;
			menutoolBar.Buttons[3].Text = GlobalData.GlobalLanguage.caller_setting;
			menutoolBar.Buttons[4].Text = GlobalData.GlobalLanguage.employee_setting;
			menutoolBar.Buttons[5].Text = GlobalData.GlobalLanguage.header_setting;
			menutoolBar.Buttons[6].Text = GlobalData.GlobalLanguage.data_setting;
			menutoolBar.Buttons[7].Text = GlobalData.GlobalLanguage.summary_setting;
			menutoolBar.Buttons[8].Text = GlobalData.GlobalLanguage.about_setting;

			waitingDataGridView.Columns[0].HeaderText = GlobalData.GlobalLanguage.ID;
			waitingDataGridView.Columns[1].HeaderText = GlobalData.GlobalLanguage.Time;
			waitingDataGridView.Columns[2].HeaderText = GlobalData.GlobalLanguage.caller_num;
			waitingDataGridView.Columns[3].HeaderText = GlobalData.GlobalLanguage.employee_num;
			waitingDataGridView.Columns[4].HeaderText = GlobalData.GlobalLanguage.type;
			waitingDataGridView.Columns[5].HeaderText = GlobalData.GlobalLanguage.isRFID;

			allDataGridView.Columns[0].HeaderText = GlobalData.GlobalLanguage.ID;
			allDataGridView.Columns[1].HeaderText = GlobalData.GlobalLanguage.Time;
			allDataGridView.Columns[2].HeaderText = GlobalData.GlobalLanguage.caller_num;
			allDataGridView.Columns[3].HeaderText = GlobalData.GlobalLanguage.employee_num;
			allDataGridView.Columns[4].HeaderText = GlobalData.GlobalLanguage.type;
			allDataGridView.Columns[5].HeaderText = GlobalData.GlobalLanguage.status;
			allDataGridView.Columns[6].HeaderText = GlobalData.GlobalLanguage.isRFID;
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
						break;
					case DBT_DEVICEARRIVAL:             // USB插入获取对应串口名称
						DEV_BROADCAST_HDR dbhdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
						if (dbhdr.dbch_devicetype == DBT_DEVTYP_PORT)
						{
							string portName = Marshal.PtrToStringUni((IntPtr)(m.LParam.ToInt32() + Marshal.SizeOf(typeof(DEV_BROADCAST_PORT_Fixed))));
							Console.WriteLine("Port '" + portName + "' arrived.");
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
		private void settings_Click(object sender, EventArgs e)
		{
		}
		private void allDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
		private void waiting4_Paint(object sender, PaintEventArgs e)
		{

		}
		private void waitingDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void SzwlForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			Application.Exit();
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
				systemSettingform.ShowDialog();
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
		}
		private void openCom()
		{
			
			COM com =InitData.com;
			InitData.com = com;
			if (com ==null)
			{
				DialogResult dr = MessageBox.Show(GlobalData.GlobalLanguage.no_device,
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
					MessageBox.Show(opencomresult.Item2);
			}
		}

		//请调用此处关闭方法，不然可能产生死锁的问题
		public void closeCom()
		{
			//根据当前串口对象，来判断操作  
			if (_server.com.IsOpen)
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
							if (message.callerNum == mess.callerNum && message.status == STATUS.WAITING)
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
				InitData.AddData(waitingDataGridView, newmsg.Skip(5).ToList());
				//this.waitingDataGridView.AutoGenerateColumns = false;
				//this.waitingDataGridView.DataSource = newmsg.Skip(5).ToList();
				//this.waitingDataGridView.Refresh();
			}
			else
			{
				InitData.AddData(waitingDataGridView, newmsg.Skip(5).ToList());
				//this.waitingDataGridView.AutoGenerateColumns = false;
				//this.waitingDataGridView.DataSource = newmsg.Skip(5).ToList();
				//this.waitingDataGridView.Refresh();
			}
			this.label1.Text = GlobalData.GlobalLanguage.no_quest;
			this.label2.Text = GlobalData.GlobalLanguage.no_quest;
			this.label3.Text = GlobalData.GlobalLanguage.no_quest;
			this.label4.Text = GlobalData.GlobalLanguage.no_quest;
			this.label5.Text = GlobalData.GlobalLanguage.no_quest;

			if (newmsg.Count() >= 1)
				this.label1.Text = string.Format(GlobalData.GlobalLanguage.have_quest, newmsg.ElementAt(0).callerNum, messages[0].type);
			if (newmsg.Count() >= 2)
				this.label2.Text = string.Format(GlobalData.GlobalLanguage.have_quest, newmsg.ElementAt(1).callerNum, messages[1].type);
			if (newmsg.Count() >= 3)
				this.label3.Text = string.Format(GlobalData.GlobalLanguage.have_quest, newmsg.ElementAt(2).callerNum, messages[2].type);
			if (newmsg.Count() >= 4)
				this.label4.Text = string.Format(GlobalData.GlobalLanguage.have_quest, newmsg.ElementAt(3).callerNum, messages[3].type);
			if (newmsg.Count() >= 5)
				this.label5.Text = string.Format(GlobalData.GlobalLanguage.have_quest, newmsg.ElementAt(4).callerNum, messages[4].type);

			
			if (addColNum > 0)
			{
				for(int i=0; i< addColNum; i++)
				{
					this.allDataGridView.DataSource = null;
					this.allDataGridView.Rows.Add();
				}
			}

			InitData.AddData(allDataGridView, messages);
			//this.allDataGridView.AutoGenerateColumns = false;
			//this.allDataGridView.DataSource = messages;
			//this.allDataGridView.Refresh();
		}

	}
}
