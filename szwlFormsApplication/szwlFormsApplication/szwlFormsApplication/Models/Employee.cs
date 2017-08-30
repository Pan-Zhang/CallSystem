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
	public class Employee
	{
		//服务员主键
		public int Id { get; set; }
		//服务员编号
		public int employeeNum { get; set; }
		//服务员姓名
		public string name { get; set; }
		//服务员电话号码
		public string phonenum { get; set; }
		//服务员备注
		public string remarks { get; set; }
		//服务员性别
		public Sex sex { get; set; }
		public static string DisplayId()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("EmployeeIdHeader")))
			{
				return GlobalData.GlobalLanguage.ID;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("EmployeeIdHeader");
			}
		}
		public static string DisplayemployeeNum()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("EmployeeemployeeNumHeader")))
			{
				return GlobalData.GlobalLanguage.employee_num;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("EmployeeemployeeNumHeader");
			}
		}
		public static string Displayname()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("EmployeenameHeader")))
			{
				return GlobalData.GlobalLanguage.employee_name;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("EmployeenameHeader");
			}
		}
		public static string Displayphonenum()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("EmployeephonenumHeader")))
			{
				return GlobalData.GlobalLanguage.telephone;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("EmployeephonenumHeader");
			}
		}
		public static string Displayremarks()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("EmployeeremarksHeader")))
			{
				return GlobalData.GlobalLanguage.remarks;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("EmployeeremarksHeader");
			}
		}
		public static string Displaysex()
		{
			if (String.IsNullOrWhiteSpace(ChangeAppConfig.getValueFromKey("EmployeesexHeader")))
			{
				return GlobalData.GlobalLanguage.gender;
			}
			else
			{
				return ChangeAppConfig.getValueFromKey("EmployeesexHeader");
			}
		}
	}

	public enum Sex
	{
		MALE,
		FEMALE
	}
}
