﻿using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Input;

namespace NewProject.Core
{
    /// <summary>
    /// a view model for a chat message thread list
    /// </summary>
    public class ChatMessageListViewModel:BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// the chat thread items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }

        /// <summary>
        /// True to show the attachment menu,false to hide
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        public bool AnyPopupVisible => AttachmentMenuVisible;

        /// <summary>
        /// the view model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        #endregion

        #region Public Commands

        //The command for when the attachment button is clicked
        public ICommand AttachmentButtonCommand { get; set; }

        //The command for when the area outside of any popup is clicked
        public ICommand PopupClickawayCommand { get; set; }

        //The command for when the user clicks the send button
        public ICommand SendCommand { get; set; }

        #endregion

        #region Constructor

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

            PopupClickawayCommand = new RelayCommand(PopupClickaway);

            SendCommand = new RelayCommand(Send);

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
            IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Send Message",
                Message = "Thank you for writing a nice message",
                OKText = "OK"
            });

        }

        #endregion
    }
}
