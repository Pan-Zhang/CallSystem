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
			this.callNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callAreaf = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.callAreaclearDatabtn = new System.Windows.Forms.Button();
			this.callAreaOKbtn = new System.Windows.Forms.Button();
			this.callAreaDeletebtn = new System.Windows.Forms.Button();
			this.callAreaUpdatebtn = new System.Windows.Forms.Button();
			this.callAreaAddbtn = new System.Windows.Forms.Button();
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
			this.callAreadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.callAreadataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.callArea});
			this.callAreadataGridView.Location = new System.Drawing.Point(-4, 0);
			this.callAreadataGridView.Name = "callAreadataGridView";
			this.callAreadataGridView.RowTemplate.Height = 23;
			this.callAreadataGridView.Size = new System.Drawing.Size(345, 554);
			this.callAreadataGridView.TabIndex = 13;
			// 
			// callArea
			// 
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
			this.callNumdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.callNumdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.callNum,
            this.callAreaf,
            this.user});
			this.callNumdataGridView.Location = new System.Drawing.Point(0, 0);
			this.callNumdataGridView.Name = "callNumdataGridView";
			this.callNumdataGridView.RowTemplate.Height = 23;
			this.callNumdataGridView.Size = new System.Drawing.Size(349, 554);
			this.callNumdataGridView.TabIndex = 14;
			// 
			// callNum
			// 
			this.callNum.HeaderText = "呼叫器编号";
			this.callNum.Name = "callNum";
			// 
			// callAreaf
			// 
			this.callAreaf.HeaderText = "呼叫区域";
			this.callAreaf.Name = "callAreaf";
			// 
			// user
			// 
			this.user.HeaderText = "服务员";
			this.user.Name = "user";
			// 
			// callAreaclearDatabtn
			// 
			this.callAreaclearDatabtn.Location = new System.Drawing.Point(415, 354);
			this.callAreaclearDatabtn.Name = "callAreaclearDatabtn";
			this.callAreaclearDatabtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaclearDatabtn.TabIndex = 23;
			this.callAreaclearDatabtn.Text = "清除数据";
			this.callAreaclearDatabtn.UseVisualStyleBackColor = true;
			// 
			// callAreaOKbtn
			// 
			this.callAreaOKbtn.Location = new System.Drawing.Point(415, 281);
			this.callAreaOKbtn.Name = "callAreaOKbtn";
			this.callAreaOKbtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaOKbtn.TabIndex = 22;
			this.callAreaOKbtn.Text = "确定";
			this.callAreaOKbtn.UseVisualStyleBackColor = true;
			// 
			// callAreaDeletebtn
			// 
			this.callAreaDeletebtn.Location = new System.Drawing.Point(415, 214);
			this.callAreaDeletebtn.Name = "callAreaDeletebtn";
			this.callAreaDeletebtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaDeletebtn.TabIndex = 21;
			this.callAreaDeletebtn.Text = "删除";
			this.callAreaDeletebtn.UseVisualStyleBackColor = true;
			// 
			// callAreaUpdatebtn
			// 
			this.callAreaUpdatebtn.Location = new System.Drawing.Point(415, 153);
			this.callAreaUpdatebtn.Name = "callAreaUpdatebtn";
			this.callAreaUpdatebtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaUpdatebtn.TabIndex = 20;
			this.callAreaUpdatebtn.Text = "修改";
			this.callAreaUpdatebtn.UseVisualStyleBackColor = true;
			// 
			// callAreaAddbtn
			// 
			this.callAreaAddbtn.Location = new System.Drawing.Point(415, 96);
			this.callAreaAddbtn.Name = "callAreaAddbtn";
			this.callAreaAddbtn.Size = new System.Drawing.Size(75, 23);
			this.callAreaAddbtn.TabIndex = 19;
			this.callAreaAddbtn.Text = "添加";
			this.callAreaAddbtn.UseVisualStyleBackColor = true;
			// 
			// settingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(540, 592);
			this.Controls.Add(this.callAreaclearDatabtn);
			this.Controls.Add(this.callAreaOKbtn);
			this.Controls.Add(this.callAreaDeletebtn);
			this.Controls.Add(this.callAreaUpdatebtn);
			this.Controls.Add(this.callAreaAddbtn);
			this.Controls.Add(this.callAreatabControl);
			this.Name = "settingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "呼叫器设置";
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
		private System.Windows.Forms.DataGridViewTextBoxColumn callNum;
		private System.Windows.Forms.DataGridViewTextBoxColumn callAreaf;
		private System.Windows.Forms.DataGridViewTextBoxColumn user;
		private System.Windows.Forms.Button callAreaAddbtn;
		private System.Windows.Forms.Button callAreaUpdatebtn;
		private System.Windows.Forms.Button callAreaDeletebtn;
		private System.Windows.Forms.Button callAreaOKbtn;
		private System.Windows.Forms.Button callAreaclearDatabtn;
		private System.Windows.Forms.DataGridViewTextBoxColumn callArea;
	}
}