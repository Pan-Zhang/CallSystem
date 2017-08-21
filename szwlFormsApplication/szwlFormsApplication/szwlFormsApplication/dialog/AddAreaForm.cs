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

namespace szwlFormsApplication.dialog
{
	public partial class AddAreaForm : Form
	{
		public AddAreaForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Callzone zone = new Callzone();
			zone.name = areaName.Text;
			if (string.IsNullOrWhiteSpace(zone.name))
			{
				MessageBox.Show("呼叫区域不能为空,不能新增！");
				return;
			}

			this.DialogResult = DialogResult.OK;
			if (InitData.list_zone == null)
				InitData.list_zone = new List<Callzone>();
			if (InitData.list_zone.Any(z => z.name == zone.name))
			{
				MessageBox.Show("该呼叫区域已存在,不能新增！");
				return;
			}
			if (szwlForm.mainForm.dm.insertZone(zone))
			{
				InitData.list_zone = szwlForm.mainForm.dm.selectZone();
				MessageBox.Show("该呼叫区域添加成功！");
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Hide();
		}
	}
}
