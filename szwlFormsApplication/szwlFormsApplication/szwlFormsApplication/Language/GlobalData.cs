
namespace szwlFormsApplication.Language
{
	class GlobalData
	{
		public static string SystemLanguage;

        private static Language globalLanguage;
        public static Language GlobalLanguage
        {
            get
            {
                if (globalLanguage == null)
                {
					SystemLanguage = System.Configuration.ConfigurationManager.AppSettings["Language"];
					
					globalLanguage = new Language();
                    return globalLanguage;
                }
                return globalLanguage;
            }
        }

		public static void setNull()
		{
			globalLanguage = null;
		}
	}
}
