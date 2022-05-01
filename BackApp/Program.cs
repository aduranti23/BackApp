using System.Configuration;
using Windows.UI.Notifications;

namespace BackApp
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
            Procedures procedures = new Procedures();
            if (!args.Contains("nogui"))
            {
                log.Info("Inizializing UI...");
                ApplicationConfiguration.Initialize();
                Application.Run(new GUI());
            }
            else
            {
                log.Info("Initializing console...");
                try
                {
                    string source = args.Where(a => a.Contains("s::")).FirstOrDefault().Split("::")[1];
                    string output = args.Where(a => a.Contains("o::")).FirstOrDefault().Split("::")[1];
                    if (String.IsNullOrEmpty(source) || String.IsNullOrEmpty(output))
                    {
                        procedures.TextToastNotificationBuilder("Backup error: no path was specified for input or output.");
                    }
                    else
                    {
                        procedures.mainProcedure(args.Contains("rec"), source, output);
                    }
                }
                catch
                {
                    procedures.TextToastNotificationBuilder("There was a problem with your backup. Retry or check log files and contact the developer.");
                }
            }
        }
    }
}