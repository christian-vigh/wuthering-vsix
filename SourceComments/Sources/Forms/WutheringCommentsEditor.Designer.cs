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
			this.ValidateButton = new System.Windows.Forms.Button();
			this.CloseButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.ContentPanel = new System.Windows.Forms.Panel();
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.SBPosition = new System.Windows.Forms.ToolStripStatusLabel();
			this.SBSize = new System.Windows.Forms.ToolStripStatusLabel();
			this.SBLineCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.TextContents = new System.Windows.Forms.RichTextBox();
			this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.TopButtonPanel.SuspendLayout();
			this.ContentPanel.SuspendLayout();
			this.StatusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// TopButtonPanel
			// 
			this.TopButtonPanel.Controls.Add(this.ValidateButton);
			this.TopButtonPanel.Controls.Add(this.CloseButton);
			this.TopButtonPanel.Controls.Add(this.SaveButton);
			this.TopButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopButtonPanel.Location = new System.Drawing.Point(0, 0);
			this.TopButtonPanel.Name = "TopButtonPanel";
			this.TopButtonPanel.Size = new System.Drawing.Size(1026, 34);
			this.TopButtonPanel.TabIndex = 1;
			// 
			// ValidateButton
			// 
			this.ValidateButton.Location = new System.Drawing.Point(797, 6);
			this.ValidateButton.Name = "ValidateButton";
			this.ValidateButton.Size = new System.Drawing.Size(75, 23);
			this.ValidateButton.TabIndex = 1;
			this.ValidateButton.Text = "&Validate";
			this.Tooltip.SetToolTip(this.ValidateButton, "Validates the current comment definitions");
			this.ValidateButton.UseVisualStyleBackColor = true;
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
			// ContentPanel
			// 
			this.ContentPanel.Controls.Add(this.StatusBar);
			this.ContentPanel.Controls.Add(this.TextContents);
			this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContentPanel.Location = new System.Drawing.Point(0, 34);
			this.ContentPanel.Name = "ContentPanel";
			this.ContentPanel.Size = new System.Drawing.Size(1026, 399);
			this.ContentPanel.TabIndex = 2;
			// 
			// StatusBar
			// 
			this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.SBPosition,
            this.SBSize,
            this.SBLineCount});
			this.StatusBar.Location = new System.Drawing.Point(0, 375);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(1026, 24);
			this.StatusBar.TabIndex = 2;
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(771, 19);
			this.toolStripStatusLabel1.Spring = true;
			// 
			// SBPosition
			// 
			this.SBPosition.AutoSize = false;
			this.SBPosition.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.SBPosition.Name = "SBPosition";
			this.SBPosition.Size = new System.Drawing.Size(80, 19);
			this.SBPosition.Text = "position";
			// 
			// SBSize
			// 
			this.SBSize.AutoSize = false;
			this.SBSize.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
			this.SBSize.Name = "SBSize";
			this.SBSize.Size = new System.Drawing.Size(80, 19);
			this.SBSize.Text = "byte#";
			// 
			// SBLineCount
			// 
			this.SBLineCount.AutoSize = false;
			this.SBLineCount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
			this.SBLineCount.Name = "SBLineCount";
			this.SBLineCount.Size = new System.Drawing.Size(80, 19);
			this.SBLineCount.Text = "line#";
			// 
			// TextContents
			// 
			this.TextContents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TextContents.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextContents.Location = new System.Drawing.Point(0, 0);
			this.TextContents.Name = "TextContents";
			this.TextContents.Size = new System.Drawing.Size(1026, 399);
			this.TextContents.TabIndex = 0;
			this.TextContents.Text = "";
			this.TextContents.WordWrap = false;
			this.TextContents.SelectionChanged += new System.EventHandler(this.TextContents_SelectionChanged);
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
			this.ShowInTaskbar = false;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WutheringCommentsEditor_FormClosing);
			this.Load += new System.EventHandler(this.WutheringCommentsEditor_Load);
			this.Shown += new System.EventHandler(this.WutheringCommentsEditor_Shown);
			this.TopButtonPanel.ResumeLayout(false);
			this.ContentPanel.ResumeLayout(false);
			this.ContentPanel.PerformLayout();
			this.StatusBar.ResumeLayout(false);
			this.StatusBar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System. Windows. Forms. Panel TopButtonPanel;
		private System. Windows. Forms. Panel ContentPanel;
		private System. Windows. Forms. Button CloseButton;
		private System. Windows. Forms. Button SaveButton;
		private System. Windows. Forms. RichTextBox TextContents;
		private System. Windows. Forms. Button ValidateButton;
		private System. Windows. Forms. ToolTip Tooltip;
		private System. Windows. Forms. StatusStrip StatusBar;
		private System. Windows. Forms. ToolStripStatusLabel SBLineCount;
		private System. Windows. Forms. ToolStripStatusLabel toolStripStatusLabel1;
		private System. Windows. Forms. ToolStripStatusLabel SBPosition;
		private System. Windows. Forms. ToolStripStatusLabel SBSize;
	}
}