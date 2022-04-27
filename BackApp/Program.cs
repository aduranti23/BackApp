using System.Configuration;
using Windows.UI.Notifications;

namespace BackApp
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Procedures procedures = new Procedures();
            if (!args.Contains("nogui"))
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new GUI());
            }
            else
            {
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
                        procedures.mainProcedure(args, source, output);
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