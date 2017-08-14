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
		DBManager dm;
		public EditAreaForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			zone.name = textBox1.Text;
			this.DialogResult = DialogResult.OK;
			if (szwlForm.mainForm.dm.updateZone(zone))
			{
				this.Hide();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void EditAreaForm_Load(object sender, EventArgs e)
		{
			textBox1.Text = zone.name;
		}
	}
}
