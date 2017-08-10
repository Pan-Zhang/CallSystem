using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szwlFormsApplication.Models
{
	public class COM
	{
		string _ID;
		int _dataBytes=1152000;
		int _baudRate=9600;
		int _stopByte=1;
		int _duration=5;

		//串口号
		public string COMID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}
		//数据位
		public int DataBytes
		{
			get
			{
				return _dataBytes;
			}
			set
			{
				_dataBytes = value;
			}
		}
		//波特率
		public int BaudRate
		{
			get
			{
				return _baudRate;
			}
			set
			{
				_baudRate = value;
			}
		}
		//停止位
		public int StopByte
		{
			get
			{
				return _stopByte;
			}
			set
			{
				_stopByte = value;
			}
		}
		//相同的呼叫间隔（秒）
		public int duration
		{
			get
			{
				return _duration;
			}
			set
			{
				_duration = value;
			}
		}
	}
}
