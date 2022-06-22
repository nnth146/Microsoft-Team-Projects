using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uwp.Core.SR
{
	public class ResThumb : DependencyObject
	{
		public ResThumb()
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
		private const string _controlName = "Thumb";
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
		//GenerateAuto by tuanhungdev
	}

}
