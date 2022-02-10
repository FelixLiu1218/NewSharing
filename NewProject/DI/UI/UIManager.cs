using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NewProject.Core;

namespace NewProject
{
    /// <summary>
    /// The application implementation of the <see cref="IUIManager"/>
    /// </summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Display a single message box to the user
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            //return new DialogMessageBox().ShowDialog(viewModel);

            // Create a task completion source
            var tcs = new TaskCompletionSource<bool>();

            // Run on UI thread
            Application.Current.Dispatcher.Invoke(async () =>
            {
                try
                {
                    // Show the dialog box
                    await new DialogMessageBox().ShowDialog(viewModel);
                }
                finally
                {
                    // Flag we are done
                    tcs.SetResult(true);
                }
            });

            // Return the task once complete
            return tcs.Task;
        }
    }
}
