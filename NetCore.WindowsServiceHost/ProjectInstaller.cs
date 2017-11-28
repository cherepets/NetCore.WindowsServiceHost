using System.ComponentModel;
using System.Configuration.Install;

namespace NetCore.WindowsServiceHost
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            serviceInstaller.ServiceName = Config.ServiceName;
            serviceInstaller.DisplayName = Config.ServiceName;
            serviceInstaller.Description = Config.ServiceName;
        }
    }
}