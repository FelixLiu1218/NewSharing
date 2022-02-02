using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace NewProject
{
    /// <summary>
    /// Focuses (keyboard focus) this element on load
    /// </summary>
    public class ScrollToBottomOnLoadProperty : BaseAttachedProperty<ScrollToBottomOnLoadProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(sender))
                return;

            // If we don't have a control, return
            if (!(sender is ScrollViewer control))
                return;

            // Focus this control once loaded
            control.DataContextChanged -= Control_DataContextChanged;
            control.DataContextChanged += Control_DataContextChanged;
        }

        private void Control_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as ScrollViewer).ScrollToBottom();
        }
    }

    /// <summary>
    /// keep scroll to bottom when something were created
    /// </summary>
    public class ScrollToBottomProperty : BaseAttachedProperty<ScrollToBottomProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(sender))
                return;

            // If we don't have a control, return
            if (!(sender is ScrollViewer control))
                return;

            // Scroll content to bottom
            control.ScrollChanged -= Control_ScrollChanged;
            control.ScrollChanged += Control_ScrollChanged;
        }

        private void Control_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;

            if(scroll.ScrollableHeight- scroll.VerticalOffset < 20)
                scroll.ScrollToBottom();
        }
    }
}
