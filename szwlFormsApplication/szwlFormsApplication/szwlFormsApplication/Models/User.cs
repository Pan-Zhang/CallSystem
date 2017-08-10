using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
