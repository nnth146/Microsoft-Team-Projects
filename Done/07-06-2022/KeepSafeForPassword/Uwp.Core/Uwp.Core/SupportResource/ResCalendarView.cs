using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uwp.Controls.SR
{
	public class ResCalendarView : DependencyObject
	{
		public ResCalendarView()
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
		private const string _controlName = "CalendarView";
		public Brush FocusBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(FocusBorderBrush)];
			set => _resources[_controlName + nameof(FocusBorderBrush)] = value;
		}
		public Brush SelectedHoverBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(SelectedHoverBorderBrush)];
			set => _resources[_controlName + nameof(SelectedHoverBorderBrush)] = value;
		}
		public Brush SelectedPressedBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(SelectedPressedBorderBrush)];
			set => _resources[_controlName + nameof(SelectedPressedBorderBrush)] = value;
		}
		public Brush SelectedBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(SelectedBorderBrush)];
			set => _resources[_controlName + nameof(SelectedBorderBrush)] = value;
		}
		public Brush HoverBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(HoverBorderBrush)];
			set => _resources[_controlName + nameof(HoverBorderBrush)] = value;
		}
		public Brush PressedBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(PressedBorderBrush)];
			set => _resources[_controlName + nameof(PressedBorderBrush)] = value;
		}
		public Brush TodayForeground
		{
			get => (Brush)_resources[_controlName + nameof(TodayForeground)];
			set => _resources[_controlName + nameof(TodayForeground)] = value;
		}
		public Brush BlackoutForeground
		{
			get => (Brush)_resources[_controlName + nameof(BlackoutForeground)];
			set => _resources[_controlName + nameof(BlackoutForeground)] = value;
		}
		public Brush SelectedForeground
		{
			get => (Brush)_resources[_controlName + nameof(SelectedForeground)];
			set => _resources[_controlName + nameof(SelectedForeground)] = value;
		}
		public Brush PressedForeground
		{
			get => (Brush)_resources[_controlName + nameof(PressedForeground)];
			set => _resources[_controlName + nameof(PressedForeground)] = value;
		}
		public Brush OutOfScopeForeground
		{
			get => (Brush)_resources[_controlName + nameof(OutOfScopeForeground)];
			set => _resources[_controlName + nameof(OutOfScopeForeground)] = value;
		}
		public Brush CalendarItemForeground
		{
			get => (Brush)_resources[_controlName + nameof(CalendarItemForeground)];
			set => _resources[_controlName + nameof(CalendarItemForeground)] = value;
		}
		public Brush OutOfScopeBackground
		{
			get => (Brush)_resources[_controlName + nameof(OutOfScopeBackground)];
			set => _resources[_controlName + nameof(OutOfScopeBackground)] = value;
		}
		public Brush CalendarItemBackground
		{
			get => (Brush)_resources[_controlName + nameof(CalendarItemBackground)];
			set => _resources[_controlName + nameof(CalendarItemBackground)] = value;
		}
		public Brush Foreground
		{
			get => (Brush)_resources[_controlName + nameof(Foreground)];
			set => _resources[_controlName + nameof(Foreground)] = value;
		}
		public Brush Background
		{
			get => (Brush)_resources[_controlName + nameof(Background)];
			set => _resources[_controlName + nameof(Background)] = value;
		}
		public Brush BorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrush)];
			set => _resources[_controlName + nameof(BorderBrush)] = value;
		}
		public Brush WeekDayForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(WeekDayForegroundDisabled)];
			set => _resources[_controlName + nameof(WeekDayForegroundDisabled)] = value;
		}
		public Brush NavigationButtonBackground
		{
			get => (Brush)_resources[_controlName + nameof(NavigationButtonBackground)];
			set => _resources[_controlName + nameof(NavigationButtonBackground)] = value;
		}
		public Brush NavigationButtonForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(NavigationButtonForegroundPointerOver)];
			set => _resources[_controlName + nameof(NavigationButtonForegroundPointerOver)] = value;
		}
		public Brush NavigationButtonForegroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(NavigationButtonForegroundPressed)];
			set => _resources[_controlName + nameof(NavigationButtonForegroundPressed)] = value;
		}
		public Brush NavigationButtonForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(NavigationButtonForegroundDisabled)];
			set => _resources[_controlName + nameof(NavigationButtonForegroundDisabled)] = value;
		}
		public Brush CalendarItemRevealBackground
		{
			get => (Brush)_resources[_controlName + nameof(CalendarItemRevealBackground)];
			set => _resources[_controlName + nameof(CalendarItemRevealBackground)] = value;
		}
		public Brush CalendarItemRevealBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(CalendarItemRevealBorderBrush)];
			set => _resources[_controlName + nameof(CalendarItemRevealBorderBrush)] = value;
		}
		public Brush NavigationButtonBorderBrushPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(NavigationButtonBorderBrushPointerOver)];
			set => _resources[_controlName + nameof(NavigationButtonBorderBrushPointerOver)] = value;
		}
		public Brush NavigationButtonBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(NavigationButtonBorderBrush)];
			set => _resources[_controlName + nameof(NavigationButtonBorderBrush)] = value;
		}
		//GenerateAuto by tuanhungdev
	}

}
