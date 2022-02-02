﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Core
{
    /// <summary>
    /// a view model for a menu
    /// </summary>
    public class MenuViewModel : BaseViewModel
    {
        /// <summary>
        /// the item in this menu
        /// </summary>
        public List<MenuItemViewModel> Items { get; set; }
    }
}
