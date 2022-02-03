namespace NewProject.Core
{
    /// <summary>
    /// a view model for chat message thread picture  in a chat thread
    /// </summary>
    public class ChatMessageListItemimageViewModel : BaseViewModel
    {
        #region Private Members
        
        //The thumbnail Url
        private string _thumbnailUrl;

        

        #endregion

        /// <summary>
        /// The title of image
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The file name of the attachment
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The file size of the attachment
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// The thumbnail URL of this attachment
        /// </summary>
        public string ThumbnailUrl
        {
            get => _thumbnailUrl;
            set
            {
                //If value hasnt changed,return
                if(value == _thumbnailUrl)
                    return;

                //Update value
                _thumbnailUrl = value;

                //TODO

                LocalFilePath = "/Images/yume.jpg";
            }
        }

        /// <summary>
        /// The local file path of downloaded thumbnail
        /// </summary>
        public string LocalFilePath { get; set; }
    }
}