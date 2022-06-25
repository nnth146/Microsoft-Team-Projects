using Microsoft.UI.Xaml.Controls;
using PlanNotes.View.Dialog;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PlanNotes.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1200, 720);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            NavigationViewPlane.SelectedItem = NavigationViewPlane.MenuItems[0];

            AddNavigationItem();
        }

        private ObservableCollection<ExplorerItem> GetData()
        {
            var list = new ObservableCollection<ExplorerItem>();
            ExplorerItem folder1 = new ExplorerItem()
            {
                Name = "To day",
                Type = ExplorerItem.ExplorerItemType.Today,
                Children = new ObservableCollection<ExplorerItem>()
            };

            ExplorerItem folder2 = new ExplorerItem()
            {
                Name = "Tomorrow",
                Type = ExplorerItem.ExplorerItemType.Tomorrow,
                Children = new ObservableCollection<ExplorerItem>()
            };

            ExplorerItem folder3 = new ExplorerItem()
            {
                Name = "Next Week",
                Type = ExplorerItem.ExplorerItemType.NextWeek,
                Children = new ObservableCollection<ExplorerItem>()
            };

            ExplorerItem folder4 = new ExplorerItem()
            {
                Name = "Completed",
                Type = ExplorerItem.ExplorerItemType.Completed,
                Children = new ObservableCollection<ExplorerItem>()
            };

            ExplorerItem folder5 = new ExplorerItem()
            {
                Name = "Work Documents",
                Type = ExplorerItem.ExplorerItemType.Plane,
                Children =
                {
                    new ExplorerItem()
                    {
                        Name = "Feature Schedule",
                        Type = ExplorerItem.ExplorerItemType.Folder,
                    },
                    new ExplorerItem()
                    {
                        Name = "Overall Project Plan",
                        Type = ExplorerItem.ExplorerItemType.Folder,
                    },
                    new ExplorerItem()
                    {
                        Name = "Feature Resources Allocation",
                        Type = ExplorerItem.ExplorerItemType.Folder,
                    }
                }
            };

            ExplorerItem folder6 = new ExplorerItem()
            {
                Name = "Personal Folder",
                Type = ExplorerItem.ExplorerItemType.Plane,
                Children =
                    {
                        new ExplorerItem()
                        {
                            Name = "Home Remodel Folder",
                            Type = ExplorerItem.ExplorerItemType.Folder,
                        }
                    }
            };

            list.Add(folder1);
            list.Add(folder2);
            list.Add(folder3);
            list.Add(folder4);

            list.Add(folder5);
            list.Add(folder6);
            return list;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            /*ObservableCollection<ExplorerItem> list = GetData();
            NavigationViewPlane.MenuItemsSource = list;*/
        }

        private void SubFrame_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            /*SubFrame.Navigate(typeof(CompletedPage))*/
            ;
        }

        private async void AddFolder_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewAndEditNoteDialog addFolderDialog = new ViewAndEditNoteDialog();
            await addFolderDialog.ShowAsync();
        }

        private void NavigationViewPlane_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        }

        private void AddNavigationItem()
        {
            Microsoft.UI.Xaml.Controls.NavigationViewItem navigationViewItem = new Microsoft.UI.Xaml.Controls.NavigationViewItem();
            navigationViewItem.Content = "HAHA";
            BitmapImage bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Icon/Plane.png"));
            ImageIcon imageIcon = new ImageIcon();
            imageIcon.Source = bitmapImage;
            navigationViewItem.Icon = imageIcon;
            navigationViewItem.Tag = "Plan";

            Microsoft.UI.Xaml.Controls.NavigationViewItem navigationViewItem1 = new Microsoft.UI.Xaml.Controls.NavigationViewItem();
            navigationViewItem1.Content = "HAHA";
            BitmapImage bitmapImage1 = new BitmapImage(new Uri("ms-appx:///Assets/Icon/Folder.png"));
            ImageIcon imageIcon1 = new ImageIcon();
            imageIcon1.Source = bitmapImage1;
            navigationViewItem1.Icon = imageIcon1;
            navigationViewItem1.Tag = "Folder";

            navigationViewItem.MenuItems.Add(navigationViewItem1);
            NavigationViewPlane.MenuItems.Add(navigationViewItem);
        }

        private void NavigationViewPlane_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            Microsoft.UI.Xaml.Controls.NavigationViewItem navigationViewItem = args.SelectedItem as Microsoft.UI.Xaml.Controls.NavigationViewItem;
            switch (navigationViewItem.Tag)
            {
                case "Today":
                    SubFrame.Navigate(typeof(TodayPage));
                    break;
                case "Tomorrow":
                    SubFrame.Navigate(typeof(TomorrowPage));
                    break;
                case "NextWeek":
                    SubFrame.Navigate(typeof(NextWeekPage));
                    break;
                case "Completed":
                    SubFrame.Navigate(typeof(CompletedPage));
                    break;
                case "Plan":
                    SubFrame.Navigate(typeof(PlanePage));
                    break;
                default:
                    SubFrame.Navigate(typeof(FolderPage));
                    break;
            }
        }
    }

    public class ExplorerItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public enum ExplorerItemType { Today, Tomorrow, NextWeek, Completed, Plane, Folder };
        public ExplorerItemType Type { get; set; }
        public string Name { get; set; }

        public string Icon
        {
            get
            {
                string icon = "";
                if (Type == ExplorerItemType.Today)
                {
                    icon = "ms-appx:///Assets/Icon/Today.png";
                }
                else if (Type == ExplorerItemType.Tomorrow)
                {
                    icon = "ms-appx:///Assets/Icon/Tomorrow.png";
                }
                else if (Type == ExplorerItemType.NextWeek)
                {
                    icon = "ms-appx:///Assets/Icon/NextWeek.png";
                }
                else if (Type == ExplorerItemType.Completed)
                {
                    icon = "ms-appx:///Assets/Icon/Completed.png";
                }
                else if (Type == ExplorerItemType.Plane)
                {
                    icon = "ms-appx:///Assets/Icon/Plane.png";
                }
                else
                {
                    icon = "ms-appx:///Assets/Icon/Folder.png";
                }
                return icon;
            }
        }

        private ObservableCollection<ExplorerItem> m_children;
        public ObservableCollection<ExplorerItem> Children
        {
            get
            {
                if (m_children == null)
                {
                    m_children = new ObservableCollection<ExplorerItem>();
                }
                return m_children;
            }
            set
            {
                m_children = value;
            }
        }

        private bool m_isExpanded;
        public bool IsExpanded
        {
            get { return m_isExpanded; }
            set
            {
                if (m_isExpanded != value)
                {
                    m_isExpanded = value;
                    NotifyPropertyChanged("IsExpanded");
                }
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}