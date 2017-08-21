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
using szwlFormsApplication.Language;
using szwlFormsApplication.Models;

namespace szwlFormsApplication
{
	public partial class settingsForm : Form
	{
		public settingsForm()
		{
			InitializeComponent();
		}

		private void settingsForm_Load(object sender, EventArgs e)
		{
			refreshZone();
			refreshCaller();
			changeLanguage();
		}

		private void refreshZone()
		{
			InitData.AddData(callAreadataGridView, InitData.list_zone);
			//this.callAreadataGridView.AutoGenerateColumns = false;
			//this.callAreadataGridView.DataSource = InitData.list_zone;
			//this.callAreadataGridView.Refresh();
			if (callAreatabControl.SelectedIndex == 0)
			{
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
		}

		private void refreshCaller()
		{
			if (InitData.list_caller == null)
			{
				return;
			}
			if (InitData.list_zone != null)
			{
				foreach (Caller caller in InitData.list_caller)
				{
					foreach (Callzone zone in InitData.list_zone)
					{
						if (caller.callZone == zone.Id)
						{
							caller.callerZoneName = zone.name;
						}
					}
				}
			}

			InitData.AddData(callNumdataGridView, InitData.list_caller);
			//this.callNumdataGridView.AutoGenerateColumns = false;
			//this.callNumdataGridView.DataSource = InitData.list_caller;
			//this.callNumdataGridView.Refresh();

			if (callAreatabControl.SelectedIndex == 1)
			{
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
				Callzone zone = InitData.list_zone[index];
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
				Caller caller = InitData.list_caller[index];
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
				Callzone zone = InitData.list_zone[index];
				DialogResult dr = MessageBox.Show("您确定想删除区域：" + zone.name + "吗？",
								 " 提示",
								MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes)
				{
					if (InitData.list_zone == null || InitData.list_zone.Count == 0)
					{
						MessageBox.Show("暂时还未有呼叫区域数据,不能删除！");
						return;
					}
					szwlForm.mainForm.dm.deleteZone(zone);
					InitData.list_zone.RemoveAll(z => z.Id == zone.Id);
					MessageBox.Show("该呼叫区域删除成功！");
					refreshZone();
					refreshCaller();
				}
			}
			else
			{
				int index = callNumdataGridView.CurrentRow.Index;
				Caller caller = InitData.list_caller[index];
				DialogResult dr = MessageBox.Show("您确定想删除呼叫器：" + caller.callerNum + "吗？",
								 " 提示",
								MessageBoxButtons.YesNo);
				if (dr == DialogResult.Yes)
				{
					if (InitData.list_zone == null || InitData.list_zone.Count == 0)
					{
						MessageBox.Show("暂时还未有呼叫器数据,不能删除！");
						return;
					}
					szwlForm.mainForm.dm.deleteCaller(caller);
					InitData.list_caller.RemoveAll(c => c.callerNum == caller.callerNum);
					MessageBox.Show("该呼叫区域删除成功！");
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
			DialogResult dr = MessageBox.Show("是否清除这些数据？",
									" 提示",
								   MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				if (callAreatabControl.SelectedIndex == 0)
				{
					MessageBox.Show("数据清除成功！");
					InitData.ClearData(this.callAreadataGridView, InitData.list_zone);
				}
				else
				{
					szwlForm.mainForm.dm.clearCaller();
					MessageBox.Show("数据清除成功！");
					InitData.ClearData(this.callNumdataGridView, InitData.list_caller);
				}
			}
		}

		private void callAreaBatchUpdatebtn_Click(object sender, EventArgs e)
		{

		}

		private void callAreaBatchDelbtn_Click(object sender, EventArgs e)
		{

		}

		private void callAreadataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int index = callAreadataGridView.CurrentRow.Index;
			if (index > 0)
			{
				this.callAreaBatchUpdatebtn.Enabled = true;
				this.callAreaBatchDelbtn.Enabled = true;
				this.callAreaDeletebtn.Enabled = true;
				this.callAreaUpdatebtn.Enabled = true;
			}
		}
		private void callNumdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int index = callNumdataGridView.CurrentRow.Index;
			if (index > 0)
			{
				this.callAreaBatchUpdatebtn.Enabled = true;
				this.callAreaBatchDelbtn.Enabled = true;
				this.callAreaDeletebtn.Enabled = true;
				this.callAreaUpdatebtn.Enabled = true;
			}
		}

		private void changeLanguage()
		{
			this.Text = GlobalData.GlobalLanguage.caller_setting;

			callAreatabControl.TabPages[0].Text = GlobalData.GlobalLanguage.caller_zone_setting;
			callAreatabControl.TabPages[1].Text = GlobalData.GlobalLanguage.caller_num_setting;

			callAreadataGridView.Columns[0].HeaderText = GlobalData.GlobalLanguage.call_zone;

			callNumdataGridView.Columns[0].HeaderText = GlobalData.GlobalLanguage.caller_num;
			callNumdataGridView.Columns[1].HeaderText = GlobalData.GlobalLanguage.call_zone;
			callNumdataGridView.Columns[2].HeaderText = GlobalData.GlobalLanguage.employee_num;

			callAreaAddbtn.Text = GlobalData.GlobalLanguage.callAreaAddbtn;
			callAreaUpdatebtn.Text = GlobalData.GlobalLanguage.callAreaUpdatebtn;
			callAreaDeletebtn.Text = GlobalData.GlobalLanguage.callAreaDeletebtn;
			callAreaBatchUpdatebtn.Text = GlobalData.GlobalLanguage.callAreaBatchUpdatebtn;
			callAreaBatchDelbtn.Text = GlobalData.GlobalLanguage.callAreaBatchDelbtn;
			callAreaOKbtn.Text = GlobalData.GlobalLanguage.callAreaOKbtn;
			callAreaclearDatabtn.Text = GlobalData.GlobalLanguage.callAreaclearDatabtn;
		}
	}
}
