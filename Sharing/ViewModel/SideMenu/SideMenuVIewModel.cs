using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dna;
using Sharing.Core;
using static Sharing.DI;
using static Dna.FrameworkDI;

namespace Sharing
{
    public class SideMenuViewModel : BaseViewModel
    {
        public ICommand LoadCommand { get; set; }

        public TextEntryViewModel Username { get; set; }

        public SideMenuViewModel()
        {
            Username = new TextEntryViewModel
            {
                Label = "Username",
                OriginalText = "ViewModelTestName"
            };

            LoadCommand = new RelayCommand(async () => await LoadAsync());
        }

        public async Task LoadAsync()
        {
            // Store single transient instance of client data store
            var scopedClientDataStore = ClientDataStore;

            // Get the user token
            var token = (await scopedClientDataStore.GetLoginCredentialsAsync())?.Token;

            // If we don't have a token (so we are not logged in...)
            if (string.IsNullOrEmpty(token))
                // Then do nothing more
                return;

            // Load user profile details from server
            var result =await WebRequests.PostAsync<ApiResponse<UserProfileDetailsApiModel>>(
                // Set URL
                RouteHelpers.GetAbsoluteRoute(ApiRoutes.GetUserProfile),
                // Pass in user Token
                bearerToken: token);



            // Create data model from the response
            var dataModel =result.ServerResponse.Response.ToLoginCredentialsDataModel();

            // Re-add our known token
            dataModel.Token = token;

            // Save the new information in the data store
            await scopedClientDataStore.SaveLoginCredentialsAsync(dataModel);

            // Update values from local cache
            await UpdateValuesFromLocalStoreAsync(scopedClientDataStore);
        }

        #region Private Helper Methods

        /// <summary>
        /// Loads the settings from the local data store and binds them 
        /// to this view model
        /// </summary>
        /// <returns></returns>
        private async Task UpdateValuesFromLocalStoreAsync(IClientDataStore clientDataStore)
        {
            // Get the stored credentials
            var storedCredentials = await clientDataStore.GetLoginCredentialsAsync();

            // Set username
            Username.OriginalText = storedCredentials?.Username;
        }

        #endregion
    }
}
