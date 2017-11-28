using NetCore.WindowsServiceHost;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NetCore.DebugServiceHost
{
    class Program
    {
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(ExitHandler handler, bool add);

        private delegate bool ExitHandler(CtrlType sig);
        private static ExitHandler BeforeExit;

        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        static void Main(string[] args)
        {
            var service = new NetCoreHostService();
            var start = service.GetType().GetMethod("OnStart", BindingFlags.NonPublic | BindingFlags.Instance);
            var stop = service.GetType().GetMethod("OnStop", BindingFlags.NonPublic | BindingFlags.Instance);
            var startArgs = new object[] { args };

            BeforeExit += new ExitHandler(c =>
            {
                stop.Invoke(service, null);
                Environment.Exit(-1);
                return true;
            });
            SetConsoleCtrlHandler(BeforeExit, true);

            Debug.Listeners.Add(new ConsoleTraceListener());

            start.Invoke(service, startArgs);
            Console.ReadLine();
        }
    }
}