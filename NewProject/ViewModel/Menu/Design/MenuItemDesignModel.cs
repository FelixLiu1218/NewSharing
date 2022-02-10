using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    /// <summary>
    /// the design time data for MenuItemViewModel
    /// </summary>
    public class MenuItemDesignModel : MenuItemViewModel
    {
        #region Instance

        public static MenuItemDesignModel Instance => new MenuItemDesignModel();

        #endregion

        #region Constructor

        public MenuItemDesignModel()
        {
            Text = "Hello!";
        }

        #endregion


    }
}
