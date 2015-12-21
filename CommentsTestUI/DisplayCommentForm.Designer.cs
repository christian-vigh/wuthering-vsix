namespace CommentsTestUI
{
	partial class DisplayCommentForm
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.CloseButton = new System.Windows.Forms.Button();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.Category = new System.Windows.Forms.ComboBox();
			this.Filename = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.CommentText = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.CloseButton);
			this.panel1.Controls.Add(this.RefreshButton);
			this.panel1.Controls.Add(this.Category);
			this.panel1.Controls.Add(this.Filename);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(902, 31);
			this.panel1.TabIndex = 0;
			// 
			// CloseButton
			// 
			this.CloseButton.Location = new System.Drawing.Point(589, 3);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 5;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// RefreshButton
			// 
			this.RefreshButton.Location = new System.Drawing.Point(511, 3);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(75, 23);
			this.RefreshButton.TabIndex = 4;
			this.RefreshButton.Text = "Refresh";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// Category
			// 
			this.Category.FormattingEnabled = true;
			this.Category.Items.AddRange(new object[] {
            "block",
            "class",
            "function",
            "header",
            "method",
            "standard"});
			this.Category.Location = new System.Drawing.Point(359, 5);
			this.Category.Name = "Category";
			this.Category.Size = new System.Drawing.Size(121, 21);
			this.Category.TabIndex = 3;
			// 
			// Filename
			// 
			this.Filename.Location = new System.Drawing.Point(71, 6);
			this.Filename.Name = "Filename";
			this.Filename.Size = new System.Drawing.Size(176, 20);
			this.Filename.TabIndex = 2;
			this.Filename.Text = "c:\\path\\filename.php";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(272, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Comment type :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Filename :";
			// 
			// CommentText
			// 
			this.CommentText.BackColor = System.Drawing.Color.White;
			this.CommentText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CommentText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CommentText.Location = new System.Drawing.Point(0, 31);
			this.CommentText.Multiline = true;
			this.CommentText.Name = "CommentText";
			this.CommentText.ReadOnly = true;
			this.CommentText.Size = new System.Drawing.Size(902, 350);
			this.CommentText.TabIndex = 1;
			// 
			// DisplayCommentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(902, 381);
			this.Controls.Add(this.CommentText);
			this.Controls.Add(this.panel1);
			this.Name = "DisplayCommentForm";
			this.Text = "Comment test form";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System. Windows. Forms. Panel panel1;
		private System. Windows. Forms. ComboBox Category;
		private System. Windows. Forms. TextBox Filename;
		private System. Windows. Forms. Label label2;
		private System. Windows. Forms. Label label1;
		private System. Windows. Forms. Button RefreshButton;
		private System. Windows. Forms. Button CloseButton;
		private System. Windows. Forms. TextBox CommentText;

	}
}