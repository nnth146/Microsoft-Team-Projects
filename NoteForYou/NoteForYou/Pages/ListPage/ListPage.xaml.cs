using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NoteForYou.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage : Page
    {
        public ListPage()
        {
            this.InitializeComponent();
        }

        private void Shadow_Loaded(object sender, RoutedEventArgs e)
        {
            Grid grid = sender as Grid;
            var _compositor = ElementCompositionPreview.GetElementVisual(grid).Compositor;

            SpriteVisual visual = _compositor.CreateSpriteVisual();
            visual.Size = new System.Numerics.Vector2(((float)grid.ActualWidth), ((float)grid.ActualHeight));

            DropShadow shadow = _compositor.CreateDropShadow();
            shadow.BlurRadius = 4;
            shadow.Offset = new Vector3(0, 4, 4);
            shadow.Color = Colors.DarkGray;

            visual.Shadow = shadow;
            ElementCompositionPreview.SetElementChildVisual(grid, visual);
        }

        private void SaveDb_Event(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Saved");
            SaveEditCommand.Command.Execute(null);
        }
    }
}
