using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uwp.Controls.SR
{
	public class ResInkToolbar : DependencyObject
	{
		public ResInkToolbar()
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
				foreach (var key in _resources.Keys)
				{
					resource[key] = _resources[key];
				}
				return resource;
			}
		}
		private const string _controlName = "InkToolbar";
		public Brush ButtonBackgroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBackgroundThemeBrush)];
			set => _resources[_controlName + nameof(ButtonBackgroundThemeBrush)] = value;
		}
		public Brush ButtonForegroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(ButtonForegroundThemeBrush)];
			set => _resources[_controlName + nameof(ButtonForegroundThemeBrush)] = value;
		}
		public Brush FlyoutItemBackgroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemBackgroundThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemBackgroundThemeBrush)] = value;
		}
		public Brush FlyoutItemForegroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemForegroundThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemForegroundThemeBrush)] = value;
		}
		public Brush ButtonHoverBackgroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(ButtonHoverBackgroundThemeBrush)];
			set => _resources[_controlName + nameof(ButtonHoverBackgroundThemeBrush)] = value;
		}
		public Brush ButtonHoverForegroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(ButtonHoverForegroundThemeBrush)];
			set => _resources[_controlName + nameof(ButtonHoverForegroundThemeBrush)] = value;
		}
		public Brush FlyoutItemHoverBackgroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemHoverBackgroundThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemHoverBackgroundThemeBrush)] = value;
		}
		public Brush FlyoutItemHoverForegroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemHoverForegroundThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemHoverForegroundThemeBrush)] = value;
		}
		public Brush ButtonSelectedBackgroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(ButtonSelectedBackgroundThemeBrush)];
			set => _resources[_controlName + nameof(ButtonSelectedBackgroundThemeBrush)] = value;
		}
		public Brush ButtonSelectedForegroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(ButtonSelectedForegroundThemeBrush)];
			set => _resources[_controlName + nameof(ButtonSelectedForegroundThemeBrush)] = value;
		}
		public Brush ButtonPressedBackgroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(ButtonPressedBackgroundThemeBrush)];
			set => _resources[_controlName + nameof(ButtonPressedBackgroundThemeBrush)] = value;
		}
		public Brush ButtonPressedForegroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(ButtonPressedForegroundThemeBrush)];
			set => _resources[_controlName + nameof(ButtonPressedForegroundThemeBrush)] = value;
		}
		public Brush FlyoutItemPressedBackgroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemPressedBackgroundThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemPressedBackgroundThemeBrush)] = value;
		}
		public Brush FlyoutItemPressedForegroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemPressedForegroundThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemPressedForegroundThemeBrush)] = value;
		}
		public Brush FlyoutItemPressedSelectedBackgroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemPressedSelectedBackgroundThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemPressedSelectedBackgroundThemeBrush)] = value;
		}
		public Brush DisabledBackgroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(DisabledBackgroundThemeBrush)];
			set => _resources[_controlName + nameof(DisabledBackgroundThemeBrush)] = value;
		}
		public Brush DisabledForegroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(DisabledForegroundThemeBrush)];
			set => _resources[_controlName + nameof(DisabledForegroundThemeBrush)] = value;
		}
		public Brush AccentColorThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(AccentColorThemeBrush)];
			set => _resources[_controlName + nameof(AccentColorThemeBrush)] = value;
		}
		public Brush FlyoutItemBorderHoverThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemBorderHoverThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemBorderHoverThemeBrush)] = value;
		}
		public Brush FlyoutItemBorderSelectedThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemBorderSelectedThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemBorderSelectedThemeBrush)] = value;
		}
		public Brush FlyoutItemBorderPressedThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemBorderPressedThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemBorderPressedThemeBrush)] = value;
		}
		public Brush FlyoutL3PreviewPen
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutL3PreviewPen)];
			set => _resources[_controlName + nameof(FlyoutL3PreviewPen)] = value;
		}
		public Brush FlyoutItemHoverSelectedBackgroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemHoverSelectedBackgroundThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemHoverSelectedBackgroundThemeBrush)] = value;
		}
		public Brush FlyoutItemSelectedBackgroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemSelectedBackgroundThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemSelectedBackgroundThemeBrush)] = value;
		}
		public Brush FlyoutItemSelectedForegroundThemeBrush
		{
			get => (Brush)_resources[_controlName + nameof(FlyoutItemSelectedForegroundThemeBrush)];
			set => _resources[_controlName + nameof(FlyoutItemSelectedForegroundThemeBrush)] = value;
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
		public Brush ButtonBackgroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBackgroundDisabled)];
			set => _resources[_controlName + nameof(ButtonBackgroundDisabled)] = value;
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
		public Brush ButtonForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ButtonForegroundDisabled)];
			set => _resources[_controlName + nameof(ButtonForegroundDisabled)] = value;
		}
		public Brush ButtonBorderThemeThickness
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBorderThemeThickness)];
			set => _resources[_controlName + nameof(ButtonBorderThemeThickness)] = value;
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
		public Brush ButtonBorderBrushDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBorderBrushDisabled)];
			set => _resources[_controlName + nameof(ButtonBorderBrushDisabled)] = value;
		}
		//GenerateAuto by tuanhungdev
	}

}
