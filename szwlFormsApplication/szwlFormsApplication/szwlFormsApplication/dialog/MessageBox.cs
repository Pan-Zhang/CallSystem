using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szwlFormsApplication.Language;

namespace szwlFormsApplication.dialog
{
	public partial class MessageBox : Form
	{
		public static MessageBox box;
		DialogResult resultLeft, resultRight;
		public MessageBox()
		{
			InitializeComponent();
			resultLeft = DialogResult.OK;
			resultRight = DialogResult.Cancel;
		}

		public static DialogResult Show(String message)
		{
			if (box == null)
			{
				box = new MessageBox();
			}
			box.Text = GlobalData.GlobalLanguage.prompt;
			box.label1.Text = message;
			box.button1.Hide();
			box.button2.Text = GlobalData.GlobalLanguage.ensure;
			box.resultRight = DialogResult.OK;
			return box.ShowDialog();
		}

		public static DialogResult Show(string content, string title)
		{
			if (box == null)
			{
				box = new MessageBox();
			}
			box.Text = GlobalData.GlobalLanguage.prompt;
			box.label1.Text = content;
			box.button1.Hide();
			box.button2.Text = GlobalData.GlobalLanguage.ensure;
			box.resultRight = DialogResult.OK;
			return box.ShowDialog();
		}

		public static DialogResult Show(string content, string title, MessageBoxButtons buttons)
		{
			if(box == null)
			{
				box = new MessageBox();
			}
			box.Text = title;
			box.label1.Text = content;
			box.button1.Text = GlobalData.GlobalLanguage.ensure;
			box.button2.Text = GlobalData.GlobalLanguage.cancel;
			switch (buttons)
			{
				case MessageBoxButtons.OKCancel:
					box.button1.Show();
					box.button2.Show();
					box.resultLeft = DialogResult.OK;
					box.resultRight = DialogResult.Cancel;
					break;

				case MessageBoxButtons.YesNo:
					box.button1.Show();
					box.button2.Show();
					box.resultLeft = DialogResult.Yes;
					box.resultRight = DialogResult.No;
					break;

				case MessageBoxButtons.OK:
					box.button2.Hide();
					box.resultLeft = DialogResult.OK;
					break;
			}
			return box.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = box.resultLeft;
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = box.resultRight;
			this.Close();
		}

	}
}
