using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewProject.Core;

namespace NewProject
{
    /// <summary>
    /// Locates view models from the Ioc for use in binding in Xaml files
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// The application view model
        /// </summary>
        public static SettingsViewModel SettingsViewModel => IoC.Get<SettingsViewModel>();
    }
}
