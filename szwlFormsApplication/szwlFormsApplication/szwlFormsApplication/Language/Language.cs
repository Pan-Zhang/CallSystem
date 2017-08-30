using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using szwlFormsApplication.Properties;

namespace szwlFormsApplication.Language
{
	class Language
	{
		public string app_name { get; set; }
		public string no_quest { get; set; }
		public string have_quest { get; set; }
		public string no_device { get; set; }
		public string prompt { get; set; }
		public string empty_warn { get; set; }
		public string login_prompt { get; set; }
		public string welcome { get; set; }
		public string login_error { get; set; }
		public string number { get; set; }
		public string nothing { get; set; }
		public string name { get; set; }
		public string finish { get; set; }
		public string overtime { get; set; }
		public string waiting { get; set; }
		public string satisfy { get; set; }
		public string unsatisfy { get; set; }
		public string records { get; set; }
		public string time { get; set; }
		public string record_null { get; set; }
		public string choose_file { get; set; }
		public string save_path { get; set; }
		public string export_succ { get; set; }
		public string delete_all { get; set; }
		public string delete_caller { get; set; }
		public string delete_zone { get; set; }
		public string delete_employee { get; set; }
		public string delete_user { get; set; }
		public string delete_record { get; set; }
		public string delete_header { get; set; }
		public string login_setting { get; set; }
		public string system_setting { get; set; }
		public string user_setting { get; set; }
		public string caller_setting { get; set; }
		public string employee_setting { get; set; }
		public string header_setting { get; set; }
		public string data_setting { get; set; }
		public string summary_setting { get; set; }
		public string about_setting { get; set; }
		public string ID { get; set; }
		public string Time { get; set; }
		public string caller_num { get; set; }
		public string employee_num { get; set; }
		public string type { get; set; }
		public string status { get; set; }
		public string isRFID { get; set; }
		public string welcome_use { get; set; }
		public string user_login { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public string login { get; set; }
		public string cancel { get; set; }
		public string summary_result { get; set; }
		public string sreach_result { get; set; }
		public string total { get; set; }
		public string zone_search { get; set; }
		public string employee_search { get; set; }
		public string option { get; set; }
		public string start { get; set; }
		public string end { get; set; }
		public string zone { get; set; }
		public string employee { get; set; }
		public string ensure { get; set; }
		public string export { get; set; }
		public string summary { get; set; }
		public string Data_initialization { get; set; }
		public string watch_out { get; set; }
		public string all_message { get; set; }
		public string all_caller { get; set; }
		public string all_zone { get; set; }
		public string all_employee { get; set; }
		public string all_user { get; set; }
		public string all_record { get; set; }
		public string all_header { get; set; }
		public string ensure_operation { get; set; }
		public string exist_app { get; set; }
		public string minimal { get; set; }
		public string company_name { get; set; }
		public string com_setting { get; set; }
		public string button_function { get; set; }
		public string record_show { get; set; }
		public string effective_time { get; set; }
		public string SerialPort { get; set; }
		public string data_bits { get; set; }
		public string baud_rate { get; set; }
		public string stop_bit { get; set; }
		public string sort { get; set; }
		public string color { get; set; }
		public string timeout { get; set; }
		public string setting { get; set; }
		public string Ascending { get; set; }
		public string Descending { get; set; }
		public string Set_timeout { get; set; }
		public string second { get; set; }
		public string minute { get; set; }
		public string hour { get; set; }
		public string Wireless_calling_system { get; set; }
		public string set_succe { get; set; }
		public string set_fail { get; set; }
		public string user_type { get; set;}
		public string add_user { get; set; }
		public string edit_user { get; set; }
		public string authority { get; set; }
		public string update_pwd { get; set; }
		public string clear_data { get; set; }
		public string _username { get; set; }
		public string _password { get; set; }
		public string del_user { get; set; }
		public string caller_zone_setting { get; set; }
		public string caller_num_setting { get; set; }
		public string call_zone { get; set; }
		public string callAreaAddbtn { get; set; }
		public string callAreaUpdatebtn { get; set; }
		public string callAreaDeletebtn { get; set; }
		public string callAreaBatchUpdatebtn { get; set; }
		public string callAreaBatchDelbtn { get; set; }
		public string callAreaOKbtn { get; set; }
		public string callAreaclearDatabtn { get; set; }
		public string telephone { get; set; }
		public string remarks { get; set; }
		public string gender { get; set; }
		public string rfid_mode { get; set; }
		public string button_mode { get; set; }
		public string choose_table { get; set; }
		public string other_name { get; set; }
		public string call_message { get; set; }
		public string employ_info { get; set; }
		public string old_name { get; set; }
		public string new_name { get; set; }
		public string header_set_succe { get; set; }
		public string Caller_number { get; set; }
		public string Caller_zone { get; set; }
		public string password_wrong { get; set; }
		public string user_not_exist { get; set; }
		public string Name { get; set; }
		public string zone_null { get; set; }
		public string zone_had_exist { get; set; }
		public string add_success { get; set; }
		public string caller_exist { get; set; }
		public string zone_bound { get; set; }
		public string add_fail { get; set; }
		public string add_caller { get; set; }
		public string add_area { get; set; }
		public string employee_exist { get; set; }
		public string employeenum_number_type { get; set; }
		public string male { get; set; }
		public string female { get; set; }
		public string user_exist { get; set; }
		public string admin_forbid { get; set; }
		public string Copyright { get; set; }
		public string Version { get; set; }
		public string right { get; set; }
		public string wireles_system { get; set; }
		public string change_user { get; set; }
		public string admin_forbid_edit { get; set; }
		public string user_no_exist { get; set; }
		public string permission { get; set; }
		public string admin_permission_cannot_change { get; set; }
		public string edit_user_permission { get; set; }
		public string not_choose { get; set; }
		public string no_data_to_edit { get; set; }
		public string edit_failed { get; set; }
		public string zone_eixst { get; set; }
		public string edit_zone { get; set; }
		public string no_caller_to_edit { get; set; }
		public string update_success { get; set; }
		public string edit_caller { get; set; }
		public string employee_not_exist { get; set; }
		public string edit_employee { get; set; }
		public string old_pwd { get; set; }
		public string new_pwd { get; set; }
		public string clear_success { get; set; }
		public string want_to_clear { get; set; }
		public string delete_succe { get; set; }
		public string want_delete_user { get; set; }
		public string Admin_cannot_delete { get; set; }
		public string no_zone_to_delete { get; set; }
		public string want_to_delte_caller { get; set; }
		public string want_to_delete_zone { get; set; }
		public string employee_select { get; set; }
		public string want_delete_employee { get; set; }
		public string Order { get; set; }
		public string Call { get; set; }
		public string CheckOut { get; set; }
		public string Satisfied { get; set; }
		public string Dissatisfied { get; set; }
		public string other { get; set; }
		public string all { get; set; }
		public string batch_update { get; set; }
		public string choose_employee { get; set; }
		public string no_employee_coose { get; set; }
		public string zone_cannot_batch { get; set; }
		public string want_to_delete_choosed { get; set; }
		public string satisfied_rank { get; set; }
		public string dissatisfied_rank { get; set; }
		public string finish_rank { get; set; }
		public string unfinish_rank { get; set; }
		public string overtime_rank { get; set; }
		public string overtime_total { get; set; }
		public string satisfied_totla { get; set; }
		public string dissatisfied_total { get; set; }
		public string frequency { get; set; }
		public string Total { get; set; }
		public string percent { get; set; }
		public string employee_name { get; set; }
		public string Summary_statistics { get; set; }
		public string print { get; set; }

		protected Dictionary<string, string> DicLanguage = new Dictionary<string, string>();

		public Language()
        {
            XmlLoad(GlobalData.SystemLanguage);
            BindLanguageText();
        }

        /// <summary>
        /// 读取XML放到内存
        /// </summary>
        /// <param name="language"></param>
        protected void XmlLoad(string language)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
				if (language.Equals(GlobalData.CHINESE))
				{
					doc.LoadXml(Resources.Chinese);
				}
				else if (language.Equals(GlobalData.ENGLISH))
				{
					doc.LoadXml(Resources.English);
				}
                
                XmlElement root = doc.DocumentElement;

                XmlNodeList nodeLst1 = root.ChildNodes;
                foreach (XmlNode item in nodeLst1)
                {
                    DicLanguage.Add(item.Name, item.InnerText);
                }
            }
            catch (Exception ex)
            {
				LogHelper.LibraryLogger.Instance.WriteLog(LogHelper.LibraryLogger.libLogLevel.Error, ex.ToString());
			}            
        }

