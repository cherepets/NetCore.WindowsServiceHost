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
					Service = FindService(Config.ServiceName);
					Status = Service == null
						? "Not installed"
						: Service.Status.ToString();
					await Task.Delay(1000);
				}
				catch (Exception exception)
				{
					Debug.WriteLine($"Polling error: {exception}");
				}
			}
		}

		private void Try(Action action)
		{
			try
			{
				action?.Invoke();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, exception.GetType().Name);
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