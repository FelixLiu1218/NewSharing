using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NewProject
{
    /// <summary>
    /// the NoFrameHistory attached property for creating a FRAME that never shows navigation
    /// </summary>
    public class PanelChildMarginProperty : BaseAttachedProperty<PanelChildMarginProperty, string>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get the Panel
            var panel = (sender as Panel);

            //Wait for panel to load
            panel.Loaded += (s, ee) =>
            {
                // Loop each child
                foreach (var VARIABLE in panel.Children)
                {
                    (VARIABLE as FrameworkElement).Margin =
                        (Thickness) (new ThicknessConverter().ConvertFromString(e.NewValue as string));
                }
            };
        }
    }
}
