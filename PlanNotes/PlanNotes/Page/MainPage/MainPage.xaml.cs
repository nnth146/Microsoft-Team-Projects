using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml.Controls;
using PlanNotes.View.Dialog;
using PlanNotes.ViewModel;
using System;
using System.Collections.ObjectModel;
using Uwp.Messenger;
using Uwp.SQLite.Model;
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
            mainPage = DataContext as MainPageViewModel;
            WeakReferenceMessenger.Default.Register<PlansRequestMessage>(this, (r, m) =>
            {
                m.Reply(mainPage.Plans);
            });
            mainPage.Plans.CollectionChanged += Plans_CollectionChanged;
            GetValue();
            for (int i = 0; i < mainPage.Plans.Count; i++)
            {
                mainPage.Plans[i].PlanFolders.CollectionChanged += PlanFolders_CollectionChanged;
            }
            SelectedPlan = false;
            IsEnabledAddFolder();
            WeakReferenceMessenger.Default.Register<MPFrameRequestMessage>(this, (r, m) =>
            {
                m.Reply(SubFrame);
            });
        }

        private void PlanFolders_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Folder folder = (Folder)e.NewItems[0];
                AddNaviFolder(folder.Plan, folder);
            }
        }

        private void AddNaviFolder(Plan plan, Folder folder)
        {
            if (plan != null)
            {
                Microsoft.UI.Xaml.Controls.NavigationViewItem navigationViewItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)NavigationViewPlane.MenuItems[plan.PlanId + 4];
                Microsoft.UI.Xaml.Controls.NavigationViewItem navigationViewItem1 = new Microsoft.UI.Xaml.Controls.NavigationViewItem();
                navigationViewItem1.Content = folder.FolderName;
                BitmapImage bitmapImage1 = new BitmapImage(new Uri("ms-appx:///Assets/Icon/Folder.png"));
                ImageIcon imageIcon1 = new ImageIcon();
                imageIcon1.Source = bitmapImage1;
                navigationViewItem1.Icon = imageIcon1;
                navigationViewItem1.Tag = "Folder";
                navigationViewItem.MenuItems.Add(navigationViewItem1);
            }
        }

        private void IsEnabledAddFolder()
        {
            if (SelectedPlan)
            {
                IconAddFolder1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                IconAddFolder2.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                IconAddFolder2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                IconAddFolder1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            AddFolder.IsEnabled = SelectedPlan;
        }

        private void Plans_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                AddNavigationItem(e.NewItems[0] as Plan);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {

            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
            }
            for (int i = 0; i < mainPage.Plans.Count; i++)
            {
                mainPage.Plans[i].PlanFolders.CollectionChanged += PlanFolders_CollectionChanged;
            }
        }

        public MainPageViewModel mainPage { get; set; }
        public bool SelectedPlan { get; set; }
        public Folder ChangeItemFolder { get; set; }

        private void GetValue()
        {
            if (mainPage != null)
            {
                if (mainPage.Plans.Count == 0)
                {
                    Plan Plan = new Plan();
                    Plan.PlanName = "Hello World";
                    Plan.PlanFolders = new ObservableCollection<Folder>();
                    Plan.PlanCreate_On = DateTime.Now.ToLocalTime();
                    mainPage.dataService.AddNewPlan(Plan);
                    mainPage.dataService.SaveChanges();
                    Plan = mainPage.dataService.GetPlans()[0];
                    Folder Folder = new Folder()
                    {
                        FolderName = "Todo",
                        PlanId = Plan.PlanId,
                        FolderNotes = new ObservableCollection<Note>(),
                        FolderCreate_On = DateTime.Now.ToLocalTime(),
                    };
                    mainPage.dataService.AddNewFolder(Folder);
                    mainPage.dataService.SaveChanges();
                    mainPage.Plans.Add(Plan);
                }
                else
                {
                    for (int i = 0; i < mainPage.Plans.Count; i++)
                    {
                        AddNavigationItem(mainPage.Plans[i]);
                    }
                }
            }
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
            Microsoft.UI.Xaml.Controls.NavigationViewItem navigationViewItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)NavigationViewPlane.SelectedItem;
            int index = NavigationViewPlane.MenuItems.IndexOf(navigationViewItem);
            WeakReferenceMessenger.Default.Register<PlanRequestMessage>(this, (r, m) =>
            {
                m.Reply(mainPage.Plans[index - 5]);
            });
            AddFolderDialog addFolderDialog = new AddFolderDialog();
            await addFolderDialog.ShowAsync();
            WeakReferenceMessenger.Default.Unregister<PlanRequestMessage>(this);
        }

        private void NavigationViewPlane_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
        }

        private void AddNavigationItem(Plan Plan)
        {
            Microsoft.UI.Xaml.Controls.NavigationViewItem navigationViewItem = new Microsoft.UI.Xaml.Controls.NavigationViewItem();
            navigationViewItem.Content = Plan.PlanName;
            BitmapImage bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Icon/Plane.png"));
            ImageIcon imageIcon = new ImageIcon();
            imageIcon.Source = bitmapImage;
            navigationViewItem.Icon = imageIcon;
            navigationViewItem.Tag = "Plan";

            for (int i = 0; i < Plan.PlanFolders.Count; i++)
            {
                Microsoft.UI.Xaml.Controls.NavigationViewItem navigationViewItem1 = new Microsoft.UI.Xaml.Controls.NavigationViewItem();
                navigationViewItem1.Content = Plan.PlanFolders[i].FolderName;
                BitmapImage bitmapImage1 = new BitmapImage(new Uri("ms-appx:///Assets/Icon/Folder.png"));
                ImageIcon imageIcon1 = new ImageIcon();
                imageIcon1.Source = bitmapImage1;
                navigationViewItem1.Icon = imageIcon1;
                navigationViewItem1.Tag = "Folder";
                navigationViewItem1.TabIndex = Plan.PlanFolders[i].FolderId;
                navigationViewItem.MenuItems.Add(navigationViewItem1);
            }

            NavigationViewPlane.MenuItems.Add(navigationViewItem);
        }

        private void NavigationViewPlane_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            Microsoft.UI.Xaml.Controls.NavigationViewItem navigationViewItem = args.SelectedItem as Microsoft.UI.Xaml.Controls.NavigationViewItem;
            int index = NavigationViewPlane.MenuItems.IndexOf(navigationViewItem);
            WeakReferenceMessenger.Default.Register<PlanRequestMessage>(this, (r, m) =>
            {
                m.Reply(mainPage.Plans[index - 5]);
            });
            if (navigationViewItem.Tag == "Folder")
            {
                int id = navigationViewItem.TabIndex;
                mainPage.getFolder();
                WeakReferenceMessenger.Default.Register<FolderRequestMessage>(this, (r, m) =>
                {
                    m.Reply(mainPage.Folders[id - 1]);
                });
            }
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
                    WeakReferenceMessenger.Default.Unregister<ChangeMessageFolder>(this);
                    WeakReferenceMessenger.Default.Register<ChangeMessageFolder>(this, (r, m) =>
                    {
                        ChangeItemFolder = m.Folder;
                        int temp = ChangeItemFolder.FolderId;
                        for (int i = 0; i < NavigationViewPlane.MenuItems.Count; i++)
                        {
                            if (i == 4) continue;
                            Microsoft.UI.Xaml.Controls.NavigationViewItem navi = (Microsoft.UI.Xaml.Controls.NavigationViewItem)NavigationViewPlane.MenuItems[i];
                            for (int j = 0; j < navi.MenuItems.Count; j++)
                            {
                                Microsoft.UI.Xaml.Controls.NavigationViewItem navi1 = (Microsoft.UI.Xaml.Controls.NavigationViewItem)navi.MenuItems[j];
                                if (navi1.TabIndex == temp)
                                {
                                    sender.SelectedItem = navi1;
                                    break;
                                }
                            }
                        }
                    });
                    SubFrame.Navigate(typeof(PlanePage));
                    break;
                default:
                    SubFrame.Navigate(typeof(FolderPage));
                    break;
            }
            if (navigationViewItem.Tag == "Plan") SelectedPlan = true;
            else SelectedPlan = false;
            IsEnabledAddFolder();
            WeakReferenceMessenger.Default.Unregister<PlanRequestMessage>(this);
            WeakReferenceMessenger.Default.Unregister<FolderRequestMessage>(this);
        }

        private async void DeletePlan_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            /*MenuFlyoutItem menuFlyoutItem = sender as MenuFlyoutItem;
            int index = int.Parse(menuFlyoutItem.Name.ToString());*/
            /*WeakReferenceMessenger.Default.Register<PlanRequestMessage>(this, (r, m) =>
            {
                m.Reply(mainPage.Plans[index - 1]);
            });
            DeletePlaneDialog dialog = new DeletePlaneDialog();
            await dialog.ShowAsync();
            WeakReferenceMessenger.Default.Unregister<PlanRequestMessage>(this);*/
        }

        private async void AddPlan_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            AddPlaneDialog viewModel = new AddPlaneDialog();
            await viewModel.ShowAsync();
        }
    }

}