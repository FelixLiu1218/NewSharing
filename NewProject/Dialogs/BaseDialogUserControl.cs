using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NewProject.Core;

namespace NewProject
{
    /// <summary>
    /// The base class for any content that is being used inside of a <see cref="DialogWindow"/>
    /// </summary>
    public  class BaseDialogUserControl :UserControl
    {
        #region Private Members

        private DialogWindow _dialogWindow;


        #endregion

        #region Public Properties

        /// <summary>
        /// The title for the dialog
        /// </summary>
        public string Title { get; set; }

        #endregion


        #region Public Commands

        /// <summary>
        /// Close the dialog
        /// </summary>
        public ICommand Close { get; private set; }


        #endregion

        #region Constructor

        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                _dialogWindow = new DialogWindow();
                _dialogWindow.ViewModel = new DialogWindowViewModel(_dialogWindow);

                Close = new RelayCommand(() => _dialogWindow.Close());
            }
            
        }

        #endregion

        #region Dialog Methods

        /// <summary>
        /// Display a single message box to the user
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel)
        where T:BaseDialogViewModel
        {
            //create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    _dialogWindow.ViewModel.Title = viewModel.Title;

                    //set this control to the dialog window content
                    _dialogWindow.ViewModel.Content = this;

                    //Setup this controls data context binding to the view model
                    DataContext = viewModel;

                    //create the owner
                    _dialogWindow.Owner = Application.Current.MainWindow;

                    //Show in the center of the parent
                    _dialogWindow.WindowStartupLocation  = WindowStartupLocation.CenterOwner;

                    //show dialog
                    _dialogWindow.ShowDialog();
                }
                finally
                {
                    //let caller know me finished
                    tcs.TrySetResult(true);
                }

            });

            return tcs.Task;
        }

        #endregion
    }
}
