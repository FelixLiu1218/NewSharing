using System;
using System.Data;
using System.Globalization;
using System.Windows;

namespace NewProject
{
    public class BooleanInvertConverter : BaseValueConverter<BooleanInvertConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool) value;



        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NoNullAllowedException();
    }
}
