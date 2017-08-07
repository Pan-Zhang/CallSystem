namespace szwlFormsApplication
{
	partial class szwlForm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(szwlForm));
			this.waitingDataGridView = new System.Windows.Forms.DataGridView();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callerNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.workerNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isRFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.waiting1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.waiting2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.waiting3 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.waiting4 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.waiting5 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.allDataGridView = new System.Windows.Forms.DataGridView();
			this.Id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.time2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callerNum2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.workerNum2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.type2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.status2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isRFID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.menuimageList = new System.Windows.Forms.ImageList(this.components);
			this.menutoolBar = new System.Windows.Forms.ToolBar();
			this.logonbtn = new System.Windows.Forms.ToolBarButton();
			this.systemsettingsbtn = new System.Windows.Forms.ToolBarButton();
			this.userbtn = new System.Windows.Forms.ToolBarButton();
			this.settingsbtn = new System.Windows.Forms.ToolBarButton();
			this.employeesettingsbtn = new System.Windows.Forms.ToolBarButton();
			this.tablesettingsbtn = new System.Windows.Forms.ToolBarButton();
			this.datamaintainbtn = new System.Windows.Forms.ToolBarButton();
			this.searchbtn = new System.Windows.Forms.ToolBarButton();
			this.aboutbtn = new System.Windows.Forms.ToolBarButton();
			((System.ComponentModel.ISupportInitialize)(this.waitingDataGridView)).BeginInit();
			this.waiting1.SuspendLayout();
			this.waiting2.SuspendLayout();
			this.waiting3.SuspendLayout();
			this.waiting4.SuspendLayout();
			this.waiting5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.allDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// waitingDataGridView
			// 
			this.waitingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.waitingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.time,
            this.callerNum,
            this.workerNum,
            this.type,
            this.isRFID});
			this.waitingDataGridView.Location = new System.Drawing.Point(0, 317);
			this.waitingDataGridView.Name = "waitingDataGridView";
			this.waitingDataGridView.RowTemplate.Height = 23;
			this.waitingDataGridView.Size = new System.Drawing.Size(525, 394);
			this.waitingDataGridView.TabIndex = 2;
			this.waitingDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.waitingDataGridView_CellContentClick);
			// 
			// Id
			// 
			this.Id.DataPropertyName = "Id";
			this.Id.HeaderText = "Id";
			this.Id.Name = "Id";
			this.Id.ReadOnly = true;
			this.Id.Width = 30;
			// 
			// time
			// 
			this.time.DataPropertyName = "time";
			this.time.HeaderText = "时间";
			this.time.Name = "time";
			this.time.ReadOnly = true;
			// 
			// callerNum
			// 
			this.callerNum.DataPropertyName = "callerNum";
			this.callerNum.HeaderText = "呼叫器编号";
			this.callerNum.Name = "callerNum";
			this.callerNum.ReadOnly = true;
			// 
			// workerNum
			// 
			this.workerNum.DataPropertyName = "workerNum";
			this.workerNum.HeaderText = "服务员编号";
			this.workerNum.Name = "workerNum";
			this.workerNum.ReadOnly = true;
			// 
			// type
			// 
			this.type.DataPropertyName = "type";
			this.type.HeaderText = "订单类型";
			this.type.Name = "type";
			this.type.ReadOnly = true;
			// 
			// isRFID
			// 
			this.isRFID.DataPropertyName = "isRFID";
			this.isRFID.HeaderText = "isRFID";
			this.isRFID.Name = "isRFID";
			this.isRFID.ReadOnly = true;
			this.isRFID.Width = 50;
			// 
			// waiting1
			// 
			this.waiting1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.waiting1.Controls.Add(this.label1);
			this.waiting1.Location = new System.Drawing.Point(2, 100);
			this.waiting1.Name = "waiting1";
			this.waiting1.Size = new System.Drawing.Size(417, 212);
			this.waiting1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(58, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// waiting2
			// 
			this.waiting2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.waiting2.Controls.Add(this.label2);
			this.waiting2.Location = new System.Drawing.Point(416, 100);
			this.waiting2.Name = "waiting2";
			this.waiting2.Size = new System.Drawing.Size(388, 104);
			this.waiting2.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(77, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "label2";
			// 
			// waiting3
			// 
			this.waiting3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.waiting3.Controls.Add(this.label3);
			this.waiting3.Location = new System.Drawing.Point(416, 204);
			this.waiting3.Name = "waiting3";
			this.waiting3.Size = new System.Drawing.Size(388, 108);
			this.waiting3.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(77, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 24);
			this.label3.TabIndex = 1;
			this.label3.Text = "label3";
			// 
			// waiting4
			// 
			this.waiting4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.waiting4.Controls.Add(this.label4);
			this.waiting4.Location = new System.Drawing.Point(804, 100);
			this.waiting4.Name = "waiting4";
			this.waiting4.Size = new System.Drawing.Size(387, 104);
			this.waiting4.TabIndex = 9;
			this.waiting4.Paint += new System.Windows.Forms.PaintEventHandler(this.waiting4_Paint);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.Red;
			this.label4.Location = new System.Drawing.Point(54, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(82, 24);
			this.label4.TabIndex = 1;
			this.label4.Text = "label4";
			// 
			// waiting5
			// 
			this.waiting5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.waiting5.Controls.Add(this.label5);
			this.waiting5.Location = new System.Drawing.Point(804, 204);
			this.waiting5.Name = "waiting5";
			this.waiting5.Size = new System.Drawing.Size(387, 108);
			this.waiting5.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(54, 31);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 24);
			this.label5.TabIndex = 1;
			this.label5.Text = "label5";
			// 
			// allDataGridView
			// 
			this.allDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.allDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id2,
            this.time2,
            this.callerNum2,
            this.workerNum2,
            this.type2,
            this.status2,
            this.isRFID2});
			this.allDataGridView.Location = new System.Drawing.Point(526, 317);
			this.allDataGridView.Name = "allDataGridView";
			this.allDataGridView.RowTemplate.Height = 23;
			this.allDataGridView.Size = new System.Drawing.Size(665, 394);
			this.allDataGridView.TabIndex = 10;
			this.allDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allDataGridView_CellContentClick);
			// 
			// Id2
			// 
			this.Id2.DataPropertyName = "Id";
			this.Id2.HeaderText = "Id";
			this.Id2.Name = "Id2";
			this.Id2.ReadOnly = true;
			this.Id2.Width = 60;
			// 
			// time2
			// 
			this.time2.DataPropertyName = "time";
			this.time2.HeaderText = "时间";
			this.time2.Name = "time2";
			this.time2.ReadOnly = true;
			// 
			// callerNum2
			// 
			this.callerNum2.DataPropertyName = "callerNum";
			this.callerNum2.HeaderText = "呼叫器编号";
			this.callerNum2.Name = "callerNum2";
			this.callerNum2.ReadOnly = true;
			// 
			// workerNum2
			// 
			this.workerNum2.DataPropertyName = "workerNum";
			this.workerNum2.HeaderText = "服务员编号";
			this.workerNum2.Name = "workerNum2";
			this.workerNum2.ReadOnly = true;
			// 
			// type2
			// 
			this.type2.DataPropertyName = "type";
			this.type2.HeaderText = "订单类型";
			this.type2.Name = "type2";
			this.type2.ReadOnly = true;
			// 
			// status2
			// 
			this.status2.DataPropertyName = "status";
			this.status2.HeaderText = "状态 ";
			this.status2.Name = "status2";
			this.status2.ReadOnly = true;
			// 
			// isRFID2
			// 
			this.isRFID2.HeaderText = "isRFID";
			this.isRFID2.Name = "isRFID2";
			this.isRFID2.ReadOnly = true;
			this.isRFID2.Width = 60;
			// 
			// menuimageList
			// 
			this.menuimageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("menuimageList.ImageStream")));
			this.menuimageList.TransparentColor = System.Drawing.Color.Transparent;
			this.menuimageList.Images.SetKeyName(0, "zj5.png");
			this.menuimageList.Images.SetKeyName(1, "zj6.png");
			this.menuimageList.Images.SetKeyName(2, "zj7.png");
			this.menuimageList.Images.SetKeyName(3, "zj8.png");
			this.menuimageList.Images.SetKeyName(4, "1.png");
			this.menuimageList.Images.SetKeyName(5, "4.png");
			this.menuimageList.Images.SetKeyName(6, "ib.png");
			this.menuimageList.Images.SetKeyName(7, "usercenter.png");
			this.menuimageList.Images.SetKeyName(8, "DrawMoneyResult1.png");
			// 
			// menutoolBar
			// 
			this.menutoolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.logonbtn,
            this.systemsettingsbtn,
            this.userbtn,
            this.settingsbtn,
            this.employeesettingsbtn,
            this.tablesettingsbtn,
            this.datamaintainbtn,
            this.searchbtn,
            this.aboutbtn});
			this.menutoolBar.DropDownArrows = true;
			this.menutoolBar.ImageList = this.menuimageList;
			this.menutoolBar.Location = new System.Drawing.Point(0, 0);
			this.menutoolBar.Name = "menutoolBar";
			this.menutoolBar.ShowToolTips = true;
			this.menutoolBar.Size = new System.Drawing.Size(1191, 75);
			this.menutoolBar.TabIndex = 11;
			this.menutoolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.menutoolBar_ButtonClick_1);
			// 
			// logonbtn
			// 
			this.logonbtn.ImageIndex = 0;
			this.logonbtn.Name = "logonbtn";
			this.logonbtn.Text = "登录";
			this.logonbtn.ToolTipText = "登录";
			// 
			// systemsettingsbtn
			// 
			this.systemsettingsbtn.ImageIndex = 1;
			this.systemsettingsbtn.Name = "systemsettingsbtn";
			this.systemsettingsbtn.Text = "系统设置";
			this.systemsettingsbtn.ToolTipText = "系统设置";
			// 
			// userbtn
			// 
			this.userbtn.ImageIndex = 2;
			this.userbtn.Name = "userbtn";
			this.userbtn.Text = "用户";
			this.userbtn.ToolTipText = "用户";
			// 
			// settingsbtn
			// 
			this.settingsbtn.ImageIndex = 3;
			this.settingsbtn.Name = "settingsbtn";
			this.settingsbtn.Text = "设置";
			this.settingsbtn.ToolTipText = "设置";
			// 
			// employeesettingsbtn
			// 
			this.employeesettingsbtn.ImageIndex = 4;
			this.employeesettingsbtn.Name = "employeesettingsbtn";
			this.employeesettingsbtn.Text = "服务员设置";
			this.employeesettingsbtn.ToolTipText = "服务员设置";
			// 
			// tablesettingsbtn
			// 
			this.tablesettingsbtn.ImageIndex = 5;
			this.tablesettingsbtn.Name = "tablesettingsbtn";
			this.tablesettingsbtn.Text = "表头设置";
			this.tablesettingsbtn.ToolTipText = "表头设置";
			// 
			// datamaintainbtn
			// 
			this.datamaintainbtn.ImageIndex = 6;
			this.datamaintainbtn.Name = "datamaintainbtn";
			this.datamaintainbtn.Text = "数据维护";
			this.datamaintainbtn.ToolTipText = "数据维护";
			// 
			// searchbtn
			// 
			this.searchbtn.ImageIndex = 7;
			this.searchbtn.Name = "searchbtn";
			this.searchbtn.Text = "历史记录查询";
			this.searchbtn.ToolTipText = "历史记录查询";
			// 
			// aboutbtn
			// 
			this.aboutbtn.ImageIndex = 8;
			this.aboutbtn.Name = "aboutbtn";
			this.aboutbtn.Text = "关于";
			this.aboutbtn.ToolTipText = "关于";
			// 
			// szwlForm
			// 
			this.ClientSize = new System.Drawing.Size(1191, 715);
			this.Controls.Add(this.waiting4);
			this.Controls.Add(this.waiting5);
			this.Controls.Add(this.waitingDataGridView);
			this.Controls.Add(this.menutoolBar);
			this.Controls.Add(this.allDataGridView);
			this.Controls.Add(this.waiting3);
			this.Controls.Add(this.waiting2);
			this.Controls.Add(this.waiting1);
			this.Name = "szwlForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "szwlFor无线呼叫系统";
			this.Load += new System.EventHandler(this.szwl呼叫系统_Load);
			((System.ComponentModel.ISupportInitialize)(this.waitingDataGridView)).EndInit();
			this.waiting1.ResumeLayout(false);
			this.waiting1.PerformLayout();
			this.waiting2.ResumeLayout(false);
			this.waiting2.PerformLayout();
			this.waiting3.ResumeLayout(false);
			this.waiting3.PerformLayout();
			this.waiting4.ResumeLayout(false);
			this.waiting4.PerformLayout();
			this.waiting5.ResumeLayout(false);
			this.waiting5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.allDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundworker1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripButton toolStripButton7;
		private System.Windows.Forms.ToolStripButton toolStripButton8;
		private System.Windows.Forms.ToolStripButton toolStripButton9;
		private System.Windows.Forms.DataGridView waitingDataGridView;
		private System.Windows.Forms.Panel waiting1;
		private System.Windows.Forms.Panel waiting2;
		private System.Windows.Forms.Panel waiting3;
		private System.Windows.Forms.Panel waiting4;
		private System.Windows.Forms.Panel waiting5;
		private System.Windows.Forms.DataGridView allDataGridView;
		private System.Windows.Forms.ImageList menuimageList;
		private System.Windows.Forms.ToolBarButton systemsettingsbtn;
		private System.Windows.Forms.ToolBarButton userbtn;
		private System.Windows.Forms.ToolBarButton settingsbtn;
		private System.Windows.Forms.ToolBarButton employeesettingsbtn;
		private System.Windows.Forms.ToolBarButton logonbtn;
		private System.Windows.Forms.ToolBar menutoolBar;
		private System.Windows.Forms.ToolBarButton tablesettingsbtn;
		private System.Windows.Forms.ToolBarButton searchbtn;
		private System.Windows.Forms.ToolBarButton aboutbtn;
		private System.Windows.Forms.ToolBarButton datamaintainbtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn isRFID;
		private System.Windows.Forms.DataGridViewTextBoxColumn type;
		private System.Windows.Forms.DataGridViewTextBoxColumn workerNum;
		private System.Windows.Forms.DataGridViewTextBoxColumn callerNum;
		private System.Windows.Forms.DataGridViewTextBoxColumn time;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id2;
		private System.Windows.Forms.DataGridViewTextBoxColumn time2;
		private System.Windows.Forms.DataGridViewTextBoxColumn callerNum2;
		private System.Windows.Forms.DataGridViewTextBoxColumn workerNum2;
		private System.Windows.Forms.DataGridViewTextBoxColumn type2;
		private System.Windows.Forms.DataGridViewTextBoxColumn status2;
		private System.Windows.Forms.DataGridViewTextBoxColumn isRFID2;
	}
}

