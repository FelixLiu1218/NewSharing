using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using NewProject.Core;

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
        protected override void OnStartup(StartupEventArgs e)
        {
            //let the base application do what it needs
            base.OnStartup(e);

            //setup the main application
            ApplicationSetup();

            //show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures the application ready for use
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void ApplicationSetup()
        {
            IoC.Setup();

            //Bind a ui manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }
    }
}
