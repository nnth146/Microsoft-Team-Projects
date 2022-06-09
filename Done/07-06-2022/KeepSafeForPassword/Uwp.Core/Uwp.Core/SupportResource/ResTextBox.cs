using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uwp.Controls.SR
{
	public class ResTextBox : DependencyObject
	{
		public ResTextBox()
		{
			_resources = new ResourceDictionary();
		}
		private ResourceDictionary _resources;
		public ResourceDictionary Resources
        {
			get
            {
				//Giúp cho tạo được nhiều resource
				ResourceDictionary resource = new ResourceDictionary();
				foreach(var key in _resources.Keys)
                {
					resource[key] = _resources[key];
                }
				return resource;
            }
        }
		private const string _controlName = "TextControl";
		public Brush Foreground
		{
			get => (Brush)_resources[_controlName + nameof(Foreground)];
			set => _resources[_controlName + nameof(Foreground)] = value;
		}
		public Brush ForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundPointerOver)];
			set => _resources[_controlName + nameof(ForegroundPointerOver)] = value;
		}
		public Brush ForegroundFocused
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundFocused)];
			set => _resources[_controlName + nameof(ForegroundFocused)] = value;
		}
		public Brush ForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundDisabled)];
			set => _resources[_controlName + nameof(ForegroundDisabled)] = value;
		}
		public Brush Background
		{
			get => (Brush)_resources[_controlName + nameof(Background)];
			set => _resources[_controlName + nameof(Background)] = value;
		}
		public Brush BackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundPointerOver)];
			set => _resources[_controlName + nameof(BackgroundPointerOver)] = value;
		}
		public Brush BackgroundFocused
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundFocused)];
			set => _resources[_controlName + nameof(BackgroundFocused)] = value;
		}
		public Brush BackgroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundDisabled)];
			set => _resources[_controlName + nameof(BackgroundDisabled)] = value;
		}
		public Brush BorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrush)];
			set => _resources[_controlName + nameof(BorderBrush)] = value;
		}
		public Brush BorderBrushPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushPointerOver)];
			set => _resources[_controlName + nameof(BorderBrushPointerOver)] = value;
		}
		public Brush BorderBrushFocused
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushFocused)];
			set => _resources[_controlName + nameof(BorderBrushFocused)] = value;
		}
		public Brush BorderBrushDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushDisabled)];
			set => _resources[_controlName + nameof(BorderBrushDisabled)] = value;
		}
		public Brush PlaceholderForeground
		{
			get => (Brush)_resources[_controlName + nameof(PlaceholderForeground)];
			set => _resources[_controlName + nameof(PlaceholderForeground)] = value;
		}
		public Brush PlaceholderForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(PlaceholderForegroundPointerOver)];
			set => _resources[_controlName + nameof(PlaceholderForegroundPointerOver)] = value;
		}
		public Brush PlaceholderForegroundFocused
		{
			get => (Brush)_resources[_controlName + nameof(PlaceholderForegroundFocused)];
			set => _resources[_controlName + nameof(PlaceholderForegroundFocused)] = value;
		}
		public Brush PlaceholderForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(PlaceholderForegroundDisabled)];
			set => _resources[_controlName + nameof(PlaceholderForegroundDisabled)] = value;
		}
		public Brush HeaderForeground
		{
			get => (Brush)_resources[_controlName + nameof(HeaderForeground)];
			set => _resources[_controlName + nameof(HeaderForeground)] = value;
		}
		public Brush HeaderForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(HeaderForegroundDisabled)];
			set => _resources[_controlName + nameof(HeaderForegroundDisabled)] = value;
		}
		public Brush SelectionHighlightColor
		{
			get => (Brush)_resources[_controlName + nameof(SelectionHighlightColor)];
			set => _resources[_controlName + nameof(SelectionHighlightColor)] = value;
		}
		public Brush ButtonBackground
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBackground)];
			set => _resources[_controlName + nameof(ButtonBackground)] = value;
		}
		public Brush ButtonBackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBackgroundPointerOver)];
			set => _resources[_controlName + nameof(ButtonBackgroundPointerOver)] = value;
		}
		public Brush ButtonBackgroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBackgroundPressed)];
			set => _resources[_controlName + nameof(ButtonBackgroundPressed)] = value;
		}
		public Brush ButtonBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBorderBrush)];
			set => _resources[_controlName + nameof(ButtonBorderBrush)] = value;
		}
		public Brush ButtonBorderBrushPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBorderBrushPointerOver)];
			set => _resources[_controlName + nameof(ButtonBorderBrushPointerOver)] = value;
		}
		public Brush ButtonBorderBrushPressed
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBorderBrushPressed)];
			set => _resources[_controlName + nameof(ButtonBorderBrushPressed)] = value;
		}
		public Brush ButtonForeground
		{
			get => (Brush)_resources[_controlName + nameof(ButtonForeground)];
			set => _resources[_controlName + nameof(ButtonForeground)] = value;
		}
		public Brush ButtonForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ButtonForegroundPointerOver)];
			set => _resources[_controlName + nameof(ButtonForegroundPointerOver)] = value;
		}
		public Brush ButtonForegroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(ButtonForegroundPressed)];
			set => _resources[_controlName + nameof(ButtonForegroundPressed)] = value;
		}
		public Brush ContentLinkForegroundColor
		{
			get => (Brush)_resources[_controlName + nameof(ContentLinkForegroundColor)];
			set => _resources[_controlName + nameof(ContentLinkForegroundColor)] = value;
		}
		public Brush ContentLinkBackgroundColor
		{
			get => (Brush)_resources[_controlName + nameof(ContentLinkBackgroundColor)];
			set => _resources[_controlName + nameof(ContentLinkBackgroundColor)] = value;
		}
		//GenerateAuto by tuanhungdev
	}

}
