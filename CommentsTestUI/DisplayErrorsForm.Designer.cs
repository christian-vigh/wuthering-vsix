namespace CommentsTestUI
{
	partial class DisplayErrorsForm
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
			this.ErrorList = new System.Windows.Forms.ListView();
			this.Step = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Severity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
			this.ErrorList.Size = new System.Drawing.Size(917, 456);
			this.ErrorList.TabIndex = 0;
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
			// DisplayErrorsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(917, 456);
			this.Controls.Add(this.ErrorList);
			this.Name = "DisplayErrorsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Validation errors have been found";
			this.ResumeLayout(false);

		}

		#endregion

		private System. Windows. Forms. ColumnHeader Step;
		private System. Windows. Forms. ColumnHeader Severity;
		private System. Windows. Forms. ColumnHeader Line;
		private System. Windows. Forms. ColumnHeader Column;
		private System. Windows. Forms. ColumnHeader Source;
		private System. Windows. Forms. ColumnHeader Message;
		internal System. Windows. Forms. ListView ErrorList;
	}
}