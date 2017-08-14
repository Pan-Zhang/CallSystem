using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szwlFormsApplication.Models
{
	public class CallBtnSetting
	{
		public enum CallBtnType
		{
			A,
			B,
			C,
			D,
			E,
			F
		}

		public Dictionary<CallBtnType, string> callBtnSettings { get; set; }
	}
}
