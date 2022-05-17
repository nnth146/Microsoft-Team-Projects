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
	public class ResToggleSwitch : DependencyObject
	{
		public ResToggleSwitch()
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
		private const string _controlName = "ToggleSwitch";
		public Brush ContentForeground
		{
			get => (Brush)_resources[_controlName + nameof(ContentForeground)];
			set => _resources[_controlName + nameof(ContentForeground)] = value;
		}
		public Brush ContentForegroundDisabled
		{
			get => (Brush)_resources[_controlName + nameof(ContentForegroundDisabled)];
			set => _resources[_controlName + nameof(ContentForegroundDisabled)] = value;
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
		public Brush FillOff
		{
			get => (Brush)_resources[_controlName + nameof(FillOff)];
			set => _resources[_controlName + nameof(FillOff)] = value;
		}
		public Brush FillOffPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(FillOffPointerOver)];
			set => _resources[_controlName + nameof(FillOffPointerOver)] = value;
		}
		public Brush FillOffPressed
		{
			get => (Brush)_resources[_controlName + nameof(FillOffPressed)];
			set => _resources[_controlName + nameof(FillOffPressed)] = value;
		}
		public Brush FillOffDisabled
		{
			get => (Brush)_resources[_controlName + nameof(FillOffDisabled)];
			set => _resources[_controlName + nameof(FillOffDisabled)] = value;
		}
		public Brush StrokeOff
		{
			get => (Brush)_resources[_controlName + nameof(StrokeOff)];
			set => _resources[_controlName + nameof(StrokeOff)] = value;
		}
		public Brush StrokeOffPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(StrokeOffPointerOver)];
			set => _resources[_controlName + nameof(StrokeOffPointerOver)] = value;
		}
		public Brush StrokeOffPressed
		{
			get => (Brush)_resources[_controlName + nameof(StrokeOffPressed)];
			set => _resources[_controlName + nameof(StrokeOffPressed)] = value;
		}
		public Brush StrokeOffDisabled
		{
			get => (Brush)_resources[_controlName + nameof(StrokeOffDisabled)];
			set => _resources[_controlName + nameof(StrokeOffDisabled)] = value;
		}
		public Brush FillOn
		{
			get => (Brush)_resources[_controlName + nameof(FillOn)];
			set => _resources[_controlName + nameof(FillOn)] = value;
		}
		public Brush FillOnPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(FillOnPointerOver)];
			set => _resources[_controlName + nameof(FillOnPointerOver)] = value;
		}
		public Brush FillOnPressed
		{
			get => (Brush)_resources[_controlName + nameof(FillOnPressed)];
			set => _resources[_controlName + nameof(FillOnPressed)] = value;
		}
		public Brush FillOnDisabled
		{
			get => (Brush)_resources[_controlName + nameof(FillOnDisabled)];
			set => _resources[_controlName + nameof(FillOnDisabled)] = value;
		}
		public Brush StrokeOn
		{
			get => (Brush)_resources[_controlName + nameof(StrokeOn)];
			set => _resources[_controlName + nameof(StrokeOn)] = value;
		}
		public Brush StrokeOnPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(StrokeOnPointerOver)];
			set => _resources[_controlName + nameof(StrokeOnPointerOver)] = value;
		}
		public Brush StrokeOnPressed
		{
			get => (Brush)_resources[_controlName + nameof(StrokeOnPressed)];
			set => _resources[_controlName + nameof(StrokeOnPressed)] = value;
		}
		public Brush StrokeOnDisabled
		{
			get => (Brush)_resources[_controlName + nameof(StrokeOnDisabled)];
			set => _resources[_controlName + nameof(StrokeOnDisabled)] = value;
		}
		public Brush KnobFillOff
		{
			get => (Brush)_resources[_controlName + nameof(KnobFillOff)];
			set => _resources[_controlName + nameof(KnobFillOff)] = value;
		}
		public Brush KnobFillOffPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(KnobFillOffPointerOver)];
			set => _resources[_controlName + nameof(KnobFillOffPointerOver)] = value;
		}
		public Brush KnobFillOffPressed
		{
			get => (Brush)_resources[_controlName + nameof(KnobFillOffPressed)];
			set => _resources[_controlName + nameof(KnobFillOffPressed)] = value;
		}
		public Brush KnobFillOffDisabled
		{
			get => (Brush)_resources[_controlName + nameof(KnobFillOffDisabled)];
			set => _resources[_controlName + nameof(KnobFillOffDisabled)] = value;
		}
		public Brush KnobFillOn
		{
			get => (Brush)_resources[_controlName + nameof(KnobFillOn)];
			set => _resources[_controlName + nameof(KnobFillOn)] = value;
		}
		public Brush KnobFillOnPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(KnobFillOnPointerOver)];
			set => _resources[_controlName + nameof(KnobFillOnPointerOver)] = value;
		}
		public Brush KnobFillOnPressed
		{
			get => (Brush)_resources[_controlName + nameof(KnobFillOnPressed)];
			set => _resources[_controlName + nameof(KnobFillOnPressed)] = value;
		}
		public Brush KnobFillOnDisabled
		{
			get => (Brush)_resources[_controlName + nameof(KnobFillOnDisabled)];
			set => _resources[_controlName + nameof(KnobFillOnDisabled)] = value;
		}
		//GenerateAuto by tuanhungdev
	}

}
