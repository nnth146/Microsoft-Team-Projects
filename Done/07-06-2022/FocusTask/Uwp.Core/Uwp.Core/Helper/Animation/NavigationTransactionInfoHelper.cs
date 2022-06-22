using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace Uwp.Core.Helper
{
    public class NavigationTransactionInfoHelper
    {
        //Cần thêm mô tả
        public static NavigationTransitionInfo EntranceTransition => new EntranceNavigationTransitionInfo();

        //Cần thêm mô tả
        public static NavigationTransitionInfo DrillInTransition => new DrillInNavigationTransitionInfo();

        //Cần thêm mô tả
        public static NavigationTransitionInfo SuppressTransaction => new SuppressNavigationTransitionInfo();
    }
}
