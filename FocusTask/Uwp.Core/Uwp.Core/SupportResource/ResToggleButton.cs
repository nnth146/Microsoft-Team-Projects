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
	public class ResToggleButton : DependencyObject
	{
		public ResToggleButton()
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
		private const string _controlName = "ToggleButton";
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
		public Brush BackgroundChecked
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundChecked)];
			set => _resources[_controlName + nameof(BackgroundChecked)] = value;
		}
		public Brush BackgroundCheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundCheckedPointerOver)];
			set => _resources[_controlName + nameof(BackgroundCheckedPointerOver)] = value;
		}
		public Brush BackgroundCheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundCheckedPressed)];
			set => _resources[_controlName + nameof(BackgroundCheckedPressed)] = value;
		}
		public Brush BackgroundCheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundCheckedDisabled)];
			set => _resources[_controlName + nameof(BackgroundCheckedDisabled)] = value;
		}
		public Brush BackgroundIndeterminate
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundIndeterminate)];
			set => _resources[_controlName + nameof(BackgroundIndeterminate)] = value;
		}
		public Brush BackgroundIndeterminatePointerOver
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundIndeterminatePointerOver)];
			set => _resources[_controlName + nameof(BackgroundIndeterminatePointerOver)] = value;
		}
		public Brush BackgroundIndeterminatePressed
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundIndeterminatePressed)];
			set => _resources[_controlName + nameof(BackgroundIndeterminatePressed)] = value;
		}
		public Brush BackgroundIndeterminateDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundIndeterminateDisabled)];
			set => _resources[_controlName + nameof(BackgroundIndeterminateDisabled)] = value;
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
		public Brush ForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundDisabled)];
			set => _resources[_controlName + nameof(ForegroundDisabled)] = value;
		}
		public Brush ForegroundChecked
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundChecked)];
			set => _resources[_controlName + nameof(ForegroundChecked)] = value;
		}
		public Brush ForegroundCheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundCheckedPointerOver)];
			set => _resources[_controlName + nameof(ForegroundCheckedPointerOver)] = value;
		}
		public Brush ForegroundCheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundCheckedPressed)];
			set => _resources[_controlName + nameof(ForegroundCheckedPressed)] = value;
		}
		public Brush ForegroundCheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundCheckedDisabled)];
			set => _resources[_controlName + nameof(ForegroundCheckedDisabled)] = value;
		}
		public Brush ForegroundIndeterminate
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundIndeterminate)];
			set => _resources[_controlName + nameof(ForegroundIndeterminate)] = value;
		}
		public Brush ForegroundIndeterminatePointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundIndeterminatePointerOver)];
			set => _resources[_controlName + nameof(ForegroundIndeterminatePointerOver)] = value;
		}
		public Brush ForegroundIndeterminatePressed
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundIndeterminatePressed)];
			set => _resources[_controlName + nameof(ForegroundIndeterminatePressed)] = value;
		}
		public Brush ForegroundIndeterminateDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundIndeterminateDisabled)];
			set => _resources[_controlName + nameof(ForegroundIndeterminateDisabled)] = value;
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
		public Brush BorderBrushChecked
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushChecked)];
			set => _resources[_controlName + nameof(BorderBrushChecked)] = value;
		}
		public Brush BorderBrushCheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushCheckedPointerOver)];
			set => _resources[_controlName + nameof(BorderBrushCheckedPointerOver)] = value;
		}
		public Brush BorderBrushCheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushCheckedPressed)];
			set => _resources[_controlName + nameof(BorderBrushCheckedPressed)] = value;
		}
		public Brush BorderBrushCheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushCheckedDisabled)];
			set => _resources[_controlName + nameof(BorderBrushCheckedDisabled)] = value;
		}
		public Brush BorderBrushIndeterminate
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushIndeterminate)];
			set => _resources[_controlName + nameof(BorderBrushIndeterminate)] = value;
		}
		public Brush BorderBrushIndeterminatePointerOver
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushIndeterminatePointerOver)];
			set => _resources[_controlName + nameof(BorderBrushIndeterminatePointerOver)] = value;
		}
		public Brush BorderBrushIndeterminatePressed
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushIndeterminatePressed)];
			set => _resources[_controlName + nameof(BorderBrushIndeterminatePressed)] = value;
		}
		public Brush BorderBrushIndeterminateDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushIndeterminateDisabled)];
			set => _resources[_controlName + nameof(BorderBrushIndeterminateDisabled)] = value;
		}
		//GenerateAuto by tuanhungdev
	}

}
