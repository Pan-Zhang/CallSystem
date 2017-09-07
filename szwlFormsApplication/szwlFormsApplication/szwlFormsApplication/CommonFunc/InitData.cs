using System;
using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json;
using szwlFormsApplication.Models;
using System.Windows.Forms;

namespace szwlFormsApplication.CommonFunc
{
	/// <summary>
	/// 初始化数据 将呼叫器、服务员、当日的呼叫消息、串口信息 从数据库中读取出来 加入静态资源中 
	/// 这些数据在系统生命周期中存在 
	/// 这些数据将会根据当前系统的处理进行更新
	/// 这些数据在系统关闭时进行保存更新数据库
	/// </summary>
	public class InitData
	{
		//初始化串口号
		public static COM com = null;
		public static CallBtnSetting callbtnsetting = null;
		public static OrderBy orderby = null;
		public static TimeColor timecolor = null;
		public static int TimeOut = 5;
		public static int UnFinish = 20;
		public static List<User> users = null;
		public static UserProgram program = null;
		public static List<Employee> employees = null;
		public static List<Employee> employeeRFID = null;

		public static List<Callzone> list_zone=null;
		public static List<Caller> list_caller = null;

		//设置COM信息
		public static void Init()
		{
			com = Common.GetComInfo();
			callbtnsetting = GetCallBtnSetting();
			orderby = GetOrederBy();
			timecolor = GetTimeColor();
			TimeOut = 5;
			UnFinish = 20;
			users = szwlForm.mainForm.dm.selectUser();
			employees = szwlForm.mainForm.dm.selectEmployee();
			employeeRFID = szwlForm.mainForm.dm.selectEmployeeRFID();
			list_zone = szwlForm.mainForm.dm.selectZone();
	        list_caller = szwlForm.mainForm.dm.selectCaller();
			program = new UserProgram(LogOnForm.currentUser);
		}
		//设置COM信息
		public static void Clear()
		{
			com = null;
			callbtnsetting = null;
			orderby = null;
			timecolor = null;
			TimeOut = 5;
			UnFinish = 20;
			users = null;
			employees = null;
			employeeRFID = null;
			list_zone = null;
			list_caller = null;
			program = null;
			LogOnForm.currentUser = null;
		}
		public static void ClearData<T>(DataGridView grid,T data)
		{
			data = default(T); 
			grid.AutoGenerateColumns = false;
			grid.DataSource = null;
			grid.Refresh();
		}
		public static void AddData<T>(DataGridView grid, List<T> data)
		{
			grid.AutoGenerateColumns = false;
			grid.DataSource = null;
			grid.Rows.Add();
			grid.DataSource = data;
			grid.Refresh();
		}
		public static void RemoveData<T>(DataGridView grid, List<T> data)
		{
			grid.AutoGenerateColumns = false;
			grid.DataSource = data;
			grid.Rows.Remove(grid.Rows[grid.Rows.Count]);
			grid.Refresh();
		}
		public static bool SetComInfo()
		{
			try
			{
				ChangeAppConfig.ChangeConfig("COMID", com.COMID);
				ChangeAppConfig.ChangeConfig("DataBits", com.DataBits.ToString());
				ChangeAppConfig.ChangeConfig("StopBit", com.StopBit.ToString());
				ChangeAppConfig.ChangeConfig("BaudRate", com.BaudRate.ToString());
				ChangeAppConfig.ChangeConfig("duration", com.duration.ToString());
				return true;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}
		//设置CallBtnSetting信息
		public static bool SetCallBtnSetting()
		{
			try
			{
				if (callbtnsetting != null && callbtnsetting.callBtnSettings != null)
				{
					foreach (var set in callbtnsetting.callBtnSettings)
					{
						ChangeAppConfig.ChangeConfig(set.Key.ToString().ToUpper(), set.Value);
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//获取CallBtnSetting信息
		public static CallBtnSetting GetCallBtnSetting()
		{
			try
			{
				CallBtnSetting set = new CallBtnSetting();
				System.Type tmp = typeof(CallBtnSetting.CallBtnType);
				foreach (var type in Enum.GetNames(tmp))
				{
					if (set.callBtnSettings == null)
						set.callBtnSettings = new Dictionary<CallBtnSetting.CallBtnType, string>();
					set.callBtnSettings.Add((CallBtnSetting.CallBtnType)Enum.Parse(typeof(CallBtnSetting.CallBtnType), type), ChangeAppConfig.getValueFromKey(type) == null ? "" : ChangeAppConfig.getValueFromKey(type));
				}
				return set;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return null;
			}
		}

		//获取OrderBy信息
		public static OrderBy GetOrederBy()
		{
			try
			{
				OrderBy orderby = new OrderBy();
				orderby.ordertype = ChangeAppConfig.getValueFromKey("orderby") == null ? OrderBy.OrderType.ASC : (OrderBy.OrderType)int.Parse(ChangeAppConfig.getValueFromKey("orderby"));

				return orderby;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return null;
			}
		}
		//设置OrdreBy信息
		public static bool SetOrdreBy()
		{
			try
			{
				if (orderby != null)
				{
					ChangeAppConfig.ChangeConfig("orderby", ((int)orderby.ordertype).ToString());
				}

				return true;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}
		//获取TimeColor信息
		public static TimeColor GetTimeColor()
		{
			try
			{
				TimeColor timecolor = new TimeColor();
				timecolor.WaitTime = ChangeAppConfig.getValueFromKey("waittimecolor") == null ? 0 : int.Parse(ChangeAppConfig.getValueFromKey("waittimecolor"));
				timecolor.TimeOutTime = ChangeAppConfig.getValueFromKey("timeouttimecolor") == null ? 0 : int.Parse(ChangeAppConfig.getValueFromKey("timeouttimecolor"));
				timecolor.FinishedTime = ChangeAppConfig.getValueFromKey("finishedtimecolor") == null ? 0 : int.Parse(ChangeAppConfig.getValueFromKey("finishedtimecolor"));

				return timecolor;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return null;
			}
		}
		//设置TimeColor信息
		public static bool SetTimeColor()
		{
			try
			{
				if (timecolor != null)
				{
					ChangeAppConfig.ChangeConfig("waittimecolor", JsonConvert.SerializeObject(timecolor.WaitTime));
					ChangeAppConfig.ChangeConfig("timeouttimecolor", JsonConvert.SerializeObject(timecolor.TimeOutTime));
					ChangeAppConfig.ChangeConfig("finishedtimecolor", JsonConvert.SerializeObject(timecolor.FinishedTime));
				}

				return true;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}
		//获取TimeOut信息
		public static int GetTimeOut()
		{
			try
			{
				TimeOut = ChangeAppConfig.getValueFromKey("TimeOut") == null ? 5 : int.Parse(ChangeAppConfig.getValueFromKey("TimeOut"));
				return TimeOut;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return 5;
			}
		}
		//设置TimeOut信息
		public static bool SetTimeOut()
		{
			try
			{
				ChangeAppConfig.ChangeConfig("TimeOut", TimeOut.ToString());
				return true;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public static int GetUnFinish()
		{
			try
			{
				UnFinish = ChangeAppConfig.getValueFromKey("UnFinish") == null ? 20 : int.Parse(ChangeAppConfig.getValueFromKey("UnFinish"));
				return UnFinish;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return 5;
			}
		}
		//设置UnFinish信息
		public static bool SetUnFinish()
		{
			try
			{
				ChangeAppConfig.ChangeConfig("UnFinish", UnFinish.ToString());
				return true;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}
	}
}
