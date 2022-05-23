using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uwp.Controls.SR
{
	public class ResCheckBox : DependencyObject
	{
		public ResCheckBox()
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
		private const string _controlName = "CheckBox";
		public Brush ForegroundUnchecked
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundUnchecked)];
			set => _resources[_controlName + nameof(ForegroundUnchecked)] = value;
		}
		public Brush ForegroundUncheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundUncheckedPointerOver)];
			set => _resources[_controlName + nameof(ForegroundUncheckedPointerOver)] = value;
		}
		public Brush ForegroundUncheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundUncheckedPressed)];
			set => _resources[_controlName + nameof(ForegroundUncheckedPressed)] = value;
		}
		public Brush ForegroundUncheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ForegroundUncheckedDisabled)];
			set => _resources[_controlName + nameof(ForegroundUncheckedDisabled)] = value;
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
		public Brush BackgroundUnchecked
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundUnchecked)];
			set => _resources[_controlName + nameof(BackgroundUnchecked)] = value;
		}
		public Brush BackgroundUncheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundUncheckedPointerOver)];
			set => _resources[_controlName + nameof(BackgroundUncheckedPointerOver)] = value;
		}
		public Brush BackgroundUncheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundUncheckedPressed)];
			set => _resources[_controlName + nameof(BackgroundUncheckedPressed)] = value;
		}
		public Brush BackgroundUncheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BackgroundUncheckedDisabled)];
			set => _resources[_controlName + nameof(BackgroundUncheckedDisabled)] = value;
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
		public Brush BorderBrushUnchecked
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushUnchecked)];
			set => _resources[_controlName + nameof(BorderBrushUnchecked)] = value;
		}
		public Brush BorderBrushUncheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushUncheckedPointerOver)];
			set => _resources[_controlName + nameof(BorderBrushUncheckedPointerOver)] = value;
		}
		public Brush BorderBrushUncheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushUncheckedPressed)];
			set => _resources[_controlName + nameof(BorderBrushUncheckedPressed)] = value;
		}
		public Brush BorderBrushUncheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(BorderBrushUncheckedDisabled)];
			set => _resources[_controlName + nameof(BorderBrushUncheckedDisabled)] = value;
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
		public Brush CheckBackgroundStrokeUnchecked
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeUnchecked)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeUnchecked)] = value;
		}
		public Brush CheckBackgroundStrokeUncheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeUncheckedPointerOver)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeUncheckedPointerOver)] = value;
		}
		public Brush CheckBackgroundStrokeUncheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeUncheckedPressed)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeUncheckedPressed)] = value;
		}
		public Brush CheckBackgroundStrokeUncheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeUncheckedDisabled)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeUncheckedDisabled)] = value;
		}
		public Brush CheckBackgroundStrokeChecked
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeChecked)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeChecked)] = value;
		}
		public Brush CheckBackgroundStrokeCheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeCheckedPointerOver)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeCheckedPointerOver)] = value;
		}
		public Brush CheckBackgroundStrokeCheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeCheckedPressed)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeCheckedPressed)] = value;
		}
		public Brush CheckBackgroundStrokeCheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeCheckedDisabled)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeCheckedDisabled)] = value;
		}
		public Brush CheckBackgroundStrokeIndeterminate
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeIndeterminate)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeIndeterminate)] = value;
		}
		public Brush CheckBackgroundStrokeIndeterminatePointerOver
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeIndeterminatePointerOver)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeIndeterminatePointerOver)] = value;
		}
		public Brush CheckBackgroundStrokeIndeterminatePressed
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeIndeterminatePressed)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeIndeterminatePressed)] = value;
		}
		public Brush CheckBackgroundStrokeIndeterminateDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundStrokeIndeterminateDisabled)];
			set => _resources[_controlName + nameof(CheckBackgroundStrokeIndeterminateDisabled)] = value;
		}
		public Brush CheckBackgroundFillUnchecked
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillUnchecked)];
			set => _resources[_controlName + nameof(CheckBackgroundFillUnchecked)] = value;
		}
		public Brush CheckBackgroundFillUncheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillUncheckedPointerOver)];
			set => _resources[_controlName + nameof(CheckBackgroundFillUncheckedPointerOver)] = value;
		}
		public Brush CheckBackgroundFillUncheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillUncheckedPressed)];
			set => _resources[_controlName + nameof(CheckBackgroundFillUncheckedPressed)] = value;
		}
		public Brush CheckBackgroundFillUncheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillUncheckedDisabled)];
			set => _resources[_controlName + nameof(CheckBackgroundFillUncheckedDisabled)] = value;
		}
		public Brush CheckBackgroundFillChecked
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillChecked)];
			set => _resources[_controlName + nameof(CheckBackgroundFillChecked)] = value;
		}
		public Brush CheckBackgroundFillCheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillCheckedPointerOver)];
			set => _resources[_controlName + nameof(CheckBackgroundFillCheckedPointerOver)] = value;
		}
		public Brush CheckBackgroundFillCheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillCheckedPressed)];
			set => _resources[_controlName + nameof(CheckBackgroundFillCheckedPressed)] = value;
		}
		public Brush CheckBackgroundFillCheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillCheckedDisabled)];
			set => _resources[_controlName + nameof(CheckBackgroundFillCheckedDisabled)] = value;
		}
		public Brush CheckBackgroundFillIndeterminate
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillIndeterminate)];
			set => _resources[_controlName + nameof(CheckBackgroundFillIndeterminate)] = value;
		}
		public Brush CheckBackgroundFillIndeterminatePointerOver
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillIndeterminatePointerOver)];
			set => _resources[_controlName + nameof(CheckBackgroundFillIndeterminatePointerOver)] = value;
		}
		public Brush CheckBackgroundFillIndeterminatePressed
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillIndeterminatePressed)];
			set => _resources[_controlName + nameof(CheckBackgroundFillIndeterminatePressed)] = value;
		}
		public Brush CheckBackgroundFillIndeterminateDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CheckBackgroundFillIndeterminateDisabled)];
			set => _resources[_controlName + nameof(CheckBackgroundFillIndeterminateDisabled)] = value;
		}
		public Brush CheckGlyphForegroundUnchecked
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundUnchecked)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundUnchecked)] = value;
		}
		public Brush CheckGlyphForegroundUncheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundUncheckedPointerOver)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundUncheckedPointerOver)] = value;
		}
		public Brush CheckGlyphForegroundUncheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundUncheckedPressed)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundUncheckedPressed)] = value;
		}
		public Brush CheckGlyphForegroundUncheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundUncheckedDisabled)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundUncheckedDisabled)] = value;
		}
		public Brush CheckGlyphForegroundChecked
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundChecked)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundChecked)] = value;
		}
		public Brush CheckGlyphForegroundCheckedPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundCheckedPointerOver)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundCheckedPointerOver)] = value;
		}
		public Brush CheckGlyphForegroundCheckedPressed
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundCheckedPressed)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundCheckedPressed)] = value;
		}
		public Brush CheckGlyphForegroundCheckedDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundCheckedDisabled)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundCheckedDisabled)] = value;
		}
		public Brush CheckGlyphForegroundIndeterminate
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundIndeterminate)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundIndeterminate)] = value;
		}
		public Brush CheckGlyphForegroundIndeterminatePointerOver
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundIndeterminatePointerOver)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundIndeterminatePointerOver)] = value;
		}
		public Brush CheckGlyphForegroundIndeterminatePressed
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundIndeterminatePressed)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundIndeterminatePressed)] = value;
		}
		public Brush CheckGlyphForegroundIndeterminateDisabled
		{
			get => (Brush)_resources[_controlName + nameof(CheckGlyphForegroundIndeterminateDisabled)];
			set => _resources[_controlName + nameof(CheckGlyphForegroundIndeterminateDisabled)] = value;
		}
		//GenerateAuto by tuanhungdev
	}


}