        public void BindLanguageText()
        {
			app_name = DicLanguage["app_name"];
			no_quest = DicLanguage["no_quest"];
			have_quest = DicLanguage["have_quest"];
			no_device = DicLanguage["no_device"];
			prompt = DicLanguage["prompt"];
			empty_warn = DicLanguage["empty_warn"];
			login_prompt = DicLanguage["login_prompt"];
			welcome = DicLanguage["welcome"];
			login_error = DicLanguage["login_error"];
			number = DicLanguage["number"];
			nothing = DicLanguage["nothing"];
			name = DicLanguage["name"];
			finish = DicLanguage["finish"];
			overtime = DicLanguage["overtime"];
			waiting = DicLanguage["waiting"];
			satisfy = DicLanguage["satisfy"];
			unsatisfy = DicLanguage["unsatisfy"];
			records = DicLanguage["records"];
			time = DicLanguage["time"];
			record_null = DicLanguage["record_null"];
			choose_file = DicLanguage["choose_file"];
			save_path = DicLanguage["save_path"];
			export_succ = DicLanguage["export_succ"];
			delete_all = DicLanguage["delete_all"];
			delete_caller = DicLanguage["delete_caller"];
			delete_zone = DicLanguage["delete_zone"];
			delete_employee = DicLanguage["delete_employee"];
			delete_user = DicLanguage["delete_user"];
			delete_record = DicLanguage["delete_record"];
			delete_header = DicLanguage["delete_header"];
			login_setting = DicLanguage["login_setting"];
			system_setting = DicLanguage["system_setting"];
			user_setting = DicLanguage["user_setting"];
			caller_setting = DicLanguage["caller_setting"];
			employee_setting = DicLanguage["employee_setting"];
			header_setting = DicLanguage["header_setting"];
			data_setting = DicLanguage["data_setting"];
			summary_setting = DicLanguage["summary_setting"];
			summary_setting = DicLanguage["summary_setting"];
			about_setting = DicLanguage["about_setting"];

			ID = DicLanguage["ID"];
			Time = DicLanguage["Time"];
			caller_num = DicLanguage["caller_num"];
			employee_num = DicLanguage["employee_num"];
			type = DicLanguage["type"];
			status = DicLanguage["status"];
			isRFID = DicLanguage["isRFID"];

			welcome_use = DicLanguage["welcome_use"];
			user_login = DicLanguage["user_login"];
			username = DicLanguage["username"];
			password = DicLanguage["password"];
			login = DicLanguage["login"];
			cancel = DicLanguage["cancel"];

			summary_result = DicLanguage["summary_result"];
			sreach_result = DicLanguage["sreach_result"];
			total = DicLanguage["total"];
			zone_search = DicLanguage["zone_search"];
			employee_search = DicLanguage["employee_search"];
			option = DicLanguage["option"];
			start = DicLanguage["start"];
			end = DicLanguage["end"];
			zone = DicLanguage["zone"];
			employee = DicLanguage["employee"];
			ensure = DicLanguage["ensure"];
			export = DicLanguage["export"];
			summary = DicLanguage["summary"];

			Data_initialization = DicLanguage["Data_initialization"];
			watch_out = DicLanguage["watch_out"];
			all_message = DicLanguage["all_message"];
			all_caller = DicLanguage["all_caller"];
			all_zone = DicLanguage["all_zone"];
			all_employee = DicLanguage["all_employee"];
			all_user = DicLanguage["all_user"];
			all_record = DicLanguage["all_record"];
			all_header = DicLanguage["all_header"];

			ensure_operation = DicLanguage["ensure_operation"];
			exist_app = DicLanguage["exist_app"];
			minimal = DicLanguage["minimal"];

			company_name = DicLanguage["company_name"];
			com_setting = DicLanguage["com_setting"];
			button_function = DicLanguage["button_function"];
			record_show = DicLanguage["record_show"];
			effective_time = DicLanguage["effective_time"];

			SerialPort = DicLanguage["SerialPort"];
			data_bits = DicLanguage["data_bits"];
			baud_rate = DicLanguage["baud_rate"];
			stop_bit = DicLanguage["stop_bit"];

			sort = DicLanguage["sort"];
			Ascending = DicLanguage["Ascending"];
			Descending = DicLanguage["Descending"];
			color = DicLanguage["color"];
			timeout = DicLanguage["timeout"];
			setting = DicLanguage["setting"];
			Set_timeout = DicLanguage["Set_timeout"];

			second = DicLanguage["second"];
			minute = DicLanguage["minute"];
			hour = DicLanguage["hour"];

			Wireless_calling_system = DicLanguage["Wireless_calling_system"];
			set_succe = DicLanguage["set_succe"];
			set_fail = DicLanguage["set_fail"];

			user_type = DicLanguage["user_type"];
			_username = DicLanguage["_username"];

			add_user = DicLanguage["add_user"];
			edit_user = DicLanguage["edit_user"];
			_password = DicLanguage["_password"];
			authority = DicLanguage["authority"];
			update_pwd = DicLanguage["update_pwd"];
			clear_data = DicLanguage["clear_data"];
			del_user = DicLanguage["del_user"];

			caller_zone_setting = DicLanguage["caller_zone_setting"];
			caller_num_setting = DicLanguage["caller_num_setting"];
			call_zone = DicLanguage["call_zone"];
			callAreaAddbtn = DicLanguage["callAreaAddbtn"];
			callAreaUpdatebtn = DicLanguage["callAreaUpdatebtn"];
			callAreaDeletebtn = DicLanguage["callAreaDeletebtn"];
			callAreaBatchUpdatebtn = DicLanguage["callAreaBatchUpdatebtn"];
			callAreaBatchDelbtn = DicLanguage["callAreaBatchDelbtn"];
			callAreaOKbtn = DicLanguage["callAreaOKbtn"];
			callAreaclearDatabtn = DicLanguage["callAreaclearDatabtn"];

			telephone = DicLanguage["telephone"];
			remarks = DicLanguage["remarks"];
			gender = DicLanguage["gender"];
			rfid_mode = DicLanguage["rfid_mode"];
			button_mode = DicLanguage["button_mode"];

			choose_table = DicLanguage["choose_table"];
			other_name = DicLanguage["other_name"];
			call_message = DicLanguage["call_message"];
			employ_info = DicLanguage["employ_info"];
			old_name = DicLanguage["old_name"];
			new_name = DicLanguage["new_name"];
			header_set_succe = DicLanguage["header_set_succe"];

			Caller_number = DicLanguage["Caller_number"];
			Caller_zone = DicLanguage["Caller_zone"];
			password_wrong = DicLanguage["password_wrong"];
			user_not_exist = DicLanguage["user_not_exist"];
			Name = DicLanguage["Name"];

			zone_null = DicLanguage["zone_null"];
			zone_had_exist = DicLanguage["zone_had_exist"];
			add_success = DicLanguage["add_success"];
			caller_exist = DicLanguage["caller_exist"];
			zone_bound = DicLanguage["zone_bound"];
			add_fail = DicLanguage["add_fail"];

			add_caller = DicLanguage["add_caller"];
			add_area = DicLanguage["add_area"];
			employee_exist = DicLanguage["employee_exist"];
			employeenum_number_type = DicLanguage["employeenum_number_type"];
			male = DicLanguage["male"];
			female = DicLanguage["female"];
			user_exist = DicLanguage["user_exist"];
			admin_forbid = DicLanguage["admin_forbid"];

			Copyright = DicLanguage["Copyright"];
			Version = DicLanguage["Version"];
			right = DicLanguage["right"];
			wireles_system = DicLanguage["wireles_system"];
			change_user = DicLanguage["change_user"];
			admin_forbid_edit = DicLanguage["admin_forbid_edit"];
			user_no_exist = DicLanguage["user_no_exist"];
			permission = DicLanguage["permission"];
			admin_permission_cannot_change = DicLanguage["admin_permission_cannot_change"];
			edit_user_permission = DicLanguage["edit_user_permission"];
			not_choose = DicLanguage["not_choose"];
			no_data_to_edit = DicLanguage["no_data_to_edit"];
			edit_failed = DicLanguage["edit_failed"];
			zone_eixst = DicLanguage["zone_eixst"];
			edit_zone = DicLanguage["edit_zone"];
			no_caller_to_edit = DicLanguage["no_caller_to_edit"];
			update_success = DicLanguage["update_success"];
			edit_caller = DicLanguage["edit_caller"];
			employee_not_exist = DicLanguage["employee_not_exist"];
			edit_employee = DicLanguage["edit_employee"];
			old_pwd = DicLanguage["old_pwd"];
			new_pwd = DicLanguage["new_pwd"];
			want_to_clear = DicLanguage["want_to_clear"];
			delete_succe = DicLanguage["delete_succe"];
			want_delete_user = DicLanguage["want_delete_user"];
			Admin_cannot_delete = DicLanguage["Admin_cannot_delete"];
			no_zone_to_delete = DicLanguage["no_zone_to_delete"];
			want_to_delte_caller = DicLanguage["want_to_delte_caller"];
			want_to_delete_zone = DicLanguage["want_to_delete_zone"];
			employee_select = DicLanguage["employee_select"];
			clear_success = DicLanguage["clear_success"];
			want_delete_employee = DicLanguage["want_delete_employee"];

			Order = DicLanguage["Order"];
			Call = DicLanguage["Call"];
			CheckOut = DicLanguage["CheckOut"];
			Satisfied = DicLanguage["Satisfied"];
			Dissatisfied = DicLanguage["Dissatisfied"];
			other = DicLanguage["other"];
			all = DicLanguage["all"];
			batch_update = DicLanguage["batch_update"];
			choose_employee = DicLanguage["choose_employee"];
			no_employee_coose = DicLanguage["no_employee_coose"];
			zone_cannot_batch = DicLanguage["zone_cannot_batch"];
			want_to_delete_choosed = DicLanguage["want_to_delete_choosed"];

			satisfied_rank = DicLanguage["satisfied_rank"];
			dissatisfied_rank = DicLanguage["dissatisfied_rank"];
			finish_rank = DicLanguage["finish_rank"];
			unfinish_rank = DicLanguage["unfinish_rank"];
			overtime_rank = DicLanguage["overtime_rank"];
			overtime_total = DicLanguage["overtime_total"];
			satisfied_totla = DicLanguage["satisfied_totla"];
			dissatisfied_total = DicLanguage["dissatisfied_total"];
			frequency = DicLanguage["frequency"];
			Total = DicLanguage["Total"];
			percent = DicLanguage["percent"];
			employee_name = DicLanguage["employee_name"];
			Summary_statistics = DicLanguage["Summary_statistics"];
			print = DicLanguage["print"];
		}
	}
}
