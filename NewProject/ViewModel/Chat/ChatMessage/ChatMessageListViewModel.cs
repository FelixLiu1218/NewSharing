using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace NewProject
{
    /// <summary>
    /// a view model for a chat message thread list
    /// </summary>
    public class ChatMessageListViewModel:BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// The last searched text in this list
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mSearchText;


        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        protected ObservableCollection<ChatMessageListItemViewModel> mItems;

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        protected bool mSearchIsOpen;

        #endregion

        #region Public Properties

        /// <summary>
        /// the chat thread items for the list
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => mItems;
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = value;

                // Update filtered list to match
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }

        /// <summary>
        /// The title of this chat list
        /// </summary>
        public string DisplayTitle { get; set; }

        /// <summary>
        /// True to show the attachment menu,false to hide
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        public bool AnyPopupVisible => AttachmentMenuVisible;

        /// <summary>
        /// the view model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        /// <summary>
        /// The text for the current message
        /// </summary>
        public string PendingMessageText { get; set; }

        /// <summary>
        /// The text to search for when we do a search
        /// </summary>
        public string SearchText
        {
            get => mSearchText;
            set
            {
                // Check value is different
                if (mSearchText == value)
                    return;

                // Update value
                mSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(SearchText))
                    // Search to restore messages
                    Search();
            }
        }

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                // Check value has changed
                if (mSearchIsOpen == value)
                    return;

                // Update value
                mSearchIsOpen = value;

                // If dialog closes...
                if (!mSearchIsOpen)
                    // Clear search text
                    SearchText = string.Empty;
            }
        }

        #endregion

        #region Public Commands

        //The command for when the attachment button is clicked
        public ICommand AttachmentButtonCommand { get; set; }

        //The command for when the area outside of any popup is clicked
        public ICommand PopupClickawayCommand { get; set; }

        //The command for when the user clicks the send button
        public ICommand SendCommand { get; set; }

        // The command for when the user wants to search
        public ICommand SearchCommand { get; set; }

        // The command for when the user wants to open the search dialog
        public ICommand OpenSearchCommand { get; set; }

        // The command for when the user wants to close to search dialog
        public ICommand CloseSearchCommand { get; set; }

        // The command for when the user wants to clear the search text
        public ICommand ClearSearchCommand { get; set; }

        #endregion

        #region Constructor

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

            PopupClickawayCommand = new RelayCommand(PopupClickaway);

            SendCommand = new RelayCommand(Send);

            SearchCommand = new RelayCommand(Search);

            OpenSearchCommand = new RelayCommand(OpenSearch);

            CloseSearchCommand = new RelayCommand(CloseSearch);

            ClearSearchCommand = new RelayCommand(ClearSearch);

            //default menu
            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// when the attachment button is clicked show or hide the popup
        /// </summary>
        public void AttachmentButton()
        {
            //Toggle menu visibility
            AttachmentMenuVisible ^= true;
        }

        /// <summary>
        /// when the popup clickaway area is clicked hide any popups
        /// </summary>
        public void PopupClickaway()
        {
            //hide attachment menu
            AttachmentMenuVisible = false;
        }

        public void Send()
        {
            // Don't send a blank message
            if (string.IsNullOrEmpty(PendingMessageText))
                return;

            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();

            if (FilteredItems == null)
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>();

            var message = new ChatMessageListItemDesignModel
            {
                Initials = "FL",
                Message = PendingMessageText,
                SenderName = "Felix Liu",
                SentByMe = true,
                NewOne = true,
            };

            // Add message to both lists
            Items.Add(message);
            FilteredItems.Add(message);

            //Clean the pending message
            PendingMessageText = String.Empty;
        }

        /// <summary>
        /// Searches the current message list and filters the view
        /// </summary>
        public void Search()
        {
            // Make sure we don't re-search the same text
            if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(mLastSearchText, SearchText))
                return;

            // If we have no search text, or no items
            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                // Make filtered list the same
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items ?? Enumerable.Empty<ChatMessageListItemViewModel>());

                // Set last search text
                mLastSearchText = SearchText;

                return;
            }

            // Find all items that contain the given text
            // TODO: Make more efficient search
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(
                Items.Where(item => item.Message.ToLower().Contains(SearchText)));

            // Set last search text
            mLastSearchText = SearchText;
        }

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearSearch()
        {
            // If there is some search text...
            if (!string.IsNullOrEmpty(SearchText))
                // Clear the text
                SearchText = string.Empty;
            // Otherwise...
            else
                // Close search dialog
                SearchIsOpen = false;
        }

        /// <summary>
        /// Opens the search dialog
        /// </summary>
        public void OpenSearch() => SearchIsOpen = true;

        /// <summary>
        /// Closes the search dialog
        /// </summary>
        public void CloseSearch() => SearchIsOpen = false;
        #endregion
    }
}