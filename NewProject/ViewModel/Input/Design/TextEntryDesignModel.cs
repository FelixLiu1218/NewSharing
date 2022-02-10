using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    /// <summary>
    /// The disign time data for a <see cref="TextEntryViewModel"/>
    /// </summary>
    public class TextEntryDesignModel : TextEntryViewModel
    {
        #region new instance

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static TextEntryDesignModel Instance => new TextEntryDesignModel();


        #endregion

        #region Constructor

        public TextEntryDesignModel()
        {
            Label = "Name";
            OriginalText = "Felix Liu";
            EditedText = "Editing";
        }

        #endregion
    }
}
