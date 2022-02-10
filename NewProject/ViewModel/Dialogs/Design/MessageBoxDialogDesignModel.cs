using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    /// <summary>
    /// details for a message box dialog
    /// </summary>
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {
        #region new instance

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();


        #endregion

        #region Constructor

        public MessageBoxDialogDesignModel()
        {
            Message = "Design Time Message";
            OKText = "OK";
        }

        #endregion
    }
}
