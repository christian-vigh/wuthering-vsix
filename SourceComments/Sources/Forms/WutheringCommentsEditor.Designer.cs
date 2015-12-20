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
			this.ConfigurationEditor = new ScintillaNET.Scintilla();
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.SBPosition = new System.Windows.Forms.ToolStripStatusLabel();
			this.SBSize = new System.Windows.Forms.ToolStripStatusLabel();
			this.SBLineCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.SBModified = new System.Windows.Forms.ToolStripStatusLabel();
			this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.Images = new System.Windows.Forms.ImageList(this.components);
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
			this.ValidateButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ValidateButton.BackgroundImage")));
			this.ValidateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ValidateButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.ValidateButton.ImageKey = "validate.png";
			this.ValidateButton.Location = new System.Drawing.Point(0, 0);
			this.ValidateButton.Name = "ValidateButton";
			this.ValidateButton.Size = new System.Drawing.Size(34, 34);
			this.ValidateButton.TabIndex = 1;
			this.Tooltip.SetToolTip(this.ValidateButton, "Validates the current comment definitions");
			this.ValidateButton.UseVisualStyleBackColor = true;
			this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
			// 
			// CloseButton
			// 
			this.CloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.BackgroundImage")));
			this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.CloseButton.Location = new System.Drawing.Point(992, 0);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(34, 34);
			this.CloseButton.TabIndex = 3;
			this.Tooltip.SetToolTip(this.CloseButton, "Closes the editor\r\n");
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.BackgroundImage")));
			this.SaveButton.Location = new System.Drawing.Point(33, 0);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(34, 34);
			this.SaveButton.TabIndex = 2;
			this.Tooltip.SetToolTip(this.SaveButton, "Saves current content");
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// ContentPanel
			// 
			this.ContentPanel.Controls.Add(this.ConfigurationEditor);
			this.ContentPanel.Controls.Add(this.StatusBar);
			this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ContentPanel.Location = new System.Drawing.Point(0, 34);
			this.ContentPanel.Name = "ContentPanel";
			this.ContentPanel.Size = new System.Drawing.Size(1026, 399);
			this.ContentPanel.TabIndex = 2;
			// 
			// ConfigurationEditor
			// 
			this.ConfigurationEditor.CaretLineBackColor = System.Drawing.Color.MistyRose;
			this.ConfigurationEditor.CaretLineVisible = true;
			this.ConfigurationEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConfigurationEditor.Lexer = ScintillaNET.Lexer.Xml;
			this.ConfigurationEditor.Location = new System.Drawing.Point(0, 0);
			this.ConfigurationEditor.Name = "ConfigurationEditor";
			this.ConfigurationEditor.Size = new System.Drawing.Size(1026, 375);
			this.ConfigurationEditor.TabIndex = 3;
			this.ConfigurationEditor.TabWidth = 8;
			this.ConfigurationEditor.UseTabs = false;
			this.ConfigurationEditor.Delete += new System.EventHandler<ScintillaNET.ModificationEventArgs>(this.ConfigurationEditor_Delete);
			this.ConfigurationEditor.Insert += new System.EventHandler<ScintillaNET.ModificationEventArgs>(this.ConfigurationEditor_Insert);
			this.ConfigurationEditor.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.ConfigurationEditor_UpdateUI);
			// 
			// StatusBar
			// 
			this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.SBPosition,
            this.SBSize,
            this.SBLineCount,
            this.SBModified});
			this.StatusBar.Location = new System.Drawing.Point(0, 375);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(1026, 24);
			this.StatusBar.TabIndex = 2;
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(755, 19);
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
			// SBModified
			// 
			this.SBModified.AutoSize = false;
			this.SBModified.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.SBModified.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.SBModified.Name = "SBModified";
			this.SBModified.Size = new System.Drawing.Size(16, 19);
			// 
			// Images
			// 
			this.Images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Images.ImageStream")));
			this.Images.TransparentColor = System.Drawing.Color.Transparent;
			this.Images.Images.SetKeyName(0, "close.png");
			this.Images.Images.SetKeyName(1, "save.png");
			this.Images.Images.SetKeyName(2, "validate.png");
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
		private System. Windows. Forms. Button ValidateButton;
		private System. Windows. Forms. ToolTip Tooltip;
		private System. Windows. Forms. StatusStrip StatusBar;
		private System. Windows. Forms. ToolStripStatusLabel SBLineCount;
		private System. Windows. Forms. ToolStripStatusLabel toolStripStatusLabel1;
		private System. Windows. Forms. ToolStripStatusLabel SBPosition;
		private System. Windows. Forms. ToolStripStatusLabel SBSize;
		private ScintillaNET. Scintilla ConfigurationEditor;
		private System. Windows. Forms. ToolStripStatusLabel SBModified;
		private System. Windows. Forms. ImageList Images;
	}
}