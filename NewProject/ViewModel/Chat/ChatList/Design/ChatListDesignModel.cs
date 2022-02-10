using System.Collections.Generic;

namespace NewProject
{
    public class ChatListDesignModel : ChatListViewModel
    {
        #region new instance

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static ChatListDesignModel Instance => new ChatListDesignModel();


        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Initials = "T123",
                    Name = "Felix",
                    Message = "abcs",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "T2",
                    Name = "Tom",
                    Message = "Twdwd",
                    ProfilePictureRGB = "3099c5",
                    IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Initials = "T3",
                    Name = "Sam",
                    Message = "GDSS",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "T123",
                    Name = "Felix",
                    Message = "abcs",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "T2",
                    Name = "Tom",
                    Message = "Twdwd",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "T3",
                    Name = "Sam",
                    Message = "GDSS",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "T123",
                    Name = "Felix",
                    Message = "abcs",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "T2",
                    Name = "Tom",
                    Message = "Twdwd",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "T3",
                    Name = "Sam",
                    Message = "GDSS",
                    ProfilePictureRGB = "3099c5"
                },
            };
        }

        #endregion

    }
}
