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
	public class ResComboBox : DependencyObject
	{
		public ResComboBox()
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
		private const string _controlName = "ComboBox";
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
		public Brush BackgroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundPressed)];
			set => _resources[_controlName + nameof(BackgroundPressed)] = value;
		}
		public Brush BackgroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundDisabled)];
			set => _resources[_controlName + nameof(BackgroundDisabled)] = value;
		}
		public Brush BackgroundUnfocused
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundUnfocused)];
			set => _resources[_controlName + nameof(BackgroundUnfocused)] = value;
		}
		public Brush BackgroundBorderBrushFocused
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundBorderBrushFocused)];
			set => _resources[_controlName + nameof(BackgroundBorderBrushFocused)] = value;
		}
		public Brush BackgroundBorderBrushUnfocused
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundBorderBrushUnfocused)];
			set => _resources[_controlName + nameof(BackgroundBorderBrushUnfocused)] = value;
		}
		public Brush Foreground
		{
			get => (Brush)_resources[_controlName + nameof(Foreground)];
			set => _resources[_controlName + nameof(Foreground)] = value;
		}
		public Brush ForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundDisabled)];
			set => _resources[_controlName + nameof(ForegroundDisabled)] = value;
		}
		public Brush ForegroundFocused
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundFocused)];
			set => _resources[_controlName + nameof(ForegroundFocused)] = value;
		}
		public Brush ForegroundFocusedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundFocusedPressed)];
			set => _resources[_controlName + nameof(ForegroundFocusedPressed)] = value;
		}
		public Brush PlaceHolderForeground
		{
			get => (Brush)_resources[_controlName + nameof(PlaceHolderForeground)];
			set => _resources[_controlName + nameof(PlaceHolderForeground)] = value;
		}
		public Brush PlaceHolderForegroundFocusedPressed
		{
			get => (Brush)_resources[_controlName + nameof(PlaceHolderForegroundFocusedPressed)];
			set => _resources[_controlName + nameof(PlaceHolderForegroundFocusedPressed)] = value;
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
		public Brush BorderBrushPressed
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushPressed)];
			set => _resources[_controlName + nameof(BorderBrushPressed)] = value;
		}
		public Brush BorderBrushDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushDisabled)];
			set => _resources[_controlName + nameof(BorderBrushDisabled)] = value;
		}
		public Brush DropDownBackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(DropDownBackgroundPointerOver)];
			set => _resources[_controlName + nameof(DropDownBackgroundPointerOver)] = value;
		}
		public Brush DropDownBackgroundPointerPressed
		{
			get => (Brush)_resources[_controlName + nameof(DropDownBackgroundPointerPressed)];
			set => _resources[_controlName + nameof(DropDownBackgroundPointerPressed)] = value;
		}
		public Brush FocusedDropDownBackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(FocusedDropDownBackgroundPointerOver)];
			set => _resources[_controlName + nameof(FocusedDropDownBackgroundPointerOver)] = value;
		}
		public Brush FocusedDropDownBackgroundPointerPressed
		{
			get => (Brush)_resources[_controlName + nameof(FocusedDropDownBackgroundPointerPressed)];
			set => _resources[_controlName + nameof(FocusedDropDownBackgroundPointerPressed)] = value;
		}
		public Brush DropDownGlyphForeground
		{
			get => (Brush)_resources[_controlName + nameof(DropDownGlyphForeground)];
			set => _resources[_controlName + nameof(DropDownGlyphForeground)] = value;
		}
		public Brush EditableDropDownGlyphForeground
		{
			get => (Brush)_resources[_controlName + nameof(EditableDropDownGlyphForeground)];
			set => _resources[_controlName + nameof(EditableDropDownGlyphForeground)] = value;
		}
		public Brush DropDownGlyphForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(DropDownGlyphForegroundDisabled)];
			set => _resources[_controlName + nameof(DropDownGlyphForegroundDisabled)] = value;
		}
		public Brush DropDownGlyphForegroundFocused
		{
			get => (Brush)_resources[_controlName + nameof(DropDownGlyphForegroundFocused)];
			set => _resources[_controlName + nameof(DropDownGlyphForegroundFocused)] = value;
		}
		public Brush DropDownGlyphForegroundFocusedPressed
		{
			get => (Brush)_resources[_controlName + nameof(DropDownGlyphForegroundFocusedPressed)];
			set => _resources[_controlName + nameof(DropDownGlyphForegroundFocusedPressed)] = value;
		}
		public Brush DropDownBackground
		{
			get => (Brush)_resources[_controlName + nameof(DropDownBackground)];
			set => _resources[_controlName + nameof(DropDownBackground)] = value;
		}
		public Brush DropDownForeground
		{
			get => (Brush)_resources[_controlName + nameof(DropDownForeground)];
			set => _resources[_controlName + nameof(DropDownForeground)] = value;
		}
		public Brush DropDownBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(DropDownBorderBrush)];
			set => _resources[_controlName + nameof(DropDownBorderBrush)] = value;
		}
		public Brush ItemForeground
		{
			get => (Brush)_resources[_controlName + nameof(ItemForeground)];
			set => _resources[_controlName + nameof(ItemForeground)] = value;
		}
		public Brush ItemForegroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundPressed)];
			set => _resources[_controlName + nameof(ItemForegroundPressed)] = value;
		}
		public Brush ItemForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundPointerOver)];
			set => _resources[_controlName + nameof(ItemForegroundPointerOver)] = value;
		}
		public Brush ItemForegroundSelected
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundSelected)];
			set => _resources[_controlName + nameof(ItemForegroundSelected)] = value;
		}
		public Brush ItemForegroundSelectedUnfocused
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundSelectedUnfocused)];
			set => _resources[_controlName + nameof(ItemForegroundSelectedUnfocused)] = value;
		}
		public Brush ItemForegroundSelectedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundSelectedPressed)];
			set => _resources[_controlName + nameof(ItemForegroundSelectedPressed)] = value;
		}
		public Brush ItemForegroundSelectedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundSelectedPointerOver)];
			set => _resources[_controlName + nameof(ItemForegroundSelectedPointerOver)] = value;
		}
		public Brush ItemForegroundSelectedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemForegroundSelectedDisabled)];
			set => _resources[_controlName + nameof(ItemForegroundSelectedDisabled)] = value;
		}
		public Brush ItemBackground
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackground)];
			set => _resources[_controlName + nameof(ItemBackground)] = value;
		}
		public Brush ItemBackgroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundPressed)];
			set => _resources[_controlName + nameof(ItemBackgroundPressed)] = value;
		}
		public Brush ItemBackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundPointerOver)];
			set => _resources[_controlName + nameof(ItemBackgroundPointerOver)] = value;
		}
		public Brush ItemBackgroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundDisabled)];
			set => _resources[_controlName + nameof(ItemBackgroundDisabled)] = value;
		}
		public Brush ItemBackgroundSelected
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundSelected)];
			set => _resources[_controlName + nameof(ItemBackgroundSelected)] = value;
		}
		public Brush ItemBackgroundSelectedUnfocused
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundSelectedUnfocused)];
			set => _resources[_controlName + nameof(ItemBackgroundSelectedUnfocused)] = value;
		}
		public Brush ItemBackgroundSelectedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundSelectedPressed)];
			set => _resources[_controlName + nameof(ItemBackgroundSelectedPressed)] = value;
		}
		public Brush ItemBackgroundSelectedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundSelectedPointerOver)];
			set => _resources[_controlName + nameof(ItemBackgroundSelectedPointerOver)] = value;
		}
		public Brush ItemBackgroundSelectedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemBackgroundSelectedDisabled)];
			set => _resources[_controlName + nameof(ItemBackgroundSelectedDisabled)] = value;
		}
		public Brush ItemBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrush)];
			set => _resources[_controlName + nameof(ItemBorderBrush)] = value;
		}
		public Brush ItemBorderBrushPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushPressed)];
			set => _resources[_controlName + nameof(ItemBorderBrushPressed)] = value;
		}
		public Brush ItemBorderBrushPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushPointerOver)];
			set => _resources[_controlName + nameof(ItemBorderBrushPointerOver)] = value;
		}
		public Brush ItemBorderBrushDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushDisabled)];
			set => _resources[_controlName + nameof(ItemBorderBrushDisabled)] = value;
		}
		public Brush ItemBorderBrushSelected
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushSelected)];
			set => _resources[_controlName + nameof(ItemBorderBrushSelected)] = value;
		}
		public Brush ItemBorderBrushSelectedUnfocused
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushSelectedUnfocused)];
			set => _resources[_controlName + nameof(ItemBorderBrushSelectedUnfocused)] = value;
		}
		public Brush ItemBorderBrushSelectedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushSelectedPressed)];
			set => _resources[_controlName + nameof(ItemBorderBrushSelectedPressed)] = value;
		}
		public Brush ItemBorderBrushSelectedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushSelectedPointerOver)];
			set => _resources[_controlName + nameof(ItemBorderBrushSelectedPointerOver)] = value;
		}
		public Brush ItemBorderBrushSelectedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ItemBorderBrushSelectedDisabled)];
			set => _resources[_controlName + nameof(ItemBorderBrushSelectedDisabled)] = value;
		}
		//GenerateAuto by tuanhungdev
	}


}
