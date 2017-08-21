using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EmployeeIdHeader"]))
			{
				return "服务员主键";
			}
			else
			{
				return ConfigurationManager.AppSettings["EmployeeIdHeader"];
			}
		}
		public static string DisplayemployeeNum()
		{
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EmployeeemployeeNumHeader"]))
			{
				return "服务员编号";
			}
			else
			{
				return ConfigurationManager.AppSettings["EmployeeemployeeNumHeader"];
			}
		}
		public static string Displayname()
		{
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EmployeenameHeader"]))
			{
				return "姓名";
			}
			else
			{
				return ConfigurationManager.AppSettings["EmployeenameHeader"];
			}
		}
		public static string Displayphonenum()
		{
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EmployeephonenumHeader"]))
			{
				return "电话号码";
			}
			else
			{
				return ConfigurationManager.AppSettings["EmployeephonenumHeader"];
			}
		}
		public static string Displayremarks()
		{
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EmployeeremarksHeader"]))
			{
				return "备注";
			}
			else
			{
				return ConfigurationManager.AppSettings["EmployeeremarksHeader"];
			}
		}
		public static string Displaysex()
		{
			if (String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EmployeesexHeader"]))
			{
				return "性别";
			}
			else
			{
				return ConfigurationManager.AppSettings["EmployeesexHeader"];
			}
		}
	}

	public enum Sex
	{
		MALE,
		FEMALE
	}
}
