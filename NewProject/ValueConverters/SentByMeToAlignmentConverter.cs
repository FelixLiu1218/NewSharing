using System;
using System.Data;
using System.Globalization;
using System.Windows;

namespace NewProject
{
    //a converter that takes in i boolean if a message was sent by me,and aligns to the right
    //if not ,aligns to the left
    public class SentByMeToAlignmentConverter : BaseValueConverter<SentByMeToAlignmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool) value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NoNullAllowedException();
        }
    }
}
