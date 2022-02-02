using System;

namespace NewProject.Core
{
    /// <summary>
    /// the application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// the current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Chat;

        /// <summary>
        /// the view model to use for the current page when the CurrentPage changes
        /// This is not a live up-to-date view model of the current page
        /// it is simply used to set the view mode lof the current page
        /// at the time it changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        public bool SideMenuVisible { get; set; } = true;

        /// <summary>
        /// True if the settings menu should be shown
        /// </summary>
        public bool SettingsMenuVisible { get; set; }

        /// <summary>
        /// navigated to the specified page
        /// </summary>
        /// <param name="chat"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            SettingsMenuVisible = false;
            //set the view model
            CurrentPageViewModel = viewModel;

            

            //set the current page
            CurrentPage = page;

            //Fire off a currentpage changed event
            OnPropertyChanged(nameof(CurrentPage));

            //show SideMenu or not
            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
