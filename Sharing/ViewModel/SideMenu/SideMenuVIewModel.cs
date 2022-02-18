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
        public bool Loading { get; set; }

        public TextEntryViewModel Username { get; set; }

        public TextEntryViewModel OriginalText { get; set; }

        public SideMenuViewModel()
        {
            Username = new TextEntryViewModel
            {
                Label = "Username",
                OriginalText = "ViewModelTestName"
            };
        }

        public async Task LoadAsync()
        {
            await RunCommandAsync(() => Loading, async () =>
            {
                // Store single transient instance of client data store
                var scopedClientDataStore = ClientDataStore;

                // Update values from local cache
                await UpdateValuesFromLocalStoreAsync(scopedClientDataStore);

                // Get the user token
                var token = (await scopedClientDataStore.GetLoginCredentialsAsync())?.Token;

                // If we don't have a token (so we are not logged in...)
                if (string.IsNullOrEmpty(token))
                    // Then do nothing more
                    return;

                // Load user profile details form server
                var result = await WebRequests.PostAsync<ApiResponse<UserProfileDetailsApiModel>>(
                    // Set URL
                    RouteHelpers.GetAbsoluteRoute(ApiRoutes.GetUserProfile),
                    // Pass in user Token
                    bearerToken: token);

                // If the response has an error...
                if (await result.HandleErrorIfFailedAsync("Load User Details Failed"))
                    // We are done
                    return;


                // Create data model from the response
                var dataModel = result.ServerResponse.Response.ToLoginCredentialsDataModel();

                // Re-add our known token
                dataModel.Token = token;

                // Save the new information in the data store
                await scopedClientDataStore.SaveLoginCredentialsAsync(dataModel);

                // Update values from local cache
                await UpdateValuesFromLocalStoreAsync(scopedClientDataStore);
            });
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
