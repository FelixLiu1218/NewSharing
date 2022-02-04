using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewProject
{
    /// <summary>
    /// the NoFrameHistory attached property for creating a FRAME that never shows navigation
    /// </summary>
    public class ClipFromBorderProperties : BaseAttachedProperty<ClipFromBorderProperties, bool>
    {
        /// <summary>
        /// Called when the border load
        /// </summary>
        private RoutedEventHandler _border_Loaded;

        /// <summary>
        /// Called when the border size change
        /// </summary>
        private SizeChangedEventHandler _border_Changed;

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get the frame
            var self = (sender as FrameworkElement);

            if (!(self.Parent is Border border))
                return;

            _border_Loaded = (s, ee) => Border_OnChange(s, ee,self);

            _border_Changed = (s, ee) => Border_OnChange(s, ee,self);

            //True,hook into events
            if ((bool) e.NewValue)
            {
                border.Loaded += _border_Loaded;
                border.SizeChanged += _border_Changed;
            }
            else
            {
                border.Loaded -= _border_Loaded;
                border.SizeChanged -= _border_Changed;
            }
        }

        /// <summary>
        /// when the border is loaded, then call this one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_OnChange(object sender, RoutedEventArgs e,FrameworkElement child)
        {
            var border = (Border) sender;

            //if the actual size doesn't exist return false
            if (border.ActualWidth == 0 && border.ActualHeight == 0)
                return;


            var rect = new RectangleGeometry();

            //Match the corner radius with the border corner radius
            rect.RadiusX = rect.RadiusY =
                Math.Max(0, border.CornerRadius.TopLeft - (border.BorderThickness.Left * 0.5));

            //Set rectangle size to child's actual size
            rect.Rect = new Rect(child.RenderSize);

            //Assign clipping area to the child
            child.Clip = rect;
        }
    }
}
