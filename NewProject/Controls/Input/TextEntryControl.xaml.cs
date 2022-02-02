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

namespace NewProject
{
    /// <summary>
    /// TextEntryControl.xaml 的互動邏輯
    /// </summary>
    public partial class TextEntryControl : UserControl
    {
        #region Constructor

        public TextEntryControl()
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
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(TextEntryControl), new PropertyMetadata(GridLength.Auto,LabelWidthChanged));

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
                (d as TextEntryControl).LabelColumnDefinition.Width =(GridLength)e.NewValue;
            }
            catch(Exception ex)
            {
                Debugger.Break();

                (d as TextEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        #endregion
    }
}
