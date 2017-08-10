using System;
using System.Collections.Generic;
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
	}

	public enum Sex
	{
		MALE,
		FEMALE
	}
}
