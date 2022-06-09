using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Uwp.Core.Converter
{
    public class DoubleToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Double valueDouble = (Double)value;
            return valueDouble.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string valueString = (string)value;
            return string.IsNullOrEmpty(valueString) ? 0 : Double.Parse(valueString);
        }
    }
}
