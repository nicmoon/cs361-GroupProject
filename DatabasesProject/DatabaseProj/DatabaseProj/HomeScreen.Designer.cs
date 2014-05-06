namespace DatabaseProj
{
    partial class HomeScreen
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiStudent = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiAddCriteria = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiAddAssessmentItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(879, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStudent,
            this.tsmiAddCriteria,
            this.tsmiAddAssessmentItem});
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.addToolStripMenuItem.Text = "&Add";
			// 
			// tsmiStudent
			// 
			this.tsmiStudent.Name = "tsmiStudent";
			this.tsmiStudent.Size = new System.Drawing.Size(152, 22);
			this.tsmiStudent.Text = "&Student";
			this.tsmiStudent.Click += new System.EventHandler(this.tsmiStudent_Click);
			// 
			// tsmiAddCriteria
			// 
			this.tsmiAddCriteria.Name = "tsmiAddCriteria";
			this.tsmiAddCriteria.Size = new System.Drawing.Size(152, 22);
			this.tsmiAddCriteria.Text = "&Criteria";
			this.tsmiAddCriteria.Click += new System.EventHandler(this.tsmiAddCriteria_Click);
			// 
			// tsmiAddAssessmentItem
			// 
			this.tsmiAddAssessmentItem.Name = "tsmiAddAssessmentItem";
			this.tsmiAddAssessmentItem.Size = new System.Drawing.Size(158, 22);
			this.tsmiAddAssessmentItem.Text = "&Assesment Item";
			this.tsmiAddAssessmentItem.Click += new System.EventHandler(this.tsmiAddAssessmentItem_Click);
			// 
			// HomeScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(879, 574);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "HomeScreen";
			this.Text = "HomeScreen";
			this.Load += new System.EventHandler(this.HomeScreen_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tsmiStudent;
		private System.Windows.Forms.ToolStripMenuItem tsmiAddCriteria;
		private System.Windows.Forms.ToolStripMenuItem tsmiAddAssessmentItem;

    }
}