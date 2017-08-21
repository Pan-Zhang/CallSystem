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
	public partial class EditAreaForm : Form
	{
		public Callzone zone { get; set; }
		public EditAreaForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			if(String.IsNullOrWhiteSpace(oldareaname.Text))
			{
				MessageBox.Show("未选中呼叫呼叫区域数据,不能修改！");
				return;
			}

			if (InitData.list_zone == null || InitData.list_zone.Count == 0)
			{
				MessageBox.Show("暂时还未有呼叫区域数据,不能修改！");
				return;
			}
			if (InitData.list_zone.Any(z => z.Id == zone.Id))
			{
				if (textBox1.Text == oldareaname.Text)
					return;
				if (InitData.list_zone.Where(z=>z.name!=oldareaname.Text).Any(z => z.name == textBox1.Text))
				{
					MessageBox.Show("该呼叫器已存在,修改失败！");
					return;
				}
				zone.name = textBox1.Text;
				if (szwlForm.mainForm.dm.updateZone(zone))
				{
					InitData.list_zone = InitData.list_zone.Select(z => z.Id == zone.Id ? zone : z).ToList();
					this.Hide();
				}
				else
				{
					MessageBox.Show("修改失败，请重试！");
					return;
				}
			}
			else
			{
				MessageBox.Show("该呼叫区域不存在,不能修改！");
				return;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void EditAreaForm_Load(object sender, EventArgs e)
		{
			oldareaname.Text=textBox1.Text = zone.name;
		}
	}
}
