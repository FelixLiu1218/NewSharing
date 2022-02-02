using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NewProject
{
    /// <summary>
    /// Match the label width of all text entry controls inside this panel
    /// </summary>
    public class TextEntryWidthProperty : BaseAttachedProperty<TextEntryWidthProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //get the Panel
            var panel = (sender as Panel);

            //Call setwidth
            SetWidth(panel);

            RoutedEventHandler onLoaded = null;

            onLoaded = (s, ee) =>
            {
                //Unhook
                panel.Loaded -= onLoaded;

                //Set width
                SetWidth(panel);

                // Loop each child
                foreach (var VARIABLE in panel.Children)
                {
                    //Ignore any non-text entry controls
                    if(!(VARIABLE is TextEntryControl control))
                        continue;

                    control.Label.SizeChanged += (ss, eee) =>
                    {
                        SetWidth(panel);
                    };
                }
            };

            //Hook into the loaded event
            panel.Loaded += onLoaded;
        }

        /// <summary>
        /// Update all text entry controls width
        /// </summary>
        private void SetWidth(Panel panel)
        {
            var maxSize = 0d;

            foreach (var VARIABLE in panel.Children)
            {
                //Ignore non-text entry controls
                if(!(VARIABLE is TextEntryControl control))
                    continue;

                //Find if this control is larger than the other controls
                maxSize = Math.Max(maxSize,
                    control.Label.RenderSize.Width + control.Label.Margin.Left + control.Label.Margin.Right);
            }

            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());

            foreach (var VARIABLE in panel.Children)
            {
                //Ignore non-text entry controls
                if (!(VARIABLE is TextEntryControl control))
                    continue;

                //Set each controls width to max size
                control.LabelWidth = gridLength;
            }
        }
    }
}
