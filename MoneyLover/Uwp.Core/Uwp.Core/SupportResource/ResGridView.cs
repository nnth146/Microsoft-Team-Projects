using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uwp.Core.SR
{
	public class ResGridView : DependencyObject
	{
		public ResGridView()
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
		private const string _controlName = "GridViewItem";
		public Brush BorderBackground
		{
			get => (Brush)_resources[_controlName + nameof(BorderBackground)];
			set => _resources[_controlName + nameof(BorderBackground)] = value;
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
		public Brush BackgroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundPressed)];
			set => _resources[_controlName + nameof(BackgroundPressed)] = value;
		}
		public Brush BackgroundSelected
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundSelected)];
			set => _resources[_controlName + nameof(BackgroundSelected)] = value;
		}
		public Brush BackgroundSelectedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundSelectedPointerOver)];
			set => _resources[_controlName + nameof(BackgroundSelectedPointerOver)] = value;
		}
		public Brush BackgroundSelectedPressed
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundSelectedPressed)];
			set => _resources[_controlName + nameof(BackgroundSelectedPressed)] = value;
		}
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
		public Brush ForegroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundPressed)];
			set => _resources[_controlName + nameof(ForegroundPressed)] = value;
		}
		public Brush ForegroundSelected
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundSelected)];
			set => _resources[_controlName + nameof(ForegroundSelected)] = value;
		}
		public Brush ForegroundSelectedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundSelectedPointerOver)];
			set => _resources[_controlName + nameof(ForegroundSelectedPointerOver)] = value;
		}
		public Brush ForegroundSelectedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundSelectedPressed)];
			set => _resources[_controlName + nameof(ForegroundSelectedPressed)] = value;
		}
		public Brush FocusVisualPrimaryBrush
		{
			get => (Brush)_resources[_controlName + nameof(FocusVisualPrimaryBrush)];
			set => _resources[_controlName + nameof(FocusVisualPrimaryBrush)] = value;
		}
		public Brush FocusVisualSecondaryBrush
		{
			get => (Brush)_resources[_controlName + nameof(FocusVisualSecondaryBrush)];
			set => _resources[_controlName + nameof(FocusVisualSecondaryBrush)] = value;
		}
		public Brush FocusBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(FocusBorderBrush)];
			set => _resources[_controlName + nameof(FocusBorderBrush)] = value;
		}
		public Brush FocusSecondaryBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(FocusSecondaryBorderBrush)];
			set => _resources[_controlName + nameof(FocusSecondaryBorderBrush)] = value;
		}
		public Brush CheckBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBrush)];
			set => _resources[_controlName + nameof(CheckBrush)] = value;
		}
		public Brush CheckBoxBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxBrush)];
			set => _resources[_controlName + nameof(CheckBoxBrush)] = value;
		}
		public Brush DragBackground
		{
			get => (Brush)_resources[_controlName + nameof(DragBackground)];
			set => _resources[_controlName + nameof(DragBackground)] = value;
		}
		public Brush DragForeground
		{
			get => (Brush)_resources[_controlName + nameof(DragForeground)];
			set => _resources[_controlName + nameof(DragForeground)] = value;
		}
		public Brush PlaceholderBackground
		{
			get => (Brush)_resources[_controlName + nameof(PlaceholderBackground)];
			set => _resources[_controlName + nameof(PlaceholderBackground)] = value;
		}
		public CornerRadius CornerRadius
		{
			get => (CornerRadius)_resources[_controlName + nameof(CornerRadius)];
			set => _resources[_controlName + nameof(CornerRadius)] = value;
		}
		public CornerRadius CheckBoxCornerRadius
		{
			get => (CornerRadius)_resources[_controlName + nameof(CheckBoxCornerRadius)];
			set => _resources[_controlName + nameof(CheckBoxCornerRadius)] = value;
		}
		public CornerRadius SelectionIndicatorCornerRadius
		{
			get => (CornerRadius)_resources[_controlName + nameof(SelectionIndicatorCornerRadius)];
			set => _resources[_controlName + nameof(SelectionIndicatorCornerRadius)] = value;
		}
		public Brush CheckPressedBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckPressedBrush)];
			set => _resources[_controlName + nameof(CheckPressedBrush)] = value;
		}
		public Brush CheckDisabledBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckDisabledBrush)];
			set => _resources[_controlName + nameof(CheckDisabledBrush)] = value;
		}
		public Brush CheckBoxPointerOverBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxPointerOverBrush)];
			set => _resources[_controlName + nameof(CheckBoxPointerOverBrush)] = value;
		}
		public Brush CheckBoxPressedBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxPressedBrush)];
			set => _resources[_controlName + nameof(CheckBoxPressedBrush)] = value;
		}
		public Brush CheckBoxDisabledBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxDisabledBrush)];
			set => _resources[_controlName + nameof(CheckBoxDisabledBrush)] = value;
		}
		public Brush CheckBoxSelectedBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxSelectedBrush)];
			set => _resources[_controlName + nameof(CheckBoxSelectedBrush)] = value;
		}
		public Brush CheckBoxSelectedPointerOverBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxSelectedPointerOverBrush)];
			set => _resources[_controlName + nameof(CheckBoxSelectedPointerOverBrush)] = value;
		}
		public Brush CheckBoxSelectedPressedBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxSelectedPressedBrush)];
			set => _resources[_controlName + nameof(CheckBoxSelectedPressedBrush)] = value;
		}
		public Brush CheckBoxSelectedDisabledBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxSelectedDisabledBrush)];
			set => _resources[_controlName + nameof(CheckBoxSelectedDisabledBrush)] = value;
		}
		public Brush CheckBoxBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxBorderBrush)];
			set => _resources[_controlName + nameof(CheckBoxBorderBrush)] = value;
		}
		public Brush CheckBoxPointerOverBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxPointerOverBorderBrush)];
			set => _resources[_controlName + nameof(CheckBoxPointerOverBorderBrush)] = value;
		}
		public Brush CheckBoxPressedBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxPressedBorderBrush)];
			set => _resources[_controlName + nameof(CheckBoxPressedBorderBrush)] = value;
		}
		public Brush CheckBoxDisabledBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(CheckBoxDisabledBorderBrush)];
			set => _resources[_controlName + nameof(CheckBoxDisabledBorderBrush)] = value;
		}
		public Brush BackgroundSelectedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundSelectedDisabled)];
			set => _resources[_controlName + nameof(BackgroundSelectedDisabled)] = value;
		}
		public Brush SelectionIndicatorBrush
		{
			get => (Brush)_resources[_controlName + nameof(SelectionIndicatorBrush)];
			set => _resources[_controlName + nameof(SelectionIndicatorBrush)] = value;
		}
		public Brush SelectionIndicatorPointerOverBrush
		{
			get => (Brush)_resources[_controlName + nameof(SelectionIndicatorPointerOverBrush)];
			set => _resources[_controlName + nameof(SelectionIndicatorPointerOverBrush)] = value;
		}
		public Brush SelectionIndicatorPressedBrush
		{
			get => (Brush)_resources[_controlName + nameof(SelectionIndicatorPressedBrush)];
			set => _resources[_controlName + nameof(SelectionIndicatorPressedBrush)] = value;
		}
		public Brush SelectionIndicatorDisabledBrush
		{
			get => (Brush)_resources[_controlName + nameof(SelectionIndicatorDisabledBrush)];
			set => _resources[_controlName + nameof(SelectionIndicatorDisabledBrush)] = value;
		}
		public Brush RevealBorderThemeThickness
		{
			get => (Brush)_resources[_controlName + nameof(RevealBorderThemeThickness)];
			set => _resources[_controlName + nameof(RevealBorderThemeThickness)] = value;
		}
		public Brush RevealBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(RevealBorderBrush)];
			set => _resources[_controlName + nameof(RevealBorderBrush)] = value;
		}
		public Brush RevealBackground
		{
			get => (Brush)_resources[_controlName + nameof(RevealBackground)];
			set => _resources[_controlName + nameof(RevealBackground)] = value;
		}
		//GenerateAuto by tuanhungdev
	}
}
