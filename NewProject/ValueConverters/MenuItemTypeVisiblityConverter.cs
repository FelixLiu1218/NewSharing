using System;
using System.Data;
using System.Globalization;
using System.Windows;
using NewProject.Core;

namespace NewProject
{
    public class MenuItemTypeVisiblityConverter : BaseValueConverter<MenuItemTypeVisiblityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if we have no parameter return invisible
            if (parameter == null)
                return Visibility.Collapsed;

            //try and convert parameter string to enum
            if(!Enum.TryParse(parameter as string, out MenuItemType type))
                return Visibility.Collapsed;

            //return visible if the parameter matches the type
            return (MenuItemType) value == type ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NoNullAllowedException();
        }
    }
}
