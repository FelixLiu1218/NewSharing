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
    public class MessageBoxDialogViewModel : BaseDialogViewModel
    {
        /// <summary>
        /// the message to display
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// the text to use for the OK button
        /// </summary>
        public string OKText { get; set; }
    }
}
