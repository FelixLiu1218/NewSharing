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
    public class BasePopupViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// the background color of the bubble in RGB value
        /// </summary>
        public string BubbleBackground { get; set; }


        /// <summary>
        /// the alignment of the bubble arrow
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        /// <summary>
        /// the content inside of this popup menu
        /// </summary>
        public BaseViewModel Content { get; set; }
        #endregion

        #region Constructor

        public BasePopupViewModel()
        {
            //set default values
            BubbleBackground = "#ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion
    }
}
