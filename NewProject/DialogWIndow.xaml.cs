using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using NewProject.Core;

namespace NewProject
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class DialogWindow : Window
    {
        /// <summary>
        /// The view model for this window
        /// </summary>
        #region Private Memberes

        private DialogWindowViewModel _viewModel;

        #endregion

        #region Public Properties

        public DialogWindowViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                //set new value
                _viewModel =value;

                //Update data context
                DataContext = _viewModel;
            }
        }

        #endregion


        #region Constructor

        public DialogWindow()
        {
            InitializeComponent();
        }

        #endregion


    }
}
