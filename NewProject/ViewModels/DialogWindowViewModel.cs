using NewProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NewProject
{
    public class DialogWindowViewModel :WindowViewModel
    {
        #region public Properties

        public string Title { get; set; }

        /// <summary>
        /// The content to host inside the dialog
        /// </summary>
        public Control Content { get; set; }

        #endregion

        #region Constructor

        public DialogWindowViewModel(Window window) : base(window)
        {
            
        }

        #endregion
    }
}