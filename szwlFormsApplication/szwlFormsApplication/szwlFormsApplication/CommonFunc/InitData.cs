using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szwlFormsApplication.Models;

namespace szwlFormsApplication.CommonFunc
{
	/// <summary>
	/// 初始化数据 将呼叫器、服务员、当日的呼叫消息、串口信息 从数据库中读取出来 加入静态资源中 
	/// 这些数据在系统生命周期中存在 
	/// 这些数据将会根据当前系统的处理进行更新
	/// 这些数据在系统关闭时进行保存更新数据库
	/// </summary>
	public class InitData
	{
		//初始化串口号
		public static COM com = new COM();

		public static List<User> allUsers = null;
		public static List<Callzone> allcallZone = null;
		public static List<Employee> allemployee = null;
		public static List<DataMessage> allCurrentDayMsg = null;
		public static void Init()
		{
			DBManager manager = new DBManager();
			allUsers = manager.selectUser();
			allcallZone = manager.selectZone();
			allemployee = manager.selectEmployee();
			allCurrentDayMsg = manager.selectMess();
		}
	}
}
