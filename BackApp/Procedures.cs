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
        NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public void backupProcedure(Boolean isRecursive, String source, String output)
        {
            List<String> files = new List<String>();
            List<String> dirs = new List<String>();
            SearchOption searchOption = SearchOption.TopDirectoryOnly;
            try
            {
                String outDir = Path.Combine(output, String.Concat("BCK_", DateTime.Now.ToString("yyyyMMddHHmmssfff")));
                Directory.CreateDirectory(outDir);
                log.Info("Output directory created");
                dirs.Add(source);
                log.Info(String.Concat(source, " imported"));
                if (isRecursive)
                {
                    searchOption = SearchOption.AllDirectories;
                    dirs.AddRange(Directory.GetDirectories(source, "", searchOption).ToList());
                    foreach (String dir in dirs)
                    {
                        log.Info(String.Concat(dir, " imported"));
                    }
                }
                int filesNumber = Directory.GetFiles(source, "*.*", searchOption).ToList().Count;
                log.Info(String.Concat("Copying ", filesNumber, " file(s)"));
                double currentFile = 0;
                foreach (String directory in dirs)
                {
                    log.Info(String.Concat("Processing directory ", directory));
                    String outDirRec = String.Empty;
                    files = Directory.GetFiles(directory, "*.*").ToList();
                    log.Info(String.Concat(files.Count, " files in directory"));
                    if (!directory.Equals(source))
                    {
                        outDirRec = directory.Replace(source, outDir); //Path.Combine(outDir, directory.Substring(source.Length + 1));
                        Directory.CreateDirectory(outDirRec);
                    }
                    else
                    {
                        outDirRec = outDir;
                    }
                    foreach (String file in files)
                    {
                        try
                        {
                            File.Copy(file, Path.Combine(outDirRec, Path.GetFileName(file)));
                        }
                        catch (Exception ex)
                        {
                            log.Error(String.Concat("ERROR: File ", file, " not copied: ", ex.Message, " ", ex.StackTrace));
                        }
                        currentFile++;
                        double value = currentFile / filesNumber;
                        UpdateBckProcToast(value);
                        Thread.Sleep(5);
                    }
                    log.Info(String.Concat("Directory ", directory, " processed"));
                }
                log.Info("Backup terminated correctly");
            }
            catch
            {
                log.Error("ERROR during backup");
                throw;
            }
        }
        public void mainProcedure(Boolean isRecursive, string source, string output)
        {
            log.Info("Initializing backup...");
            try
            {
                if (isRecursive)
                {
                    log.Info("Recursive backup");
                }
                else
                {
                    log.Info("Not recursive backup");
                }
                ToastNotification progressNotification = SendUpdatableToastWithProgressBckProc();
                try
                {
                    backupProcedure(isRecursive, source, output);
                    ToastNotificationManagerCompat.CreateToastNotifier().Hide(progressNotification);
                    TextToastNotificationBuilder("Backup has terminated correctly");
                }
                catch
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                log.Error(String.Concat(ex.Message, " ", ex.StackTrace));
                TextToastNotificationBuilder("There was a problem with your backup. Retry or check log files and contact the developer.");
            }
        }
        public void TextToastNotificationBuilder(String text)
        {
            log.Info("Building text toast notification...");
            ToastContentBuilder notification = new ToastContentBuilder();
            try
            {
                notification.AddText("BackApp", hintMaxLines: 1);
                notification.AddText(text);
                notification.Show();
                log.Info("Toast notification built");
            }
            catch (Exception ex)
            {
                log.Error(String.Concat("Error during toast notification build-up: ", ex.Message, " ", ex.StackTrace));
                throw;
            }
        }
        public ToastNotification SendUpdatableToastWithProgressBckProc()
        {
            string value = "progressValue";
            log.Info("Creating progress toast notification...");
            try
            {
                log.Info("Building progress toast notification...");
                ToastContentBuilder notification = new ToastContentBuilder();
                notification.AddText("BackApp", hintMaxLines: 1);
                notification.AddVisualChild(
                    new AdaptiveProgressBar()
                    {
                        Title = "Running backup...",
                        Value = new BindableProgressBarValue(value),
                        Status = "Copying files to backup folder..."
                    }
                    );
                log.Info("Toast notification built");
                ToastNotification bckProgressBar = new ToastNotification(notification.GetToastContent().GetXml());
                bckProgressBar.Tag = "backup-procedure";
                bckProgressBar.Data = new NotificationData();
                bckProgressBar.Data.Values[value] = "0";
                bckProgressBar.Data.SequenceNumber = 0;
                bckProgressBar.Priority = ToastNotificationPriority.Default;
                ToastNotificationManagerCompat.CreateToastNotifier().Show(bckProgressBar);
                log.Info("Toast notification created");
                return bckProgressBar;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, " ", ex.StackTrace);
                throw;
            }
        }
        public void UpdateBckProcToast(double value)
        {
            string tag = "backup-procedure";
            NotificationData data = new NotificationData();
            try
            {
                data.Values["progressValue"] = value.ToString().Replace(',', '.');
            }
            catch
            {
                throw;
            }
            finally
            {
                ToastNotificationManagerCompat.CreateToastNotifier().Update(data, tag);
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