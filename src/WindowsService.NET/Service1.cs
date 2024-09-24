using System;
using System.Globalization;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace WindowsService.NET
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer = new Timer();
        private int _intervalInMilliseconds = 10000; // 10,000 milliseconds (ms) = 10 seconds
        private int _errorExitCode = 0;  // Exit code for error recovery mechanism

        public Service1()
        {
            InitializeComponent();
            this.ServiceName = "WindowsService.NET";
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry($"Service '{ServiceName}' has been started");
            WriteLog($"Service '{ServiceName}' has been started");
            _timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            _timer.Interval = _intervalInMilliseconds;
            _timer.Enabled = true;
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteLog(string.Format("{0} ms elapsed.", _intervalInMilliseconds));

            // Reset _errorExitCode = 0           
            _errorExitCode = 0;

            DateTime start = new DateTime(2024, 09, 24, 18, 06, 0); // 10 o'clock
            DateTime end = new DateTime(2024, 09, 24, 18, 08, 0); // 12 o'clock
            DateTime now = DateTime.Now;

            if ((now > start) && (now < end))
            {
                _errorExitCode = 99;
                StopServiceWithError();
            }
            else
            {
                _errorExitCode = 0;
                StopService();
            }

        }

        protected override void OnStop()
        {
            _timer.Stop();
            WriteLog($"Service '{ServiceName}' has been stopped.");
            EventLog.WriteEntry($"Service '{ServiceName}' has been stopped.");
        }

        public void WriteLog(string logMessage, bool addTimeStamp = true)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = string.Format("{0}\\{1}_{2}.txt",
                path,
                ServiceName,
                DateTime.Now.ToString("yyyyMMdd", CultureInfo.CurrentCulture)
                );

            if (addTimeStamp)
            {
                logMessage = string.Format("[{0}] - {1}\r\n",
                    DateTime.Now.ToString("HH:mm:ss", CultureInfo.CurrentCulture),
                    logMessage
                    );
            }

            File.AppendAllText(filePath, logMessage);
        }

        private void StopService()
        {
            // Log the service stopping and stop it
            EventLog.WriteEntry($"Batch processing completed. Stopping the '{ServiceName}' service.");
            this.Stop(); // Gracefully stop the service
        }

        private void StopServiceWithError()
        {
            // Stop the service with an error exit code
            Environment.ExitCode = _errorExitCode;
            this.ExitCode = _errorExitCode;
            this.Stop();
        }
    }
}