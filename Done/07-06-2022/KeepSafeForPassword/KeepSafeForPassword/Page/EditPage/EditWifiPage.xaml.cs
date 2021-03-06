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

namespace KeepSafeForPassword.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditWifiPage : Page
    {
        public EditWifiPage()
        {
            this.InitializeComponent();
        }

        private void NoteField_TextChanged(object sender, RoutedEventArgs e)
        {
            RichEditBox edit = sender as RichEditBox;
            edit.Document.GetText(Windows.UI.Text.TextGetOptions.UseObjectText, out string value);
            edit.Tag = value;
        }

        private void NoteField_Loaded(object sender, RoutedEventArgs e)
        {
            RichEditBox edit = sender as RichEditBox;
            edit.Document.SetText(Windows.UI.Text.TextSetOptions.None, edit.Tag as string ?? "");
        }
    }
}
