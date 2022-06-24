using FlashCard.View.Dialog;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Uwp.Messenger;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlashCard.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            WeakReferenceMessenger.Default.Register<MPFrameRequestMessage>(this, (r, m) =>
            {
                m.Reply(SubFrame);
            });
        }

        private async void AddStudy_Click(object sender, RoutedEventArgs e)
        {
            AddStudyDialog addStudyDialog = new AddStudyDialog();
            await addStudyDialog.ShowAsync();
        }

        private void LearnNow_Click(object sender, RoutedEventArgs e)
        {
            SubFrame.Navigate(typeof(ViewStudy));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*if (NavView.MenuItems.Count > 0)
            {
                Debug.WriteLine("Da vao day");
                NavView.SelectedItem = NavView.MenuItems[0];
            }*/
        }

        private ObservableCollection<ExplorerItem> GetData()
        {
            var list = new ObservableCollection<ExplorerItem>();
            ExplorerItem folder1 = new ExplorerItem()
            {
                Name = "Work Documents",
                Type = ExplorerItem.ExplorerItemType.Folder,
                Children =
                {
                    new ExplorerItem()
                    {
                        Name = "Feature Schedule",
                        Type = ExplorerItem.ExplorerItemType.File,
                    },
                    new ExplorerItem()
                    {
                        Name = "Overall Project Plan",
                        Type = ExplorerItem.ExplorerItemType.File,
                    },
                    new ExplorerItem()
                    {
                        Name = "Feature Resources Allocation",
                        Type = ExplorerItem.ExplorerItemType.File,
                    }
                }
            };

            ExplorerItem folder2 = new ExplorerItem()
            {
                Name = "Personal Folder",
                Type = ExplorerItem.ExplorerItemType.Folder,
                Children =
                    {
                        new ExplorerItem()
                        {
                            Name = "Home Remodel Folder",
                            Type = ExplorerItem.ExplorerItemType.File,
                        }
                    }
            };

            list.Add(folder1);
            list.Add(folder2);
            return list;
        }

        private void NavigationViewItem_Loaded(object sender, RoutedEventArgs e)
        {
            Microsoft.UI.Xaml.Controls.NavigationViewItem item = sender as Microsoft.UI.Xaml.Controls.NavigationViewItem;
            if (item.Tag.ToString() == "Uwp.SQLite.Model.FolderModel")
            {
                item.ContextFlyout = FlashCardFlyout;
            }
            else
                item.ContextFlyout = StudyFlyout;
        }

        private void NavView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            ChangeItemCommand.Command.Execute(args.SelectedItem);
        }

        private void SubFrame_Loaded(object sender, RoutedEventArgs e)
        {
            SubFrame.Navigate(typeof(EmptyFlashCard));
        }
    }

    public class ExplorerItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public enum ExplorerItemType { Folder, File };
        public ExplorerItemType Type { get; set; }
        public string Icon => Type == ExplorerItemType.Folder ? "ms-appx:///Assets/Icon/Folder.png" : "ms-appx:///Assets/Icon/File.png";
        public string Name { get; set; }

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
