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
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);

        }

        private void MainWindow_OnDeactivated(object sender, EventArgs e)
        {
            // show overlay
            (DataContext as WindowViewModel).DimmableOverlayVisible=true;
        }

        private void MainWindow_OnActivated(object sender, EventArgs e)
        {
            //hide overlay if we are focused
            (DataContext as WindowViewModel).DimmableOverlayVisible = false;
        }
    }
}
