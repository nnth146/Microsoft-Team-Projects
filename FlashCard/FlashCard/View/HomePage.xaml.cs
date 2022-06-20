using FlashCard.View.Dialog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
        }

        private void SubFrame_Loaded(object sender, RoutedEventArgs e)
        {
            SubFrame.Navigate(typeof(EmptyFlashCard));
        }

        private async void AddFolder_Click(object sender, RoutedEventArgs e)
        {
            AddFolderDialog addFolderDialog = new AddFolderDialog();
            await addFolderDialog.ShowAsync();
        }

        private async void EditFolder_Click(object sender, RoutedEventArgs e)
        {
            EditFolderDialog editFolderDialog = new EditFolderDialog();
            await editFolderDialog.ShowAsync();
        }

        private async void AddStudy_Click(object sender, RoutedEventArgs e)
        {
            AddStudyDialog addStudyDialog = new AddStudyDialog();
            await addStudyDialog.ShowAsync();
        }

        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteItemDialog deleteItemDialog = new DeleteItemDialog();
            await deleteItemDialog.ShowAsync();
        }

        private async void DeteteAllItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteAllItemDialog deleteAllItemDialog = new DeleteAllItemDialog();
            await deleteAllItemDialog.ShowAsync();
        }

        private void LearnNow_Click(object sender, RoutedEventArgs e)
        {
            SubFrame.Navigate(typeof(ViewStudy));
        }

        private async void EditStudy_CLick(object sender, RoutedEventArgs e)
        {
            EditStudyDialog editStudyDialog = new EditStudyDialog();
            await editStudyDialog.ShowAsync();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ExplorerItem> DataSource = GetData();
            NavView.MenuItemsSource = DataSource;
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
    }

    public class ExplorerItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public enum ExplorerItemType { Folder, File };
        public string Name { get; set; }
        public ExplorerItemType Type { get; set; }
        public string Icon => Type == ExplorerItemType.Folder ? "ms-appx:///Assets/Icon/Folder.png" : "ms-appx:///Assets/Icon/File.png";

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
