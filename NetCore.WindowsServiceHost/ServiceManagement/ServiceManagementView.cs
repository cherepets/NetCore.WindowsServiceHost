using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCore.WindowsServiceHost.ServiceManagement
{
	public partial class ServiceManagementView : Form
	{
		public ServiceManagementViewModel ViewModel { get; }
		
		public ServiceManagementView()
		{
			InitializeComponent();
			ViewModel = new ServiceManagementViewModel();
			StatusLabel.DataBindings.Add(new Binding("Text", ViewModel, "Status"));
		}

		private void InstallButton_Click(object sender, EventArgs e)
			=> ViewModel.Install();

		private void UninstallButton_Click(object sender, EventArgs e)
			=> ViewModel.Uninstall();

		private void StartButton_Click(object sender, EventArgs e)
			=> ViewModel.Start();

		private void StopButton_Click(object sender, EventArgs e)
			=> ViewModel.Stop();
	}
}
