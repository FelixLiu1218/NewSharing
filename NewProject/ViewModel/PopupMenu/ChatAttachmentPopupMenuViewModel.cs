using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using NewProject.Core;

namespace NewProject
{
    /// <summary>
    /// a view model for any popup menus
    /// </summary>
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel
    {

        #region Public Properties

        

        #endregion


        #region Constructor

        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel
                    {
                        Type = MenuItemType.Header,
                        Text = "Attach a File"
                    },
                    new MenuItemViewModel
                    {
                        Text = "From Computer",
                    },
                    new MenuItemViewModel
                    {
                        Text = "From Pictures",
                    },
                })
            };
        }

        #endregion
    }
}
