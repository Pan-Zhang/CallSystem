using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szwlFormsApplication.Models
{
	public class OrderBy
	{
		public enum OrderType { ASC,DESC}
		public OrderType ordertype { get; set; }
	}
}
