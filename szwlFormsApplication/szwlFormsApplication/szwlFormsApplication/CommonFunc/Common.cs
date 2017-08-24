using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szwlFormsApplication.Models;

namespace szwlFormsApplication.CommonFunc
{
	class Common
	{

		public static bool isRFID = true;

		public static void SetTableHeader(DataGridView dataGridView)
		{
			dataGridView.Columns[1].HeaderCell.Value = DataMessage.Displaytime();
			dataGridView.Columns[2].HeaderCell.Value = DataMessage.DisplaycallerNum();
			dataGridView.Columns[3].HeaderCell.Value = DataMessage.DisplayemployeeNum();
			dataGridView.Columns[4].HeaderCell.Value = DataMessage.Displaytype();
			dataGridView.Columns[5].HeaderCell.Value = DataMessage.Displaystatus();
		}

		//获取所有端口号，获取串口可能比较经常用的是SerialPort.GetPortNames()这个方法，或者是读取注册表的方式，但是这两种方式都是有问题，尤其是在多次插拔串口后，会有重复串口出现，采用以下方式解决该问题
		public static string[] MulGetHardwareInfo(HardwareEnum hardType, string propKey)
		{

			List<string> strs = new List<string>();
			try
			{
				using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
				{
					var hardInfos = searcher.Get();
					foreach (var hardInfo in hardInfos)
					{
						if (hardInfo.Properties[propKey].Value.ToString().Contains("COM"))
						{
							strs.Add(hardInfo.Properties[propKey].Value.ToString());
						}

					}
					searcher.Dispose();
				}
				return strs.ToArray();
			}
			catch
			{
				return null;
			}
			finally
			{
				strs = null;
			}
		}

		//获取特定硬件端口号
		public static int GetComNum1()
		{
			int comNum = -1;
			string[] strArr = GetHarewareInfo(HardwareEnum.Win32_PnPEntity, "Name");
			foreach (string s in strArr)
			{
				Debug.WriteLine(s);

				if (s.Length >= 23 && s.Contains("CH340"))
				{
					int start = s.IndexOf("(") + 3;
					int end = s.IndexOf(")");
					comNum = Convert.ToInt32(s.Substring(start + 1, end - start - 1));
				}
			}

			return comNum;

		}

		public static int GetComNum()
		{
			int comNum = -1;
			string[] strArr = GetHarewareInfo(HardwareEnum.Win32_PnPEntity, "Name");
			foreach (string s in strArr)
			{
				Debug.WriteLine(s);

				if (s.Length >= 23 && s.Contains("CH340"))
				{
					int start = s.IndexOf("(") + 3;
					int end = s.IndexOf(")");
					comNum = Convert.ToInt32(s.Substring(start + 1, end - start - 1));
					break;
				}
			}
			return comNum;

		}

		//获取COM信息
		public static COM GetComInfo()
		{
			COM com = new COM();
			//if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["COMID"]))
			//{
			//	var tmp = Common.GetComNum();
			//	if (tmp != -1)
			//	{
			//		com.COMID = string.Format("COM{0}", tmp);
			//		ChangeAppConfig.ChangeConfig("COMID", com.COMID);
			//	}
			//}
			//else
			//	com.COMID = ConfigurationManager.AppSettings["COMID"];

			var tmp = Common.GetComNum();
			if (tmp != -1)
			{
				com.COMID = string.Format("COM{0}", tmp);
			}

			if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["DataBits"]))
			{
				com.DataBits = 8;
				ChangeAppConfig.ChangeConfig("DataBits", com.DataBits.ToString());
			}
			else
				com.DataBits = int.Parse(ConfigurationManager.AppSettings["DataBits"]);

