using System.ServiceProcess;

namespace NetCore.WindowsServiceHost
{
    static class Program
    {
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new NetCoreHostService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}