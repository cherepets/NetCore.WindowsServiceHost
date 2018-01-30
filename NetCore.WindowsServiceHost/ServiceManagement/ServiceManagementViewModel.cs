using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCore.WindowsServiceHost.ServiceManagement
{
	public class ServiceManagementViewModel : INotifyPropertyChanged
	{
		public const string Status_NotInstalled = "Not installed";
		public const string Status_Pending = "Pending";
		public static readonly string Status_Running = ServiceControllerStatus.Running.ToString();
		public static readonly string Status_Paused = ServiceControllerStatus.Paused.ToString();
		public static readonly string Status_Stopped = ServiceControllerStatus.Stopped.ToString();

		private bool _dontPoll;

		public event PropertyChangedEventHandler PropertyChanged;

		public ServiceController Service { get; private set; }

		public string Status
		{
			get => _status;
			private set
			{
				if (_status == value)
					return;
				_status = value;
				OnPropertyChanged();
			}
		}
		private string _status;

		public string Location => typeof(NetCoreHostService).Assembly.Location;

		public ServiceManagementViewModel()
		{
			Poll();
		}

		public void Install() => Try(() => ManagedInstallerClass.InstallHelper(new[] { "/LogFile=", "/LogToConsole=true", Location }));

		public void Uninstall() => Try(() => ManagedInstallerClass.InstallHelper(new[] { "/u", "/LogFile=", "/LogToConsole=true", Location }));

		public void Start() => Try(() => Service?.Start());

		public void Stop() => Try(() => Service?.Stop());

		private async void Poll()
		{
			while(true)
			{
				try
				{
					if (!_dontPoll)
						UpdateStatus();
					await Task.Delay(1000);
				}
				catch (Exception exception)
				{
					Debug.WriteLine($"Polling error: {exception}");
				}
			}
		}

		private async void Try(Action action)
		{
			try
			{
				_dontPoll = true;
				UpdateStatus(Status_Pending);
				await Task.Run(() => action?.Invoke());
				UpdateStatus();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, exception.GetType().Name);
			}
			finally
			{
				_dontPoll = false;
			}
		}

		private void UpdateStatus(string value = null)
		{
			if (value == null)
			{
				Service = FindService(Config.ServiceName);
				if (Service == null)
					Status = Status_NotInstalled;
				else
				{
					switch (Service.Status)
					{
						case ServiceControllerStatus.Running:
							Status = Status_Running;
							break;
						case ServiceControllerStatus.Paused:
							Status = Status_Paused;
							break;
						case ServiceControllerStatus.Stopped:
							Status = Status_Stopped;
							break;
						default:
							Status = Status_Pending;
							break;
					}
				}
			}
			else
			{
				Status = value;
			}
		}

		private static ServiceController FindService(string serviceName)
			=> ServiceController
			.GetServices()
			.FirstOrDefault(x => x.ServiceName == serviceName);

		private void OnPropertyChanged([CallerMemberName] string propertyName = null) 
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}