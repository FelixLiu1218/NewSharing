using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Dna;
using NewProject.Core;
using static NewProject.DI;

namespace NewProject
{
    public class RegisterViewModel :BaseViewModel
    {
        #region public Properties

        /// <summary>
        /// The username of the user
        /// </summary>
        public string Username { get; set; }

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
                // Call the server and attempt to register with the provided credentials
                var result = await WebRequests.PostAsync<ApiResponse<RegisterResultApiModel>>(
                    // Set URL
                    RouteHelpers.GetAbsoluteRoute(ApiRoutes.Register),
                    // Create api model
                    new RegisterCredentialsApiModel
                    {
                        Username = Username,
                        Email = Email,
                        Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                    });

                // If the response has an error...
                if (await result.HandleErrorIfFailedAsync("Register Failed"))
                    // We are done
                    return;

                // OK successfully registered (and logged in)... now get users data
                var loginResult = result.ServerResponse.Response;

                // Let the application view model handle what happens
                // with the successful login
                await ViewModelApplication.HandleSuccessfulLoginAsync(loginResult);
            });
        }

        /// <summary>
        /// takes the user to the login page
        /// </summary>
        /// <returns></returns>
        public async Task Login()
        {
            ViewModelApplication.GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
        }
    }
}