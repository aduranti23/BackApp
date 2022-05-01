using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Win32.TaskScheduler;
using Windows.UI.Notifications;

namespace BackApp
{
    internal class Procedures
    {
        
       const string appID = "BackApp";
       public bool backupProcedure(Boolean isRecursive, String source, String output)
        {
            List<String> files = new List<String>();
            List<String> dirs = new List<String>();
            SearchOption searchOption = SearchOption.TopDirectoryOnly;
            try
            {
                String outDir = Path.Combine(output, String.Concat("BCK_", DateTime.Now.ToString("yyyyMMddHHmmssfff")));
                Directory.CreateDirectory(outDir);
                if (isRecursive)
                {
                    searchOption = SearchOption.AllDirectories;
                    dirs.Add(source);
                    dirs.AddRange(Directory.GetDirectories(source, "", searchOption).ToList());
                }
                 
                int filesNumber = Directory.GetFiles(source, "*.*", searchOption).ToList().Count;
                int currentFile = 0;
                if (dirs.Count > 0)
                {
                    foreach (String directory in dirs)
                    {
                        String outDirRec = String.Empty;
                        files = Directory.GetFiles(directory, "*.*").ToList();
                        if (!directory.Equals(source))
                        {
                            outDirRec = Path.Combine(outDir, Path.GetFileName(directory));
                            Directory.CreateDirectory(outDirRec);
                        }
                        else
                        {
                            outDirRec = outDir;
                        }
                        foreach (String file in files)
                        {
                            File.Copy(file, Path.Combine(outDirRec, Path.GetFileName(file)));
                            currentFile++;
                            double value = currentFile / filesNumber;
                            UpdateBckProcToast(value);
                        }
                    }
                }
                else
                {
                    files = Directory.GetFiles(source, "*.*").ToList();
                    foreach (String file in files)
                    {
                        File.Copy(file, Path.Combine(outDir, Path.GetFileName(file)));
                        currentFile++;
                        double value = currentFile / filesNumber;
                        UpdateBckProcToast(value);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void TextToastNotificationBuilder(String text)
        {
            ToastContentBuilder notification = new ToastContentBuilder();
            try
            {
                notification.AddText("BackApp", hintMaxLines: 1);
                notification.AddText(text);
                notification.Show();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ToastContentBuilder ProgressBarToastNotificationBuilder(String title, String value, String status)
        {
            ToastContentBuilder notification = new ToastContentBuilder();
            try
            {
                notification.AddText("BackApp", hintMaxLines: 1);
                notification.AddVisualChild(
                    new AdaptiveProgressBar()
                    {
                        Title = title,
                        Value = new BindableProgressBarValue(value),
                        Status = status
                    }
                    );
                return notification;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void mainProcedure(string[] args, string source, string output)
        {
            try
            {
                Boolean isRecursive = false;
                if (args.Contains("rec"))
                {
                    isRecursive = true;
                }
                SendUpdatableToastWithProgressBckProc("Progress", "progressValue", "Copying files to backup folder...");
                if (backupProcedure(isRecursive, source, output))
                {
                    TextToastNotificationBuilder("Backup has terminated correctly");
                }
                else
                {
                    TextToastNotificationBuilder("There was a problem with your backup. Retry or check log files and contact the developer.");
                }
            }
            catch
            {
                TextToastNotificationBuilder("There was a problem with your backup. Retry or check log files and contact the developer.");
            }
        }
        public void mainProcedure(Boolean isRecursive, string source, string output)
        {
            try
            {
                SendUpdatableToastWithProgressBckProc("Progress", "progressValue", "Copying files to backup folder...");
                if (backupProcedure(isRecursive, source, output))
                {
                    TextToastNotificationBuilder("Backup has terminated correctly");
                }
                else
                {
                    TextToastNotificationBuilder("There was a problem with your backup. Retry or check log files and contact the developer.");
                }
            }
            catch
            {
                TextToastNotificationBuilder("There was a problem with your backup. Retry or check log files and contact the developer.");
            }
        }
        public void SendUpdatableToastWithProgressBckProc(String title, String value, String status)
        {
            
            ToastNotification bckProgressBar = new ToastNotification(ProgressBarToastNotificationBuilder(title, value, status).GetXml());
            bckProgressBar.Tag = "backup-procedure";
            bckProgressBar.Data = new NotificationData();
            bckProgressBar.Data.Values[value] = "0";
            ToastNotificationManager.CreateToastNotifier(appID).Show(bckProgressBar);
        }
        public void UpdateBckProcToast(double value)
        {
            string tag = "backup-procedure";
            NotificationData data = new NotificationData();
            try
            {
                data.Values["progressValue"] = value.ToString();
                ToastNotificationManager.CreateToastNotifier(appID).Update(data, tag);
            }
            catch
            {
                throw;
            }
        }
        public bool dailySchedule(DateTimePicker time, short daysInterval, TaskDefinition td)
        {
            DailyTrigger dt = new DailyTrigger();
            dt.StartBoundary = DateTime.Parse(time.Text);
            if (daysInterval > 0)
            {
                dt.DaysInterval = daysInterval;
                td.Triggers.Add(dt);
                return true;
            }
            else
            {
                MessageBox.Show("The day interval cannot be lower than 1");
                return false;
            }
        }
        public bool weeklySchedule(DateTimePicker time, short weeksInterval, CheckedListBox daysPicker, TaskDefinition td)
        {
            WeeklyTrigger wt = new WeeklyTrigger();
            DaysOfTheWeek days = 0;
            wt.StartBoundary = DateTime.Parse(time.Text);
            wt.WeeksInterval = weeksInterval;
            if (weeksInterval > 0)
            {
                if (daysPicker.CheckedItems.Count > 0)
                {
                    if (daysPicker.CheckedItems.Contains("Monday"))
                    {
                        days |= DaysOfTheWeek.Monday;
                    }
                    if (daysPicker.CheckedItems.Contains("Tuesday"))
                    {
                        days |= DaysOfTheWeek.Tuesday;
                    }
                    if (daysPicker.CheckedItems.Contains("Wednesday"))
                    {
                        days |= DaysOfTheWeek.Wednesday;
                    }
                    if (daysPicker.CheckedItems.Contains("Thursday"))
                    {
                        days |= DaysOfTheWeek.Thursday;
                    }
                    if (daysPicker.CheckedItems.Contains("Friday"))
                    {
                        days |= DaysOfTheWeek.Friday;
                    }
                    if (daysPicker.CheckedItems.Contains("Saturday"))
                    {
                        days |= DaysOfTheWeek.Saturday;
                    }
                    if (daysPicker.CheckedItems.Contains("Sunday"))
                    {
                        days |= DaysOfTheWeek.Sunday;
                    }
                    wt.DaysOfWeek = days;
                    td.Triggers.Add(wt);
                    return true;
                }
                else
                {
                    MessageBox.Show("Select almost a day!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("The week interval cannot be lower than 1");
                return false;
            }
        }
        public bool monthlySchedule(DateTimePicker time, TextBox days, TaskDefinition td)
        {
            MonthlyTrigger mt = new MonthlyTrigger();
            mt.StartBoundary = DateTime.Parse(time.Text);
            List<int> daysOfMonth = new List<int>();
            if (!String.IsNullOrEmpty(days.Text))
            {
                if (days.Text.Contains(';'))
                {
                    foreach (String day in days.Text.Split(';'))
                    {
                        daysOfMonth.Add(int.Parse(day));
                    }
                    mt.DaysOfMonth = daysOfMonth.ToArray();
                }
                else
                {
                    mt.DaysOfMonth[0] = int.Parse(days.Text);
                }
                td.Triggers.Add(mt);
                return true;
            }
            else
            {
                MessageBox.Show("Write almost a day of the month!");
                return false;
            }
        }
    }
}
