using System;
using System.Data;
using System.Globalization;
using System.Windows;

namespace NewProject
{
    public class BooleanToCollapsedConverter : BaseValueConverter<BooleanToCollapsedConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter == null)
                return (bool) value ? Visibility.Visible : Visibility.Collapsed;
            else
            {
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
        }


        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NoNullAllowedException();
        }
    }
}
