using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NewProject
{
    public class RegisterViewModel :BaseViewModel
    {
        #region public Properties

        /// <summary>
        /// the email of user
        /// </summary>
        public string Email { get; set; }

        public bool RegisterIsRunning { get; set; }
        /// <summary>
        /// the password of user
        /// </summary>
        public SecureString Password { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// the command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// the command to create a new account
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RegisterViewModel()
        {
            RegisterCommand = new RelayParameterizedCommand(async(parameter) => await Register(parameter));
            LoginCommand = new RelayCommand(async () => await Login());
        }

        #endregion


        /// <summary>
        /// attempts to register a new user
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task Register(object parameter)
        {
            await RunCommandAsync(() => this.RegisterIsRunning, async () =>
            {
                await Task.Delay(1000);

                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
            });
        }

        /// <summary>
        /// takes the user to the login page
        /// </summary>
        /// <returns></returns>
        public async Task Login()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
        }
    }
}