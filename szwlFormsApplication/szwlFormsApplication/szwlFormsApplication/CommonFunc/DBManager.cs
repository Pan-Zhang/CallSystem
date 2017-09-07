using ADOX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		string systemPath = Common.basePath;

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
				admin.name = "Admin";
				admin.pass = "123";
				new UserProgram(admin);
				insertUser(admin);

				for(int i=1; i<6; i++)
				{
					Callzone zone = new Callzone();
					zone.name = "Hall" + i;
					insertZone(zone);
				}

				for (int i = 6; i < 101; i++)
				{
					Callzone zone = new Callzone();
					zone.name = "name" + (i-5);
					insertZone(zone);
				}

				for (int i = 1; i < 101; i++)
				{
					Caller caller = new Caller();
					caller.callerNum = i.ToString();
					caller.callZone = i;
					caller.employeeNum = -1;
					insertCaller(caller);
				}
			}
		}

		public void createAdmin(Catalog catalog)
		{
			try
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
				table.Columns.Append("programs", DataTypeEnum.adVarWChar,50);
				catalog.Tables.Append(table);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
			}
		}

		public void createEmployee(Catalog catalog)
		{
			try
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
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
			}

			//connection.Close();
		}
		public void createEmployeeRFID(Catalog catalog)
		{
			try
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
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
			}

			//connection.Close();
		}

		public void createZone(Catalog catalog)
		{
			try
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
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
			}

		}

		public void createCaller(Catalog catalog)
		{
			try
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
				caller.Columns.Append("callerNum", DataTypeEnum.adVarWChar, 50);
				caller.Columns.Append("callZone", DataTypeEnum.adInteger, 9);
				caller.Columns.Append("waiterNum", DataTypeEnum.adInteger, 9);

				catalog.Tables.Append(caller);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
			}

		}

		public void createMess(Catalog catalog)
		{
			try
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

				message.Columns.Append("time", DataTypeEnum.adVarWChar, 50);
				message.Columns.Append("callerNum", DataTypeEnum.adVarWChar, 9);
				message.Columns.Append("waiterNum", DataTypeEnum.adInteger, 9);
				message.Columns.Append("type", DataTypeEnum.adInteger, 9);
				message.Columns.Append("status", DataTypeEnum.adInteger, 9);
				message.Columns.Append("isRFID", DataTypeEnum.adInteger, 9);
				message.Columns.Append("longTime", DataTypeEnum.adDouble, 20);
				message.Columns.Append("isOverTime", DataTypeEnum.adInteger, 2);

				catalog.Tables.Append(message);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
			}
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
					LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, e.ToString());
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
					LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, sql);
					LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, e.ToString());
				}
				finally
				{
					connection.Close();
				}
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
			try
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
					Models.User.UserClass type = (Models.User.UserClass)Enum.Parse(typeof(Models.User.UserClass), dataTable.Rows[i][3].ToString());

					admin.userClass = type;
					admin.id = id;
					admin.name = name;
					admin.pass = pass;

					if (dataTable.Columns.Count < 5)
					{
						var tmp = new UserProgram(admin);
						admin.programs = tmp.programs;
					}
					else
					{
						string programs = dataTable.Rows[i][4].ToString();
						admin.programs = programs == null ? null : programs.Split(',').Select(p => int.Parse(p)).ToList();
					}

					list.Add(admin);
				}
				return list;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return new List<Models.User>();
			}
		}

		//添加新的管理员
		public bool insertUser(Models.User admin)
		{
			try
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
				return operateData("insert into " + TABLE_ADMIN + "(name, pass, userClass, programs) values('" + admin.name + "', '" + admin.pass + "', '" + type.ToString() + "', '" + string.Join(",", admin.programs) + "')");
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
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
			try
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
				return operateData("update " + TABLE_ADMIN + " set name='" + admin.name + "', pass='" + admin.pass + "', userClass='" + type + "', programs='" + string.Join(",", admin.programs) + "' where Id=" + admin.id);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		/**
		 * 
		 * 按钮模式下员工信息操作-----------------------------------------------------------------------------------------start
		 * */

		//查找所有员工信息
		public List<Employee> selectEmployee()
		{
			try
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
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return new List<Employee>();
			}
		}

		//插入新员工信息
		public bool insertEmployee(Employee employee)
		{
			try
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
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//修改员工信息
		public bool updateEmployee(Employee employee)
		{
			try
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
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//删除某个员工
		public bool deleteEmployee(Employee employee)
		{
			try
			{
				return operateData("delete from " + TABLE_EMPLOYEE + " where Id=" + employee.Id);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool deleteAllEmployee()
		{
			try
			{
				return operateData("delete from " + TABLE_EMPLOYEE);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		/**
		 * RFID模式下员工表数据操作-----------------------------------------------------------------------------------------start
		 * */
		//查找所有员工信息
		public List<Employee> selectEmployeeRFID()
		{
			try
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
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return new List<Employee>();
			}
		}

		//插入新员工信息
		public bool insertEmployeeRFID(Employee employee)
		{
			try
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
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//table.Columns.Append("num", DataTypeEnum.adInteger, 2);
		//	table.Columns.Append("name", DataTypeEnum.adVarWChar, 50);
		//	table.Columns.Append("phoneNum", DataTypeEnum.adVarWChar, 50);
		//	table.Columns.Append("remarks", DataTypeEnum.adVarWChar, 50);
		//	table.Columns.Append("sex", DataTypeEnum.adInteger, 1);
		//修改员工信息
		public bool updateEmployeeRFID(Employee employee)
		{
			try
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
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//删除某个员工
		public bool deleteEmployeeRFID(Employee employee)
		{
			try
			{
				return operateData("delete from " + TABLE_EMPLOYEE_RFID + " where Id=" + employee.Id);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool deleteAllEmployeeRFID()
		{
			try
			{
				return operateData("delete from " + TABLE_EMPLOYEE_RFID);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		/**
		 * 
		 * 区域信息操作-----------------------------------------------------------------------------------------start
		 * */

		//获取区域信息
		public List<Callzone> selectZone()
		{
			try
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
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return new List<Callzone>();
			}
		}

		//插入区域信息
		public bool insertZone(Callzone zone)
		{
			try
			{
				return operateData("insert into " + TABLE_ZONE + "(name) values('" + zone.name + "')");
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//修改区域信息
		public bool updateZone(Callzone zone)
		{
			try
			{
				return operateData("update " + TABLE_ZONE + " set name='" + zone.name + "' where Id=" + zone.Id);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//删除区域信息
		public bool deleteZone(Callzone zone)
		{
			try
			{
				return operateData("delete from " + TABLE_ZONE + " where Id=" + zone.Id);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}


		/**
		 * 
		 * 呼叫器信息操作-----------------------------------------------------------------------------------------start
		 * */

		public List<Caller> selectCaller()
		{
			try
			{
				DataTable dataTable = select("select * from " + TABLE_CALLER);
				List<Caller> list = new List<Caller>();
				if (dataTable == null)
					return list;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					Caller caller = new Caller();
					int id = (int)dataTable.Rows[i][0];
					string callerNum = dataTable.Rows[i][1].ToString();
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
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return new List<Caller>();
			}
		}


		//插入呼叫器
		public bool insertCaller(Caller caller)
		{
			try
			{
				return operateData("insert into " + TABLE_CALLER + "(callerNum, callZone, waiterNum) values('" + caller.callerNum + "', " + caller.callZone + ", " + caller.employeeNum + ")");
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//修改呼叫器信息
		public bool updateCaller(Caller caller)
		{
			try
			{
				return operateData("update " + TABLE_CALLER + " set callerNum='" + caller.callerNum + "', callZone=" + caller.callZone + ", waiterNum=" + caller.employeeNum + " where Id=" + caller.ID);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//删除呼叫器
		public bool deleteCaller(Caller caller)
		{
			try
			{
				return operateData("delete from " + TABLE_CALLER + " where Id=" + caller.ID + "");
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		/**
		 * 
		 * 呼叫信息操作-----------------------------------------------------------------------------------------start
		 * */

		//获取呼叫信息
		public List<DataMessage> selectMess()
		{
			try
			{
				DataTable dataTable = select("select * from " + TABLE_MESS + " order by Id desc");
				List<DataMessage> list = new List<DataMessage>();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataMessage message = new DataMessage();
					int id = (int)dataTable.Rows[i][0];
					message.time = dataTable.Rows[i][1].ToString();
					message.time = message.timeConvert().ToString("yyyy-MM-dd HH:mm:ss");
					string callerNum = dataTable.Rows[i][2].ToString();
					int waiterNum = (int)dataTable.Rows[i][3];
					int type = (int)dataTable.Rows[i][4];
					int status = (int)dataTable.Rows[i][5];
					int isRFID = (int)dataTable.Rows[i][6];
					double longTime = (double)dataTable.Rows[i][7];
					int isOverTime = (int)dataTable.Rows[i][8];
					message.isOverTime = isOverTime==0?false:true;

					message.Id = id;
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

						case 3:
							message.status = STATUS.UNFINISH;
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
					message.longTime = longTime;
					list.Add(message);
				}
				return list;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return new List<DataMessage>();
			}
		}

		public List<DataMessage> selectMess(long time)
		{
			try
			{
				DataTable dataTable = select("select * from " + TABLE_MESS + " where longTime>" + time + " order by Id desc");
				List<DataMessage> list = new List<DataMessage>();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataMessage message = new DataMessage();
					int id = (int)dataTable.Rows[i][0];
					message.time = dataTable.Rows[i][1].ToString();
					message.time = message.timeConvert().ToString("yyyy-MM-dd HH:mm:ss");
					string callerNum = dataTable.Rows[i][2].ToString();
					int waiterNum = (int)dataTable.Rows[i][3];
					int type = (int)dataTable.Rows[i][4];
					int status = (int)dataTable.Rows[i][5];
					int isRFID = (int)dataTable.Rows[i][6];
					double longTime = (double)dataTable.Rows[i][7];
					int isOverTime = (int)dataTable.Rows[i][8];
					message.isOverTime = isOverTime == 0 ? false : true;

					message.Id = id;
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

						case 3:
							message.status = STATUS.UNFINISH;
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
					message.longTime = longTime;
					list.Add(message);
				}
				return list;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return new List<DataMessage>();
			}
		}

		public DataMessage selectMessLast()
		{
			try
			{
				DataTable dataTable = select("select top 1 * from " + TABLE_MESS + " order by Id desc");
				DataMessage message = new DataMessage();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int id = (int)dataTable.Rows[i][0];
					message.time = dataTable.Rows[i][1].ToString();
					message.time = message.timeConvert().ToString("yyyy-MM-dd HH:mm:ss");
					string callerNum = dataTable.Rows[i][2].ToString();
					int waiterNum = (int)dataTable.Rows[i][3];
					int type = (int)dataTable.Rows[i][4];
					int status = (int)dataTable.Rows[i][5];
					int isRFID = (int)dataTable.Rows[i][6];
					double longTime = (double)dataTable.Rows[i][7];
					int isOverTime = (int)dataTable.Rows[i][8];
					message.isOverTime = isOverTime == 0 ? false : true;

					message.Id = id;
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

						case 3:
							message.status = STATUS.UNFINISH;
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
					message.longTime = longTime;
				}
				return message;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return new DataMessage();
			}
		}

		//添加呼叫信息
		public bool insertMess(DataMessage message)
		{
			try
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

					case STATUS.UNFINISH:
						status = 3;
						break;
				}
				int isRFID = 0;
				if (message.isRFID)
				{
					isRFID = 1;
				}
				return operateData("insert into " + TABLE_MESS + "([time], [callerNum], [waiterNum], [type], [status], [isRFID], [longTime], [isOverTime]) values ('" + message.timeConvert() + "', '" + message.callerNum + "', '" + message.employeeNum.ToString() + "', '" + type.ToString() + "', '" + status.ToString() + "', '" + isRFID.ToString() + "', '" + DateTime.Now.ToFileTime().ToString() +  "', '0')");
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//删除呼叫信息
		public bool deleteMess(DataMessage message)
		{
			try
			{
				return operateData("delete from " + TABLE_MESS + " where Id =" + message.Id + "");
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//更改呼叫信息，主要用于完成服务的修改
		public bool updateMess(DataMessage message)
		{
			try
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

					case STATUS.UNFINISH:
						status = 3;
						break;
				}
				int isRFID = 0;
				if (message.isRFID)
				{
					isRFID = 1;
				}

				return operateData("update " + TABLE_MESS + " set [time]='" + message.timeConvert() + "', [waiterNum]=" + message.employeeNum + ", [status]=" + status + ", [isRFID]=" + isRFID + " where [callerNum]='" + message.callerNum + "' and ([status]=0 or [status]=2)");
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		//更改呼叫信息，主要用于服务超时的修改
		public bool updateMessTimeOut(DataMessage message)
		{
			try
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

					case STATUS.UNFINISH:
						status = 3;
						break;
				}
				return operateData("update " + TABLE_MESS + " set [status]=" + status + ", [isOverTime]=1" + " where [callerNum]='" + message.callerNum + "' and [time] ='" + message.timeConvert() + "'");
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool updateMessUnfinish(DataMessage message)
		{
			try
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

					case STATUS.UNFINISH:
						status = 3;
						break;
				}
				return operateData("update " + TABLE_MESS + " set [status]=" + status + " where [callerNum]='" + message.callerNum + "' and [time] ='" + message.timeConvert() + "'");
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool clearAll()
		{
			try
			{
				operateData("delete from " + TABLE_ADMIN + " where Id>1");
				operateData("delete from " + TABLE_CALLER);
				operateData("delete from " + TABLE_ZONE);
				for (int i = 1; i < 6; i++)
				{
					Callzone zone = new Callzone();
					zone.name = "Hall" + i;
					insertZone(zone);
				}

				for (int i = 6; i < 101; i++)
				{
					Callzone zone = new Callzone();
					zone.name = "name" + (i - 5);
					insertZone(zone);
				}

				for (int i = 1; i < 101; i++)
				{
					Caller caller = new Caller();
					caller.callerNum = i.ToString();
					caller.callZone = i;
					caller.employeeNum = -1;
					insertCaller(caller);
				}
				operateData("delete from " + TABLE_EMPLOYEE);
				operateData("delete from " + TABLE_EMPLOYEE_RFID);
				return operateData("delete from " + TABLE_MESS);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool clearCaller()
		{
			try
			{
				operateData("delete from " + TABLE_CALLER);
				for (int i = 1; i < 101; i++)
				{
					Caller caller = new Caller();
					caller.callerNum = i.ToString();
					caller.callZone = i;
					caller.employeeNum = -1;
					insertCaller(caller);
				}
				return true;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool clearZone()
		{
			try
			{
				operateData("delete from " + TABLE_ZONE);
				for (int i = 1; i < 6; i++)
				{
					Callzone zone = new Callzone();
					zone.name = "Hall" + i;
					insertZone(zone);
				}

				for (int i = 6; i < 101; i++)
				{
					Callzone zone = new Callzone();
					zone.name = "name" + (i - 5);
					insertZone(zone);
				}
				return true;
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool clearEmployee()
		{
			try
			{
				operateData("delete from " + TABLE_EMPLOYEE);
				return operateData("delete from " + TABLE_EMPLOYEE_RFID);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool clearUser()
		{
			try
			{
				return operateData("delete from " + TABLE_ADMIN + " where Id>1");
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool clearRecodrd()
		{
			try
			{
				return operateData("delete from " + TABLE_MESS);
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool deleteRecordToday()
		{
			try
			{
				return operateData("delete from " + TABLE_MESS + " where longTime>" + DateTime.Now.Date.ToFileTime());
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool deleteRecordWaitting()
		{
			try
			{
				return operateData("delete from " + TABLE_MESS + " where status=0");
			}
			catch (Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
				return false;
			}
		}

		public bool clearTableHead()
		{
			return true;
		}

	}
}
