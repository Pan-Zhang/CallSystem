using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szwlFormsApplication.Models
{
	public class DataMessage
	{
		public int Id { get; set; }
		public DateTime time { get; set; }
		public int callerNum { get; set; }
		public int employeeNum { get; set; }
		public Type type { get; set; }
		public STATUS status { get; set; }
		public bool isRFID { get; set; }
	}

	public enum Type
	{
		CANCEL,
		ORDER,
		CALL,
		CHECK_OUT,
		CHANGE_MEDICATION,
		EMERGENCY_CALL,
		PULING_NEEDLE,
		NEED_SERVICE,
		NEED_WATER,
		WANT_TO_PAY,
		NEED_NURSES,
		SATISFIED,
		DISSATISFIED,
		LOW_POWER,
		TAMPER
	}

	public enum STATUS
	{
		WAITING,
		FINISH,
		OVERTIME
	}
}
