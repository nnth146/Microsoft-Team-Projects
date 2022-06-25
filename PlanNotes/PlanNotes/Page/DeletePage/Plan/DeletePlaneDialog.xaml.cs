using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PlanNotes.View.Dialog
{
    public sealed partial class DeletePlaneDialog : ContentDialog
    {
        public DeletePlaneDialog()
        {
            InitializeComponent();
        }

        private void Hide_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DeletePlan.Hide();
        }
    }
}
