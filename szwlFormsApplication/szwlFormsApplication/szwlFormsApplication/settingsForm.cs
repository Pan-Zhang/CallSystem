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
using szwlFormsApplication.Models;

namespace szwlFormsApplication
{
	public partial class settingsForm : Form
	{
		List<Callzone> list_zone;
		List<Caller> list_caller;

		public settingsForm()
		{
			InitializeComponent();
		}

		private void settingsForm_Load(object sender, EventArgs e)
		{
			DBManager dm = new DBManager();

			list_zone = dm.selectZone();
			list_caller = dm.selectCaller();
			foreach(Caller caller in list_caller)
			{
				foreach(Callzone zone in list_zone)
				{
					if(caller.callZone == zone.Id)
					{
						caller.callerZoneName = zone.name;
					}
				}
			}
			this.callAreadataGridView.AutoGenerateColumns = false;
			this.callAreadataGridView.DataSource = list_zone;
			this.callAreadataGridView.Refresh();

			this.callNumdataGridView.AutoGenerateColumns = false;
			this.callNumdataGridView.DataSource = list_caller;
			this.callNumdataGridView.Refresh();
		}
	}
}
