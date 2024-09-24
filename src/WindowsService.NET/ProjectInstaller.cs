using System.ComponentModel;
using System.Configuration.Install;

namespace WindowsService.NET
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}