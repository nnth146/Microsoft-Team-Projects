using KeepSafeForPassword.Messenger;
using KeepSafeForPassword.Model;
using Microsoft.Toolkit.Mvvm.Messaging;
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
    public sealed partial class ViewDatabasePage : Page
    {
        public ViewDatabasePage()
        {
            this.InitializeComponent();

            WeakReferenceMessenger.Default.Register<AddPasswordFrameRequestMessage>(this, (r, m) =>
            {
                m.Reply(AddPasswordFrame);
            });

            WeakReferenceMessenger.Default.Register<EditPasswordFrameRequestMessage>(this, (r, m) =>
            {
                m.Reply(ShowPasswordFrame);
            });

            WeakReferenceMessenger.Default.Register<ScrollIntoViewRequestMessage<Password>>(this, (r, m) =>
            {
                ListPassword.ScrollIntoView(m.Item);
            });
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            WeakReferenceMessenger.Default.UnregisterAll(this);
            WeakReferenceMessenger.Default.UnregisterAll(DataContext);
        }
    }
}
