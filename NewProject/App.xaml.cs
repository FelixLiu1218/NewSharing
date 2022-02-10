using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Dna;
using Microsoft.Extensions.Logging;
using NewProject.Core;
using Relational;
using static Dna.FrameworkDI;
using static NewProject.DI;
using static NewProject.Core.CoreDI;
using Microsoft.Extensions.DependencyInjection;

namespace NewProject
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// custom startup so we load our ioc immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            //let the base application do what it needs
            base.OnStartup(e);

            //setup the main application
            await ApplicationSetup();

            //Log it
            Logger.LogDebugSource("Application starting up");

            // Setup the application view model based on if we are logged in
            ViewModelApplication.GoToPage(
                // If we are logged in...
                await ClientDataStore.HasCredentials() ?
                    // Go to chat page
                    ApplicationPage.Chat :
                    // Otherwise, go to login page
                    ApplicationPage.Login);

            //show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures the application ready for use
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private async Task ApplicationSetup()
        {
            Framework.Construct<DefaultFrameworkConstruction>()
                .AddFileLogger()
                .AddClientDataStore()
                .AddFasettoWordViewModels()
                .AddFasettoWordClientServices()
                .Build();

            //Ensure the client data store 
            await ClientDataStore.EnsureDataStore();

            // Monitor for server connection status
            MonitorServerStatus();

            // Load new settings
            TaskManager.RunAndForget(ViewModelSettings.Load);
        }

        /// <summary>
        /// Monitors the fasetto website is up, running and reachable
        /// by periodically hitting it up
        /// </summary>
        private void MonitorServerStatus()
        {
            // Create a new endpoint watcher
            var httpWatcher = new HttpEndpointChecker(
                // Checking fasetto.chat
                FrameworkDI.Configuration["FasettoWordServer:HostUrl"],
                // Every 20 seconds
                interval: 20000,
                // Pass in the DI logger
                logger: Framework.Provider.GetService<ILogger>(),
                // On change...
                stateChangedCallback: (result) =>
                {
                    // Update the view model property with the new result
                    ViewModelApplication.ServerReachable = result;
                });
        }
    }
}
