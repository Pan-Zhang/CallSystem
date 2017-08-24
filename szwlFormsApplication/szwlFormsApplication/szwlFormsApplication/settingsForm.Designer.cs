namespace szwlFormsApplication
{
	partial class settingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.callAreatabControl = new System.Windows.Forms.TabControl();
			this.callAreatabPage = new System.Windows.Forms.TabPage();
			this.callAreadataGridView = new System.Windows.Forms.DataGridView();
			this.callArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callNumtabPage = new System.Windows.Forms.TabPage();
			this.callNumdataGridView = new System.Windows.Forms.DataGridView();
			this.callAreaclearDatabtn = new System.Windows.Forms.Button();
			this.callAreaOKbtn = new System.Windows.Forms.Button();
			this.callAreaDeletebtn = new System.Windows.Forms.Button();
			this.callAreaUpdatebtn = new System.Windows.Forms.Button();
			this.callAreaAddbtn = new System.Windows.Forms.Button();
			this.callAreaBatchUpdatebtn = new System.Windows.Forms.Button();
			this.callAreaBatchDelbtn = new System.Windows.Forms.Button();
			this.callNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callAreaf = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callAreatabControl.SuspendLayout();
			this.callAreatabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.callAreadataGridView)).BeginInit();
			this.callNumtabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.callNumdataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// callAreatabControl
			// 
			this.callAreatabControl.Controls.Add(this.callAreatabPage);
			this.callAreatabControl.Controls.Add(this.callNumtabPage);
			this.callAreatabControl.Location = new System.Drawing.Point(2, 4);
			this.callAreatabControl.Name = "callAreatabControl";
			this.callAreatabControl.SelectedIndex = 0;
			this.callAreatabControl.Size = new System.Drawing.Size(352, 580);
			this.callAreatabControl.TabIndex = 13;
			// 
			// callAreatabPage
			// 
			this.callAreatabPage.Controls.Add(this.callAreadataGridView);
			this.callAreatabPage.Location = new System.Drawing.Point(4, 22);
			this.callAreatabPage.Name = "callAreatabPage";
			this.callAreatabPage.Padding = new System.Windows.Forms.Padding(3);
			this.callAreatabPage.Size = new System.Drawing.Size(344, 554);
			this.callAreatabPage.TabIndex = 0;
			this.callAreatabPage.Text = "呼叫器区域设置";
			this.callAreatabPage.UseVisualStyleBackColor = true;
			// 
			// callAreadataGridView
			// 
			this.callAreadataGridView.AllowUserToAddRows = false;
			this.callAreadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.callAreadataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.callArea});
			this.callAreadataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.callAreadataGridView.Location = new System.Drawing.Point(-4, 0);
			this.callAreadataGridView.Name = "callAreadataGridView";
			this.callAreadataGridView.RowTemplate.Height = 23;
			this.callAreadataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.callAreadataGridView.Size = new System.Drawing.Size(345, 554);
			this.callAreadataGridView.TabIndex = 13;
			this.callAreadataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.callAreadataGridView_CellContentClick);
			// 
			// callArea
			// 
			this.callArea.DataPropertyName = "name";
			this.callArea.HeaderText = "呼叫区域";
			this.callArea.Name = "callArea";
			// 
			// callNumtabPage
			// 
			this.callNumtabPage.Controls.Add(this.callNumdataGridView);
			this.callNumtabPage.Location = new System.Drawing.Point(4, 22);
			this.callNumtabPage.Name = "callNumtabPage";
			this.callNumtabPage.Padding = new System.Windows.Forms.Padding(3);
			this.callNumtabPage.Size = new System.Drawing.Size(344, 554);
			this.callNumtabPage.TabIndex = 1;
			this.callNumtabPage.Text = "呼叫器编号设置";
			this.callNumtabPage.UseVisualStyleBackColor = true;
			// 
			// callNumdataGridView
			// 
			this.callNumdataGridView.AllowUserToAddRows = false;
			this.callNumdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.callNumdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.callNum,
            this.callAreaf,
            this.user});
			this.callNumdataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.callNumdataGridView.Location = new System.Drawing.Point(0, 0);
			this.callNumdataGridView.Name = "callNumdataGridView";
			this.callNumdataGridView.RowTemplate.Height = 23;
			this.callNumdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.callNumdataGridView.Size = new System.Drawing.Size(349, 554);
			this.callNumdataGridView.TabIndex = 14;
			this.callNumdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.callNumdataGridView_CellContentClick);
			// 
			// callAreaclearDatabtn
			// 
			this.callAreaclearDatabtn.Location = new System.Drawing.Point(415, 480);
			this.callAreaclearDatabtn.Name = "callAreaclearDatabtn";
			this.callAreaclearDatabtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaclearDatabtn.TabIndex = 23;
			this.callAreaclearDatabtn.Text = "清除数据";
			this.callAreaclearDatabtn.UseVisualStyleBackColor = true;
			this.callAreaclearDatabtn.Click += new System.EventHandler(this.callAreaclearDatabtn_Click);
			// 
			// callAreaOKbtn
			// 
			this.callAreaOKbtn.Location = new System.Drawing.Point(415, 408);
			this.callAreaOKbtn.Name = "callAreaOKbtn";
			this.callAreaOKbtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaOKbtn.TabIndex = 22;
			this.callAreaOKbtn.Text = "确定";
			this.callAreaOKbtn.UseVisualStyleBackColor = true;
			this.callAreaOKbtn.Click += new System.EventHandler(this.callAreaOKbtn_Click);
			// 
			// callAreaDeletebtn
			// 
			this.callAreaDeletebtn.Location = new System.Drawing.Point(415, 214);
			this.callAreaDeletebtn.Name = "callAreaDeletebtn";
			this.callAreaDeletebtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaDeletebtn.TabIndex = 21;
			this.callAreaDeletebtn.Text = "删除";
			this.callAreaDeletebtn.UseVisualStyleBackColor = true;
			this.callAreaDeletebtn.Click += new System.EventHandler(this.callAreaDeletebtn_Click);
			// 
			// callAreaUpdatebtn
			// 
			this.callAreaUpdatebtn.Location = new System.Drawing.Point(415, 153);
			this.callAreaUpdatebtn.Name = "callAreaUpdatebtn";
			this.callAreaUpdatebtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaUpdatebtn.TabIndex = 20;
			this.callAreaUpdatebtn.Text = "修改";
			this.callAreaUpdatebtn.UseVisualStyleBackColor = true;
			this.callAreaUpdatebtn.Click += new System.EventHandler(this.callAreaUpdatebtn_Click);
			// 
			// callAreaAddbtn
			// 
			this.callAreaAddbtn.Location = new System.Drawing.Point(415, 96);
			this.callAreaAddbtn.Name = "callAreaAddbtn";
			this.callAreaAddbtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaAddbtn.TabIndex = 19;
			this.callAreaAddbtn.Text = "添加";
			this.callAreaAddbtn.UseVisualStyleBackColor = true;
			this.callAreaAddbtn.Click += new System.EventHandler(this.callAreaAddbtn_Click);
			// 
			// callAreaBatchUpdatebtn
			// 
			this.callAreaBatchUpdatebtn.Location = new System.Drawing.Point(415, 274);
			this.callAreaBatchUpdatebtn.Name = "callAreaBatchUpdatebtn";
			this.callAreaBatchUpdatebtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaBatchUpdatebtn.TabIndex = 24;
			this.callAreaBatchUpdatebtn.Text = "批量修改";
			this.callAreaBatchUpdatebtn.UseVisualStyleBackColor = true;
			this.callAreaBatchUpdatebtn.Click += new System.EventHandler(this.callAreaBatchUpdatebtn_Click);
			// 
			// callAreaBatchDelbtn
			// 
			this.callAreaBatchDelbtn.Location = new System.Drawing.Point(415, 336);
			this.callAreaBatchDelbtn.Name = "callAreaBatchDelbtn";
			this.callAreaBatchDelbtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaBatchDelbtn.TabIndex = 25;
			this.callAreaBatchDelbtn.Text = "批量删除";
			this.callAreaBatchDelbtn.UseVisualStyleBackColor = true;
			this.callAreaBatchDelbtn.Click += new System.EventHandler(this.callAreaBatchDelbtn_Click);
			// 
			// callNum
			// 
			this.callNum.DataPropertyName = "callerNum";
			this.callNum.HeaderText = "呼叫器编号";
			this.callNum.Name = "callNum";
			// 
			// callAreaf
			// 
			this.callAreaf.DataPropertyName = "callerZoneName";
			this.callAreaf.HeaderText = "呼叫区域";
			this.callAreaf.Name = "callAreaf";
			// 
			// user
			// 
			this.user.DataPropertyName = "employeeNum";
			this.user.HeaderText = "员工";
			this.user.Name = "user";
			// 
			// settingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(540, 592);
			this.Controls.Add(this.callAreaBatchDelbtn);
			this.Controls.Add(this.callAreaBatchUpdatebtn);
			this.Controls.Add(this.callAreaclearDatabtn);
			this.Controls.Add(this.callAreaOKbtn);
			this.Controls.Add(this.callAreaDeletebtn);
			this.Controls.Add(this.callAreaUpdatebtn);
			this.Controls.Add(this.callAreaAddbtn);
			this.Controls.Add(this.callAreatabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "settingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "呼叫器设置";
			this.Load += new System.EventHandler(this.settingsForm_Load);
			this.callAreatabControl.ResumeLayout(false);
			this.callAreatabPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.callAreadataGridView)).EndInit();
			this.callNumtabPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.callNumdataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl callAreatabControl;
		private System.Windows.Forms.TabPage callAreatabPage;
		private System.Windows.Forms.DataGridView callAreadataGridView;
		private System.Windows.Forms.TabPage callNumtabPage;
		private System.Windows.Forms.DataGridView callNumdataGridView;
		private System.Windows.Forms.Button callAreaAddbtn;
		private System.Windows.Forms.Button callAreaUpdatebtn;
		private System.Windows.Forms.Button callAreaDeletebtn;
		private System.Windows.Forms.Button callAreaOKbtn;
		private System.Windows.Forms.Button callAreaclearDatabtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn callArea;
		private System.Windows.Forms.Button callAreaBatchUpdatebtn;
		private System.Windows.Forms.Button callAreaBatchDelbtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn callNum;
		private System.Windows.Forms.DataGridViewTextBoxColumn callAreaf;
		private System.Windows.Forms.DataGridViewTextBoxColumn user;
	}
}