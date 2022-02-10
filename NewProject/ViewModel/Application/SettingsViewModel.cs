using System;
using System.Windows.Input;

namespace NewProject
{
    /// <summary>
    /// the settings state as a view model
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// The current user name
        /// </summary>
        public TextEntryViewModel Name { get; set; }

        /// <summary>
        /// The current user Username
        /// </summary>
        public TextEntryViewModel Username { get; set; }

        /// <summary>
        /// The current user Password
        /// </summary>
        public PasswordEntryViewModel Password { get; set; }

        /// <summary>
        /// The current user Email
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        /// <summary>
        /// The text for the logout button
        /// </summary>
        public string LogoutButtonText { get; set; }
        #endregion

        #region Public Commands

        /// <summary>
        /// The command to close the settings menu
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to open the settings menu
        /// </summary>
        public ICommand OpenCommand { get; set; }

        /// <summary>
        /// The command to Logout
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        /// <summary>
        /// The command to clear the user data
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }
        #endregion

        #region Constructor

        public SettingsViewModel()
        {
            //Create commands
            OpenCommand = new RelayCommand(Open);
            CloseCommand = new RelayCommand(Close);
            LogoutCommand = new RelayCommand(Logout);
            ClearUserDataCommand = new RelayCommand(ClearUserData);

            //i need to remove this later
            Name = new TextEntryViewModel
            {
                Label = "Name",
                OriginalText = "Felix Liu"
            };
            Username = new TextEntryViewModel
            {
                Label = "Username",
                OriginalText = "Felix"
            };
            Password = new PasswordEntryViewModel()
            {
                Label = "Password",
                FakePassword = "********"
            };
            Email = new TextEntryViewModel
            {
                Label = "Email",
                OriginalText = "pengfeiliu1218@gmail.com"
            };

            LogoutButtonText = "Logout";
        }

        #endregion

        public void Open()
        {
            //Open Settings menu
            IoC.Get<ApplicationViewModel>().SettingsMenuVisible = true;
        }

        public void Close()
        {
            //Close Settings menu
            IoC.Get<ApplicationViewModel>().SettingsMenuVisible = false;
        }

        public void Logout()
        {
            ClearUserData();

            //Logout and then back to login page
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
        }

        /// <summary>
        /// Clear data
        /// </summary>
        public void ClearUserData()
        {
            Name = null;
            Username = null;
            Password = null;
            Email = null;
        }
    }
}
