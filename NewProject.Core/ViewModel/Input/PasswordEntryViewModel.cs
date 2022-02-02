using System.Security;
using System.Windows.Input;

namespace NewProject.Core
{
    /// <summary>
    /// The View model for a password entry to edit a string value
    /// </summary>
    public class PasswordEntryViewModel :BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The label to identify when this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The fakepassword
        /// </summary>
        public string FakePassword { get; set; }

        /// <summary>
        /// The current password hint text
        /// </summary>
        public string CurrentPasswordHint { get; set; }

        /// <summary>
        /// The new password hint text
        /// </summary>
        public string NewPasswordHint { get; set; }

        /// <summary>
        /// The confirm password hint text
        /// </summary>
        public string ConfirmPasswordHint { get; set; }

        /// <summary>
        /// The current saved value
        /// </summary>
        public SecureString OriginalPassword { get; set; }

        /// <summary>
        /// The current non-commit edited password
        /// </summary>
        public SecureString EditedPassword { get; set; }

        /// <summary>
        /// The current non-commit edited password
        /// </summary>
        public SecureString ConfirmPassword { get; set; }

        /// <summary>
        /// Indicated if the current text is in edit mode
        /// </summary>
        public bool Editing { get; set; }
        #endregion

        #region MyRegion

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Back to normal mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Commits the edits and saves the value
        /// </summary>
        public ICommand SaveCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PasswordEntryViewModel()
        {
            //Create commands
            EditCommand = new RelayCommand(Edit);
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);

            //Set default value
            CurrentPasswordHint = " Current Password";
            NewPasswordHint = " New Password";
            ConfirmPasswordHint = " Confirm Password";
        }

        #endregion

        #region Command Methods

        public void Edit()
        {
            //Clear all password
            EditedPassword = new SecureString();
            ConfirmPassword = new SecureString();

            //Go to edit mode
            Editing = true;
        }

        public void Save()
        {
            var storePassword = "Testing";

            //Confirm current password is match or not
            if (storePassword != OriginalPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Error",
                    Message = "The current password is invalid",
                    OKText = "OK"

                });

                return;
            }

            //Check the new one and confirm password match or not
            if (EditedPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Error",
                    Message = "The new and confirm password do not match",
                    OKText = "OK"
                });

                return;
            }

            //Check edited password have a password
            if (EditedPassword.Unsecure().Length == 0)
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Error",
                    Message = "Password cannot be empty",
                    OKText = "OK"
                });

                return;
            }

            //Set the edited password to the current value
            OriginalPassword = new SecureString();
            foreach (var VARIABLE in EditedPassword.Unsecure().ToCharArray())
            {
                OriginalPassword.AppendChar(VARIABLE);
            }

            Editing = false;
        }

        public void Cancel()
        {
            Editing = false;
        }

        #endregion
    }
}
