using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PlanNotes.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FolderPage : Page
    {
        public FolderPage()
        {
            this.InitializeComponent();
            isVisibility = true;
        }

        private bool isVisibility;

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            isVisibility = !isVisibility;
            if (isVisibility)
            {
                Unchecked.Visibility = Visibility.Collapsed;
                Checked.Visibility = Visibility.Visible;
            }
            else
            {
                Checked.Visibility = Visibility.Collapsed;
                Unchecked.Visibility = Visibility.Visible;
            }
        }
    }
}
