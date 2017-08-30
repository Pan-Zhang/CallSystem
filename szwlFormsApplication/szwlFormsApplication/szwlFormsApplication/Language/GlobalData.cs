
using szwlFormsApplication.CommonFunc;

namespace szwlFormsApplication.Language
{
	class GlobalData
	{
		public static string SystemLanguage;
		public static string ENGLISH = "English";
		public static string CHINESE = "Chinese";
		public static string LANGUAGE = "Language";
		public static bool CHANGE = true;

        private static Language globalLanguage;
        public static Language GlobalLanguage
        {
            get
            {
                if (globalLanguage == null || CHANGE)
                {
					SystemLanguage = ChangeAppConfig.getValueFromKey(LANGUAGE);
					CHANGE = false;
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
