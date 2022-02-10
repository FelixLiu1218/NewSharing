namespace NewProject
{
    /// <summary>
    /// a view model for chat message thread item  in a chat thread
    /// </summary>
    public class ChatMessageListItemViewModel:BaseViewModel
    {
        //the display name of the sender of the message
        public string SenderName { get; set; }

        public string Message { get; set; }

        //the initials to show for the profile picture
        public string Initials { get; set; }

        public string ProfilePictureRGB { get; set; }


        //True(if this item is selected)
        public bool IsSelected { get; set; }

        //True if the message was sent by myself
        public bool SentByMe { get; set; }

        //True if this thing is a new one
        public bool NewOne { get; set; }

        /// <summary>
        /// The attachment to the message , if it's image type
        /// </summary>
        public ChatMessageListItemimageViewModel ImageAttachment { get; set; }

        public bool HasMessage => Message != null;

        public bool HasImage => ImageAttachment != null;
    }
}
