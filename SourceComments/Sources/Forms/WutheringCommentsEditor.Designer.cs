namespace Wuthering. WutheringComments
{
	partial class WutheringCommentsEditor
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WutheringCommentsEditor));
			this.TopButtonPanel = new System.Windows.Forms.Panel();
			this.ContentPanel = new System.Windows.Forms.Panel();
			this.LineNumbers = new System.Windows.Forms.RichTextBox();
			this.TextContents = new System.Windows.Forms.RichTextBox();
			this.CloseButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.Validate = new System.Windows.Forms.Button();
			this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.TopButtonPanel.SuspendLayout();
			this.ContentPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// TopButtonPanel
			// 
			this.TopButtonPanel.Controls.Add(this.Validate);
			this.TopButtonPanel.Controls.Add(this.CloseButton);
			this.TopButtonPanel.Controls.Add(this.SaveButton);
			this.TopButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopButtonPanel.Location = new System.Drawing.Point(0, 0);
			this.TopButtonPanel.Name = "TopButtonPanel";
			this.TopButtonPanel.Size = new System.Drawing.Size(1026, 34);
			this.TopButtonPanel.TabIndex = 1;
			// 
			// ContentPanel
			// 
			this.ContentPanel.Controls.Add(this.TextContents);
			this.ContentPanel.Controls.Add(this.LineNumbers);
			this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContentPanel.Location = new System.Drawing.Point(0, 34);
			this.ContentPanel.Name = "ContentPanel";
			this.ContentPanel.Size = new System.Drawing.Size(1026, 399);
			this.ContentPanel.TabIndex = 2;
			// 
			// LineNumbers
			// 
			this.LineNumbers.BackColor = System.Drawing.SystemColors.Menu;
			this.LineNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LineNumbers.Dock = System.Windows.Forms.DockStyle.Left;
			this.LineNumbers.Location = new System.Drawing.Point(0, 0);
			this.LineNumbers.Name = "LineNumbers";
			this.LineNumbers.ReadOnly = true;
			this.LineNumbers.Size = new System.Drawing.Size(44, 399);
			this.LineNumbers.TabIndex = 0;
			this.LineNumbers.Text = "";
			// 
			// TextContents
			// 
			this.TextContents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TextContents.Location = new System.Drawing.Point(44, 0);
			this.TextContents.Name = "TextContents";
			this.TextContents.Size = new System.Drawing.Size(982, 399);
			this.TextContents.TabIndex = 1;
			this.TextContents.Text = "";
			// 
			// CloseButton
			// 
			this.CloseButton.Location = new System.Drawing.Point(945, 6);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 3;
			this.CloseButton.Text = "&Close";
			this.Tooltip.SetToolTip(this.CloseButton, "Closes the editor\r\nA confirmation will be displayed if the contents have been cha" +
        "nged but not saved.");
			this.CloseButton.UseVisualStyleBackColor = true;
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(871, 6);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 2;
			this.SaveButton.Text = "&Save";
			this.Tooltip.SetToolTip(this.SaveButton, "Saves current content");
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// Validate
			// 
			this.Validate.Location = new System.Drawing.Point(797, 6);
			this.Validate.Name = "Validate";
			this.Validate.Size = new System.Drawing.Size(75, 23);
			this.Validate.TabIndex = 4;
			this.Validate.Text = "&Validate";
			this.Tooltip.SetToolTip(this.Validate, "Validates the current comment definitions");
			this.Validate.UseVisualStyleBackColor = true;
			// 
			// WutheringCommentsEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1026, 433);
			this.Controls.Add(this.ContentPanel);
			this.Controls.Add(this.TopButtonPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "WutheringCommentsEditor";
			this.Text = "WutheringComments file editor";
			this.TopButtonPanel.ResumeLayout(false);
			this.ContentPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System. Windows. Forms. Panel TopButtonPanel;
		private System. Windows. Forms. Panel ContentPanel;
		private System. Windows. Forms. Button CloseButton;
		private System. Windows. Forms. Button SaveButton;
		private System. Windows. Forms. RichTextBox TextContents;
		private System. Windows. Forms. RichTextBox LineNumbers;
		private System. Windows. Forms. Button Validate;
		private System. Windows. Forms. ToolTip Tooltip;
	}
}