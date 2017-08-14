using ADOX;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szwlFormsApplication.Models;

namespace szwlFormsApplication.CommonFunc
{
	public class DBManager
	{
		string TABLE_ADMIN = "Admin_tb";
		string TABLE_EMPLOYEE = "Employee_tb";
		string TABLE_EMPLOYEE_RFID = "EmployeeRFID_tb";
		string TABLE_ZONE = "Zone_tb";
		string TABLE_CALLER = "Caller_tb";
		string TABLE_MESS = "Mess_tb";

		string systemPath = String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["systemPath"]) ? "D:\\szwl" : ConfigurationManager.AppSettings["systemPath"];

		private OleDbConnection connection;

		private static object obj = new object();//锁

		public DBManager()
		{
			connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + systemPath + "\\call.mdb");

			if (!Directory.Exists(systemPath))//如果不存在就创建file文件夹
			{
				Directory.CreateDirectory(systemPath);
			}
			if (!File.Exists(systemPath + "\\call.mdb"))
			{
				Catalog catalog = new Catalog();
				catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + systemPath + "\\call.mdb;Jet OLEDB:Engine Type=5");
				connection.Open();
				ADODB.Connection cn = new ADODB.Connection();
				cn.Open(connection.ConnectionString);
				catalog.ActiveConnection = cn;

				createAdmin(catalog);

				createEmployee(catalog);

				createEmployeeRFID(catalog);

				createZone(catalog);

				createCaller(catalog);

				createMess(catalog);

				connection.Close();

				Models.User admin = new Models.User();
				admin.name = "admin";
				admin.pass = "123456";
				insertUser(admin);

