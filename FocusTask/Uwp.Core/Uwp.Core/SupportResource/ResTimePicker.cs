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
	public class ResTimePicker : DependencyObject
	{
		public ResTimePicker()
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
		private const string _controlName = "TimePicker";
		public Brush SpacerFill
		{
			get => (Brush)_resources[_controlName + nameof(SpacerFill)];
			set => _resources[_controlName + nameof(SpacerFill)] = value;
		}
		public Brush SpacerFillDisabled
		{
			get => (Brush)_resources[_controlName + nameof(SpacerFillDisabled)];
			set => _resources[_controlName + nameof(SpacerFillDisabled)] = value;
		}
		public Brush HeaderForeground
		{
			get => (Brush)_resources[_controlName + nameof(HeaderForeground)];
			set => _resources[_controlName + nameof(HeaderForeground)] = value;
		}
		public Brush HeaderForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(HeaderForegroundDisabled)];
			set => _resources[_controlName + nameof(HeaderForegroundDisabled)] = value;
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
		public Brush ButtonBackgroundFocused
		{
			get => (Brush)_resources[_controlName + nameof(ButtonBackgroundFocused)];
			set => _resources[_controlName + nameof(ButtonBackgroundFocused)] = value;
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
		public Brush ButtonForegroundFocused
		{
			get => (Brush)_resources[_controlName + nameof(ButtonForegroundFocused)];
			set => _resources[_controlName + nameof(ButtonForegroundFocused)] = value;
		}
		//GenerateAuto by tuanhungdev
	}

}
