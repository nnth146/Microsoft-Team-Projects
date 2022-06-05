using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Uwp.Core.Service
{
    public class NavigationService : INavigationService
    {
        private Dictionary<Type, Type> _pages;
        public Dictionary<Type, Type> Pages => _pages ?? (_pages = new Dictionary<Type, Type>());
        private Frame _frame;
        public Frame Frame => _frame ?? (_frame = Window.Current.Content as Frame);
        public NavigationService(Dictionary<Type, Type> pages)
        {
            _pages = pages;
        }
        public void GoBack()
        {
            Frame.IsNavigationStackEnabled = true;
            if(Frame.CanGoBack) Frame.GoBack();
        }

        public void GoBack(object subFrame)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = true;
            if(frame.CanGoBack) frame.GoBack();
        }

        public void GoForward()
        {
            Frame.IsNavigationStackEnabled = true;
            if(Frame.CanGoForward) Frame.GoForward();
        }

        public void GoForward(object subFrame)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = true;
            if(frame.CanGoForward) frame.GoForward();
        }

        public void Navigate(Type page, object parameter)
        {
            Frame.IsNavigationStackEnabled = true;
            Frame.Navigate(_pages[page], parameter);
        }

        public void Navigate(object subFrame, Type page, object parameter)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = true;
            frame.Navigate(_pages[page], parameter);
        }

        public void Navigate(Type page)
        {
            Frame.IsNavigationStackEnabled = true;
            Frame.Navigate(_pages[page]);
        }

        public void Navigate(object subFrame, Type page)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = true;
            frame.Navigate(_pages[page]);
        }

        public Dictionary<Type, Type> GetPages()
        {
            return _pages;
        }

        public void NavigateOneTime(Type page, object parameter)
        {
            if (Frame.Content.GetType() == _pages[page]) return;
            Frame.IsNavigationStackEnabled = true;
            Frame.Navigate(_pages[page], parameter);
        }

        public void NavigateOneTime(object subFrame, Type page, object parameter)
        {
            Frame frame = (Frame)subFrame;
            if (frame.Content.GetType() == _pages[page]) return;
            frame.IsNavigationStackEnabled = true;
            frame.Navigate(_pages[page], parameter);
        }

        public void NavigateOneTime(Type page)
        {
            if (Frame.Content.GetType() == _pages[page]) return;
            Frame.IsNavigationStackEnabled = true;
            Frame.Navigate(_pages[page]);
        }

        public void NavigateOneTime(object subFrame, Type page)
        {
            Frame frame = (Frame)subFrame;
            if (frame.Content.GetType() == _pages[page]) return;
            frame.IsNavigationStackEnabled = true;
            frame.Navigate(_pages[page]);
        }

        public void GoBackToEnd()
        {
            Frame.IsNavigationStackEnabled = true;
            while (Frame.CanGoBack)
            {
                Frame.GoBack(null);
            }
        }

        public void GoBackToEnd(object subFrame)
        {
            Frame frame = subFrame as Frame;
            frame.IsNavigationStackEnabled = true;
            while (frame.CanGoBack)
            {
                frame.GoBack(null);
            }
        }

        public void GoForwardToEnd()
        {
            Frame.IsNavigationStackEnabled = true;
            while (Frame.CanGoForward)
            {
                Frame.GoBack(null);
            }
        }

        public void GoForwardToEnd(object subFrame)
        {
            Frame frame = subFrame as Frame;
            frame.IsNavigationStackEnabled = true;
            while (frame.CanGoForward)
            {
                frame.GoBack(null);
            }
        }

        public void GoBack(NavigationTransitionInfo animation)
        {
            Frame.IsNavigationStackEnabled = true;
            if(Frame.CanGoBack) Frame.GoBack(animation);
        }

        public void GoBack(object subFrame, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = true;
            if(frame.CanGoBack) frame.GoBack(animation);
        }

        public void GoBackToEnd(NavigationTransitionInfo animation)
        {
            Frame.IsNavigationStackEnabled = true;
            while (Frame.CanGoBack)
            {
                Frame.GoBack(animation);
            }
        }

        public void GoBackToEnd(object subFrame, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = true;
            while (Frame.CanGoBack)
            {
                Frame.GoBack(animation);
            }
        }

        public void Navigate(Type page, NavigationTransitionInfo animation)
        {
            Frame.IsNavigationStackEnabled = true;
            Frame.Navigate(_pages[page], null, animation);
        }

        public void Navigate(Type page, object parameter, NavigationTransitionInfo animation)
        {
            Frame.IsNavigationStackEnabled = true;
            Frame.Navigate(_pages[page], parameter, animation);
        }

        public void Navigate(object subFrame, Type page, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = true;
            frame.Navigate(_pages[page], null, animation);
        }

        public void Navigate(object subFrame, Type page, object parameter, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = true;
            frame.Navigate(_pages[page], parameter, animation);
        }

        public void NavigateOneTime(Type page, NavigationTransitionInfo animation)
        {
            if (Frame.Content.GetType() == _pages[page]) return;
            Frame.IsNavigationStackEnabled = true;
            Frame.Navigate(_pages[page], null, animation);
        }

        public void NavigateOneTime(Type page, object parameter, NavigationTransitionInfo animation)
        {
            if (Frame.Content.GetType() == _pages[page]) return;
            Frame.IsNavigationStackEnabled = true;
            Frame.Navigate(_pages[page], parameter, animation);
        }

        public void NavigateOneTime(object subFrame, Type page, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            if (frame.Content.GetType() == _pages[page]) return;
            frame.IsNavigationStackEnabled = true;
            frame.Navigate(_pages[page], null, animation);
        }

        public void NavigateOneTime(object subFrame, Type page, object parameter, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            if (frame.Content.GetType() == _pages[page]) return;
            frame.IsNavigationStackEnabled = true;
            frame.Navigate(_pages[page], parameter, animation);
        }

        public void GoBackWithoutSaving()
        {
            Frame.IsNavigationStackEnabled = false;
            if(Frame.CanGoBack) Frame.GoBack();
        }

        public void GoForwardWithoutSaving()
        {
            Frame.IsNavigationStackEnabled = false;
            if(Frame.CanGoForward) Frame.GoForward();
        }

        public void GoBackWithoutSaving(object subFrame)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = false;
            if(frame.CanGoBack) frame.GoBack();
        }

        public void GoBackToEndWithoutSaving()
        {
            Frame.IsNavigationStackEnabled = false;
            while (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        public void GoBackToEndWithoutSaving(object subFrame)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = false;
            while (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        public void GoForwardToEndWithoutSaving()
        {
            Frame.IsNavigationStackEnabled = false;
            while (Frame.CanGoForward)
            {
                Frame.GoForward();
            }
        }

        public void GoForwardToEndWithoutSaving(object subFrame)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = false;
            while (frame.CanGoForward)
            {
                frame.GoForward();
            }
        }

        public void GoForwardWithoutSaving(object subFrame)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = false;
            if(frame.CanGoForward) frame.GoForward();
        }

        public void NavigateWithoutSaving(Type page)
        {
            Frame.IsNavigationStackEnabled = false;
            Frame.Navigate(_pages[page]);
        }

        public void NavigateWithoutSaving(Type page, object parameter)
        {
            Frame.IsNavigationStackEnabled = false;
            Frame.Navigate(_pages[page], parameter);
        }

        public void NavigateWithoutSaving(object subFrame, Type page)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = false;
            frame.Navigate(_pages[page]);
        }

        public void NavigateWithoutSaving(object subFrame, Type page, object parameter)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = false;
            frame.Navigate(_pages[page], parameter);
        }

        public void NavigateOneTimeWithoutSaving(Type page)
        {
            if (Frame.Content.GetType() == _pages[page]) return;
            Frame.IsNavigationStackEnabled = false;
            Frame.Navigate(_pages[page]);
        }

        public void NavigateOneTimeWithoutSaving(Type page, object parameter)
        {
            if (Frame.Content.GetType() == _pages[page]) return;
            Frame.IsNavigationStackEnabled = false;
            Frame.Navigate(_pages[page], parameter);
        }

        public void NavigateOneTimeWithoutSaving(object subFrame, Type page)
        {
            Frame frame = (Frame)subFrame;
            if (frame.Content.GetType() == _pages[page]) return;
            frame.IsNavigationStackEnabled = false;
            frame.Navigate(_pages[page]);
        }

        public void NavigateOneTimeWithoutSaving(object subFrame, Type page, object parameter)
        {
            Frame frame = (Frame)subFrame;
            if (frame.Content.GetType() == _pages[page]) return;
            frame.IsNavigationStackEnabled = false;
            frame.Navigate(_pages[page], parameter);
        }

        public void GoBackWithoutSaving(NavigationTransitionInfo animation)
        {
            Frame.IsNavigationStackEnabled = false;
            if(Frame.CanGoBack) Frame.GoBack(animation);
        }

        public void GoBackWithoutSaving(object subFrame, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = false;
            if(frame.CanGoBack) frame.GoBack(animation);
        }

        public void GoBackToEndWithoutSaving(NavigationTransitionInfo animation)
        {
            Frame.IsNavigationStackEnabled = false;
            while (Frame.CanGoBack)
            {
                Frame.GoBack(animation);
            }
        }

        public void GoBackToEndWithoutSaving(object subFrame, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = false;
            while (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }


        public void NavigateWithoutSaving(Type page, NavigationTransitionInfo animation)
        {
            Frame.IsNavigationStackEnabled = false;
            Frame.Navigate(_pages[page], null, animation);
        }

        public void NavigateWithoutSaving(Type page, object parameter, NavigationTransitionInfo animation)
        {
            Frame.IsNavigationStackEnabled = false;
            Frame.Navigate(_pages[page], parameter, animation);
        }

        public void NavigateWithoutSaving(object subFrame, Type page, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = false;
            frame.Navigate(_pages[page], null, animation);
        }

        public void NavigateWithoutSaving(object subFrame, Type page, object parameter, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            frame.IsNavigationStackEnabled = false;
            frame.Navigate(_pages[page], parameter, animation);
        }

        public void NavigateOneTimeWithoutSaving(Type page, NavigationTransitionInfo animation)
        {
            if (Frame.Content.GetType() == _pages[page]) return;
            Frame.IsNavigationStackEnabled = false;
            Frame.Navigate(_pages[page], null, animation);
        }

        public void NavigateOneTimeWithoutSaving(Type page, object parameter, NavigationTransitionInfo animation)
        {
            if (Frame.Content.GetType() == _pages[page]) return;
            Frame.IsNavigationStackEnabled = false;
            Frame.Navigate(_pages[page], parameter, animation);
        }

        public void NavigateOneTimeWithoutSaving(object subFrame, Type page, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            if (frame.Content.GetType() == _pages[page]) return;
            frame.IsNavigationStackEnabled = false;
            frame.Navigate(_pages[page], null, animation);
        }

        public void NavigateOneTimeWithoutSaving(object subFrame, Type page, object parameter, NavigationTransitionInfo animation)
        {
            Frame frame = (Frame)subFrame;
            if (frame.Content.GetType() == _pages[page]) return;
            frame.IsNavigationStackEnabled = false;
            frame.Navigate(_pages[page], parameter, animation);
        }
    }
}
