using System.Collections.ObjectModel;
using Uwp.SQLite.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlashCard.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddAndEditCard : Page
    {
        public AddAndEditCard()
        {
            InitializeComponent();
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<TopicModel> TopicModels = ListViewTopics.ItemsSource as ObservableCollection<TopicModel>;
            TextBlock textBlock = sender as TextBlock;
            TopicModel Topic = textBlock.Tag as TopicModel;
            textBlock.Text = (TopicModels.IndexOf(Topic) + 1).ToString();
        }
    }
}
