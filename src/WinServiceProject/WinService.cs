using System;
using System.IO;
using System.ServiceProcess;

namespace WinServiceProject
{
    internal class WinService : ServiceBase
    {
        /// <summary>
        /// The main entry point for the process
        /// </summary>
        private static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new WinService() };
            ServiceBase.Run(ServicesToRun);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServiceName = "WinServiceDemo";
        }

        private string folderPath = @"c:\temp";

        /// <summary>
        /// Set things in motion so your service can do its work.
        /// </summary>
        protected override void OnStart(string[] args)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            FileStream fs = new FileStream(folderPath + "\\WinServiceDemo.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine("WinServiceDemo: Service Started at " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\n");
            m_streamWriter.Flush();
            m_streamWriter.Close();
        }

        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            FileStream fs = new FileStream(folderPath + "\\WinServiceDemo.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine("WinServiceDemo: Service Stopped at " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\n");
            m_streamWriter.Flush();
            m_streamWriter.Close();
        }
    }
}