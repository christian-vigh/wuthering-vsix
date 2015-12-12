namespace CommentsTestUI
{
	partial class TestUI
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
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.InputXml = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.CheckInputButton = new System.Windows.Forms.Button();
			this.GenerateButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.OutputXml = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.CheckOutputButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// Splitter
			// 
			this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Splitter.Location = new System.Drawing.Point(0, 0);
			this.Splitter.Name = "Splitter";
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.AutoScroll = true;
			this.Splitter.Panel1.Controls.Add(this.panel2);
			this.Splitter.Panel1.Controls.Add(this.panel1);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.AutoScroll = true;
			this.Splitter.Panel2.Controls.Add(this.panel4);
			this.Splitter.Panel2.Controls.Add(this.panel3);
			this.Splitter.Size = new System.Drawing.Size(765, 434);
			this.Splitter.SplitterDistance = 405;
			this.Splitter.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.InputXml);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(405, 410);
			this.panel2.TabIndex = 4;
			// 
			// InputXml
			// 
			this.InputXml.AcceptsReturn = true;
			this.InputXml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InputXml.Location = new System.Drawing.Point(0, 0);
			this.InputXml.Multiline = true;
			this.InputXml.Name = "InputXml";
			this.InputXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.InputXml.Size = new System.Drawing.Size(405, 410);
			this.InputXml.TabIndex = 3;
			this.InputXml.Text = "sample input text";
			this.InputXml.WordWrap = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.CheckInputButton);
			this.panel1.Controls.Add(this.GenerateButton);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(405, 24);
			this.panel1.TabIndex = 3;
			// 
			// CheckInputButton
			// 
			this.CheckInputButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.CheckInputButton.Location = new System.Drawing.Point(255, 0);
			this.CheckInputButton.Name = "CheckInputButton";
			this.CheckInputButton.Size = new System.Drawing.Size(75, 24);
			this.CheckInputButton.TabIndex = 2;
			this.CheckInputButton.Text = "&Check";
			this.CheckInputButton.UseVisualStyleBackColor = true;
			this.CheckInputButton.Click += new System.EventHandler(this.CheckInputButton_Click);
			// 
			// GenerateButton
			// 
			this.GenerateButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.GenerateButton.Location = new System.Drawing.Point(330, 0);
			this.GenerateButton.Name = "GenerateButton";
			this.GenerateButton.Size = new System.Drawing.Size(75, 24);
			this.GenerateButton.TabIndex = 1;
			this.GenerateButton.Text = "&Generate";
			this.GenerateButton.UseVisualStyleBackColor = true;
			this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Input Xml :";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.OutputXml);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 24);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(356, 410);
			this.panel4.TabIndex = 5;
			// 
			// OutputXml
			// 
			this.OutputXml.AcceptsReturn = true;
			this.OutputXml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OutputXml.Location = new System.Drawing.Point(0, 0);
			this.OutputXml.Multiline = true;
			this.OutputXml.Name = "OutputXml";
			this.OutputXml.ReadOnly = true;
			this.OutputXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.OutputXml.Size = new System.Drawing.Size(356, 410);
			this.OutputXml.TabIndex = 4;
			this.OutputXml.Text = "sample output text";
			this.OutputXml.WordWrap = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.CheckOutputButton);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(356, 24);
			this.panel3.TabIndex = 4;
			// 
			// CheckOutputButton
			// 
			this.CheckOutputButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.CheckOutputButton.Location = new System.Drawing.Point(281, 0);
			this.CheckOutputButton.Name = "CheckOutputButton";
			this.CheckOutputButton.Size = new System.Drawing.Size(75, 24);
			this.CheckOutputButton.TabIndex = 1;
			this.CheckOutputButton.Text = "&Check";
			this.CheckOutputButton.UseVisualStyleBackColor = true;
			this.CheckOutputButton.Click += new System.EventHandler(this.CheckOutputButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 14);
			this.label2.TabIndex = 0;
			this.label2.Text = "Output Xml :";
			// 
			// TestUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(765, 434);
			this.Controls.Add(this.Splitter);
			this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "TestUI";
			this.Text = "Test UI for Wuthering Comments";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Shown += new System.EventHandler(this.TestUI_Shown);
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
			this.Splitter.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System. Windows. Forms. SplitContainer Splitter;
		private System. Windows. Forms. Panel panel2;
		private System. Windows. Forms. TextBox InputXml;
		private System. Windows. Forms. Panel panel1;
		private System. Windows. Forms. Label label1;
		private System. Windows. Forms. Panel panel4;
		private System. Windows. Forms. TextBox OutputXml;
		private System. Windows. Forms. Panel panel3;
		private System. Windows. Forms. Label label2;
		private System. Windows. Forms. Button GenerateButton;
		private System. Windows. Forms. Button CheckOutputButton;
		private System. Windows. Forms. Button CheckInputButton;

	}
}

