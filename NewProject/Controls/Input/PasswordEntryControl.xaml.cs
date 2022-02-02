using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace NewProject
{
    /// <summary>
    /// TextEntryControl.xaml 的互動邏輯
    /// </summary>
    public partial class PasswordEntryControl : UserControl
    {
        #region Constructor

        public PasswordEntryControl()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// The label width of the control
        /// </summary>
        public GridLength LabelWidth
        {
            get { return (GridLength)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(PasswordEntryControl), new PropertyMetadata(GridLength.Auto,LabelWidthChanged));

        #region Dependency Callback

        /// <summary>
        /// Called when the label width changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void LabelWidthChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (d as PasswordEntryControl).LabelColumnDefinition.Width =(GridLength)e.NewValue;
            }
            catch(Exception ex)
            {
                Debugger.Break();

                (d as PasswordEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        #endregion
        /// <summary>
        /// Update the view model value with the new password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.OriginalPassword = CurrentPassword.SecurePassword;
        }

        /// <summary>
        /// Update the view model value with the new password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.EditedPassword = NewPassword.SecurePassword;
        }

        /// <summary>
        /// Update the view model value with the new password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.ConfirmPassword = ConfirmPassword.SecurePassword;
        }
    }
}
