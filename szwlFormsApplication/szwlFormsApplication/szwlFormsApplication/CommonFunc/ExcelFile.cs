
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using szwlFormsApplication.Models;
using szwlFormsApplication.Properties;

namespace szwlFormsApplication.CommonFunc
{
	class ExcelFile
	{ 
		public static void makeExcel(List<DataMessage> list, string destFile)
		{
			destFile = destFile + "\\Record.xls";

			byte[] bytes = Resources.Record;
			FileStream outputExcelFile = new FileStream(destFile, FileMode.Create, FileAccess.Write);
			outputExcelFile.Write(bytes, 0, bytes.Length);
			outputExcelFile.Close();

			string strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + destFile + ";Extended Properties='Excel 8.0;IMEX=10;HDR=YES;'";
			//string strConn = "Provider=Microsoft.Ace.OleDb.12.0;Persist Security Info=False;" + "data source=" + @path + ";Extended Prop";
			OleDbConnection conn = new OleDbConnection();
			conn.ConnectionString = strConn;

			OleDbCommand cmd = null;
			try
			{
				conn.Open();
				//向"Sheet1"表中插入几条数据,访问Excel的表的时候需要在表名后添加"$"符号,Insert语句可以不指定列名  
				foreach(DataMessage mess in list)
				{
					cmd = new OleDbCommand("Insert Into [Sheet1$] Values('" + mess.Id + "', '" + mess.time.ToString() + "', '"+ mess.callerNum + "', '" + mess.employeeNum +"', '" + mess.type.ToString() + "', '" + mess.status.ToString() + "','" + (mess.isRFID?"是":"否") + "')", conn);//(A,B,C,D,E,F,G)   
					cmd.ExecuteNonQuery();
				}
			}
			catch (System.Exception ex)
			{
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
			}
			finally
			{
				conn.Close();
			}
		}
	}
}
