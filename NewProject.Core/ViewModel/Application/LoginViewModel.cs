using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NewProject.Core
{
    public class LoginViewModel :BaseViewModel
    {
        #region public Properties

        /// <summary>
        /// the email of user
        /// </summary>
        public string Email { get; set; }

        public bool LoginIsRunning { get; set; }
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
        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async(parameter) => await Login(parameter));
            RegisterCommand = new RelayCommand(async () => await Register());
        }

        #endregion


        /// <summary>
        /// attempts to log the user in
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await RunCommandAsync(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(1000);

                IoC.Settings.Name = new TextEntryViewModel
                {
                    Label = "Name",
                    OriginalText = $"Felix Liu {DateTime.Now.ToLocalTime()}"
                };
                IoC.Settings.Username = new TextEntryViewModel
                {
                    Label = "Username",
                    OriginalText = "Felix"
                };
                IoC.Settings.Password = new PasswordEntryViewModel()
                {
                    Label = "Password",
                    FakePassword = "********"
                };
                IoC.Settings.Email = new TextEntryViewModel
                {
                    Label = "Email",
                    OriginalText = "pengfeiliu1218@gmail.com"
                };

                //Go to chat page
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);

                // var email = Email;
                // var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            }
            );
            
        }

        public async Task Register()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);
            //((WindowViewModel) ((MainWindow) Application.Current.MainWindow).DataContext).CurrentPage  = ApplicationPage.Register;

            await Task.Delay(1);
        }
    }
}