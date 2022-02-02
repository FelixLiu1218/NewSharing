using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NewProject.Core
{
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        #region new instance

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();


        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatMessageListDesignModel()
        {
            Items = new ObservableCollection<ChatMessageListItemViewModel>
            {
                new ChatMessageListItemViewModel
                {
                    Initials = "FL",
                    SenderName = "Felix",
                    Message = "This is a test,This is a test,This is a test,This is a test",
                    ProfilePictureRGB = "3099c5",
                    SentByMe = false,
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "AO",
                    SenderName = "Amy",
                    Message = "This is a test123,This is a test123,This is a test123,This is a test123",
                    ProfilePictureRGB = "3099c5",
                    SentByMe = true,
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "SA",
                    SenderName = "Sam",
                    Message = "This is a test456,This is a test456,This is a test456,This is a test456",
                    ProfilePictureRGB = "3099c5",
                    SentByMe = false,
                },
            };
        }

        #endregion

    }
}
