using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace szwlFormsApplication.CommonFunc
{
	public static class ChangeAppConfig
	{
		public static bool ChangeConfig(string AppKey, string AppValue)
		{
			bool result = true;
			try
			{
				XmlDocument xDoc = new XmlDocument();
				//获取App.config文件绝对路径
				String basePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
				basePath = basePath.Substring(0, basePath.Length - 10);
				String path = basePath + "App.config";
				xDoc.Load(path);

				XmlNode xNode;
				XmlElement xElem1;
				XmlElement xElem2;
				//修改完文件内容，还需要修改缓存里面的配置内容，使得刚修改完即可用
				//如果不修改缓存，需要等到关闭程序，在启动，才可使用修改后的配置信息
				Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				xNode = xDoc.SelectSingleNode("//appSettings");
				xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
				if (xElem1 != null)
				{
					xElem1.SetAttribute("value", AppValue);
					cfa.AppSettings.Settings[AppKey].Value = AppValue;
				}
				else
				{
					xElem2 = xDoc.CreateElement("add");
					xElem2.SetAttribute("key", AppKey);
					xElem2.SetAttribute("value", AppValue);
					xNode.AppendChild(xElem2);
					cfa.AppSettings.Settings.Add(AppKey, AppValue);
				}
				//改变缓存中的配置文件信息（读取出来才会是最新的配置）
				cfa.Save();
				ConfigurationManager.RefreshSection("appSettings");
				xDoc.Save(path);
			}
			catch (Exception ex)
			{
				result = false;
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
			}
			return result;
		}
	}
}
