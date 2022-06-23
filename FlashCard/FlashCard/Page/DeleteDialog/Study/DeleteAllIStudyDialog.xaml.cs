using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlashCard.View.Dialog
{
    public sealed partial class DeleteAllIStudyDialog : ContentDialog
    {
        public DeleteAllIStudyDialog()
        {
            InitializeComponent();
        }

        private void HideDialog_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Hide();
        }
    }
}
