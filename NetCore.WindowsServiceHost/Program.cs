using NetCore.WindowsServiceHost.ServiceManagement;
using System;
using System.ServiceProcess;

namespace NetCore.WindowsServiceHost
{
    static class Program
    {
        static void Main()
        {
			if (Environment.UserInteractive)
				LaunchUI();
			else
				RunService();
        }

		private static void LaunchUI()
		{
			var form = new ServiceManagementView();
			form.ShowDialog();
		}

		private static void RunService()
		{
			var services = new [] { new NetCoreHostService() };
			ServiceBase.Run(services);
		}
	}
}