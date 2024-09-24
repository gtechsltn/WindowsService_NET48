using System;
using System.Globalization;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace WindowsService.NET
{
    public partial class Service1 : ServiceBase
    {
        private Timer Timer = new Timer();
        private int Interval = 10000; // 10,000 milliseconds (ms) = 10 seconds

        public Service1()
        {
            InitializeComponent();
            this.ServiceName = "WindowsService.NET";
        }

        protected override void OnStart(string[] args)
        {
            WriteLog("Service has been started");
            Timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            Timer.Interval = Interval;
            Timer.Enabled = true;
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteLog(String.Format("{0} ms elapsed.", Interval));
        }

        protected override void OnStop()
        {
            Timer.Stop();
            WriteLog("Service has been stopped.");
        }

        public void WriteLog(string logMessage, bool addTimeStamp = true)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = String.Format("{0}\\{1}_{2}.txt",
                path,
                ServiceName,
                DateTime.Now.ToString("yyyyMMdd", CultureInfo.CurrentCulture)
                );

            if (addTimeStamp)
            {
                logMessage = String.Format("[{0}] - {1}\r\n",
                    DateTime.Now.ToString("HH:mm:ss", CultureInfo.CurrentCulture),
                    logMessage
                    );
            }

            File.AppendAllText(filePath, logMessage);
        }
    }
}