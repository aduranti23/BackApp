using Ookii.Dialogs.WinForms;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackApp
{
    public partial class scheduleTool : Form
    {
        Procedures procedures = new Procedures();
        public scheduleTool()
        {
            InitializeComponent();
        }

        private void sourceDir_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog browser = new VistaFolderBrowserDialog();
            browser.Description = "Select source folder...";
            browser.UseDescriptionForTitle = true;
            if (browser.ShowDialog() == DialogResult.OK)
            {
                sourceBox.Text = browser.SelectedPath;
            }
        }

        private void outDir_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog browser = new VistaFolderBrowserDialog();
            browser.Description = "Select output folder...";
            browser.UseDescriptionForTitle = true;
            if (browser.ShowDialog() == DialogResult.OK)
            {
                outBox.Text = browser.SelectedPath;
            }
        }
        private void createSchedule_Click(object sender, EventArgs e)
        {
            Boolean isOK = false;
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "BackApp schedule";
                if (!String.IsNullOrEmpty(sourceBox.Text))
                {
                    if (!String.IsNullOrEmpty(outBox.Text))
                    {
                        if (!String.IsNullOrEmpty(periodPicker.Text))
                        {
                            switch (periodPicker.Text)
                            {
                                case "Every day":
                                    isOK = procedures.dailySchedule(dateTimePicker, 1, td);
                                    break;
                                case "Every week":
                                    isOK = procedures.weeklySchedule(dateTimePicker, 1, daysPicker, td);
                                    break;
                                case "Every month":
                                    isOK = procedures.monthlySchedule(dateTimePicker, monthDaysBox, td);
                                    break;
                                case "Custom":
                                    switch (customPeriodPicker.Text)
                                    {
                                        case "days":
                                            isOK = procedures.dailySchedule(dateTimePicker, short.Parse(customTimesBox.Text), td);
                                            break;
                                        case "weeks":
                                            isOK = procedures.weeklySchedule(dateTimePicker, short.Parse(customTimesBox.Text), daysPicker, td);
                                            break;
                                    }
                                    break;
                            }
                            if (isOK)
                            {
                                string scheduleArgs = "nogui";
                                if (chkIsRecursive.Checked)
                                {
                                    scheduleArgs = String.Join(' ', scheduleArgs, "rec");
                                }
                                scheduleArgs = String.Join(' ', scheduleArgs, String.Concat("s::", sourceBox.Text), String.Concat("o::", outBox.Text));
                                td.Actions.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BackApp.exe"), scheduleArgs);
                                ts.RootFolder.RegisterTaskDefinition(String.Concat("BackApp Schedule_", DateTime.Now.ToString("yyyyMMddHHmmssff")), td);
                                MessageBox.Show("Backup succesfully scheduled!");
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select a period!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must choose an out directory");
                    }
                }
                else
                {
                    MessageBox.Show("You must choose a source directory");
                }
            }
        }
        private void periodPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (periodPicker.Text)
            {
                case "Every month":
                    daysPicker.Enabled = false;
                    customPeriodPicker.Enabled = false;
                    customTimesBox.Enabled = false;
                    monthDaysBox.Enabled = true;
                    break;
                case "Every week":
                    daysPicker.Enabled = true;
                    customPeriodPicker.Enabled = false;
                    customTimesBox.Enabled = false;
                    monthDaysBox.Enabled = false;
                    break;
                case "Every day":
                    daysPicker.Enabled = false;
                    customPeriodPicker.Enabled = false;
                    customTimesBox.Enabled = false;
                    monthDaysBox.Enabled = false;
                    break;
                case "Custom":
                    customPeriodPicker.Enabled = true;
                    customTimesBox.Enabled = true;
                    monthDaysBox.Enabled = false;
                    if (customPeriodPicker.Text.Equals("days") || String.IsNullOrEmpty(customPeriodPicker.Text))
                    {
                        daysPicker.Enabled = false;
                        monthDaysBox.Enabled = false;
                    }
                    else if(customPeriodPicker.Text.Equals("weeks"))
                    {
                        daysPicker.Enabled = true;
                        monthDaysBox.Enabled = false;
                    }
                    break;
            }
        }
        private void customPeriodPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (customPeriodPicker.Text)
            {
                case "days":
                    daysPicker.Enabled = false;
                    monthDaysBox.Enabled = false;
                    break;
                case "weeks":
                    daysPicker.Enabled = true;
                    monthDaysBox.Enabled = false;
                    break;
                case "months":
                    daysPicker.Enabled = false;
                    monthDaysBox.Enabled = true;
                    break;
            }
        }
    }
}
