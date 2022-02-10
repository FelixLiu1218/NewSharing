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
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {
        #region new instance

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();


        #endregion

        #region Constructor

        public PasswordEntryDesignModel()
        {
            Label = "Name";
            FakePassword = "********";
        }

        #endregion
    }
}
