using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szwlFormsApplication.CommonFunc;
using szwlFormsApplication.Language;
using szwlFormsApplication.Models;

namespace szwlFormsApplication.dialog
{
	public partial class SummaryForm : Form
	{
		public List<Summary> list { get; set; }
		public string title { get; set; }
		public SummaryForm()
		{
			InitializeComponent();
		}

		private void SummaryForm_Load(object sender, EventArgs e)
		{
			this.Text = title;
			dataGridView1.DataSource = list;
			dataGridView1.Columns[0].HeaderCell.Value = DataMessage.DisplaycallerNum();
			dataGridView1.Columns[1].HeaderCell.Value = GlobalData.GlobalLanguage.zone;
			dataGridView1.Columns[2].HeaderCell.Value = Employee.Displayname();
			dataGridView1.Columns[3].HeaderCell.Value = Employee.DisplayemployeeNum();
			dataGridView1.Columns[4].HeaderText = GlobalData.GlobalLanguage.frequency;
			button1.Text = GlobalData.GlobalLanguage.export;
			button2.Text = GlobalData.GlobalLanguage.print;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MakeExcel();
		}

		private void MakeExcel()
		{
			if (list == null || list.Count == 0)
			{
				dialog.MessageBox.Show(GlobalData.GlobalLanguage.record_null, GlobalData.GlobalLanguage.prompt, MessageBoxButtons.OK);
			}
			else
			{
				FolderBrowserDialog FDialog = new FolderBrowserDialog();
				FDialog.Description = GlobalData.GlobalLanguage.choose_file;
				if (FDialog.ShowDialog() == DialogResult.OK)
				{
					string foldPath = FDialog.SelectedPath;
					string path = "";
					ExcelFile.makeExcel2(list, foldPath, out path);
					dialog.MessageBox.Show(GlobalData.GlobalLanguage.save_path + path, GlobalData.GlobalLanguage.export_succ, MessageBoxButtons.OK);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			print();
		}

		private void print()
		{
			string path;
			ExcelFile.makeExcel2(list, ChangeAppConfig.getValueFromKey("tem_file"), out path);

			Workbook workbook = new Workbook();
			workbook.LoadFromFile(path);

			Worksheet sheet = workbook.Worksheets[0];
			sheet.PageSetup.PrintArea = "A7:T8";
			sheet.PageSetup.PrintTitleRows = "$1:$1";
			sheet.PageSetup.FitToPagesWide = 1;
			sheet.PageSetup.FitToPagesTall = 1;
			//sheet.PageSetup.Orientation = PageOrientationType.Landscape;
			//sheet.PageSetup.PaperSize = PaperSizeType.PaperA3;

			PrintDialog dialog = new PrintDialog();
			dialog.AllowPrintToFile = true;
			dialog.AllowCurrentPage = true;
			dialog.AllowSomePages = true;
			dialog.AllowSelection = true;
			dialog.UseEXDialog = true;
			dialog.PrinterSettings.Duplex = Duplex.Simplex;
			dialog.PrinterSettings.FromPage = 0;
			dialog.PrinterSettings.ToPage = 8;
			dialog.PrinterSettings.PrintRange = PrintRange.SomePages;
			workbook.PrintDialog = dialog;
			PrintDocument pd = workbook.PrintDocument;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				pd.Print();
			}
		}
	}
}
