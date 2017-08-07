using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using szwlFormsApplication.Models;

namespace szwlFormsApplication
{
	public partial class szwlForm : Form, RefreshInterface
	{
		public static szwlForm mainForm = null;//创建一个自身的静态对象
		Server _server;
		List<DataMessage> messages, newmsg;
		public bool isStop;
		private static object obj = new object();//锁

		public szwlForm()
		{
			InitializeComponent();
			mainForm = this;
			_server = new Server();
			_server.refreshInterface = this;
		}

		private void szwl呼叫系统_Load(object sender, EventArgs e)
		{
			openCom();

			//测试代码，正式环境请注释掉
			_server.open();

			messages = _server.selectMess();
			newmsg = messages.Where(m => m.status == STATUS.WAITING).ToList();
			isStop = false;
			new Thread(CheckTimeOut).Start();

			refresh();
			//if (messages == null)
			//	messages = new List<DataMessage>();
			//var newmsg = messages.Where(m => m.status == STATUS.WAITING);
			//if (newmsg.Count() > 5)
			//{
			//	this.waitingDataGridView.AutoGenerateColumns = false;
			//	this.waitingDataGridView.DataSource = newmsg.Skip(5).ToList();
			//	this.waitingDataGridView.Refresh();
			//}
			//this.label1.Text = "无请求";
			//this.label2.Text = "无请求";
			//this.label3.Text = "无请求";
			//this.label4.Text = "无请求";
			//this.label5.Text = "无请求";

			//if (newmsg.Count() >= 1)
			//	this.label1.Text = string.Format("{0}号桌，类型：{1}", newmsg.ElementAt(0).callerNum, messages[0].type);
			//if (newmsg.Count() >= 2)
			//	this.label2.Text = string.Format("{0}号桌，类型：{1}", newmsg.ElementAt(1).callerNum, messages[1].type);
			//if (newmsg.Count() >= 3)
			//	this.label3.Text = string.Format("{0}号桌，类型：{1}", newmsg.ElementAt(2).callerNum, messages[2].type);
			//if (newmsg.Count() >= 4)
			//	this.label4.Text = string.Format("{0}号桌，类型：{1}", newmsg.ElementAt(3).callerNum, messages[3].type);
			//if (newmsg.Count() >= 5)
			//	this.label5.Text = string.Format("{0}号桌，类型：{1}", newmsg.ElementAt(4).callerNum, messages[4].type);

			//this.allDataGridView.AutoGenerateColumns = false;
			//this.allDataGridView.DataSource = messages;
			//this.allDataGridView.Refresh();
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
						if (DateTime.Compare(message.time.AddMinutes(5), DateTime.Now)<0)
						{
							message.status = STATUS.OVERTIME;
							_server.updateMessTimeOut(message);
							needRefresh = true;
						}
					}
					if (needRefresh)
					{
						newmsg = messages.Where(m => m.status == STATUS.WAITING).ToList();
						this.Invoke((EventHandler)(delegate
						{
							refresh();
						}));
					}
				}
				Thread.Sleep(10000);
			}
		}

		public const int WM_DEVICE_CHANGE = 0x219;
		public const int DBT_DEVICEARRIVAL = 0x8000;
		public const int DBT_DEVICE_REMOVE_COMPLETE = 0x8004;
		public const UInt32 DBT_DEVTYP_PORT = 0x00000003;

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

		private void menutoolBar_ButtonClick_1(object sender, ToolBarButtonClickEventArgs e)
		{
			if (e.Button.Name == "logonbtn")
			{
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

		private void waitingDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void openCom()
		{
			int ComNum = Common.GetComNum();
			if (ComNum == -1)
			{
				DialogResult dr = MessageBox.Show(" 获取设备端口失败，请确认插入对应设备？",
								 " 提示",
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
				_server.open(ComNum);
			}
		}

		//请调用此处关闭方法，不然可能产生死锁的问题
		private void closeCom()
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
					//更新组件
					this.Invoke((EventHandler)(delegate
					{
						refresh();
					}));
				}
				else
				{
					int num = mess.callerNum;
					if (mess.status == STATUS.FINISH)
					{
						Debug.WriteLine(num.ToString() + "号桌完成服务");
					}
					else
					{
						Debug.WriteLine(num.ToString() + "号桌呼叫服务");
					}
					if (mess.type == Models.Type.CANCEL)
					{
						foreach (DataMessage message in messages)
						{
							if (message.callerNum == mess.callerNum && message.status == STATUS.WAITING)
							{
								message.workerNum = mess.workerNum;
								message.status = STATUS.FINISH;
								message.time = mess.time;
								message.isRFID = mess.isRFID;
							}
						}
					}
					else
					{
						messages.Insert(0, mess);
					}
				}
			}
		}

		private void refresh()
		{
			if (messages == null)
				messages = new List<DataMessage>();
			//var newmsg = messages.Where(m => m.status == STATUS.WAITING);
			int num = newmsg.Count();
			if (newmsg.Count() > 5)
			{
				this.waitingDataGridView.AutoGenerateColumns = false;
				this.waitingDataGridView.DataSource = newmsg.Skip(5).ToList();
				this.waitingDataGridView.Refresh();
			}
			else
			{
				this.waitingDataGridView.AutoGenerateColumns = false;
				this.waitingDataGridView.DataSource = newmsg.Skip(5).ToList();
				this.waitingDataGridView.Refresh();
			}
			this.label1.Text = "无请求";
			this.label2.Text = "无请求";
			this.label3.Text = "无请求";
			this.label4.Text = "无请求";
			this.label5.Text = "无请求";

			if (newmsg.Count() >= 1)
				this.label1.Text = string.Format("{0}号桌，类型：{1}", newmsg.ElementAt(0).callerNum, messages[0].type);
			if (newmsg.Count() >= 2)
				this.label2.Text = string.Format("{0}号桌，类型：{1}", newmsg.ElementAt(1).callerNum, messages[1].type);
			if (newmsg.Count() >= 3)
				this.label3.Text = string.Format("{0}号桌，类型：{1}", newmsg.ElementAt(2).callerNum, messages[2].type);
			if (newmsg.Count() >= 4)
				this.label4.Text = string.Format("{0}号桌，类型：{1}", newmsg.ElementAt(3).callerNum, messages[3].type);
			if (newmsg.Count() >= 5)
				this.label5.Text = string.Format("{0}号桌，类型：{1}", newmsg.ElementAt(4).callerNum, messages[4].type);

			this.allDataGridView.AutoGenerateColumns = false;
			this.allDataGridView.DataSource = messages;
			this.allDataGridView.Refresh();
		}
	}
}
