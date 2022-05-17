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
	public class ResRadioButton : DependencyObject
	{
		public ResRadioButton()
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
		private const string _controlName = "RadioButton";
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
		public Brush OuterEllipseStroke
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseStroke)];
			set => _resources[_controlName + nameof(OuterEllipseStroke)] = value;
		}
		public Brush OuterEllipseStrokePointerOver
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseStrokePointerOver)];
			set => _resources[_controlName + nameof(OuterEllipseStrokePointerOver)] = value;
		}
		public Brush OuterEllipseStrokePressed
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseStrokePressed)];
			set => _resources[_controlName + nameof(OuterEllipseStrokePressed)] = value;
		}
		public Brush OuterEllipseStrokeDisabled
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseStrokeDisabled)];
			set => _resources[_controlName + nameof(OuterEllipseStrokeDisabled)] = value;
		}
		public Brush OuterEllipseFill
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseFill)];
			set => _resources[_controlName + nameof(OuterEllipseFill)] = value;
		}
		public Brush OuterEllipseFillPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseFillPointerOver)];
			set => _resources[_controlName + nameof(OuterEllipseFillPointerOver)] = value;
		}
		public Brush OuterEllipseFillPressed
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseFillPressed)];
			set => _resources[_controlName + nameof(OuterEllipseFillPressed)] = value;
		}
		public Brush OuterEllipseFillDisabled
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseFillDisabled)];
			set => _resources[_controlName + nameof(OuterEllipseFillDisabled)] = value;
		}
		public Brush OuterEllipseCheckedStroke
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseCheckedStroke)];
			set => _resources[_controlName + nameof(OuterEllipseCheckedStroke)] = value;
		}
		public Brush OuterEllipseCheckedStrokePointerOver
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseCheckedStrokePointerOver)];
			set => _resources[_controlName + nameof(OuterEllipseCheckedStrokePointerOver)] = value;
		}
		public Brush OuterEllipseCheckedStrokePressed
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseCheckedStrokePressed)];
			set => _resources[_controlName + nameof(OuterEllipseCheckedStrokePressed)] = value;
		}
		public Brush OuterEllipseCheckedStrokeDisabled
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseCheckedStrokeDisabled)];
			set => _resources[_controlName + nameof(OuterEllipseCheckedStrokeDisabled)] = value;
		}
		public Brush OuterEllipseCheckedFill
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseCheckedFill)];
			set => _resources[_controlName + nameof(OuterEllipseCheckedFill)] = value;
		}
		public Brush OuterEllipseCheckedFillPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseCheckedFillPointerOver)];
			set => _resources[_controlName + nameof(OuterEllipseCheckedFillPointerOver)] = value;
		}
		public Brush OuterEllipseCheckedFillPressed
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseCheckedFillPressed)];
			set => _resources[_controlName + nameof(OuterEllipseCheckedFillPressed)] = value;
		}
		public Brush OuterEllipseCheckedFillDisabled
		{
			get => (Brush)_resources[_controlName + nameof(OuterEllipseCheckedFillDisabled)];
			set => _resources[_controlName + nameof(OuterEllipseCheckedFillDisabled)] = value;
		}
		public Brush CheckGlyphFill
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphFill)];
			set => _resources[_controlName + nameof(CheckGlyphFill)] = value;
		}
		public Brush CheckGlyphFillPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphFillPointerOver)];
			set => _resources[_controlName + nameof(CheckGlyphFillPointerOver)] = value;
		}
		public Brush CheckGlyphFillPressed
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphFillPressed)];
			set => _resources[_controlName + nameof(CheckGlyphFillPressed)] = value;
		}
		public Brush CheckGlyphFillDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphFillDisabled)];
			set => _resources[_controlName + nameof(CheckGlyphFillDisabled)] = value;
		}
		public Brush CheckGlyphStroke
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphStroke)];
			set => _resources[_controlName + nameof(CheckGlyphStroke)] = value;
		}
		public Brush CheckGlyphStrokePointerOver
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphStrokePointerOver)];
			set => _resources[_controlName + nameof(CheckGlyphStrokePointerOver)] = value;
		}
		public Brush CheckGlyphStrokePressed
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphStrokePressed)];
			set => _resources[_controlName + nameof(CheckGlyphStrokePressed)] = value;
		}
		public Brush CheckGlyphStrokeDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphStrokeDisabled)];
			set => _resources[_controlName + nameof(CheckGlyphStrokeDisabled)] = value;
		}
		//GenerateAuto by tuanhungdev
	}

}
