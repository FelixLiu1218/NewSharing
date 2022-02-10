namespace NewProject
{
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region new instance

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();


        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "T4";
            Name = "Felix";
            Message = "Test123123123123";
            ProfilePictureRGB = "3099c5";
        }

        #endregion

    }
}
