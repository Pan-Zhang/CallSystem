using System;
using System.IO.Ports;
using System.Collections.Generic;
using szwlFormsApplication.Models;
using System.Threading;

namespace szwlFormsApplication.CommonFunc
{
	class Server
	{
		public SerialPort com;

		public Boolean RFID = true;
		public Boolean Listening;
		public Boolean Closing;
		private byte[] binary_data_1 = new byte[10];//53 5A 57 4C 01 03 03 E6 60 9D 

		List<Employee> employee_list;//员工信息缓存数据，避免每次都去查询员工表

		private List<byte> buffer = new List<byte>(4096);//默认分配1页内存，并始终限制不允许超过 

		DBManager dm;

		public RefreshInterface refreshInterface { get; set; }

		public Server()
		{
			dm = new DBManager();
			employee_list = dm.selectEmployeeRFID();
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

		public void open(int ComNum)
		{
			com = new SerialPort();
			com.BaudRate = 115200;
			com.PortName = "COM" + ComNum.ToString();
			com.DataBits = 8;
			com.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
			com.Open();//打开串口
			//Console.ReadKey();
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
				while (buffer.Count >= 7)//至少要包含头（4字节）+长度（1字节）+校验（1字节）  
				{
					//请不要担心使用>=，因为>=已经和>,<,=一样，是独立操作符，并不是解析成>和=2个符号  
					//2.1 查找数据头  
					if (buffer[0] == 0x53 && buffer[1] == 0x5A && buffer[2] == 0x57 && buffer[3] == 0x4C)
					{
						//2.2 探测缓存数据是否有一条数据的字节，如果不够，就不用费劲的做其他验证了  
						//前面已经限定了剩余长度>=7，那我们这里一定能访问到buffer[5]这个长度  
						int len = buffer[5];//数据长度  
											//数据完整判断第一步，长度是否足够  
											//len是数据段长度,4个字节是while行注释的3部分长度  
						if (buffer.Count < len + 7) break;//数据不够的时候什么都不做  
														  //这里确保数据长度足够，数据头标志找到，我们开始计算校验  
														  //2.3 校验数据，确认数据正确  
														  //校验和校验，逐个字节异或得到校验码  
						byte checksum = 0;


						for (int i = 0; i < len + 6; i++)//len+7表示校验之前的位置  
						{
							//checksum ^= buffer[i];
							checksum += buffer[i];
						}

						if (checksum != buffer[len + 6]) //如果数据校验失败，丢弃这一包数据  
						{
							buffer.RemoveRange(0, len + 7);//从缓存中删除错误数据  
							continue;//继续下一次循环  
						}
						//至此，已经被找到了一条完整数据。我们将数据直接分析，或是缓存起来一起分析  
						//我们这里采用的办法是缓存一次，好处就是如果你某种原因，数据堆积在缓存buffer中  
						//已经很多了，那你需要循环的找到最后一组，只分析最新数据，过往数据你已经处理不及时  
						//了，就不要浪费更多时间了，这也是考虑到系统负载能够降低。  
						buffer.CopyTo(0, binary_data_1, 0, len + 7);//复制一条完整数据到具体的数据缓存  
						data_1_catched = true;
						//53 5A 57 4C 01 03 03 E6 60 9D
						buffer.RemoveRange(0, len + 7);//正确分析一条数据，从缓存中移除数据。
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
			if (!RFID && bytes[4] == 0x01)
			{
				return;
			}

			int len = binary_data_1[5];
			if (binary_data_1[4] == 0)//呼叫服务
			{
				short s = 0;   //一个16位整形变量，初值为 0000 0000 0000 0000
				byte b1 = binary_data_1[6];   //一个byte的变量，作为转换后的高8位，假设初值为 0000 0001
				byte b2 = binary_data_1[7];   //一个byte的变量，作为转换后的低8位，假设初值为 0000 0010
				s = (short)(s ^ b1);  //将b1赋给s的低8位
				s = (short)(s << 8);  //s的低8位移动到高8位
				s = (short)(s ^ b2); //在b2赋给s的低8位
				int table = (int)s; //几号桌
				int type = binary_data_1[5 + len];//服务类型
				DataMessage message = new DataMessage();
				message.callerNum = table;
				DateTime dateTime = new DateTime();
				message.time = DateTime.Now;
				message.isRFID = false;
				message.status = STATUS.WAITING;
				message.workerNum = -1;
				switch (type)
				{
					case 0:
						message.type = Models.Type.CANCEL;
						message.status = STATUS.FINISH;//收到cancel请求，就认为完成服务
						dm.updateMess(message);
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
				dm.insertMess(message);
				//更新通知
				if (refreshInterface != null)
				{
					refreshInterface.refresh(message, false);
				}

			}
			else if (binary_data_1[4] == 1)//上报服务
			{
				short s = 0;   //一个16位整形变量，初值为 0000 0000 0000 0000
				byte b1 = binary_data_1[6];   //一个byte的变量，作为转换后的高8位，假设初值为 0000 0001
				byte b2 = binary_data_1[7];   //一个byte的变量，作为转换后的低8位，假设初值为 0000 0010
				s = (short)(s ^ b1);  //将b1赋给s的低8位
				s = (short)(s << 8);  //s的低8位移动到高8位
				s = (short)(s ^ b2); //在b2赋给s的低8位
				int table = (int)s; //几号桌
				int number = binary_data_1[5 + len];//对应服务员编号
				DataMessage message = new DataMessage();
				message.callerNum = table;
				message.workerNum = number;
				message.isRFID = true;
				message.time = DateTime.Now;
				message.status = STATUS.FINISH;
				dm.updateMess(message);
				bool exist = false;
				foreach (Employee employee in employee_list)
				{
					if (employee.num == message.workerNum)
					{
						exist = true;
						break;
					}
				}
				if (!exist)
				{
					Employee employ = new Employee();
					employ.num = message.workerNum;
					dm.insertEmployeeRFID(employ);
					employee_list = dm.selectEmployeeRFID();
				}
				//更新通知
				if (refreshInterface != null)
				{
					refreshInterface.refresh(message, false);
				}
				
			}
		}

		public void sentData(Byte[] data)
		{
			com.Write(data, 0, data.Length);
		}

		public List<DataMessage> selectMess()
		{
			return dm.selectMess();
		}

		public bool updateMessTimeOut(DataMessage mess)
		{
			return dm.updateMessTimeOut(mess);
		}
	}
}