			if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["StopBit"]))
			{
				com.StopBit = 7;
				ChangeAppConfig.ChangeConfig("StopBit", com.StopBit.ToString());
			}
			else
				com.StopBit = double.Parse(ConfigurationManager.AppSettings["StopBit"]);

			if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["BaudRate"]))
			{
				com.BaudRate = 115200;
				ChangeAppConfig.ChangeConfig("BaudRate", com.BaudRate.ToString());
			}
			else
				com.BaudRate = int.Parse(ConfigurationManager.AppSettings["BaudRate"]);


			if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["duration"]))
			{
				com.duration = 5;
				ChangeAppConfig.ChangeConfig("duration", com.duration.ToString());
			}
			else
				com.duration = int.Parse(ConfigurationManager.AppSettings["duration"]);
			return com;

		}

		/// <summary>
		/// Get the system devices information with windows api.
		/// </summary>
		/// <param name="hardType">Device type.</param>
		/// <param name="propKey">the property of the device.</param>
		/// <returns></returns>
		private static string[] GetHarewareInfo(HardwareEnum hardType, string propKey)
		{

			List<string> strs = new List<string>();
			try
			{
				using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
				{
					var hardInfos = searcher.Get();
					foreach (var hardInfo in hardInfos)
					{
						if (hardInfo.Properties[propKey].Value != null)
						{
							String str = hardInfo.Properties[propKey].Value.ToString();
							strs.Add(str);
						}

					}
				}
				return strs.ToArray();
			}
			catch
			{
				return null;
			}
			finally
			{
				strs = null;
			}
		}//end of func GetHarewareInfo().

		/// <summary>
		/// 枚举win32 api
		/// </summary>
		public enum HardwareEnum
		{
			// 硬件
			Win32_Processor, // CPU 处理器
			Win32_PhysicalMemory, // 物理内存条
			Win32_Keyboard, // 键盘
			Win32_PointingDevice, // 点输入设备，包括鼠标。
			Win32_FloppyDrive, // 软盘驱动器
			Win32_DiskDrive, // 硬盘驱动器
			Win32_CDROMDrive, // 光盘驱动器
			Win32_BaseBoard, // 主板
			Win32_BIOS, // BIOS 芯片
			Win32_ParallelPort, // 并口
			Win32_SerialPort, // 串口
			Win32_SerialPortConfiguration, // 串口配置
			Win32_SoundDevice, // 多媒体设置，一般指声卡。
			Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
			Win32_USBController, // USB 控制器
			Win32_NetworkAdapter, // 网络适配器
			Win32_NetworkAdapterConfiguration, // 网络适配器设置
			Win32_Printer, // 打印机
			Win32_PrinterConfiguration, // 打印机设置
			Win32_PrintJob, // 打印机任务
			Win32_TCPIPPrinterPort, // 打印机端口
			Win32_POTSModem, // MODEM
			Win32_POTSModemToSerialPort, // MODEM 端口
			Win32_DesktopMonitor, // 显示器
			Win32_DisplayConfiguration, // 显卡
			Win32_DisplayControllerConfiguration, // 显卡设置
			Win32_VideoController, // 显卡细节。
			Win32_VideoSettings, // 显卡支持的显示模式。

			// 操作系统
			Win32_TimeZone, // 时区
			Win32_SystemDriver, // 驱动程序
			Win32_DiskPartition, // 磁盘分区
			Win32_LogicalDisk, // 逻辑磁盘
			Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
			Win32_LogicalMemoryConfiguration, // 逻辑内存配置
			Win32_PageFile, // 系统页文件信息
			Win32_PageFileSetting, // 页文件设置
			Win32_BootConfiguration, // 系统启动配置
			Win32_ComputerSystem, // 计算机信息简要
			Win32_OperatingSystem, // 操作系统信息
			Win32_StartupCommand, // 系统自动启动程序
			Win32_Service, // 系统安装的服务
			Win32_Group, // 系统管理组
			Win32_GroupUser, // 系统组帐号
			Win32_UserAccount, // 用户帐号
			Win32_Process, // 系统进程
			Win32_Thread, // 系统线程
			Win32_Share, // 共享
			Win32_NetworkClient, // 已安装的网络客户端
			Win32_NetworkProtocol, // 已安装的网络协议
			Win32_PnPEntity,//all device
		}
	}
}
