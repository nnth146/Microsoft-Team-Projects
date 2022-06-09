using Fluent.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Uwp.Core.Converter
{
    public class StringToFluentIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string valueString = (string)value;
            return (FluentSymbol)Application.Current.Resources[valueString];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
