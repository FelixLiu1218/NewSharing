using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    /// <summary>
    /// a view model for a menu item
    /// </summary>
    public class MenuItemViewModel : BaseViewModel
    {
        /// <summary>
        /// the text to display for the menu item
        /// </summary>
        public string  Text { get; set; }


        /// <summary>
        /// the type of this menu item
        /// </summary>
        public MenuItemType Type { get; set; }
    }
}
