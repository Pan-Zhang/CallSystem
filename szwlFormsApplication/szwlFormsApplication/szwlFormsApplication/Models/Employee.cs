using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szwlFormsApplication.Models
{
	class Employee
	{
		public int Id;
		public int num;
		public string name;
		public string phonenum;
		public string remarks;
		public Sex sex;
	}

	public enum Sex
	{
		MALE,
		FEMALE
	}
}
