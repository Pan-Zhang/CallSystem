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
				case 0: return GlobalData.GlobalLanguage.user_login;
				case 1: return GlobalData.GlobalLanguage.system_setting;
				case 2: return GlobalData.GlobalLanguage.caller_setting;
				case 3: return GlobalData.GlobalLanguage.user_setting;
				case 4: return GlobalData.GlobalLanguage.employee_setting;
				case 5: return GlobalData.GlobalLanguage.header_setting;
				case 6: return GlobalData.GlobalLanguage.data_setting;
				case 7: return GlobalData.GlobalLanguage.summary_setting;
				case 8: return GlobalData.GlobalLanguage.about_setting;
			default: return null;
			}
		}
	}
}
