using PlanNotes.View.Dialog;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PlanNotes.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlanePage : Page
    {
        public PlanePage()
        {
            InitializeComponent();
        }

        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            DeletePlaneDialog deleteAllPlaneDialog = new DeletePlaneDialog();
            await deleteAllPlaneDialog.ShowAsync();
        }

        private async void DeleteAllItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteAllPlaneDialog deleteAllPlaneDialog = new DeleteAllPlaneDialog();
            await deleteAllPlaneDialog.ShowAsync();
        }
    }
}
