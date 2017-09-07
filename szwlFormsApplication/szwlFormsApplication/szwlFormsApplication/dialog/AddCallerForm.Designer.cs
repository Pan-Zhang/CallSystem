namespace szwlFormsApplication.dialog
{
	partial class AddCallerForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.callerNum = new System.Windows.Forms.TextBox();
			this.callerArea = new System.Windows.Forms.ComboBox();
			this.worker = new System.Windows.Forms.ComboBox();
			this.ensure = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(56, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "呼叫器编号:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(56, 105);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "呼叫区域:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(56, 166);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "工作人员:";
			// 
			// callerNum
			// 
			this.callerNum.Location = new System.Drawing.Point(183, 49);
			this.callerNum.Name = "callerNum";
			this.callerNum.Size = new System.Drawing.Size(225, 21);
			this.callerNum.TabIndex = 3;
			// 
			// callerArea
			// 
			this.callerArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.callerArea.FormattingEnabled = true;
			this.callerArea.Location = new System.Drawing.Point(183, 102);
			this.callerArea.Name = "callerArea";
			this.callerArea.Size = new System.Drawing.Size(225, 20);
			this.callerArea.TabIndex = 4;
			// 
			// worker
			// 
			this.worker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.worker.FormattingEnabled = true;
			this.worker.Location = new System.Drawing.Point(183, 163);
			this.worker.Name = "worker";
			this.worker.Size = new System.Drawing.Size(225, 20);
			this.worker.TabIndex = 5;
			// 
			// ensure
			// 
			this.ensure.Location = new System.Drawing.Point(170, 245);
			this.ensure.Name = "ensure";
			this.ensure.Size = new System.Drawing.Size(75, 23);
			this.ensure.TabIndex = 6;
			this.ensure.Text = "确定";
			this.ensure.UseVisualStyleBackColor = true;
			this.ensure.Click += new System.EventHandler(this.button1_Click);
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(320, 245);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 7;
			this.cancel.Text = "取消";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.button2_Click);
			// 
			// AddCallerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(483, 321);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ensure);
			this.Controls.Add(this.worker);
			this.Controls.Add(this.callerArea);
			this.Controls.Add(this.callerNum);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "AddCallerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "添加呼叫器";
			this.Load += new System.EventHandler(this.AddCallerForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox callerNum;
		private System.Windows.Forms.ComboBox callerArea;
		private System.Windows.Forms.ComboBox worker;
		private System.Windows.Forms.Button ensure;
		private System.Windows.Forms.Button cancel;
	}
}