using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PlanNotes.View.Dialog
{
    public sealed partial class EditPlaneDialog : ContentDialog
    {
        public EditPlaneDialog()
        {
            InitializeComponent();
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            EditPlane.Hide();
        }
    }
}
