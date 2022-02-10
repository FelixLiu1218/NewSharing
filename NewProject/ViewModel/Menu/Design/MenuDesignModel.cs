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
    public class MenuDesignModel : MenuViewModel
    {

        #region Instance

        public static MenuDesignModel Instance => new MenuDesignModel();

        #endregion


        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel> (new[]
            {
                new MenuItemViewModel
                {
                    Type = MenuItemType.Header,
                    Text = "Design time header"
                },
                new MenuItemViewModel
                {
                    Text = "menu item 1",
                },
                new MenuItemViewModel
                {
                    Text = "menu item 2",
                },
            });
        }
    }
}
