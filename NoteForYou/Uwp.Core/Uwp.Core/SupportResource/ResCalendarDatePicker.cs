using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uwp.Controls.SR
{
	public class ResCalendarDatePicker : DependencyObject
	{
		public ResCalendarDatePicker()
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
		private const string _controlName = "CalendarDatePicker";
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
		public Brush CalendarGlyphForeground
		{
			get => (Brush)_resources[_controlName + nameof(CalendarGlyphForeground)];
			set => _resources[_controlName + nameof(CalendarGlyphForeground)] = value;
		}
		public Brush CalendarGlyphForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CalendarGlyphForegroundDisabled)];
			set => _resources[_controlName + nameof(CalendarGlyphForegroundDisabled)] = value;
		}
		public Brush TextForeground
		{
			get => (Brush)_resources[_controlName + nameof(TextForeground)];
			set => _resources[_controlName + nameof(TextForeground)] = value;
		}
		public Brush TextForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(TextForegroundDisabled)];
			set => _resources[_controlName + nameof(TextForegroundDisabled)] = value;
		}
		public Brush TextForegroundSelected
		{
			get => (Brush)_resources[_controlName + nameof(TextForegroundSelected)];
			set => _resources[_controlName + nameof(TextForegroundSelected)] = value;
		}
		public Brush HeaderForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(HeaderForegroundDisabled)];
			set => _resources[_controlName + nameof(HeaderForegroundDisabled)] = value;
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
		public Brush BackgroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundDisabled)];
			set => _resources[_controlName + nameof(BackgroundDisabled)] = value;
		}
		public Brush BackgroundFocused
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundFocused)];
			set => _resources[_controlName + nameof(BackgroundFocused)] = value;
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
		//GenerateAuto by tuanhungdev
	}


}
