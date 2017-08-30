using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szwlFormsApplication.Models
{
	public class Summary
	{
		public string callerNum { get; set; }
		public string zoneName { get; set; }
		public string employeeName { get; set; }
		public int employeeNum { get; set; }
		public int count { get; set; }
		public int total { get; set; }
		public string percent
		{
			get { return total==0?"":(float)count * 100 / total + "%"; }
			set { }
		}
	}
}
