namespace Wuthering. WutheringCommentsPackage
{
	partial class WutheringCommentsOptionsPageUI
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WutheringCommentsOptionsPageUI));
			this.UseCustomFileCheckbox = new System.Windows.Forms.CheckBox();
			this.FilenameTextbox = new System.Windows.Forms.TextBox();
			this.FileOpenButton = new System.Windows.Forms.Button();
			this.FileOpenDialog = new System.Windows.Forms.OpenFileDialog();
			this.TooltipControl = new System.Windows.Forms.ToolTip(this.components);
			this.GenerateButton = new System.Windows.Forms.Button();
			this.EditButton = new System.Windows.Forms.Button();
			this.FileSaveDialog = new System.Windows.Forms.SaveFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.EmbracingStartIndentationTextbox = new System.Windows.Forms.TextBox();
			this.EmbracingStopIndentationTextbox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// UseCustomFileCheckbox
			// 
			this.UseCustomFileCheckbox.AutoSize = true;
			this.UseCustomFileCheckbox.Location = new System.Drawing.Point(7, 12);
			this.UseCustomFileCheckbox.Name = "UseCustomFileCheckbox";
			this.UseCustomFileCheckbox.Size = new System.Drawing.Size(104, 17);
			this.UseCustomFileCheckbox.TabIndex = 0;
			this.UseCustomFileCheckbox.Text = "Use custom file :";
			this.UseCustomFileCheckbox.UseVisualStyleBackColor = true;
			// 
			// FilenameTextbox
			// 
			this.FilenameTextbox.Location = new System.Drawing.Point(25, 29);
			this.FilenameTextbox.Name = "FilenameTextbox";
			this.FilenameTextbox.Size = new System.Drawing.Size(293, 20);
			this.FilenameTextbox.TabIndex = 1;
			// 
			// FileOpenButton
			// 
			this.FileOpenButton.Image = ((System.Drawing.Image)(resources.GetObject("FileOpenButton.Image")));
			this.FileOpenButton.Location = new System.Drawing.Point(319, 27);
			this.FileOpenButton.Name = "FileOpenButton";
			this.FileOpenButton.Size = new System.Drawing.Size(23, 23);
			this.FileOpenButton.TabIndex = 2;
			this.TooltipControl.SetToolTip(this.FileOpenButton, "Loads an existing comments definition file");
			this.FileOpenButton.UseVisualStyleBackColor = true;
			this.FileOpenButton.Click += new System.EventHandler(this.FileOpenButton_Click);
			// 
			// FileOpenDialog
			// 
			this.FileOpenDialog.Filter = "Xml files|*.xml|All files (*.*)|*.*";
			this.FileOpenDialog.SupportMultiDottedExtensions = true;
			this.FileOpenDialog.Title = "Open a custom comment definitions file";
			// 
			// GenerateButton
			// 
			this.GenerateButton.Image = ((System.Drawing.Image)(resources.GetObject("GenerateButton.Image")));
			this.GenerateButton.Location = new System.Drawing.Point(341, 27);
			this.GenerateButton.Name = "GenerateButton";
			this.GenerateButton.Size = new System.Drawing.Size(23, 23);
			this.GenerateButton.TabIndex = 3;
			this.TooltipControl.SetToolTip(this.GenerateButton, "Generates a comments definitions file from the existing stock definitions");
			this.GenerateButton.UseVisualStyleBackColor = true;
			this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
			// 
			// EditButton
			// 
			this.EditButton.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Image")));
			this.EditButton.Location = new System.Drawing.Point(363, 27);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(23, 23);
			this.EditButton.TabIndex = 4;
			this.TooltipControl.SetToolTip(this.EditButton, "Edit this comment definitions file");
			this.EditButton.UseVisualStyleBackColor = true;
			this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
			// 
			// FileSaveDialog
			// 
			this.FileSaveDialog.FileName = "Wuthering comments.xml";
			this.FileSaveDialog.Filter = "Xml files|*.xml|All files (*.*)|*.*";
			this.FileSaveDialog.SupportMultiDottedExtensions = true;
			this.FileSaveDialog.Title = "Output comment definitions file";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(118, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Embracing indentation :";
			// 
			// EmbracingStartIndentationTextbox
			// 
			this.EmbracingStartIndentationTextbox.Location = new System.Drawing.Point(126, 57);
			this.EmbracingStartIndentationTextbox.Name = "EmbracingStartIndentationTextbox";
			this.EmbracingStartIndentationTextbox.Size = new System.Drawing.Size(30, 20);
			this.EmbracingStartIndentationTextbox.TabIndex = 5;
			this.EmbracingStartIndentationTextbox.Text = "3";
			this.EmbracingStartIndentationTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// EmbracingStopIndentationTextbox
			// 
			this.EmbracingStopIndentationTextbox.Location = new System.Drawing.Point(225, 57);
			this.EmbracingStopIndentationTextbox.Name = "EmbracingStopIndentationTextbox";
			this.EmbracingStopIndentationTextbox.Size = new System.Drawing.Size(33, 20);
			this.EmbracingStopIndentationTextbox.TabIndex = 6;
			this.EmbracingStopIndentationTextbox.Text = "4";
			this.EmbracingStopIndentationTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(158, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "(opening)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(260, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "(ending)";
			// 
			// WutheringCommentsOptionsPageUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.EmbracingStopIndentationTextbox);
			this.Controls.Add(this.EmbracingStartIndentationTextbox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.GenerateButton);
			this.Controls.Add(this.FileOpenButton);
			this.Controls.Add(this.FilenameTextbox);
			this.Controls.Add(this.UseCustomFileCheckbox);
			this.Name = "WutheringCommentsOptionsPageUI";
			this.Size = new System.Drawing.Size(394, 236);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System. Windows. Forms. Button FileOpenButton;
		private System. Windows. Forms. OpenFileDialog FileOpenDialog;
		private System. Windows. Forms. ToolTip TooltipControl;
		private System. Windows. Forms. Button GenerateButton;
		private System. Windows. Forms. SaveFileDialog FileSaveDialog;
		private System. Windows. Forms. Button EditButton;
		private System. Windows. Forms. Label label1;
		private System. Windows. Forms. Label label2;
		private System. Windows. Forms. Label label3;
		internal System. Windows. Forms. CheckBox UseCustomFileCheckbox;
		internal System. Windows. Forms. TextBox FilenameTextbox;
		internal System. Windows. Forms. TextBox EmbracingStartIndentationTextbox;
		internal System. Windows. Forms. TextBox EmbracingStopIndentationTextbox;

	}
}
