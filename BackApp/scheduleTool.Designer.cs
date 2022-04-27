namespace BackApp
{
    partial class scheduleTool
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
            System.Windows.Forms.Label label1;
            this.periodPicker = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sourceBox = new System.Windows.Forms.TextBox();
            this.outBox = new System.Windows.Forms.TextBox();
            this.createSchedule = new System.Windows.Forms.Button();
            this.sourceDir = new System.Windows.Forms.Button();
            this.outDir = new System.Windows.Forms.Button();
            this.chkIsRecursive = new System.Windows.Forms.CheckBox();
            this.daysPicker = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.customPeriodPicker = new System.Windows.Forms.ComboBox();
            this.customTimesBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.monthDaysBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(30, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(119, 15);
            label1.TabIndex = 0;
            label1.Text = "Schedule this backup";
            // 
            // periodPicker
            // 
            this.periodPicker.FormattingEnabled = true;
            this.periodPicker.Items.AddRange(new object[] {
            "Every day",
            "Every week",
            "Every month",
            "Custom"});
            this.periodPicker.Location = new System.Drawing.Point(30, 31);
            this.periodPicker.Name = "periodPicker";
            this.periodPicker.Size = new System.Drawing.Size(121, 23);
            this.periodPicker.TabIndex = 1;
            this.periodPicker.SelectedIndexChanged += new System.EventHandler(this.periodPicker_SelectedIndexChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "HH:mm";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(30, 76);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(75, 23);
            this.dateTimePicker.TabIndex = 2;
            this.dateTimePicker.Value = new System.DateTime(2022, 4, 25, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "at";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Source:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Output:";
            // 
            // sourceBox
            // 
            this.sourceBox.Location = new System.Drawing.Point(96, 192);
            this.sourceBox.Name = "sourceBox";
            this.sourceBox.Size = new System.Drawing.Size(267, 23);
            this.sourceBox.TabIndex = 6;
            // 
            // outBox
            // 
            this.outBox.Location = new System.Drawing.Point(96, 229);
            this.outBox.Name = "outBox";
            this.outBox.Size = new System.Drawing.Size(267, 23);
            this.outBox.TabIndex = 7;
            // 
            // createSchedule
            // 
            this.createSchedule.Location = new System.Drawing.Point(162, 312);
            this.createSchedule.Name = "createSchedule";
            this.createSchedule.Size = new System.Drawing.Size(191, 46);
            this.createSchedule.TabIndex = 8;
            this.createSchedule.Text = "Create schedule";
            this.createSchedule.UseVisualStyleBackColor = true;
            this.createSchedule.Click += new System.EventHandler(this.createSchedule_Click);
            // 
            // sourceDir
            // 
            this.sourceDir.Location = new System.Drawing.Point(369, 192);
            this.sourceDir.Name = "sourceDir";
            this.sourceDir.Size = new System.Drawing.Size(106, 23);
            this.sourceDir.TabIndex = 9;
            this.sourceDir.Text = "Choose folder...";
            this.sourceDir.UseVisualStyleBackColor = true;
            this.sourceDir.Click += new System.EventHandler(this.sourceDir_Click);
            // 
            // outDir
            // 
            this.outDir.Location = new System.Drawing.Point(369, 228);
            this.outDir.Name = "outDir";
            this.outDir.Size = new System.Drawing.Size(106, 23);
            this.outDir.TabIndex = 10;
            this.outDir.Text = "Choose folder...";
            this.outDir.UseVisualStyleBackColor = true;
            this.outDir.Click += new System.EventHandler(this.outDir_Click);
            // 
            // chkIsRecursive
            // 
            this.chkIsRecursive.AutoSize = true;
            this.chkIsRecursive.Location = new System.Drawing.Point(49, 271);
            this.chkIsRecursive.Name = "chkIsRecursive";
            this.chkIsRecursive.Size = new System.Drawing.Size(151, 19);
            this.chkIsRecursive.TabIndex = 11;
            this.chkIsRecursive.Text = "Check all subdirectories";
            this.chkIsRecursive.UseVisualStyleBackColor = true;
            // 
            // daysPicker
            // 
            this.daysPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.daysPicker.CheckOnClick = true;
            this.daysPicker.Enabled = false;
            this.daysPicker.FormattingEnabled = true;
            this.daysPicker.HorizontalScrollbar = true;
            this.daysPicker.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.daysPicker.Location = new System.Drawing.Point(186, 31);
            this.daysPicker.MultiColumn = true;
            this.daysPicker.Name = "daysPicker";
            this.daysPicker.Size = new System.Drawing.Size(324, 76);
            this.daysPicker.TabIndex = 12;
            this.daysPicker.UseTabStops = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Days:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Every";
            // 
            // customPeriodPicker
            // 
            this.customPeriodPicker.Enabled = false;
            this.customPeriodPicker.FormattingEnabled = true;
            this.customPeriodPicker.Items.AddRange(new object[] {
            "days",
            "weeks"});
            this.customPeriodPicker.Location = new System.Drawing.Point(389, 153);
            this.customPeriodPicker.Name = "customPeriodPicker";
            this.customPeriodPicker.Size = new System.Drawing.Size(121, 23);
            this.customPeriodPicker.TabIndex = 16;
            this.customPeriodPicker.SelectedIndexChanged += new System.EventHandler(this.customPeriodPicker_SelectedIndexChanged);
            // 
            // customTimesBox
            // 
            this.customTimesBox.Enabled = false;
            this.customTimesBox.Location = new System.Drawing.Point(290, 153);
            this.customTimesBox.Name = "customTimesBox";
            this.customTimesBox.Size = new System.Drawing.Size(73, 23);
            this.customTimesBox.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Days of the month (ex. 1;2;3...)";
            // 
            // monthDaysBox
            // 
            this.monthDaysBox.Enabled = false;
            this.monthDaysBox.Location = new System.Drawing.Point(360, 118);
            this.monthDaysBox.Name = "monthDaysBox";
            this.monthDaysBox.Size = new System.Drawing.Size(150, 23);
            this.monthDaysBox.TabIndex = 19;
            // 
            // scheduleTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 409);
            this.Controls.Add(this.monthDaysBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.customTimesBox);
            this.Controls.Add(this.customPeriodPicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.daysPicker);
            this.Controls.Add(this.chkIsRecursive);
            this.Controls.Add(this.outDir);
            this.Controls.Add(this.sourceDir);
            this.Controls.Add(this.createSchedule);
            this.Controls.Add(this.outBox);
            this.Controls.Add(this.sourceBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.periodPicker);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "scheduleTool";
            this.Text = "BackApp scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox periodPicker;
        private DateTimePicker dateTimePicker;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox sourceBox;
        private TextBox outBox;
        private Button createSchedule;
        private Button sourceDir;
        private Button outDir;
        private CheckBox chkIsRecursive;
        private CheckedListBox daysPicker;
        private Label label5;
        private Label label6;
        private ComboBox customPeriodPicker;
        private TextBox customTimesBox;
        private Label label7;
        private TextBox monthDaysBox;
    }
}