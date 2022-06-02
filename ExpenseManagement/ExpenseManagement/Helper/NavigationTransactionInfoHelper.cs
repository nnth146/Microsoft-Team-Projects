using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace Uwp.Mvvm.Core.Helper
{
    public class NavigationTransactionInfoHelper
    {
        public static NavigationTransitionInfo EntranceTransition => new EntranceNavigationTransitionInfo();
        public static NavigationTransitionInfo DrillInTransition => new DrillInNavigationTransitionInfo();
        public static NavigationTransitionInfo SuppressTransaction => new SuppressNavigationTransitionInfo();
    }
}
