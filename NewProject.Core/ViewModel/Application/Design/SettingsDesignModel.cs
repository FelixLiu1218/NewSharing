using System.Collections.Generic;

namespace NewProject.Core
{
    public class SettingsDesignModel : SettingsViewModel
    {
        #region new instance

        /// <summary>
        /// a single instance of the design model
        /// </summary>
        public static SettingsDesignModel Instance => new SettingsDesignModel();


        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsDesignModel()
        {
            Name = new TextEntryViewModel
            {
                Label = "Name",
                OriginalText = "Felix Liu"
            };
            Username = new TextEntryViewModel
            {
                Label = "Username",
                OriginalText = "Felix"
            };
            Password = new PasswordEntryViewModel()
            {
                Label = "Password",
                FakePassword = "********"
            };
            Email = new TextEntryViewModel
            {
                Label = "Email",
                OriginalText = "pengfeiliu1218@gmail.com"
            };
        }

        #endregion

    }
}
