namespace NetCore.WindowsServiceHost.ServiceManagement
{
	partial class ServiceManagementView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.StatusLabel = new System.Windows.Forms.Label();
			this.StatusCaption = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.UninstallButton = new System.Windows.Forms.Button();
			this.InstallButton = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.StopButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.StatusLabel.Location = new System.Drawing.Point(58, 9);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(0, 13);
			this.StatusLabel.TabIndex = 0;
			// 
			// StatusCaption
			// 
			this.StatusCaption.AutoSize = true;
			this.StatusCaption.Location = new System.Drawing.Point(12, 9);
			this.StatusCaption.Name = "StatusCaption";
			this.StatusCaption.Size = new System.Drawing.Size(40, 13);
			this.StatusCaption.TabIndex = 1;
			this.StatusCaption.Text = "Status:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.UninstallButton);
			this.panel1.Controls.Add(this.InstallButton);
			this.panel1.Location = new System.Drawing.Point(12, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(164, 31);
			this.panel1.TabIndex = 2;
			// 
			// UninstallButton
			// 
			this.UninstallButton.Location = new System.Drawing.Point(85, 4);
			this.UninstallButton.Name = "UninstallButton";
			this.UninstallButton.Size = new System.Drawing.Size(75, 23);
			this.UninstallButton.TabIndex = 1;
			this.UninstallButton.Text = "Uninstall";
			this.UninstallButton.UseVisualStyleBackColor = true;
			this.UninstallButton.Click += new System.EventHandler(this.UninstallButton_Click);
			// 
			// InstallButton
			// 
			this.InstallButton.Location = new System.Drawing.Point(4, 4);
			this.InstallButton.Name = "InstallButton";
			this.InstallButton.Size = new System.Drawing.Size(75, 23);
			this.InstallButton.TabIndex = 0;
			this.InstallButton.Text = "Install";
			this.InstallButton.UseVisualStyleBackColor = true;
			this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.StopButton);
			this.panel2.Controls.Add(this.StartButton);
			this.panel2.Location = new System.Drawing.Point(12, 62);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(164, 31);
			this.panel2.TabIndex = 3;
			// 
			// StopButton
			// 
			this.StopButton.Location = new System.Drawing.Point(85, 4);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(75, 23);
			this.StopButton.TabIndex = 1;
			this.StopButton.Text = "Stop";
			this.StopButton.UseVisualStyleBackColor = true;
			this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(4, 4);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 0;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// ServiceManagementView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(188, 105);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.StatusCaption);
			this.Controls.Add(this.StatusLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ServiceManagementView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label StatusLabel;
		private System.Windows.Forms.Label StatusCaption;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button UninstallButton;
		private System.Windows.Forms.Button InstallButton;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button StopButton;
		private System.Windows.Forms.Button StartButton;
	}
}