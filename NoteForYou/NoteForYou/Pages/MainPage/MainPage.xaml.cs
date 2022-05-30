using Fluent.Icons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using static NoteForYou.ViewModel.MainPageViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NoteForYou.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.SetupNavItems();
        }

        public class NavItem
        {
            public string Text { get; set; }
            public FluentIconElement Icon { get; set; }
            public Type Page { get; set; }
        }

        public ObservableCollection<NavItem> NavItems { get; set; }

        private void SetupNavItems()
        {
            NavItems = new ObservableCollection<NavItem>();
            NavItems.Add(new NavItem
            {
                Icon = new FluentIconElement(FluentSymbol.Note20),
                Text = "Notes",
                Page = typeof(NotesPage),
            });
            NavItems.Add(new NavItem
            {
                Icon = new FluentIconElement(FluentSymbol.Notebook24),
                Text = "Image Notes",
                Page = typeof(ImageNotesPage),
            });
        }

        private void NavView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            NavItem selectedItem = args.SelectedItem as NavItem;
            if (selectedItem != null)
            {
                MainFrame.Navigate(selectedItem.Page);
            }
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            NavView.SelectedItem = NavItems[0];
        }
    }
}
