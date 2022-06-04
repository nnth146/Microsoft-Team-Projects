using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uwp.Core.SR
{
	public class ResPivot : DependencyObject
	{
		public ResPivot()
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
		private const string _controlName = "Pivot";
		public Brush Background
		{
			get => (Brush)_resources[_controlName + nameof(Background)];
			set => _resources[_controlName + nameof(Background)] = value;
		}
		public Brush HeaderBackground
		{
			get => (Brush)_resources[_controlName + nameof(HeaderBackground)];
			set => _resources[_controlName + nameof(HeaderBackground)] = value;
		}
		public Brush NextButtonBackground
		{
			get => (Brush)_resources[_controlName + nameof(NextButtonBackground)];
			set => _resources[_controlName + nameof(NextButtonBackground)] = value;
		}
		public Brush NextButtonBackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(NextButtonBackgroundPointerOver)];
			set => _resources[_controlName + nameof(NextButtonBackgroundPointerOver)] = value;
		}
		public Brush NextButtonBackgroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(NextButtonBackgroundPressed)];
			set => _resources[_controlName + nameof(NextButtonBackgroundPressed)] = value;
		}
		public Brush NextButtonBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(NextButtonBorderBrush)];
			set => _resources[_controlName + nameof(NextButtonBorderBrush)] = value;
		}
		public Brush NextButtonBorderBrushPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(NextButtonBorderBrushPointerOver)];
			set => _resources[_controlName + nameof(NextButtonBorderBrushPointerOver)] = value;
		}
		public Brush NextButtonBorderBrushPressed
		{
			get => (Brush)_resources[_controlName + nameof(NextButtonBorderBrushPressed)];
			set => _resources[_controlName + nameof(NextButtonBorderBrushPressed)] = value;
		}
		public Brush NextButtonForeground
		{
			get => (Brush)_resources[_controlName + nameof(NextButtonForeground)];
			set => _resources[_controlName + nameof(NextButtonForeground)] = value;
		}
		public Brush NextButtonForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(NextButtonForegroundPointerOver)];
			set => _resources[_controlName + nameof(NextButtonForegroundPointerOver)] = value;
		}
		public Brush NextButtonForegroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(NextButtonForegroundPressed)];
			set => _resources[_controlName + nameof(NextButtonForegroundPressed)] = value;
		}
		public Brush PreviousButtonBackground
		{
			get => (Brush)_resources[_controlName + nameof(PreviousButtonBackground)];
			set => _resources[_controlName + nameof(PreviousButtonBackground)] = value;
		}
		public Brush PreviousButtonBackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(PreviousButtonBackgroundPointerOver)];
			set => _resources[_controlName + nameof(PreviousButtonBackgroundPointerOver)] = value;
		}
		public Brush PreviousButtonBackgroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(PreviousButtonBackgroundPressed)];
			set => _resources[_controlName + nameof(PreviousButtonBackgroundPressed)] = value;
		}
		public Brush PreviousButtonBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(PreviousButtonBorderBrush)];
			set => _resources[_controlName + nameof(PreviousButtonBorderBrush)] = value;
		}
		public Brush PreviousButtonBorderBrushPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(PreviousButtonBorderBrushPointerOver)];
			set => _resources[_controlName + nameof(PreviousButtonBorderBrushPointerOver)] = value;
		}
		public Brush PreviousButtonBorderBrushPressed
		{
			get => (Brush)_resources[_controlName + nameof(PreviousButtonBorderBrushPressed)];
			set => _resources[_controlName + nameof(PreviousButtonBorderBrushPressed)] = value;
		}
		public Brush PreviousButtonForeground
		{
			get => (Brush)_resources[_controlName + nameof(PreviousButtonForeground)];
			set => _resources[_controlName + nameof(PreviousButtonForeground)] = value;
		}
		public Brush PreviousButtonForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(PreviousButtonForegroundPointerOver)];
			set => _resources[_controlName + nameof(PreviousButtonForegroundPointerOver)] = value;
		}
		public Brush PreviousButtonForegroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(PreviousButtonForegroundPressed)];
			set => _resources[_controlName + nameof(PreviousButtonForegroundPressed)] = value;
		}
		//GenerateAuto by tuanhungdev
	}

}
