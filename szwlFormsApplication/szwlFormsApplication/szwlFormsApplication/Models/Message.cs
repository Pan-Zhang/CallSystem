using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szwlFormsApplication.Language;

namespace szwlFormsApplication.Models
{
	public class DataMessage
	{
		public int Id { get; set; }
		public string time { get; set; }
		public string callerNum { get; set; }
		public int employeeNum { get; set; }
		//呼叫器区域
		public int callZone { get; set; }
		public Type type { get; set; }
		public STATUS status { get; set; }
		public bool isRFID { get; set; }
		public double longTime { get; set; }
		public static string DisplaycallerNum()
		{
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MessagecallerNumHeader"]))
			{
				return GlobalData.GlobalLanguage.Caller_number;
			}
			else
			{
				return ConfigurationManager.AppSettings["MessagecallerNumHeader"];
			}
		}

		public DateTime timeConvert()
		{
			return Convert.ToDateTime(time);
		}
		public static string DisplaycallZone()
		{
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MessagecallZoneHeader"]))
			{
				return GlobalData.GlobalLanguage.Caller_zone;
			}
			else
			{
				return ConfigurationManager.AppSettings["MessagecallZoneHeader"];
			}
		}
		public static string DisplayemployeeNum()
		{
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MessageemployeeNumHeader"]))
			{
				return GlobalData.GlobalLanguage.employee_num;
			}
			else
			{
				return ConfigurationManager.AppSettings["MessageemployeeNumHeader"];
			}
		}
		public static string Displaytype()
		{
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MessagetypeHeader"]))
			{
				return GlobalData.GlobalLanguage.type;
			}
			else
			{
				return ConfigurationManager.AppSettings["MessagetypeHeader"];
			}
		}
		public static string Displaystatus()
		{
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MessagestatusHeader"]))
			{
				return GlobalData.GlobalLanguage.status;
			}
			else
			{
				return ConfigurationManager.AppSettings["MessagestatusHeader"];
			}
		}
		public static string Displaytime()
		{
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MessagetimeHeader"]))
			{
				return GlobalData.GlobalLanguage.Time;
			}
			else
			{
				return ConfigurationManager.AppSettings["MessagetimeHeader"];
			}
		}
	}

	public enum Type
	{
		CANCEL,
		ORDER,
		CALL,
		CHECK_OUT,
		CHANGE_MEDICATION,
		EMERGENCY_CALL,
		PULING_NEEDLE,
		NEED_SERVICE,
		NEED_WATER,
		WANT_TO_PAY,
		NEED_NURSES,
		SATISFIED,
		DISSATISFIED,
		LOW_POWER,
		TAMPER
	}

	public enum STATUS
	{
		WAITING,
		FINISH,
		OVERTIME
	}
}
