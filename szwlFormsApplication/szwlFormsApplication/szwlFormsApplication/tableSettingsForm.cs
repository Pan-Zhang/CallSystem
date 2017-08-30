using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szwlFormsApplication.CommonFunc;
using szwlFormsApplication.Language;
using szwlFormsApplication.Models;

namespace szwlFormsApplication
{
	public partial class tableSettingsForm : Form
	{
		public static List<TableHeader> headers = new List<TableHeader>();
		public tableSettingsForm()
		{
			InitializeComponent();
			changeLanguage();
			tablelistView.Items[0].Selected = true;
		}

		private void tablelistView_SelectedIndexChanged(object sender, EventArgs e)
		{
			headers = new List<TableHeader>();
			foreach (ListViewItem item in tablelistView.SelectedItems)
			{
				if (item.Text == GlobalData.GlobalLanguage.call_message)
				{
					headers.Add(new TableHeader { oldheader = DataMessage.Displaytime() });
					headers.Add(new TableHeader { oldheader = DataMessage.DisplaycallerNum() });
					headers.Add(new TableHeader { oldheader = DataMessage.DisplayemployeeNum() });
					headers.Add(new TableHeader { oldheader = DataMessage.Displaytype() });
					headers.Add(new TableHeader { oldheader = DataMessage.Displaystatus() });
					headers.Add(new TableHeader { oldheader = DataMessage.DisplaycallZone() });
				}
				else if (item.Text == GlobalData.GlobalLanguage.employ_info)
				{
					headers.Add(new TableHeader { oldheader = Employee.DisplayemployeeNum() });
					headers.Add(new TableHeader { oldheader = Employee.Displayname() });
					headers.Add(new TableHeader { oldheader = Employee.Displayphonenum() });
					headers.Add(new TableHeader { oldheader = Employee.Displayremarks() });
					headers.Add(new TableHeader { oldheader = Employee.Displaysex() });
				}
				dataGridView.DataSource = headers;
				dataGridView.Refresh();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in tablelistView.SelectedItems)
			{
				if (item.Text == GlobalData.GlobalLanguage.call_message)
				{
					if (headers.Count()>0 &&!String.IsNullOrWhiteSpace(headers[0].newheader))
						ChangeAppConfig.ChangeConfig("MessagetimeHeader", headers[0].newheader);
					if (headers.Count() > 1 && !String.IsNullOrWhiteSpace(headers[1].newheader))
						ChangeAppConfig.ChangeConfig("MessagecallerNumHeader", headers[1].newheader);
					if (headers.Count() > 2 && !String.IsNullOrWhiteSpace(headers[2].newheader)) 
						ChangeAppConfig.ChangeConfig("MessageemployeeNumHeader", headers[2].newheader);
					if (headers.Count() > 3 && !String.IsNullOrWhiteSpace(headers[3].newheader)) 
						ChangeAppConfig.ChangeConfig("MessagetypeHeader", headers[3].newheader);
					if (headers.Count() > 4 && !String.IsNullOrWhiteSpace(headers[4].newheader))
						ChangeAppConfig.ChangeConfig("MessagestatusHeader", headers[4].newheader);
					if (headers.Count() > 5 && !String.IsNullOrWhiteSpace(headers[5].newheader))
						ChangeAppConfig.ChangeConfig("MessagecallZoneHeader", headers[5].newheader);
				}
				else if (item.Text == GlobalData.GlobalLanguage.employ_info)
				{
					if (headers.Count() > 0 && !String.IsNullOrWhiteSpace(headers[0].newheader))
						ChangeAppConfig.ChangeConfig("EmployeeemployeeNumHeader", headers[0].newheader);
					if (headers.Count() > 1 && !String.IsNullOrWhiteSpace(headers[1].newheader))
						ChangeAppConfig.ChangeConfig("EmployeenameHeader", headers[1].newheader);
					if (headers.Count() > 2 && !String.IsNullOrWhiteSpace(headers[2].newheader))
						ChangeAppConfig.ChangeConfig("EmployeephonenumHeader", headers[2].newheader);
					if (headers.Count() > 3 && !String.IsNullOrWhiteSpace(headers[3].newheader))
						ChangeAppConfig.ChangeConfig("EmployeeremarksHeader", headers[3].newheader);
					if (headers.Count() >4 && !String.IsNullOrWhiteSpace(headers[4].newheader))
						ChangeAppConfig.ChangeConfig("EmployeesexHeader", headers[4].newheader);
				}
			}
			dialog.MessageBox.Show(GlobalData.GlobalLanguage.header_set_succe);
			this.Close();
			szwlForm.mainForm.SetTableHeader();
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.header_setting;

			choosegroupBox.Text = GlobalData.GlobalLanguage.choose_table;
			columnSetgroupBox.Text = GlobalData.GlobalLanguage.other_name;

			tablelistView.Items[0].Text = GlobalData.GlobalLanguage.call_message;
			tablelistView.Items[1].Text = GlobalData.GlobalLanguage.employ_info;

			dataGridView.Columns[0].HeaderText = GlobalData.GlobalLanguage.old_name;
			dataGridView.Columns[1].HeaderText = GlobalData.GlobalLanguage.new_name;
		}
	}
}
