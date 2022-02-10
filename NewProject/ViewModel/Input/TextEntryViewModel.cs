using System.Windows.Input;

namespace NewProject
{
    /// <summary>
    /// The View model for a text entry to edit a string value
    /// </summary>
    public class TextEntryViewModel :BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The label to identify when this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The current saved value
        /// </summary>
        public string OriginalText { get; set; }

        /// <summary>
        /// The current non-commit edited text
        /// </summary>
        public string EditedText { get; set; }

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
        public TextEntryViewModel()
        {
            //Create commands
            EditCommand = new RelayCommand(Edit);
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        #endregion

        #region Command Methods

        public void Edit()
        {
            //Restore the original text
            EditedText = OriginalText;

            //Go to edit mode
            Editing = true;
        }

        public void Save()
        {
            //Save
            OriginalText = EditedText;

            Editing = false;
        }

        public void Cancel()
        {
            Editing = false;
        }

        #endregion
    }
}
