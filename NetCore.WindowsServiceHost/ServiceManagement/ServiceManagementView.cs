using System;
using System.ComponentModel;
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
			StatusLabel.DataBindings.Add(new Binding(nameof(StatusLabel.Text), ViewModel, nameof(ViewModel.Status)));
			ViewModel.PropertyChanged += UpdateUI;
			UpdateUI(this, null);
		}

		private void UpdateUI(object sender, PropertyChangedEventArgs e)
		{
			// Default state
			InstallButton.Enabled = false;
			UninstallButton.Enabled = true;
			StartButton.Enabled = false;
			StopButton.Enabled = false;
			// Change state
			if (ViewModel.Status == ServiceManagementViewModel.Status_NotInstalled)
			{
				InstallButton.Enabled = true;
				UninstallButton.Enabled = false;
			}
			if (ViewModel.Status == ServiceManagementViewModel.Status_Pending)
			{
				UninstallButton.Enabled = false;
			}
			if (ViewModel.Status == ServiceManagementViewModel.Status_Running)
			{
				StopButton.Enabled = true;
			}
			if (ViewModel.Status == ServiceManagementViewModel.Status_Paused 
				|| ViewModel.Status == ServiceManagementViewModel.Status_Stopped)
			{
				StartButton.Enabled = true;
			}
		}

		private void InstallButton_Click(object sender, EventArgs e)
		{
			ViewModel.Install();
			Unfocus();
		}

		private void UninstallButton_Click(object sender, EventArgs e)
		{
			ViewModel.Uninstall();
			Unfocus();
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			ViewModel.Start();
			Unfocus();
		}

		private void StopButton_Click(object sender, EventArgs e)
		{
			ViewModel.Stop();
			Unfocus();
		}

		private void Unfocus()
		{
			InvisibleButton.Focus();
		}
	}
}