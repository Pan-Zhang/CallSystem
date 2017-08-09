using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szwlFormsApplication.CommonFunc
{
	public class AppConfig
	{
		public static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

		/// <summary>  
		/// 获取配置值  
		/// </summary>  
		/// <param name="key">配置标识</param>  
		/// <returns></returns>  
		public static string GetValue(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}

		/// <summary>  
		/// 修改或增加配置值  
		/// </summary>  
		/// <param name="key">配置标识</param>  
		/// <param name="value">配置值</param>  
		public static void SetValue(string key, string value)
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			//make changes
			config.AppSettings.Settings[key].Value = value;

			//save to apply changes
			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
		}
	}
}
