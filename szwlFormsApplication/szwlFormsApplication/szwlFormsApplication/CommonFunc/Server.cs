using System;
using System.IO.Ports;
using System.Collections.Generic;
using szwlFormsApplication.Models;
using System.Threading;
using System.Globalization;

namespace szwlFormsApplication.CommonFunc
{
	public class Server
	{
		public SerialPort com;

		public Boolean Listening;
		public Boolean Closing;

		List<Employee> employee_list;//员工信息缓存数据，避免每次都去查询员工表

		private List<byte> buffer = new List<byte>(4096);//默认分配1页内存，并始终限制不允许超过 
		Dictionary<int, byte[]> dic = new Dictionary<int, byte[]>();
		public RefreshInterface refreshInterface { get; set; }

		public Server()
		{
			employee_list = InitData.employeeRFID;
		}

		public void open()
		{
			com = new SerialPort();
			com.BaudRate = 115200;
			com.PortName = "COM3";
			com.DataBits = 8;
			com.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
			com.Open();//打开串口
					   //Console.ReadKey();
		}

		public Tuple<bool,string> open(COM Com)
		{
			try
			{
				com = new SerialPort();
				com.BaudRate = Com.BaudRate;
				com.PortName = Com.COMID;
				com.DataBits =Com.DataBits;
				com.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
				com.Open();//打开串口
						   //Console.ReadKey();
				return Tuple.Create(true,default(string));
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return Tuple.Create(false,ex.Message);
			}
		}

		private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			//53 5A 57 4C    00    03    03 E6    02    3E 为 998 号桌 Call
			//53 5A 57 4C    01    03    03 E6    60    9D 为 998 号桌 被 96 号服务员服务

			if (Closing) return;//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环
			//Thread.Sleep(200);
			try
			{
				Listening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI的。  
				int n = com.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
				byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据    
				com.Read(buf, 0, n);//读取缓冲数据  
									/////////////////////////////////////////////////////////////////////////////////////////////////////////////  
									//<协议解析>  
				bool data_1_catched = false;//缓存记录数据是否捕获到  
											//1.缓存数据  
				buffer.AddRange(buf);
				//2.完整性判断  
				while (buffer.Count >= 10)//有两种数据，最短十个 
				{
					//2.1 查找数据头  
					if (buffer[0] == 0x53 && buffer[1] == 0x5A && buffer[2] == 0x57 && buffer[3] == 0x4C)
					{
						int len = buffer[5];//数据长度  
						int totalLen = len + 7;
						if (buffer.Count < totalLen) break;//数据不够的时候什么都不做  
						byte checksum = 0;//校验和校验，逐个字节异或得到校验码  
						for (int i = 0; i < len + 6; i++)//len+6表示校验之前的位置  
						{
							//checksum ^= buffer[i];
							checksum += buffer[i];
						}

						if (checksum != buffer[len + 6]) //如果数据校验失败，丢弃这一包数据  
						{
							buffer.RemoveRange(0, totalLen);//从缓存中删除错误数据  
							continue;//继续下一次循环  
						}
						byte[] binary_data_1;
						if (dic.ContainsKey(totalLen))
						{
							dic.TryGetValue(totalLen, out binary_data_1);
						}
						else
						{
							binary_data_1 = new byte[totalLen];
							dic.Add(totalLen, binary_data_1);
						}

						buffer.CopyTo(0, binary_data_1, 0, totalLen);//复制一条完整数据到具体的数据缓存  
						data_1_catched = true;
						//53 5A 57 4C 01 03 03 E6 60 9D
						buffer.RemoveRange(0, totalLen);//正确分析一条数据，从缓存中移除数据。
													   //解析数据  
						Analytic(binary_data_1);
					}
					else
					{
						//这里是很重要的，如果数据开始不是头，则删除数据  
						buffer.RemoveAt(0);
					}
				}
				//更新通知
				if (refreshInterface != null)
				{
					refreshInterface.refresh(null, true);
				}
			}
			finally
			{
				Listening = false;//我用完了，ui可以关闭串口了。  
			}
		}

