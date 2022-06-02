using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UWP.Mvvm.Core.Converter
{
    public class Int64ToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Int64 valueInt64 = (Int64)value;
            return valueInt64.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string valueString = (string)value;
            return string.IsNullOrEmpty(valueString) ? 0 : Int64.Parse(valueString);
        }
    }
}
