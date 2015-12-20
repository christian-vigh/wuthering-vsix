namespace Wuthering. WutheringComments
{
	partial class WutheringCommentsErrorList
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System. ComponentModel. IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components. Dispose ( );
			}
			base. Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WutheringCommentsErrorList));
			this.ErrorList = new System.Windows.Forms.ListView();
			this.Step = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Severity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.BottomPanel = new System.Windows.Forms.Panel();
			this.CloseButton = new System.Windows.Forms.Button();
			this.BottomPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ErrorList
			// 
			this.ErrorList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Step,
            this.Severity,
            this.Line,
            this.Column,
            this.Source,
            this.Message});
			this.ErrorList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ErrorList.Location = new System.Drawing.Point(0, 0);
			this.ErrorList.MultiSelect = false;
			this.ErrorList.Name = "ErrorList";
			this.ErrorList.Size = new System.Drawing.Size(877, 262);
			this.ErrorList.TabIndex = 1;
			this.ErrorList.UseCompatibleStateImageBehavior = false;
			this.ErrorList.View = System.Windows.Forms.View.Details;
			// 
			// Step
			// 
			this.Step.Text = "Step";
			this.Step.Width = 88;
			// 
			// Severity
			// 
			this.Severity.Text = "Severity";
			this.Severity.Width = 107;
			// 
			// Line
			// 
			this.Line.Text = "Ln";
			this.Line.Width = 34;
			// 
			// Column
			// 
			this.Column.Text = "Col";
			this.Column.Width = 35;
			// 
			// Source
			// 
			this.Source.Text = "Source";
			this.Source.Width = 127;
			// 
			// Message
			// 
			this.Message.Text = "Message";
			this.Message.Width = 536;
			// 
			// BottomPanel
			// 
			this.BottomPanel.Controls.Add(this.CloseButton);
			this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.BottomPanel.Location = new System.Drawing.Point(0, 224);
			this.BottomPanel.Name = "BottomPanel";
			this.BottomPanel.Size = new System.Drawing.Size(877, 38);
			this.BottomPanel.TabIndex = 2;
			// 
			// CloseButton
			// 
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseButton.Location = new System.Drawing.Point(795, 8);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 0;
			this.CloseButton.Text = "&Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.Close_Click);
			// 
			// WutheringCommentsErrorList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(877, 262);
			this.Controls.Add(this.BottomPanel);
			this.Controls.Add(this.ErrorList);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WutheringCommentsErrorList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Xml validation errors";
			this.BottomPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		internal System. Windows. Forms. ListView ErrorList;
		private System. Windows. Forms. ColumnHeader Step;
		private System. Windows. Forms. ColumnHeader Severity;
		private System. Windows. Forms. ColumnHeader Line;
		private System. Windows. Forms. ColumnHeader Column;
		private System. Windows. Forms. ColumnHeader Source;
		private System. Windows. Forms. ColumnHeader Message;
		private System. Windows. Forms. Panel BottomPanel;
		private System. Windows. Forms. Button CloseButton;
	}
}