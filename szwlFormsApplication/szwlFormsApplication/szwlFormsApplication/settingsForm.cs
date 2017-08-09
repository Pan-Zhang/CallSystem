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
using szwlFormsApplication.dialog;
using szwlFormsApplication.Models;

namespace szwlFormsApplication
{
	public partial class settingsForm : Form
	{
		List<Callzone> list_zone;
		List<Caller> list_caller;
		DBManager dm;

		public settingsForm()
		{
			InitializeComponent();
		}

		private void settingsForm_Load(object sender, EventArgs e)
		{
			dm = new DBManager();
			refreshZone();
			refreshCaller();
		}

		private void refreshZone()
		{
			list_zone = dm.selectZone();
			this.callAreadataGridView.AutoGenerateColumns = false;
			this.callAreadataGridView.DataSource = list_zone;
			this.callAreadataGridView.Refresh();
		}

		private void refreshCaller()
		{
			list_caller = dm.selectCaller();
			foreach (Caller caller in list_caller)
			{
				foreach (Callzone zone in list_zone)
				{
					if (caller.callZone == zone.Id)
					{
						caller.callerZoneName = zone.name;
					}
				}
			}

			this.callNumdataGridView.AutoGenerateColumns = false;
			this.callNumdataGridView.DataSource = list_caller;
			this.callNumdataGridView.Refresh();
		}

		private void callAreaAddbtn_Click(object sender, EventArgs e)
		{
			if(callAreatabControl.SelectedIndex == 0){
				AddAreaForm form = new AddAreaForm();
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					refreshZone();
				}
			}
			else
			{
				AddCallerForm form = new AddCallerForm();
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					refreshCaller();
				}
			}
		}

		private void callAreaUpdatebtn_Click(object sender, EventArgs e)
		{
			if (callAreatabControl.SelectedIndex == 0)
			{
				int index = callAreadataGridView.CurrentRow.Index;
				Callzone zone = list_zone[index];
				EditAreaForm form = new EditAreaForm();
				form.zone = zone;
				DialogResult dr = form.ShowDialog();
				if(dr == DialogResult.OK)
				{
					refreshZone();
					refreshCaller();
				}
			}
			else
			{
				int index = callNumdataGridView.CurrentRow.Index;
				Caller caller = list_caller[index];
				EditCallerForm form = new EditCallerForm();
				form.caller = caller;
				DialogResult dr = form.ShowDialog();
				if (dr == DialogResult.OK)
				{
					refreshCaller();
				}
			}
		}

		private void callAreaDeletebtn_Click(object sender, EventArgs e)
		{
			if (callAreatabControl.SelectedIndex == 0)
			{
				int index = callAreadataGridView.CurrentRow.Index;
				Callzone zone = list_zone[index];
				DialogResult dr = MessageBox.Show("您确定想删除区域："+  zone.name + "吗？",
								 " 提示",
								MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes)
				{
					dm.deleteZone(zone);
					refreshZone();
					refreshCaller();
				}
			}
			else
			{
				int index = callNumdataGridView.CurrentRow.Index;
				Caller caller = list_caller[index];
				DialogResult dr = MessageBox.Show("您确定想删除呼叫器：" + caller.callerNum + "吗？",
								 " 提示",
								MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes)
				{
					dm.deleteCaller(caller);
					refreshCaller();
				}
			}
		}

		private void callAreaOKbtn_Click(object sender, EventArgs e)
		{
			if (callAreatabControl.SelectedIndex == 0)
			{
				this.Hide();
			}
			else
			{
				this.Hide();
			}
		}

		private void callAreaclearDatabtn_Click(object sender, EventArgs e)
		{
			if (callAreatabControl.SelectedIndex == 0)
			{

			}
			else
			{

			}
		}

		private void callAreaBatchUpdatebtn_Click(object sender, EventArgs e)
		{

		}

		private void callAreaBatchDelbtn_Click(object sender, EventArgs e)
		{

		}
	}
}
