using System.Collections.Generic;

namespace Sharing
{
    /// <summary>
    /// The design-time data for a <see cref="SettingsViewModel"/>
    /// </summary>
    public class SettingsDesignModel : SettingsViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SettingsDesignModel Instance => new SettingsDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsDesignModel()
        {
            FirstName = new TextEntryViewModel { Label = "First Name", OriginalText = "Felix" };
            LastName = new TextEntryViewModel { Label = "Last Name", OriginalText = "Liu" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "Felix1218" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "pengfeiliu1218@gmail.com" };
        }

        #endregion
    }
}
