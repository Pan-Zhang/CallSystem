using System;
using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json;
using szwlFormsApplication.Models;

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
		public static COM com = Common.GetComInfo();
		public static CallBtnSetting callbtnsetting = GetCallBtnSetting();
		public static OrderBy orderby = GetOrederBy();
		public static TimeColor timecolor = GetTimeColor();
		public static int TimeOut = 5;

		//设置COM信息
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
					set.callBtnSettings.Add((CallBtnSetting.CallBtnType)Enum.Parse(typeof(CallBtnSetting.CallBtnType), type), ConfigurationManager.AppSettings[type] == null ? "" : ConfigurationManager.AppSettings[type]);
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
				orderby.ordertype = ConfigurationManager.AppSettings["orderby"] == null ? OrderBy.OrderType.ASC : (OrderBy.OrderType)int.Parse(ConfigurationManager.AppSettings["orderby"]);

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
				timecolor.WaitTime = ConfigurationManager.AppSettings["waittimecolor"] == null ? 0 : int.Parse(ConfigurationManager.AppSettings["waittimecolor"]);
				timecolor.TimeOutTime = ConfigurationManager.AppSettings["timeouttimecolor"] == null ? 0 : int.Parse(ConfigurationManager.AppSettings["timeouttimecolor"]);
				timecolor.FinishedTime = ConfigurationManager.AppSettings["finishedtimecolor"] == null ? 0 : int.Parse(ConfigurationManager.AppSettings["finishedtimecolor"]);

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
				TimeOut = ConfigurationManager.AppSettings["TimeOut"] == null ? 5 : int.Parse(ConfigurationManager.AppSettings["TimeOut"]);
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
	}
}
