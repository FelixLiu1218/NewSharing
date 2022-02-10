using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using NewProject.Core;

namespace NewProject
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

        /// <summary>
        /// Indicates if the current control is pending an update (in progress)
        /// </summary>
        public bool Working { get; set; }

        /// <summary>
        /// The action to run when saving the text.
        /// Returns true if the commit was successful, or false otherwise.
        /// </summary>
        public Func<Task<bool>> CommitAction { get; set; }

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
            // Store the result of a commit call
            var result = default(bool);

            RunCommandAsync(() => Working, async () =>
            {
                // While working, come out of edit mode
                Editing = false;

                // Try and do the work
                result = CommitAction == null ? true : await CommitAction();

            }).ContinueWith(t =>
            {
                // If we succeeded...
                // Nothing to do
                // If we fail...
                if (!result)
                {
                    // Go back into edit mode
                    Editing = true;
                }
            });
        }

        public void Cancel()
        {
            Editing = false;
        }

        #endregion
    }
}
