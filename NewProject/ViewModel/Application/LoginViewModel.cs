using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Dna;

namespace NewProject
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
                //Call the servrer and attempt to login with credentials
                var result =
                    await WebRequests.PostAsync<ApiResponse<UserProfileDetailsApiModel>>(
                        // Set URL
                        RouteHelpers.GetAbsoluteRoute(ApiRoutes.Login),
                        // Create api model
                        new LoginCredentialsApiModel
                        {
                            UsernameOrEmail = Email,
                            Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                        });

                #region need to fix

                // // If the response has an error...
                // if (await result.HandleErrorIfFailedAsync("Login Failed"))
                //     // We are done
                //     return;
                // // Let the application view model handle what happens
                // // with the successful login
                // await ViewModelApplication.HandleSuccessfulLoginAsync(loginResult);

                #endregion


                // OK successfully logged in... now get users data
                var loginResult = result.ServerResponse.Response;

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
            });
            
        }

        public async Task Register()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);
            
            await Task.Delay(1);
        }
    }
}