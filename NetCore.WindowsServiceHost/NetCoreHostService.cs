using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace NetCore.WindowsServiceHost
{
    public partial class NetCoreHostService : ServiceBase
    {
        private bool _shouldRestart;
        private Process _process;
        private object _lock;

        public NetCoreHostService()
        {
            InitializeComponent();
            ServiceName = Config.ServiceName;
        }

        protected override void OnStart(string[] args)
        {
			CanStop = true;
			Debug.WriteLine($"Service [{ServiceName}] started");
            _shouldRestart = true;
            _lock = new object();
            var assembly = Assembly.GetExecutingAssembly();
            var path = Path.GetDirectoryName(assembly.Location);
            Directory.SetCurrentDirectory(path);
            Restart();
        }

        protected override void OnStop()
		{
			lock (_lock)
			{
				if (!CanStop) return;
				CanStop = false;
			}
            Debug.WriteLine($"Service [{ServiceName}] stopped");
            try
            {
                _shouldRestart = false;
                _process.Exit();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        private async void Restart()
        {
            lock (_lock)
            {
                if (!_shouldRestart) return;
                if (_process != null)
                {
                    _process.Exited -= Process_Exited;
                    _process.Exit();
                }

                _process = new Process
                {
                    EnableRaisingEvents = true,
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "dotnet",
                        Arguments = Config.Executeable,
                        UseShellExecute = false,
                        CreateNoWindow = !Config.DebugMode
					}
                };
                _process.Exited += Process_Exited;
                _process.Disposed += Process_Exited;
                _process.Start();
                Debug.WriteLine("Launching process");
            }
            var process = _process;
            while (CanStop)
            {
                try
                {
                    await Task.Delay(Config.PingInterval);
                    var restartNow = false;
                    lock (_lock)
                    {
                        restartNow = process == _process && !process.IsRunning();
                    }
                    if (restartNow && CanStop)
                    {
                        Debug.WriteLine("Process seems to be not running");
						if (Config.AutoRestart)
							Restart();
						else
							Stop();
                        return;
                    }
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
					if (Config.AutoRestart)
						Restart();
					else
						Stop();
					return;
                }
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            Debug.WriteLine("Process exited");
			if (Config.AutoRestart)
				Restart();
			else
				Stop();
		}
    }
}