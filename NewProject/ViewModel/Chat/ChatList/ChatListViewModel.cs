using System.Collections.Generic;

namespace NewProject
{
    /// <summary>
    /// a view model for the overview chat list in the overview chat list
    /// </summary>
    public class ChatListViewModel:BaseViewModel
    {
        /// <summary>
        /// the cat list items for the list
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }


    }
}
