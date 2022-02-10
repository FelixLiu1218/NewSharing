using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NewProject.Core;
using static NewProject.DI; 

namespace NewProject
{
    /// <summary>
    /// a view model for chat list in the overview chat list
    /// </summary>
    public class ChatListItemViewModel:BaseViewModel
    {
        #region Public properties

        public string Name { get; set; }

        public string Message { get; set; }

        public string Initials { get; set; }

        public string ProfilePictureRGB { get; set; }

        //True if there are unread message in this chat
        public bool NewContentAvailable { get; set; }

        //True(if this item is selected)
        public bool IsSelected { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Opens the current message thread
        /// </summary>
        public ICommand OpenMessageCommand { get; set; }

        #endregion

        #region Constructor

        public ChatListItemViewModel()
        {
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }

        #endregion

        #region CommandMethods

        public void OpenMessage()
        {
            ViewModelApplication.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel
            {
                Items = new ObservableCollection<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Felix",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "this is a new message page test by felix",
                        Initials = Initials,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Helen",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Felix",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "thanks for using this app",
                        Initials = Initials,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Helen",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Felix",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "I'm glad to see you again",
                        Initials = Initials,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Helen",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "I'm glad to see you again",
                        ImageAttachment = new ChatMessageListItemimageViewModel
                        {
                            ThumbnailUrl = "http",

                        },
                        Initials = Initials,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Helen",
                        SentByMe = false,
                    },
                }
            });
        }
        #endregion
    }
}

