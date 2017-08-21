using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szwlFormsApplication.CommonFunc;

namespace szwlFormsApplication.Models
{
	/// <summary>
	/// 登录用户
	/// </summary>
	public class User
	{
		public int id { get; set; }
		public string name { get; set; }
		public string pass { get; set; }
		public enum UserClass
		{
			Admin,
			normal
		}
		public UserClass userClass { get; set; }
		public List<int> programs { get; set; }
	}
	public class UserProgram
	{
		public UserProgram() { }
		public UserProgram(User user)
		{
			if (user == null)
				return;
			if (user.programs == null || user.programs.Count == 0)
			{
				userclass = user.userClass;
				if (ConfigurationManager.AppSettings[Key] == null)
				{
					switch (userclass)
					{
						case User.UserClass.Admin: ChangeAppConfig.ChangeConfig(Key, "0_1_2_3_4_5_6_7_8"); break;
						case User.UserClass.normal: ChangeAppConfig.ChangeConfig(Key, "0_3_4_7_8"); break;
					}
				}
				programs = ConfigurationManager.AppSettings[Key].Split('_').Select(p => int.Parse(p)).ToList();
			}
			else
			{
				programs = user.programs;
			}
			user.programs = programs;
		}
		public User.UserClass userclass { get; set; }
		public List<int> programs { get; set; }
		public string Key
		{
			get { return string.Format("UserProgram_{0}", userclass.ToString()); }
		}
		public static string DisplayProgram(int p)
		{
			switch (p)
			{
				case 0: return "用户登录";
				case 1: return "系统设置";
				case 2: return "用户";
				case 3: return "呼叫器设置";
				case 4: return "员工设置";
				case 5: return "表头设置";
				case 6: return "数据维护";
				case 7: return "数据统计";
				case 8: return "关于";
				default: return null;
			}
		}
	}
}
