namespace szwlFormsApplication
{
	partial class tableSettingsForm
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "呼叫信息"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "员工信息"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
			this.choosegroupBox = new System.Windows.Forms.GroupBox();
			this.tablelistView = new System.Windows.Forms.ListView();
			this.columnSetgroupBox = new System.Windows.Forms.GroupBox();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.oldheader = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.newheader = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.listView1 = new System.Windows.Forms.ListView();
			this.button1 = new System.Windows.Forms.Button();
			this.choosegroupBox.SuspendLayout();
			this.columnSetgroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// choosegroupBox
			// 
			this.choosegroupBox.Controls.Add(this.tablelistView);
			this.choosegroupBox.Location = new System.Drawing.Point(2, 12);
			this.choosegroupBox.Name = "choosegroupBox";
			this.choosegroupBox.Size = new System.Drawing.Size(225, 680);
			this.choosegroupBox.TabIndex = 0;
			this.choosegroupBox.TabStop = false;
			this.choosegroupBox.Text = "选择表";
			// 
			// tablelistView
			// 
			this.tablelistView.Dock = System.Windows.Forms.DockStyle.Fill;
			listViewItem1.ToolTipText = "呼叫信息";
			listViewItem2.ToolTipText = "员工信息";
			this.tablelistView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
			this.tablelistView.Location = new System.Drawing.Point(3, 17);
			this.tablelistView.Name = "tablelistView";
			this.tablelistView.Size = new System.Drawing.Size(219, 660);
			this.tablelistView.TabIndex = 0;
			this.tablelistView.UseCompatibleStateImageBehavior = false;
			this.tablelistView.View = System.Windows.Forms.View.Tile;
			this.tablelistView.SelectedIndexChanged += new System.EventHandler(this.tablelistView_SelectedIndexChanged);
			// 
			// columnSetgroupBox
			// 
			this.columnSetgroupBox.Controls.Add(this.dataGridView);
			this.columnSetgroupBox.Controls.Add(this.listView1);
			this.columnSetgroupBox.Location = new System.Drawing.Point(233, 12);
			this.columnSetgroupBox.Name = "columnSetgroupBox";
			this.columnSetgroupBox.Size = new System.Drawing.Size(503, 615);
			this.columnSetgroupBox.TabIndex = 1;
			this.columnSetgroupBox.TabStop = false;
			this.columnSetgroupBox.Text = "列别名设置";
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oldheader,
            this.newheader});
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGridView.Location = new System.Drawing.Point(3, 17);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowTemplate.Height = 23;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView.Size = new System.Drawing.Size(497, 196);
			this.dataGridView.TabIndex = 2;
			// 
			// oldheader
			// 
			this.oldheader.DataPropertyName = "oldheader";
			this.oldheader.HeaderText = "原列名";
			this.oldheader.Name = "oldheader";
			this.oldheader.ReadOnly = true;
			this.oldheader.ToolTipText = "原列名";
			// 
			// newheader
			// 
			this.newheader.DataPropertyName = "newheader";
			this.newheader.HeaderText = "新列名";
			this.newheader.Name = "newheader";
			this.newheader.ToolTipText = "新列名";
			// 
			// listView1
			// 
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Location = new System.Drawing.Point(3, 17);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(497, 595);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(627, 647);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(106, 34);
			this.button1.TabIndex = 2;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tableSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(767, 693);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.columnSetgroupBox);
			this.Controls.Add(this.choosegroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "tableSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "表头设置";
			this.choosegroupBox.ResumeLayout(false);
			this.columnSetgroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox choosegroupBox;
		private System.Windows.Forms.GroupBox columnSetgroupBox;
		private System.Windows.Forms.ListView tablelistView;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridViewTextBoxColumn newheader;
		private System.Windows.Forms.DataGridViewTextBoxColumn oldheader;
	}
}