using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szwlFormsApplication.CommonFunc;
using szwlFormsApplication.Language;

namespace szwlFormsApplication.Models
{
	public class DataMessage
	{
		public int Id { get; set; }
		public string time { get; set; }
		public string callerNum { get; set; }
		public string showEmployeeNum
		{
			get {
				if (employeeNum == -1 || employeeNum == 0) return "";
				else if (employeeNum == -2) return "Admin";
				else
				{
					string name = employeeNum.ToString();
					if (Common.isRFID)
					{
						foreach (Employee emp in InitData.employeeRFID)
						{
							if (emp.employeeNum == employeeNum)
							{
								if (!string.IsNullOrEmpty(emp.name))
								{
									name = emp.name;
								}
								break;
							}
						}
					}
					else
					{
						foreach (Employee emp in InitData.employees)
						{
							if (emp.employeeNum == employeeNum)
							{
								if (!string.IsNullOrEmpty(emp.name))
								{
									name = emp.name;
								}
								break;
							}
						}
					}
					return name;
				}
			}
			set { }
		}
		//呼叫器区域
		public int callZone { get; set; }
		
		public string showType {
			get { return getType(); }
			set { }
		}
		public STATUS status { get; set; }
		public string showRFID
		{
			get { return isRFID ? employeeNum.ToString() : ""; }
			set { }
		}
		public bool isOverTime { get; set; }
		public Type type { get; set; }
		public bool isRFID { get; set; }
		public int employeeNum { get; set; }
		public double longTime { get; set; }
		public string showOverTime
		{
			get { return isOverTime?GlobalData.GlobalLanguage.yes:GlobalData.GlobalLanguage.no; }
			set { }
		}
		public static string DisplaycallerNum()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("MessagecallerNumHeader")))
			{
				return GlobalData.GlobalLanguage.Caller_number;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("MessagecallerNumHeader");
			}
		}

		public string getType()
		{
			string str = "";
			switch (type)
			{
				case Type.ORDER:
					if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("A")))
					{
						str = GlobalData.GlobalLanguage.Call;
					}
					else
					{
						str = ChangeAppConfig.getValueFromKey("A");
					}
					break;

				case Type.CALL:
					if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("B")))
					{
						str = GlobalData.GlobalLanguage.Call;
					}
					else
					{
						str = ChangeAppConfig.getValueFromKey("B");
					}
					break;

				case Type.CHECK_OUT:
					if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("C")))
					{
						str = GlobalData.GlobalLanguage.Call;
					}
					else
					{
						str = ChangeAppConfig.getValueFromKey("C");
					}
					break;

				case Type.SATISFIED:
					if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("D")))
					{
						str = GlobalData.GlobalLanguage.Call;
					}
					else
					{
						str = ChangeAppConfig.getValueFromKey("D");
					}
					break;

				case Type.DISSATISFIED:
					if (string.IsNullOrEmpty(ChangeAppConfig.getValueFromKey("E")))
					{
						str = GlobalData.GlobalLanguage.Call;
					}
					else
					{
						str = ChangeAppConfig.getValueFromKey("E");
					}
					break;

				default:
					type.ToString();
					break;
			}
			return str;
		}

		public string getZoneName()
		{
			foreach(Caller caller in InitData.list_caller)
			{
				if (caller.callerNum == callerNum)
				{
					foreach(Callzone zone in InitData.list_zone)
					{
						if (zone.Id == caller.callZone)
						{
							return zone.name;
						}
					}
				}
			}
			return "";
		}

		public DateTime timeConvert()
		{
			return Convert.ToDateTime(time);
		}
		public static string DisplaycallZone()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("MessagecallZoneHeader")))
			{
				return GlobalData.GlobalLanguage.Caller_zone;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("MessagecallZoneHeader");
			}
		}
		public static string DisplayemployeeNum()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("MessageemployeeNumHeader")))
			{
				return GlobalData.GlobalLanguage.employee_num;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("MessageemployeeNumHeader");
			}
		}
		public static string Displaytype()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("MessagetypeHeader")))
			{
				return GlobalData.GlobalLanguage.type;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("MessagetypeHeader");
			}
		}
		public static string Displaystatus()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("MessagestatusHeader")))
			{
				return GlobalData.GlobalLanguage.status;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("MessagestatusHeader");
			}
		}
		public static string Displaytime()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("MessagetimeHeader")))
			{
				return GlobalData.GlobalLanguage.Time;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("MessagetimeHeader");
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
		OVERTIME,
		UNFINISH
	}
}
