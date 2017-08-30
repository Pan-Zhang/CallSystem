
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using szwlFormsApplication.Language;
using szwlFormsApplication.Models;
using szwlFormsApplication.Properties;

namespace szwlFormsApplication.CommonFunc
{
	class ExcelFile
	{ 
		public static void makeExcel(List<DataMessage> list, string destFile, out string path)
		{
			if (!Directory.Exists(destFile))
			{
				Directory.CreateDirectory(destFile);
			}
			destFile = destFile + "\\Record(" + DateTime.Now.ToString("hh mm ss") + ").xls";
			path = destFile;
			byte[] bytes;
			if (ChangeAppConfig.getValueFromKey(GlobalData.LANGUAGE).Equals(GlobalData.CHINESE))
			{
				bytes = Resources.Record;
			}
			else
			{
				bytes = Resources.Record_en;
			}
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
					cmd = new OleDbCommand("Insert Into [Sheet1$] Values('" + mess.Id + "', '" + mess.time.ToString() + "', '"+ mess.callerNum + "', '" + mess.employeeNum +"', '" + mess.getType() + "', '" + mess.status.ToString() + "','" + (mess.isRFID?"true":"false") + "')", conn);//(A,B,C,D,E,F,G)   
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

		public static void makeExcel2(List<Summary> list, string destFile, out string path)
		{
			if (!Directory.Exists(destFile))
			{
				Directory.CreateDirectory(destFile);
			}
			destFile = destFile + "\\Summary(" + DateTime.Now.ToString("hh mm ss") + ").xls";
			path = destFile;
			byte[] bytes;
			if (ChangeAppConfig.getValueFromKey(GlobalData.LANGUAGE).Equals(GlobalData.CHINESE))
			{
				bytes = Resources.Summary;
			}
			else
			{
				bytes = Resources.Summary_en;
			}
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
				foreach (Summary summary in list)
				{
					cmd = new OleDbCommand("Insert Into [Sheet1$] Values('" + summary.callerNum + "', '" + summary.zoneName + "', '" + summary.employeeName + "', '" + summary.employeeNum + "', '" + summary.count + "', '" + summary.total + "','" + summary.percent + "')", conn);//(A,B,C,D,E,F,G)   
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