		public void Analytic(byte[] bytes)
		{
			if (!Common.isRFID && (bytes[4] == 0x02 || bytes[4] == 0x12))
			{
				return;
			}

			int len = bytes[5];
			if (bytes[4] == 0)//呼叫服务
			{
				short s = 0;   //一个16位整形变量，初值为 0000 0000 0000 0000
				byte b1 = bytes[6];   //一个byte的变量，作为转换后的高8位，假设初值为 0000 0001
				byte b2 = bytes[7];   //一个byte的变量，作为转换后的低8位，假设初值为 0000 0010
				s = (short)(s ^ b1);  //将b1赋给s的低8位
				s = (short)(s << 8);  //s的低8位移动到高8位
				s = (short)(s ^ b2); //在b2赋给s的低8位
				int table = (int)s; //几号桌
				int type = bytes[5 + len];//服务类型
				DataMessage message = new DataMessage();
				message.callerNum = table.ToString();
				DateTimeFormatInfo datestyle = new CultureInfo("en-US",false).DateTimeFormat;
				message.time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				long ti = DateTime.Now.ToFileTime();
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Info, message.timeConvert().ToString());
				message.isRFID = false;
				message.status = STATUS.WAITING;
				message.employeeNum = -1;
				switch (type)
				{
					case 0:
						message.type = Models.Type.CANCEL;
						message.status = STATUS.FINISH;//收到cancel请求，就认为完成服务
						szwlForm.mainForm.dm.updateMess(message);
						//更新通知
						if (refreshInterface != null)
						{
							refreshInterface.refresh(message, false);
						}
						return;

					case 1:
						message.type = Models.Type.ORDER;
						break;

					case 2:
						message.type = Models.Type.CALL;
						break;

					case 3:
						message.type = Models.Type.CHECK_OUT;
						break;

					case 4:
						message.type = Models.Type.CHANGE_MEDICATION;
						break;

					case 5:
						message.type = Models.Type.EMERGENCY_CALL;
						break;

					case 6:
						message.type = Models.Type.PULING_NEEDLE;
						break;

					case 7:
						message.type = Models.Type.NEED_SERVICE;
						break;

					case 8:
						message.type = Models.Type.NEED_WATER;
						break;

					case 9:
						message.type = Models.Type.WANT_TO_PAY;
						break;

					case 10:
						message.type = Models.Type.NEED_NURSES;
						break;

					case 11:
						message.type = Models.Type.SATISFIED;
						message.status = STATUS.FINISH;//收到评价请求，默认为已完成的服务
						break;

					case 12:
						message.type = Models.Type.DISSATISFIED;
						message.status = STATUS.FINISH;//收到评价请求，默认为已完成的服务
						break;

					case 13:
						message.type = Models.Type.LOW_POWER;
						break;

					case 14:
						message.type = Models.Type.TAMPER;
						break;
				}
				 var t=szwlForm.mainForm.dm.insertMess(message);
				//更新通知
				if (t&&refreshInterface != null)
				{
					refreshInterface.refresh(message, false);
				}

			}
			else if (bytes[4] == 2)//上报服务
			{
				short s = 0;   //一个16位整形变量，初值为 0000 0000 0000 0000
				byte b1 = bytes[6];   //一个byte的变量，作为转换后的高8位，假设初值为 0000 0001
				byte b2 = bytes[7];   //一个byte的变量，作为转换后的低8位，假设初值为 0000 0010
				s = (short)(s ^ b1);  //将b1赋给s的低8位
				s = (short)(s << 8);  //s的低8位移动到高8位
				s = (short)(s ^ b2); //在b2赋给s的低8位
				int table = (int)s; //几号桌
				int number = bytes[5 + len];//对应服务员编号
				DataMessage message = new DataMessage();
				message.callerNum = table.ToString();
				message.employeeNum = number;
				message.isRFID = true;
				message.time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				message.status = STATUS.FINISH;
				szwlForm.mainForm.dm.updateMess(message);
				bool exist = false;
				employee_list = InitData.employeeRFID;
				foreach (Employee employee in employee_list)
				{
					if (employee.employeeNum == message.employeeNum)
					{
						exist = true;
						break;
					}
				}
				if (!exist)
				{
					Employee employ = new Employee();
					employ.employeeNum = message.employeeNum;
					szwlForm.mainForm.dm.insertEmployeeRFID(employ);
					InitData.employeeRFID.Add(employ);
					employee_list = InitData.employeeRFID;
				}
				//更新通知
				if (refreshInterface != null)
				{
					refreshInterface.refresh(message, false);
				}

			}
			else if(bytes[4] == 0x10)//呼叫服务
			{
				byte[] stringHex = new byte[len-1];
				for(int i=0; i<len-1; i++)
				{
					stringHex[i] = bytes[6 + i];
				}
				string table = UnHex(byteToHexStr(stringHex), "utf-8");
				int type = bytes[5 + len];//服务类型
				DataMessage message = new DataMessage();
				message.callerNum = table;
				DateTimeFormatInfo datestyle = new CultureInfo("en-US", false).DateTimeFormat;
				message.time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Info, message.timeConvert().ToString());
				message.isRFID = false;
				message.status = STATUS.WAITING;
				message.employeeNum = -1;
				switch (type)
				{
					case 0:
						message.type = Models.Type.CANCEL;
						message.status = STATUS.FINISH;//收到cancel请求，就认为完成服务
						szwlForm.mainForm.dm.updateMess(message);
						//更新通知
						if (refreshInterface != null)
						{
							refreshInterface.refresh(message, false);
						}
						return;

					case 1:
						message.type = Models.Type.ORDER;
						break;

					case 2:
						message.type = Models.Type.CALL;
						break;

					case 3:
						message.type = Models.Type.CHECK_OUT;
						break;

					case 4:
						message.type = Models.Type.CHANGE_MEDICATION;
						break;

					case 5:
						message.type = Models.Type.EMERGENCY_CALL;
						break;

					case 6:
						message.type = Models.Type.PULING_NEEDLE;
						break;

					case 7:
						message.type = Models.Type.NEED_SERVICE;
						break;

					case 8:
						message.type = Models.Type.NEED_WATER;
						break;

					case 9:
						message.type = Models.Type.WANT_TO_PAY;
						break;

					case 10:
						message.type = Models.Type.NEED_NURSES;
						break;

					case 11:
						message.type = Models.Type.SATISFIED;
						message.status = STATUS.FINISH;//收到评价请求，默认为已完成的服务
						break;

					case 12:
						message.type = Models.Type.DISSATISFIED;
						message.status = STATUS.FINISH;//收到评价请求，默认为已完成的服务
						break;

					case 13:
						message.type = Models.Type.LOW_POWER;
						break;

					case 14:
						message.type = Models.Type.TAMPER;
						break;
				}
				var t = szwlForm.mainForm.dm.insertMess(message);
				//更新通知
				if (t && refreshInterface != null)
				{
					refreshInterface.refresh(message, false);
				}
			}
			else if(bytes[4] == 0x12)//上报服务
			{
				byte[] stringHex = new byte[len - 1];
				for (int i = 0; i < len - 1; i++)
				{
					stringHex[i] = bytes[6 + i];
				}
				string table = UnHex(byteToHexStr(stringHex), "utf-8");
				int number = bytes[5 + len];//对应服务员编号
				DataMessage message = new DataMessage();
				message.callerNum = table;
				message.employeeNum = number;
				message.isRFID = true;
				message.time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				message.status = STATUS.FINISH;
				szwlForm.mainForm.dm.updateMess(message);
				bool exist = false;
				employee_list = InitData.employeeRFID;
				foreach (Employee employee in employee_list)
				{
					if (employee.employeeNum == message.employeeNum)
					{
						exist = true;
						break;
					}
				}
				if (!exist)
				{
					Employee employ = new Employee();
					employ.employeeNum = message.employeeNum;
					szwlForm.mainForm.dm.insertEmployeeRFID(employ);
					InitData.employeeRFID.Add(employ);
					employee_list = InitData.employeeRFID;
				}
				//更新通知
				if (refreshInterface != null)
				{
					refreshInterface.refresh(message, false);
				}
			}
		}

		public static string UnHex(string hex, string charset)
		{
			if (hex == null)
				throw new ArgumentNullException("hex");
			hex = hex.Replace(",", "");
			hex = hex.Replace("\n", "");
			hex = hex.Replace("\\", "");
			hex = hex.Replace(" ", "");
			if (hex.Length % 2 != 0)
			{
				hex += "20";//空格 
			}
			// 需要将 hex 转换成 byte 数组。 
			byte[] bytes = new byte[hex.Length / 2];
			for (int i = 0; i < bytes.Length; i++)
			{
				try
				{
					// 每两个字符是一个 byte。 
					bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
					System.Globalization.NumberStyles.HexNumber);
				}
				catch(Exception e)
				{
					LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, e.ToString());
				}
			}
			System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
			return chs.GetString(bytes);
		}

		public static string byteToHexStr(byte[] bytes)
		{
			string returnStr = "";
			if (bytes != null)
			{
				for (int i = 0; i < bytes.Length; i++)
				{
					returnStr += bytes[i].ToString("X2");
				}
			}
			return returnStr;
		}

		public void sentData(Byte[] data)
		{
			com.Write(data, 0, data.Length);
		}

		public List<DataMessage> selectMess()
		{
			return szwlForm.mainForm.dm.selectMess();
		}

		public List<DataMessage> selectMess(long longTime)
		{
			return szwlForm.mainForm.dm.selectMess(longTime);
		}

		public bool updateMessTimeOut(DataMessage mess)
		{
			return szwlForm.mainForm.dm.updateMessTimeOut(mess);
		}
	}
}
