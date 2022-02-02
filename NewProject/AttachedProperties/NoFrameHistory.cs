using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NewProject
{
    /// <summary>
    /// the NoFrameHistory attached property for creating a FRAME that never shows navigation
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get the frame
            var frame = (sender as Frame);

            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            frame.Navigated += (ss, ee) => ((Frame) ss).NavigationService.RemoveBackEntry();
        }
    }
}
