using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace WinUI3.Controls.SR
{
	public class ResScrollBar : DependencyObject
	{
		public ResScrollBar()
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
		private const string _controlName = "ScrollBar";
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
		public Brush BackgroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundDisabled)];
			set => _resources[_controlName + nameof(BackgroundDisabled)] = value;
		}
		public Brush Foreground
		{
			get => (Brush)_resources[_controlName + nameof(Foreground)];
			set => _resources[_controlName + nameof(Foreground)] = value;
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
		public Brush BorderBrushDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushDisabled)];
			set => _resources[_controlName + nameof(BorderBrushDisabled)] = value;
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
		public Brush ButtonArrowForeground
		{
			get => (Brush)_resources[_controlName + nameof(ButtonArrowForeground)];
			set => _resources[_controlName + nameof(ButtonArrowForeground)] = value;
		}
		public Brush ButtonArrowForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ButtonArrowForegroundPointerOver)];
			set => _resources[_controlName + nameof(ButtonArrowForegroundPointerOver)] = value;
		}
		public Brush ButtonArrowForegroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(ButtonArrowForegroundPressed)];
			set => _resources[_controlName + nameof(ButtonArrowForegroundPressed)] = value;
		}
		public Brush ButtonArrowForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ButtonArrowForegroundDisabled)];
			set => _resources[_controlName + nameof(ButtonArrowForegroundDisabled)] = value;
		}
		public Brush ThumbFill
		{
			get => (Brush)_resources[_controlName + nameof(ThumbFill)];
			set => _resources[_controlName + nameof(ThumbFill)] = value;
		}
		public Brush ThumbFillPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ThumbFillPointerOver)];
			set => _resources[_controlName + nameof(ThumbFillPointerOver)] = value;
		}
		public Brush ThumbFillPressed
		{
			get => (Brush)_resources[_controlName + nameof(ThumbFillPressed)];
			set => _resources[_controlName + nameof(ThumbFillPressed)] = value;
		}
		public Brush ThumbFillDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ThumbFillDisabled)];
			set => _resources[_controlName + nameof(ThumbFillDisabled)] = value;
		}
		public Brush TrackFill
		{
			get => (Brush)_resources[_controlName + nameof(TrackFill)];
			set => _resources[_controlName + nameof(TrackFill)] = value;
		}
		public Brush TrackFillPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(TrackFillPointerOver)];
			set => _resources[_controlName + nameof(TrackFillPointerOver)] = value;
		}
		public Brush TrackFillDisabled
		{
			get => (Brush)_resources[_controlName + nameof(TrackFillDisabled)];
			set => _resources[_controlName + nameof(TrackFillDisabled)] = value;
		}
		public Brush TrackStroke
		{
			get => (Brush)_resources[_controlName + nameof(TrackStroke)];
			set => _resources[_controlName + nameof(TrackStroke)] = value;
		}
		public Brush TrackStrokePointerOver
		{
			get => (Brush)_resources[_controlName + nameof(TrackStrokePointerOver)];
			set => _resources[_controlName + nameof(TrackStrokePointerOver)] = value;
		}
		public Brush TrackStrokeDisabled
		{
			get => (Brush)_resources[_controlName + nameof(TrackStrokeDisabled)];
			set => _resources[_controlName + nameof(TrackStrokeDisabled)] = value;
		}
		public Brush PanningThumbBackgroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(PanningThumbBackgroundDisabled)];
			set => _resources[_controlName + nameof(PanningThumbBackgroundDisabled)] = value;
		}
		public Brush ThumbBackgroundColor
		{
			get => (Brush)_resources[_controlName + nameof(ThumbBackgroundColor)];
			set => _resources[_controlName + nameof(ThumbBackgroundColor)] = value;
		}
		public Brush PanningThumbBackgroundColor
		{
			get => (Brush)_resources[_controlName + nameof(PanningThumbBackgroundColor)];
			set => _resources[_controlName + nameof(PanningThumbBackgroundColor)] = value;
		}
		public Brush ThumbBackground
		{
			get => (Brush)_resources[_controlName + nameof(ThumbBackground)];
			set => _resources[_controlName + nameof(ThumbBackground)] = value;
		}
		public Brush PanningThumbBackground
		{
			get => (Brush)_resources[_controlName + nameof(PanningThumbBackground)];
			set => _resources[_controlName + nameof(PanningThumbBackground)] = value;
		}
		//GenerateAuto by tuanhungdev
	}

}
