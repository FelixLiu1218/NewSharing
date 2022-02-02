using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using NewProject.Core;

namespace NewProject
{
    public static class ApplicationPageHelpers
    {
        /// <summary>
        /// Takes a ApplicationPage and a view model,creates the desired page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage page,object viewModel = null)
        {
            //find the appropriate page
            switch (page)
            {
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);
                case ApplicationPage.Chat:
                    return new ChatPage(viewModel as ChatMessageListViewModel);
                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);
                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Converts a BasePage to the specific ApplicationPage
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            if (page is ChatPage)
                return ApplicationPage.Chat;

            if (page is LoginPage)
                return ApplicationPage.Login;

            if (page is RegisterPage)
                return ApplicationPage.Register;

            Debugger.Break();
            return default(ApplicationPage);
        }
    }
}
