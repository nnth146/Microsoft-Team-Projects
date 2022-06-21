using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Core.Helper;
using Uwp.SQLite.Model;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Uwp.Core.Converter
{
    public class PriorityToColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Priority priority = (Priority)value;
            switch (priority)
            {
                case Priority.No: return CommonHelper.GetAppResources("NoColor") as Brush;
                case Priority.Low: return CommonHelper.GetAppResources("LowColor") as Brush;
                case Priority.Medium: return CommonHelper.GetAppResources("MediumColor") as Brush;
                default: return CommonHelper.GetAppResources("HighColor") as Brush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
