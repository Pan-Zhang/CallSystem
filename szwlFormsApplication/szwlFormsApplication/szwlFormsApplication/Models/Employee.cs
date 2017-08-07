using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szwlFormsApplication.Models
{
	class Employee
	{
		public int Id { get; set; }
		public int num { get; set; }
		public string name { get; set; }
		public string phonenum { get; set; }
		public string remarks { get; set; }
		public Sex sex { get; set; }
	}

	public enum Sex
	{
		MALE,
		FEMALE
	}
}
