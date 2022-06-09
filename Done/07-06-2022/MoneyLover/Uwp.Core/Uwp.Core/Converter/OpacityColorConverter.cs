using System;
using System.Collections.Generic;
using Windows.UI;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using System.Diagnostics;

namespace Uwp.Core.Converter
{
    public class OpacityColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, string language)
        {
            Color convert = (Color)value; // Color is a struct, so we cast

            return Color.FromArgb(byte.Parse(parameter as string), convert.R, convert.G, convert.B);
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
