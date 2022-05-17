using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace WinUI3.Controls.SR
{
	public class ResSlider : DependencyObject
	{
		public ResSlider()
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
		private const string _controlName = "Slider";
		public Brush ContainerBackground
		{
			get => (Brush)_resources[_controlName + nameof(ContainerBackground)];
			set => _resources[_controlName + nameof(ContainerBackground)] = value;
		}
		public Brush ContainerBackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ContainerBackgroundPointerOver)];
			set => _resources[_controlName + nameof(ContainerBackgroundPointerOver)] = value;
		}
		public Brush ContainerBackgroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(ContainerBackgroundPressed)];
			set => _resources[_controlName + nameof(ContainerBackgroundPressed)] = value;
		}
		public Brush ContainerBackgroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ContainerBackgroundDisabled)];
			set => _resources[_controlName + nameof(ContainerBackgroundDisabled)] = value;
		}
		public Brush ThumbBackground
		{
			get => (Brush)_resources[_controlName + nameof(ThumbBackground)];
			set => _resources[_controlName + nameof(ThumbBackground)] = value;
		}
		public Brush ThumbBackgroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ThumbBackgroundPointerOver)];
			set => _resources[_controlName + nameof(ThumbBackgroundPointerOver)] = value;
		}
		public Brush ThumbBackgroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(ThumbBackgroundPressed)];
			set => _resources[_controlName + nameof(ThumbBackgroundPressed)] = value;
		}
		public Brush ThumbBackgroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ThumbBackgroundDisabled)];
			set => _resources[_controlName + nameof(ThumbBackgroundDisabled)] = value;
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
		public Brush TrackFillPressed
		{
			get => (Brush)_resources[_controlName + nameof(TrackFillPressed)];
			set => _resources[_controlName + nameof(TrackFillPressed)] = value;
		}
		public Brush TrackFillDisabled
		{
			get => (Brush)_resources[_controlName + nameof(TrackFillDisabled)];
			set => _resources[_controlName + nameof(TrackFillDisabled)] = value;
		}
		public Brush TrackValueFill
		{
			get => (Brush)_resources[_controlName + nameof(TrackValueFill)];
			set => _resources[_controlName + nameof(TrackValueFill)] = value;
		}
		public Brush TrackValueFillPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(TrackValueFillPointerOver)];
			set => _resources[_controlName + nameof(TrackValueFillPointerOver)] = value;
		}
		public Brush TrackValueFillPressed
		{
			get => (Brush)_resources[_controlName + nameof(TrackValueFillPressed)];
			set => _resources[_controlName + nameof(TrackValueFillPressed)] = value;
		}
		public Brush TrackValueFillDisabled
		{
			get => (Brush)_resources[_controlName + nameof(TrackValueFillDisabled)];
			set => _resources[_controlName + nameof(TrackValueFillDisabled)] = value;
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
		public Brush TickBarFill
		{
			get => (Brush)_resources[_controlName + nameof(TickBarFill)];
			set => _resources[_controlName + nameof(TickBarFill)] = value;
		}
		public Brush TickBarFillDisabled
		{
			get => (Brush)_resources[_controlName + nameof(TickBarFillDisabled)];
			set => _resources[_controlName + nameof(TickBarFillDisabled)] = value;
		}
		public Brush InlineTickBarFill
		{
			get => (Brush)_resources[_controlName + nameof(InlineTickBarFill)];
			set => _resources[_controlName + nameof(InlineTickBarFill)] = value;
		}
		//GenerateAuto by tuanhungdev
	}

}
