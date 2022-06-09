using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace UWP.Core.Service
{
    public interface INavigationService
    {
        void GoBack();
        void GoForward();
        void GoBack(object subFrame);
        void GoBackToEnd();
        void GoBackToEnd(object subFrame);
        void GoForwardToEnd();
        void GoForwardToEnd(object subFrame);
        void GoForward(object subFrame);
        void Navigate(Type page);
        void Navigate(Type page, object parameter);
        void Navigate(object subFrame, Type page);
        void Navigate(object subFrame, Type page, object parameter);
        void NavigateOneTime(Type page);
        void NavigateOneTime(Type page, object parameter);
        void NavigateOneTime(object subFrame, Type page);
        void NavigateOneTime(object subFrame, Type page, object parameter);

        void GoBack(NavigationTransitionInfo animation);
        void GoBack(object subFrame, NavigationTransitionInfo animation);
        void GoBackToEnd(NavigationTransitionInfo animation);
        void GoBackToEnd(object subFrame, NavigationTransitionInfo animation);
        void Navigate(Type page, NavigationTransitionInfo animation);
        void Navigate(Type page, object parameter, NavigationTransitionInfo animation);
        void Navigate(object subFrame, Type page, NavigationTransitionInfo animation);
        void Navigate(object subFrame, Type page, object parameter, NavigationTransitionInfo animation);
        void NavigateOneTime(Type page, NavigationTransitionInfo animation);
        void NavigateOneTime(Type page, object parameter, NavigationTransitionInfo animation);
        void NavigateOneTime(object subFrame, Type page, NavigationTransitionInfo animation);
        void NavigateOneTime(object subFrame, Type page, object parameter, NavigationTransitionInfo animation);

        void GoBackWithoutSaving();
        void GoForwardWithoutSaving();
        void GoBackWithoutSaving(object subFrame);
        void GoBackToEndWithoutSaving();
        void GoBackToEndWithoutSaving(object subFrame);
        void GoForwardToEndWithoutSaving();
        void GoForwardToEndWithoutSaving(object subFrame);
        void GoForwardWithoutSaving(object subFrame);
        void NavigateWithoutSaving(Type page);
        void NavigateWithoutSaving(Type page, object parameter);
        void NavigateWithoutSaving(object subFrame, Type page);
        void NavigateWithoutSaving(object subFrame, Type page, object parameter);
        void NavigateOneTimeWithoutSaving(Type page);
        void NavigateOneTimeWithoutSaving(Type page, object parameter);
        void NavigateOneTimeWithoutSaving(object subFrame, Type page);
        void NavigateOneTimeWithoutSaving(object subFrame, Type page, object parameter);

        void GoBackWithoutSaving(NavigationTransitionInfo animation);
        void GoBackWithoutSaving(object subFrame, NavigationTransitionInfo animation);
        void GoBackToEndWithoutSaving(NavigationTransitionInfo animation);
        void GoBackToEndWithoutSaving(object subFrame, NavigationTransitionInfo animation);
        void NavigateWithoutSaving(Type page, NavigationTransitionInfo animation);
        void NavigateWithoutSaving(Type page, object parameter, NavigationTransitionInfo animation);
        void NavigateWithoutSaving(object subFrame, Type page, NavigationTransitionInfo animation);
        void NavigateWithoutSaving(object subFrame, Type page, object parameter, NavigationTransitionInfo animation);
        void NavigateOneTimeWithoutSaving(Type page, NavigationTransitionInfo animation);
        void NavigateOneTimeWithoutSaving(Type page, object parameter, NavigationTransitionInfo animation);
        void NavigateOneTimeWithoutSaving(object subFrame, Type page, NavigationTransitionInfo animation);
        void NavigateOneTimeWithoutSaving(object subFrame, Type page, object parameter, NavigationTransitionInfo animation);

        Dictionary<Type, Type> GetPages();
    }
}
