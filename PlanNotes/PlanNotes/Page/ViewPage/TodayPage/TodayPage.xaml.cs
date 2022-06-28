using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PlanNotes.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TodayPage : Page
    {
        public TodayPage()
        {
            InitializeComponent();
        }

        private void ListViewNotes_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewNotes.SelectedItem = null;
        }

        private void ListViewSort_ItemClick(object sender, ItemClickEventArgs e)
        {
            FilterFlyout.Hide();
        }
    }
}
