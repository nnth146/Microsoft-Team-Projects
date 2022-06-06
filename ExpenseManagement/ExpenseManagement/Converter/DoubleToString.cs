using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UWP.Mvvm.Core.Converter
{
    public class DoubleToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencySymbol = "$";

            string result = String.Format(nfi, "{0:C}", value);

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string valueString = (string)value;
            return string.IsNullOrEmpty(valueString) ? 0 : Double.Parse(valueString);
        }
    }
}
