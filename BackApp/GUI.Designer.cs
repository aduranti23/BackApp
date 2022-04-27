namespace BackApp
{
    partial class GUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.sourceBox = new System.Windows.Forms.TextBox();
            this.outBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceSelection = new System.Windows.Forms.Button();
            this.outputSelection = new System.Windows.Forms.Button();
            this.chkIsRecursive = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.scheduleTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showScheduledTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.Location = new System.Drawing.Point(268, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(324, 274);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start backup";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sourceBox
            // 
            this.sourceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceBox.Location = new System.Drawing.Point(116, 391);
            this.sourceBox.Name = "sourceBox";
            this.sourceBox.Size = new System.Drawing.Size(565, 23);
            this.sourceBox.TabIndex = 1;
            this.sourceBox.TextChanged += new System.EventHandler(this.sourceBox_TextChanged);
            // 
            // outBox
            // 
            this.outBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outBox.Location = new System.Drawing.Point(116, 420);
            this.outBox.Name = "outBox";
            this.outBox.Size = new System.Drawing.Size(565, 23);
            this.outBox.TabIndex = 2;
            this.outBox.TextChanged += new System.EventHandler(this.outBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output:";
            // 
            // sourceSelection
            // 
            this.sourceSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceSelection.Location = new System.Drawing.Point(687, 391);
            this.sourceSelection.Name = "sourceSelection";
            this.sourceSelection.Size = new System.Drawing.Size(108, 24);
            this.sourceSelection.TabIndex = 4;
            this.sourceSelection.Text = "Choose folder...";
            this.sourceSelection.UseVisualStyleBackColor = true;
            this.sourceSelection.Click += new System.EventHandler(this.sourceSelection_Click);
            // 
            // outputSelection
            // 
            this.outputSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.outputSelection.Location = new System.Drawing.Point(687, 420);
            this.outputSelection.Name = "outputSelection";
            this.outputSelection.Size = new System.Drawing.Size(108, 23);
            this.outputSelection.TabIndex = 5;
            this.outputSelection.Text = "Choose folder...";
            this.outputSelection.UseVisualStyleBackColor = true;
            this.outputSelection.Click += new System.EventHandler(this.outputSelection_Click);
            // 
            // chkIsRecursive
            // 
            this.chkIsRecursive.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkIsRecursive.AutoSize = true;
            this.chkIsRecursive.Location = new System.Drawing.Point(369, 323);
            this.chkIsRecursive.Name = "chkIsRecursive";
            this.chkIsRecursive.Size = new System.Drawing.Size(132, 19);
            this.chkIsRecursive.TabIndex = 6;
            this.chkIsRecursive.Text = "Check all subfolders";
            this.chkIsRecursive.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleTaskToolStripMenuItem,
            this.showScheduledTasksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(828, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // scheduleTaskToolStripMenuItem
            // 
            this.scheduleTaskToolStripMenuItem.Name = "scheduleTaskToolStripMenuItem";
            this.scheduleTaskToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.scheduleTaskToolStripMenuItem.Text = "Schedule task...";
            this.scheduleTaskToolStripMenuItem.Click += new System.EventHandler(this.scheduleTaskToolStripMenuItem_Click);
            // 
            // showScheduledTasksToolStripMenuItem
            // 
            this.showScheduledTasksToolStripMenuItem.Name = "showScheduledTasksToolStripMenuItem";
            this.showScheduledTasksToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.showScheduledTasksToolStripMenuItem.Text = "Show scheduled tasks";
            this.showScheduledTasksToolStripMenuItem.Click += new System.EventHandler(this.showScheduledTasksToolStripMenuItem_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 455);
            this.Controls.Add(this.chkIsRecursive);
            this.Controls.Add(this.outputSelection);
            this.Controls.Add(this.sourceSelection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outBox);
            this.Controls.Add(this.sourceBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(844, 494);
            this.Name = "GUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackApp";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox sourceBox;
        private TextBox outBox;
        private Label label1;
        private Label label2;
        private Button sourceSelection;
        private Button outputSelection;
        private CheckBox chkIsRecursive;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem scheduleTaskToolStripMenuItem;
        private ToolStripMenuItem showScheduledTasksToolStripMenuItem;
    }
}