				for (int i = 1; i < 101; i++)
				{
					Callzone zone = new Callzone();
					zone.name = "桌位" + i;
					insertZone(zone);

					Caller caller = new Caller();
					caller.callerNum = i;
					caller.callZone = i;
					caller.employeeNum = -1;
					insertCaller(caller);
				}
			}
		}

		public void createAdmin(Catalog catalog)
		{
			Table table = new Table();
			table.Name = TABLE_ADMIN;
			Column column = new Column();
			column.ParentCatalog = catalog;
			column.Name = "Id";
			column.Type = DataTypeEnum.adInteger;
			column.DefinedSize = 9;
			column.Properties["AutoIncrement"].Value = true;
			table.Columns.Append(column, DataTypeEnum.adInteger, 9);
			table.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

			table.Columns.Append("name", DataTypeEnum.adVarWChar, 50);
			table.Columns.Append("pass", DataTypeEnum.adVarWChar, 50);
			table.Columns.Append("userClass", DataTypeEnum.adInteger, 2);
			catalog.Tables.Append(table);
		}

		public void createEmployee(Catalog catalog)
		{
			Table table = new Table();
			table.Name = TABLE_EMPLOYEE;
			Column column = new Column();
			column.ParentCatalog = catalog;
			column.Name = "Id";
			column.Type = DataTypeEnum.adInteger;
			column.DefinedSize = 9;
			column.Properties["AutoIncrement"].Value = true;
			table.Columns.Append(column, DataTypeEnum.adInteger, 9);
			table.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

			table.Columns.Append("num", DataTypeEnum.adInteger, 2);
			table.Columns.Append("name", DataTypeEnum.adVarWChar, 50);
			table.Columns.Append("phoneNum", DataTypeEnum.adVarWChar, 50);
			table.Columns.Append("remarks", DataTypeEnum.adVarWChar, 50);
			table.Columns.Append("sex", DataTypeEnum.adInteger, 1);
			catalog.Tables.Append(table);

			//connection.Close();
		}
		public void createEmployeeRFID(Catalog catalog)
		{
			Table table = new Table();
			table.Name = TABLE_EMPLOYEE_RFID;
			Column column = new Column();
			column.ParentCatalog = catalog;
			column.Name = "Id";
			column.Type = DataTypeEnum.adInteger;
			column.DefinedSize = 9;
			column.Properties["AutoIncrement"].Value = true;
			table.Columns.Append(column, DataTypeEnum.adInteger, 9);
			table.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

			table.Columns.Append("num", DataTypeEnum.adInteger, 2);
			table.Columns.Append("name", DataTypeEnum.adVarWChar, 50);
			table.Columns.Append("phoneNum", DataTypeEnum.adVarWChar, 50);
			table.Columns.Append("remarks", DataTypeEnum.adVarWChar, 50);
			table.Columns.Append("sex", DataTypeEnum.adInteger, 1);
			catalog.Tables.Append(table);

			//connection.Close();
		}

		public void createZone(Catalog catalog)
		{
			Table zone = new Table();
			zone.Name = TABLE_ZONE;
			Column column = new Column();
			column.ParentCatalog = catalog;
			column.Name = "Id";
			column.Type = DataTypeEnum.adInteger;
			column.DefinedSize = 9;
			column.Properties["AutoIncrement"].Value = true;
			zone.Columns.Append(column, DataTypeEnum.adInteger, 9);
			zone.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

			zone.Columns.Append("name", DataTypeEnum.adVarWChar, 50);
			catalog.Tables.Append(zone);

		}

		public void createCaller(Catalog catalog)
		{
			Table caller = new Table();
			caller.Name = TABLE_CALLER;
			Column column = new Column();
			column.ParentCatalog = catalog;
			column.Name = "Id";
			column.Type = DataTypeEnum.adInteger;
			column.DefinedSize = 9;
			column.Properties["AutoIncrement"].Value = true;
			caller.Columns.Append(column, DataTypeEnum.adInteger, 9);
			caller.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);
			caller.Columns.Append("callerNum", DataTypeEnum.adInteger, 9);
			caller.Columns.Append("callZone", DataTypeEnum.adInteger, 9);
			caller.Columns.Append("waiterNum", DataTypeEnum.adInteger, 9);

			catalog.Tables.Append(caller);

		}

		public void createMess(Catalog catalog)
		{
			Table message = new Table();
			message.Name = TABLE_MESS;
			Column column = new Column();
			column.ParentCatalog = catalog;
			column.Name = "Id";
			column.Type = DataTypeEnum.adInteger;
			column.DefinedSize = 9;
			column.Properties["AutoIncrement"].Value = true;
			message.Columns.Append(column, DataTypeEnum.adInteger, 9);
			message.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

			message.Columns.Append("time", DataTypeEnum.adDate, 1);
			message.Columns.Append("callerNum", DataTypeEnum.adInteger, 9);
			message.Columns.Append("waiterNum", DataTypeEnum.adInteger, 9);
			message.Columns.Append("type", DataTypeEnum.adInteger, 9);
			message.Columns.Append("status", DataTypeEnum.adInteger, 9);
			message.Columns.Append("isRFID", DataTypeEnum.adInteger, 9);

			catalog.Tables.Append(message);
		}

		public DataTable select(string sql)
		{
			DataTable dataTable = null;
			lock (obj)
			{
				connection.Open();
				//获取数据表
				//string sql = "select * from 表名 order by 字段1";
				//查询
				//string sql = "select * from 表名 where 字段2=...";
				try
				{
					OleDbDataAdapter da = new OleDbDataAdapter(sql, connection); //创建适配对象

					DataSet dataSetSelect = new DataSet();
					da.Fill(dataSetSelect, "sel");
					dataTable = dataSetSelect.Tables["sel"];
				}
				catch (Exception e)
				{

				}

				connection.Close();
			}
			return dataTable;
		}

		public bool operateData(string sql)
		{
			int cum = 0;
			lock (obj)
			{
				connection.Open();
				//增
				//string sql = "insert into 表名(字段1,字段2,字段3,字段4)values(...)";
				//删 
				//string sql = "delete from 表名 where 字段1="...; 
				//改 
				//string sql = "update student set 学号=" ...; 

				OleDbCommand comm = new OleDbCommand(sql, connection);

				try
				{
					cum = comm.ExecuteNonQuery();
				}
				catch (Exception e)
				{

				}
				connection.Close();
			}

			if (cum > 0)
			{
				return true;
			}
			return false;
		}




		//数据库操作具体部分

		/**
		 * 
		 * 管理员信息操作-----------------------------------------------------------------------------------------start
		 * */

		//查找所有管理员
		public List<Models.User> selectUser()
		{
			DataTable dataTable = select("select * from " + TABLE_ADMIN);
			List<Models.User> list = new List<Models.User>();
			if (dataTable == null)
				return list;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				Models.User admin = new Models.User();
				int id = (int)dataTable.Rows[i][0];
				string name = dataTable.Rows[i][1].ToString();
				string pass = dataTable.Rows[i][2].ToString();
				int type = (int)dataTable.Rows[i][3];
				if (type == 0)
				{
					admin.userClass = Models.User.UserClass.Admin;
				}
				else
				{
					admin.userClass = Models.User.UserClass.normal;
				}
				admin.id = id;
				admin.name = name;
				admin.pass = pass;
				
				list.Add(admin);
			}
			return list;
		}

		//添加新的管理员
		public bool insertUser(Models.User admin)
		{
			int type = 0;
			if (admin.userClass == Models.User.UserClass.Admin)
			{
				type = 0;
			}
			else
			{
				type = 1;
			}
			return operateData("insert into " + TABLE_ADMIN + "(name, pass, userClass) values('" + admin.name + "', '" + admin.pass + "', '" + type.ToString() + "')");
		}

		//查找特定管理员（用于登录验证）
		public bool ValidUser(Models.User admin)
		{
			DataTable dataTable = select("select * from " + TABLE_ADMIN + " where name='" + admin.name + "' and pass='" + admin.pass + "'");
			if (dataTable.Rows.Count > 0)
			{
				return true;
			}
			return false;
		}

		//删除某个管理员
		public bool deleteUser(Models.User admin)
		{
			return operateData("delete from " + TABLE_ADMIN + " where name='" + admin.name + "' and pass='" + admin.pass + "'");
		}

		public bool updateUser(Models.User admin)
		{
			int type = 0;
			if (admin.userClass == Models.User.UserClass.Admin)
			{
				type = 0;
			}
			else
			{
				type = 1;
			}
			return operateData("update " + TABLE_ADMIN + " set name='" + admin.name + "', pass='" + admin.pass + "', userClass=" + type + " where Id=" + admin.id);
		}

		/**
		 * 
		 * 按钮模式下员工信息操作-----------------------------------------------------------------------------------------start
		 * */

		//查找所有员工信息
		public List<Employee> selectEmployee()
		{
			DataTable dataTable = select("select * from " + TABLE_EMPLOYEE);
			List<Employee> list = new List<Employee>();
			if (dataTable == null)
				return list;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				Employee employee = new Employee();
				int id = (int)dataTable.Rows[i][0];
				int num = (int)dataTable.Rows[i][1];
				string name = dataTable.Rows[i][2].ToString();
				string phoneNum = dataTable.Rows[i][3].ToString();
				string remarks = dataTable.Rows[i][4].ToString();
				int sex = (int)dataTable.Rows[i][5];
				employee.Id = id;
				employee.name = name;
				employee.phonenum = phoneNum;
				employee.remarks = remarks;
				employee.employeeNum = num;
				if (sex == 0)
				{
					employee.sex = Sex.MALE;
				}
				else
				{
					employee.sex = Sex.FEMALE;
				}
				list.Add(employee);
			}
			return list;
		}

		//插入新员工信息
		public bool insertEmployee(Employee employee)
		{
			string sql = "";
			switch (employee.sex)
			{
				case Sex.MALE:
					sql = "insert into " + TABLE_EMPLOYEE + "(num, name, phoneNum, remarks, sex) values('" + employee.employeeNum.ToString() + "', '" + employee.name + "', '" + employee.phonenum + "', '" + employee.remarks + "', 0)";
					break;

				case Sex.FEMALE:
					sql = "insert into " + TABLE_EMPLOYEE + "(num, name, phoneNum, remarks, sex) values('" + employee.employeeNum.ToString() + "', '" + employee.name + "', '" + employee.phonenum + "', '" + employee.remarks + "', 1)";
					break;
			}
			return operateData(sql);
		}

		//修改员工信息
		public bool updateEmployee(Employee employee)
		{
			int sex = 0;
			switch (employee.sex)
			{
				case Sex.MALE:
					sex = 0;
					break;

				case Sex.FEMALE:
					sex = 1;
					break;
			}
			return operateData("update " + TABLE_EMPLOYEE + " set num=" + employee.employeeNum + ", name='" + employee.name + "', phoneNum='" + employee.phonenum + "', remarks='" + employee.remarks + "', sex='" + sex + "' where Id=" + employee.Id);
		}

		//删除某个员工
		public bool deleteEmployee(Employee employee)
		{
			return operateData("delete from " + TABLE_EMPLOYEE + " where Id=" + employee.Id);
		}

		public bool deleteAllEmployee()
		{
			return operateData("delete from " + TABLE_EMPLOYEE);
		}

		/**
		 * RFID模式下员工表数据操作-----------------------------------------------------------------------------------------start
		 * */
		//查找所有员工信息
		public List<Employee> selectEmployeeRFID()
		{
			DataTable dataTable = select("select * from " + TABLE_EMPLOYEE_RFID);
			List<Employee> list = new List<Employee>();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				Employee employee = new Employee();
				int id = (int)dataTable.Rows[i][0];
				int num = (int)dataTable.Rows[i][1];
				string name = dataTable.Rows[i][2].ToString();
				string phoneNum = dataTable.Rows[i][3].ToString();
				string remarks = dataTable.Rows[i][4].ToString();
				int sex = (int)dataTable.Rows[i][5];
				employee.Id = id;
				employee.name = name;
				employee.phonenum = phoneNum;
				employee.remarks = remarks;
				employee.employeeNum = num;
				if (sex == 0)
				{
					employee.sex = Sex.MALE;
				}
				else
				{
					employee.sex = Sex.FEMALE;
				}
				list.Add(employee);
			}
			return list;
		}

		//插入新员工信息
		public bool insertEmployeeRFID(Employee employee)
		{
			string sql = "";
			switch (employee.sex)
			{
				case Sex.MALE:
					sql = "insert into " + TABLE_EMPLOYEE_RFID + "(num, name, phoneNum, remarks, sex) values('" + employee.employeeNum.ToString() + "', '" + employee.name + "', '" + employee.phonenum + "', '" + employee.remarks + "', 0)";
					break;

				case Sex.FEMALE:
					sql = "insert into " + TABLE_EMPLOYEE_RFID + "(num, name, phoneNum, remarks, sex) values('" + employee.employeeNum.ToString() + "', '" + employee.name + "', '" + employee.phonenum + "', '" + employee.remarks + "', 1)";
					break;
			}
			return operateData(sql);
		}

		//table.Columns.Append("num", DataTypeEnum.adInteger, 2);
		//	table.Columns.Append("name", DataTypeEnum.adVarWChar, 50);
		//	table.Columns.Append("phoneNum", DataTypeEnum.adVarWChar, 50);
		//	table.Columns.Append("remarks", DataTypeEnum.adVarWChar, 50);
		//	table.Columns.Append("sex", DataTypeEnum.adInteger, 1);
		//修改员工信息
		public bool updateEmployeeRFID(Employee employee)
		{
			int sex = 0;
			switch (employee.sex)
			{
				case Sex.MALE:
					sex = 0;
					break;

				case Sex.FEMALE:
					sex = 1;
					break;
			}
			return operateData("update " + TABLE_EMPLOYEE_RFID + " set num=" + employee.employeeNum + ", name='" + employee.name + "', phoneNum='" + employee.phonenum + "', remarks='" + employee.remarks + "', sex='" + sex + "' where Id=" + employee.Id);
		}

		//删除某个员工
		public bool deleteEmployeeRFID(Employee employee)
		{
			return operateData("delete from " + TABLE_EMPLOYEE_RFID + " where Id=" + employee.Id);
		}

		public bool deleteAllEmployeeRFID()
		{
			return operateData("delete from " + TABLE_EMPLOYEE_RFID);
		}

		/**
		 * 
		 * 区域信息操作-----------------------------------------------------------------------------------------start
		 * */

		//获取区域信息
		public List<Callzone> selectZone()
		{
			DataTable dataTable = select("select * from " + TABLE_ZONE);
			List<Callzone> list = new List<Callzone>();
			if (dataTable == null)
				return list;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				Callzone zone = new Callzone();
				int id = (int)dataTable.Rows[i][0];
				string name = dataTable.Rows[i][1].ToString();
				zone.Id = id;
				zone.name = name;
				list.Add(zone);
			}
			return list;
		}

		//插入区域信息
		public bool insertZone(Callzone zone)
		{
			return operateData("insert into " + TABLE_ZONE + "(name) values('" + zone.name + "')");
		}

		//修改区域信息
		public bool updateZone(Callzone zone)
		{
			return operateData("update " + TABLE_ZONE + " set name='" + zone.name + "' where Id=" + zone.Id);
		}

		//删除区域信息
		public bool deleteZone(Callzone zone)
		{
			return operateData("delete from " + TABLE_ZONE + " where Id=" + zone.Id);
		}


		/**
		 * 
		 * 呼叫器信息操作-----------------------------------------------------------------------------------------start
		 * */

		public List<Caller> selectCaller()
		{
			DataTable dataTable = select("select * from " + TABLE_CALLER);
			List<Caller> list = new List<Caller>();
			if (dataTable == null)
				return list;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				Caller caller = new Caller();
				int id = (int)dataTable.Rows[i][0];
				int callerNum = (int)dataTable.Rows[i][1];
				int callerZone = (int)dataTable.Rows[i][2];
				int waiternum = (int)dataTable.Rows[i][3];
				caller.ID = id;
				caller.callerNum = callerNum;
				caller.callZone = callerZone;
				caller.employeeNum = waiternum;
				list.Add(caller);
			}
			return list;
		}


		//插入呼叫器
		public bool insertCaller(Caller caller)
		{
			return operateData("insert into " + TABLE_CALLER + "(callerNum, callZone, waiterNum) values(" + caller.callerNum + ", " + caller.callZone + ", " + caller.employeeNum + ")");
		}

		//修改呼叫器信息
		public bool updateCaller(Caller caller)
		{
			return operateData("update " + TABLE_CALLER + " set callerNum=" + caller.callerNum + ", callZone=" + caller.callZone + ", waiterNum=" + caller.employeeNum + " where Id=" + caller.ID);
		}

		//删除呼叫器
		public bool deleteCaller(Caller caller)
		{
			return operateData("delete from " + TABLE_CALLER + " where Id=" + caller.ID + "");
		}

		/**
		 * 
		 * 呼叫信息操作-----------------------------------------------------------------------------------------start
		 * */

		//获取呼叫信息
		public List<DataMessage> selectMess()
		{
			DataTable dataTable = select("select * from " + TABLE_MESS + " order by Id desc");
			List<DataMessage> list = new List<DataMessage>();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataMessage message = new DataMessage();
				int id = (int)dataTable.Rows[i][0];
				DateTime time = (DateTime)dataTable.Rows[i][1];
				int callerNum = (int)dataTable.Rows[i][2];
				int waiterNum = (int)dataTable.Rows[i][3];
				int type = (int)dataTable.Rows[i][4];
				int status = (int)dataTable.Rows[i][5];
				int isRFID = (int)dataTable.Rows[i][6];

				message.Id = id;
				message.time = time;
				message.callerNum = callerNum;
				message.employeeNum = waiterNum;
				switch (type)
				{
					case 0:
						message.type = Models.Type.CANCEL;
						break;

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
						break;

					case 12:
						message.type = Models.Type.DISSATISFIED;
						break;

					case 13:
						message.type = Models.Type.LOW_POWER;
						break;

					case 14:
						message.type = Models.Type.TAMPER;
						break;
				}
				switch (status)
				{
					case 0:
						message.status = STATUS.WAITING;
						break;

					case 1:
						message.status = STATUS.FINISH;
						break;

					case 2:
						message.status = STATUS.OVERTIME;
						break;
				}
				if (isRFID == 0)
				{
					message.isRFID = false;
				}
				else
				{
					message.isRFID = true;
				}
				list.Add(message);
			}
			return list;
		}

		//添加呼叫信息
		public bool insertMess(DataMessage message)
		{
			int type = 0;
			switch (message.type)
			{
				case Models.Type.CANCEL:
					type = 0;
					break;

				case Models.Type.ORDER:
					type = 1;
					break;

				case Models.Type.CALL:
					type = 2;
					break;

				case Models.Type.CHECK_OUT:
					type = 3;
					break;

				case Models.Type.CHANGE_MEDICATION:
					type = 4;
					break;

				case Models.Type.EMERGENCY_CALL:
					type = 5;
					break;

				case Models.Type.PULING_NEEDLE:
					type = 6;
					break;

				case Models.Type.NEED_SERVICE:
					type = 7;
					break;

				case Models.Type.NEED_WATER:
					type = 8;
					break;

				case Models.Type.WANT_TO_PAY:
					type = 9;
					break;

				case Models.Type.NEED_NURSES:
					type = 10;
					break;

				case Models.Type.SATISFIED:
					type = 11;
					break;

				case Models.Type.DISSATISFIED:
					type = 12;
					break;

				case Models.Type.LOW_POWER:
					type = 13;
					break;

				case Models.Type.TAMPER:
					type = 14;
					break;
			}
			int status = 0;
			switch (message.status)
			{
				case STATUS.WAITING:
					status = 0;
					break;

				case STATUS.FINISH:
					status = 1;
					break;

				case STATUS.OVERTIME:
					status = 2;
					break;
			}
			int isRFID = 0;
			if (message.isRFID)
			{
				isRFID = 1;
			}
			return operateData("insert into " + TABLE_MESS + "([time], [callerNum], [waiterNum], [type], [status], [isRFID]) values (#" + message.time + "#, '" + message.callerNum.ToString() + "', '" + message.employeeNum.ToString() + "', '" + type.ToString() + "', '" + status.ToString() + "', '" + isRFID.ToString() + "')");
		}

		//删除呼叫信息
		public bool deleteMess(DataMessage message)
		{
			return operateData("delete from " + TABLE_MESS + " where Id ='" + message.Id + "'");
		}

		//更改呼叫信息，主要用于完成服务的修改
		public bool updateMess(DataMessage message)
		{
			int status = 0;
			switch (message.status)
			{
				case STATUS.WAITING:
					status = 0;
					break;

				case STATUS.FINISH:
					status = 1;
					break;

				case STATUS.OVERTIME:
					status = 2;
					break;
			}
			int isRFID = 0;
			if (message.isRFID)
			{
				isRFID = 1;
			}

			return operateData("update " + TABLE_MESS + " set [time]=#" + message.time + "#, [waiterNum]=" + message.employeeNum + ", [status]=" + status + ", [isRFID]=" + isRFID + " where [callerNum]=" + message.callerNum + " and [status]=0");
		}

		//更改呼叫信息，主要用于服务超时的修改
		public bool updateMessTimeOut(DataMessage message)
		{
			int status = 0;
			switch (message.status)
			{
				case STATUS.WAITING:
					status = 0;
					break;

				case STATUS.FINISH:
					status = 1;
					break;

				case STATUS.OVERTIME:
					status = 2;
					break;
			}
			int isRFID = 0;
			if (message.isRFID)
			{
				isRFID = 1;
			}

			return operateData("update " + TABLE_MESS + " set [status]=" + status + " where [callerNum]=" + message.callerNum + " and [time] =#" + message.time + "#");
		}

		public bool clearAll()
		{
			operateData("delete from " + TABLE_ADMIN + " where Id>0");
			operateData("delete from " + TABLE_CALLER);
			operateData("delete from " + TABLE_ZONE);
			operateData("delete from " + TABLE_EMPLOYEE);
			operateData("delete from " + TABLE_EMPLOYEE_RFID);
			return operateData("delete from " + TABLE_MESS);
		}

		public bool clearCaller()
		{
			return operateData("delete from " + TABLE_CALLER);
		}

		public bool clearZone()
		{
			return operateData("delete from " + TABLE_ZONE);
		}

		public bool clearEmployee()
		{
			operateData("delete from " + TABLE_EMPLOYEE);
			return operateData("delete from " + TABLE_EMPLOYEE_RFID);
		}

		public bool clearUser()
		{
			return operateData("delete from " + TABLE_ADMIN + " where userClass>0");
		}

		public bool clearRecodrd()
		{
			return operateData("delete from " + TABLE_MESS);
		}

		public bool clearTableHead()
		{
			return true;
		}

	}
}
