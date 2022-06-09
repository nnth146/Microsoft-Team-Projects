using Fluent.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Uwp.Core.Converter.StringToObject
{
    public class StringToFluentIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (FluentSymbol)Application.Current.Resources[value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
