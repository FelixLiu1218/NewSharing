namespace NewProject
{
    public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {
        #region new instance

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static ChatMessageListItemDesignModel Instance => new ChatMessageListItemDesignModel();


        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatMessageListItemDesignModel()
        {
            Initials = "FL";
            SenderName = "Felix";
            Message = "some design time visual text";
            ProfilePictureRGB = "3099c5";
            SentByMe = true;
        }

        #endregion

    }
}
