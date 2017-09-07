using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szwlFormsApplication.Models
{
	public class Caller
	{
		//呼叫器主键
		public int ID { get; set; }
		//呼叫器编号
		public string callerNum { get; set; }
		//呼叫器区域
		public int callZone { get; set; }
		//服务员编号
		public int employeeNum { get; set; }
		public string callerName { get; set; }
		public string callerZoneName { get; set; }
		public string showEmployeeNum
		{
			get { if(employeeNum == -1 || employeeNum == 0) return ""; else return employeeNum.ToString(); }
			set { }
		}
	}
}
