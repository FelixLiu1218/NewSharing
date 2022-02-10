using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using NewProject.Core;
using static NewProject.DI;

namespace NewProject
{
    /// <summary>
    /// SettingsControl.xaml 的互動邏輯
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            // If we are in design mode...
            if (DesignerProperties.GetIsInDesignMode(this))
                // Create new instance of settings view model
                DataContext = new SettingsViewModel();
            else
                DataContext = ViewModelSettings;
        }
    }
}
