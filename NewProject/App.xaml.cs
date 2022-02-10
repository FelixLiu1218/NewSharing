using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Dna;
using NewProject.Core;
using Relational;


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
            IoC.Logger.Log("Application starting up", LogLevel.Debug);

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
                .Build();

            IoC.Setup();

            //Bind a ui manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            //Bind a logger
            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new []
            {
                new Core.FileLogger("log.text")
            }));

            //Bind a file manager
            IoC.Kernel.Bind<IFileManager>().ToConstant(new BaseFileManager());

            //Bind a file manager
            IoC.Kernel.Bind<ITaskManager>().ToConstant(new BaseTaskManager());

            //Ensure the client data store 
            await IoC.ClientDataStore.EnsureDataStore();
        }
    }
}
