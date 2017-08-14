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
			refreshZone();
			refreshCaller();
		}

		private void refreshZone()
		{
			list_zone = szwlForm.mainForm.dm.selectZone();
			this.callAreadataGridView.AutoGenerateColumns = false;
			this.callAreadataGridView.DataSource = list_zone;
			this.callAreadataGridView.Refresh();
			if (this.callAreadataGridView.SelectedRows != null && this.callAreadataGridView.SelectedRows.Count > 0)
			{
				callAreaUpdatebtn.Enabled = true;
				callAreaDeletebtn.Enabled = true;
				callAreaBatchUpdatebtn.Enabled = true;
				callAreaBatchDelbtn.Enabled = true;
			}
			else
			{
				callAreaUpdatebtn.Enabled = false;
				callAreaDeletebtn.Enabled = false;
				callAreaBatchUpdatebtn.Enabled = false;
				callAreaBatchDelbtn.Enabled = false;
			}
		}

		private void refreshCaller()
		{
			list_caller = szwlForm.mainForm.dm.selectCaller();
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
			if (this.callNumdataGridView.SelectedRows != null && this.callNumdataGridView.SelectedRows.Count > 0)
			{
				callAreaUpdatebtn.Enabled = true;
				callAreaDeletebtn.Enabled = true;
				callAreaBatchUpdatebtn.Enabled = true;
				callAreaBatchDelbtn.Enabled = true;
			}
			else
			{
				callAreaUpdatebtn.Enabled = false;
				callAreaDeletebtn.Enabled = false;
				callAreaBatchUpdatebtn.Enabled = false;
				callAreaBatchDelbtn.Enabled = false;
			}
		}

		private void callAreaAddbtn_Click(object sender, EventArgs e)
		{
			if (callAreatabControl.SelectedIndex == 0)
			{
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
				if (dr == DialogResult.OK)
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
				DialogResult dr = MessageBox.Show("您确定想删除区域：" + zone.name + "吗？",
								 " 提示",
								MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes)
				{
					szwlForm.mainForm.dm.deleteZone(zone);
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
					szwlForm.mainForm.dm.deleteCaller(caller);
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
