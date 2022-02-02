using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewProject.Core;
using Ninject;

namespace NewProject
{
    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //find the appropriate page
            switch ((string)parameter)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Get<ApplicationViewModel>();
                default:
                    Debugger.Break();
                    return null;
            }
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
