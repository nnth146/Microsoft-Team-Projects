using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uwp.Core.SR
{
	public class ResNavigationView : DependencyObject
	{
		public ResNavigationView()
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
		private const string _controlName = "NavigationView";
		public Brush DefaultPaneBackground
		{
			get => (Brush)_resources[_controlName + nameof(DefaultPaneBackground)];
			set => _resources[_controlName + nameof(DefaultPaneBackground)] = value;
		}
		public Brush ExpandedPaneBackground
		{
			get => (Brush)_resources[_controlName + nameof(ExpandedPaneBackground)];
			set => _resources[_controlName + nameof(ExpandedPaneBackground)] = value;
		}
		public Brush TopPaneBackground
		{
			get => (Brush)_resources[_controlName + nameof(TopPaneBackground)];
			set => _resources[_controlName + nameof(TopPaneBackground)] = value;
		}
		public Brush ItemBackground
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackground)];
			set => _resources[_controlName + nameof(ItemBackground)] = value;
		}
		public Brush ItemBackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundPointerOver)];
			set => _resources[_controlName + nameof(ItemBackgroundPointerOver)] = value;
		}
		public Brush ItemBackgroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundPressed)];
			set => _resources[_controlName + nameof(ItemBackgroundPressed)] = value;
		}
		public Brush ItemBackgroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundDisabled)];
			set => _resources[_controlName + nameof(ItemBackgroundDisabled)] = value;
		}
		public Brush ItemBackgroundChecked
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundChecked)];
			set => _resources[_controlName + nameof(ItemBackgroundChecked)] = value;
		}
		public Brush ItemBackgroundCheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundCheckedPointerOver)];
			set => _resources[_controlName + nameof(ItemBackgroundCheckedPointerOver)] = value;
		}
		public Brush ItemBackgroundCheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundCheckedPressed)];
			set => _resources[_controlName + nameof(ItemBackgroundCheckedPressed)] = value;
		}
		public Brush ItemBackgroundCheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundCheckedDisabled)];
			set => _resources[_controlName + nameof(ItemBackgroundCheckedDisabled)] = value;
		}
		public Brush ItemBackgroundSelected
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundSelected)];
			set => _resources[_controlName + nameof(ItemBackgroundSelected)] = value;
		}
		public Brush ItemBackgroundSelectedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundSelectedPointerOver)];
			set => _resources[_controlName + nameof(ItemBackgroundSelectedPointerOver)] = value;
		}
		public Brush ItemBackgroundSelectedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundSelectedPressed)];
			set => _resources[_controlName + nameof(ItemBackgroundSelectedPressed)] = value;
		}
		public Brush ItemBackgroundSelectedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundSelectedDisabled)];
			set => _resources[_controlName + nameof(ItemBackgroundSelectedDisabled)] = value;
		}
		public Brush ItemForeground
		{
			get => (Brush)_resources[_controlName + nameof(ItemForeground)];
			set => _resources[_controlName + nameof(ItemForeground)] = value;
		}
		public Brush ItemForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundPointerOver)];
			set => _resources[_controlName + nameof(ItemForegroundPointerOver)] = value;
		}
		public Brush ItemForegroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundPressed)];
			set => _resources[_controlName + nameof(ItemForegroundPressed)] = value;
		}
		public Brush ItemForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundDisabled)];
			set => _resources[_controlName + nameof(ItemForegroundDisabled)] = value;
		}
		public Brush ItemForegroundChecked
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundChecked)];
			set => _resources[_controlName + nameof(ItemForegroundChecked)] = value;
		}
		public Brush ItemForegroundCheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundCheckedPointerOver)];
			set => _resources[_controlName + nameof(ItemForegroundCheckedPointerOver)] = value;
		}
		public Brush ItemForegroundCheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundCheckedPressed)];
			set => _resources[_controlName + nameof(ItemForegroundCheckedPressed)] = value;
		}
		public Brush ItemForegroundCheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundCheckedDisabled)];
			set => _resources[_controlName + nameof(ItemForegroundCheckedDisabled)] = value;
		}
		public Brush ItemForegroundSelected
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundSelected)];
			set => _resources[_controlName + nameof(ItemForegroundSelected)] = value;
		}
		public Brush ItemForegroundSelectedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundSelectedPointerOver)];
			set => _resources[_controlName + nameof(ItemForegroundSelectedPointerOver)] = value;
		}
		public Brush ItemForegroundSelectedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundSelectedPressed)];
			set => _resources[_controlName + nameof(ItemForegroundSelectedPressed)] = value;
		}
		public Brush ItemForegroundSelectedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundSelectedDisabled)];
			set => _resources[_controlName + nameof(ItemForegroundSelectedDisabled)] = value;
		}
		public Brush ItemBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrush)];
			set => _resources[_controlName + nameof(ItemBorderBrush)] = value;
		}
		public Brush ItemBorderBrushPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushPointerOver)];
			set => _resources[_controlName + nameof(ItemBorderBrushPointerOver)] = value;
		}
		public Brush ItemBorderBrushPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushPressed)];
			set => _resources[_controlName + nameof(ItemBorderBrushPressed)] = value;
		}
		public Brush ItemBorderBrushDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushDisabled)];
			set => _resources[_controlName + nameof(ItemBorderBrushDisabled)] = value;
		}
		public Brush ItemBorderBrushChecked
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushChecked)];
			set => _resources[_controlName + nameof(ItemBorderBrushChecked)] = value;
		}
		public Brush ItemBorderBrushCheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushCheckedPointerOver)];
			set => _resources[_controlName + nameof(ItemBorderBrushCheckedPointerOver)] = value;
		}
		public Brush ItemBorderBrushCheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushCheckedPressed)];
			set => _resources[_controlName + nameof(ItemBorderBrushCheckedPressed)] = value;
		}
		public Brush ItemBorderBrushCheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushCheckedDisabled)];
			set => _resources[_controlName + nameof(ItemBorderBrushCheckedDisabled)] = value;
		}
		public Brush ItemBorderBrushSelected
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushSelected)];
			set => _resources[_controlName + nameof(ItemBorderBrushSelected)] = value;
		}
		public Brush ItemBorderBrushSelectedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushSelectedPointerOver)];
			set => _resources[_controlName + nameof(ItemBorderBrushSelectedPointerOver)] = value;
		}
		public Brush ItemBorderBrushSelectedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushSelectedPressed)];
			set => _resources[_controlName + nameof(ItemBorderBrushSelectedPressed)] = value;
		}
		public Brush ItemBorderBrushSelectedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushSelectedDisabled)];
			set => _resources[_controlName + nameof(ItemBorderBrushSelectedDisabled)] = value;
		}
		public Brush SelectionIndicatorForeground
		{
			get => (Brush)_resources[_controlName + nameof(SelectionIndicatorForeground)];
			set => _resources[_controlName + nameof(SelectionIndicatorForeground)] = value;
		}
		public Brush TopItemForeground
		{
			get => (Brush)_resources[_controlName + nameof(TopItemForeground)];
			set => _resources[_controlName + nameof(TopItemForeground)] = value;
		}
		public Brush TopItemForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(TopItemForegroundPointerOver)];
			set => _resources[_controlName + nameof(TopItemForegroundPointerOver)] = value;
		}
		public Brush TopItemForegroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(TopItemForegroundPressed)];
			set => _resources[_controlName + nameof(TopItemForegroundPressed)] = value;
		}
		public Brush TopItemForegroundSelected
		{
			get => (Brush)_resources[_controlName + nameof(TopItemForegroundSelected)];
			set => _resources[_controlName + nameof(TopItemForegroundSelected)] = value;
		}
		public Brush TopItemForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(TopItemForegroundDisabled)];
			set => _resources[_controlName + nameof(TopItemForegroundDisabled)] = value;
		}
		public Brush TopItemBackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(TopItemBackgroundPointerOver)];
			set => _resources[_controlName + nameof(TopItemBackgroundPointerOver)] = value;
		}
		public Brush TopItemBackgroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(TopItemBackgroundPressed)];
			set => _resources[_controlName + nameof(TopItemBackgroundPressed)] = value;
		}
		public Brush TopItemBackgroundSelected
		{
			get => (Brush)_resources[_controlName + nameof(TopItemBackgroundSelected)];
			set => _resources[_controlName + nameof(TopItemBackgroundSelected)] = value;
		}
		public Brush TopItemRevealBackgroundFocused
		{
			get => (Brush)_resources[_controlName + nameof(TopItemRevealBackgroundFocused)];
			set => _resources[_controlName + nameof(TopItemRevealBackgroundFocused)] = value;
		}
		public Brush TopItemRevealIconForegroundFocused
		{
			get => (Brush)_resources[_controlName + nameof(TopItemRevealIconForegroundFocused)];
			set => _resources[_controlName + nameof(TopItemRevealIconForegroundFocused)] = value;
		}
		public Brush TopItemRevealContentForegroundFocused
		{
			get => (Brush)_resources[_controlName + nameof(TopItemRevealContentForegroundFocused)];
			set => _resources[_controlName + nameof(TopItemRevealContentForegroundFocused)] = value;
		}
		public Brush BackButtonBackground
		{
			get => (Brush)_resources[_controlName + nameof(BackButtonBackground)];
			set => _resources[_controlName + nameof(BackButtonBackground)] = value;
		}
		public Brush BackButtonForeground
		{
			get => (Brush)_resources["SystemControlForegroundBaseHighBrush"];
			set => _resources["SystemControlForegroundBaseHighBrush"] = value;
		}
		public Brush ButtonBackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBackgroundPointerOver)];
			set => _resources[_controlName + nameof(ButtonBackgroundPointerOver)] = value;
		}
		public Brush ButtonForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ButtonForegroundPointerOver)];
			set => _resources[_controlName + nameof(ButtonForegroundPointerOver)] = value;
		}
		//GenerateAuto by tuanhungdev
	}

}
