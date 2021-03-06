using System;
using System.Collections.Generic;
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

namespace NoteForYou.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddImageNotePage : Page
    {
        public AddImageNotePage()
        {
            this.InitializeComponent();
        }

        private void RichEditBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string value;

            RichEditBox richEditBox = sender as RichEditBox;

            richEditBox.Document.GetText(Windows.UI.Text.TextGetOptions.UseObjectText, out value);
            richEditBox.Tag = value;
        }

        private void GoBack_Event(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
