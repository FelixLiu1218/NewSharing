using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace NewProject.Core
{

    /// <summary>
    /// the Ioc container for application
    /// </summary>
    public static class IoC
    {

        #region public properties

        /// <summary>
        /// the kernel for ioc container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// a shortcut to access the <see cref="IUIManager"/>
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        /// <summary>
        /// a shortcut to access the <see cref="ILogFactory"/>
        /// </summary>
        public static ILogFactory Logger => IoC.Get<ILogFactory>();

        /// <summary>
        /// a shortcut to access the <see cref="IFileManager"/>
        /// </summary>
        public static IFileManager File => IoC.Get<IFileManager>();

        /// <summary>
        /// a shortcut to access the <see cref="ITaskManager"/>
        /// </summary>
        public static ITaskManager Task => IoC.Get<ITaskManager>();

        /// <summary>
        /// a shortcut to access the <see cref="SettingsViewModel"/>
        /// </summary>
        public static SettingsViewModel Settings => IoC.Get<SettingsViewModel>();

        #endregion


        #region Construction

        /// <summary>
        /// Setup the Ioc container,binds all information required and is ready for use
        /// must be called as soon as your application starts up to ensure all service can be found
        /// </summary>
        public static void Setup()
        {
            //bind all required view models
            BindViewModels();
        }

        
        private static void BindViewModels()
        {
            //bind to a single instance of application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

            //bind to a single instance of settings view model
            Kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel());
        }

        #endregion

        /// <summary>
        /// get's a service from the Ioc,of the specified type
        /// </summary>
        /// <typeparam name="T">the type to get</typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
