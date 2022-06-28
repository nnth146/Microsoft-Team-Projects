using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uwp.Core.SR
{
	public class ResExpander : DependencyObject
	{
		public ResExpander()
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
		private const string _controlName = "Expander";

		public Brush HeaderBackground
		{
			get => (Brush)_resources[_controlName + nameof(HeaderBackground)];
			set => _resources[_controlName + nameof(HeaderBackground)] = value;
		}
		public Brush HeaderForeground
		{
			get => (Brush)_resources[_controlName + nameof(HeaderForeground)];
			set => _resources[_controlName + nameof(HeaderForeground)] = value;
		}
		public Brush HeaderForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(HeaderForegroundPointerOver)];
			set => _resources[_controlName + nameof(HeaderForegroundPointerOver)] = value;
		}
		public Brush HeaderForegroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(HeaderForegroundPressed)];
			set => _resources[_controlName + nameof(HeaderForegroundPressed)] = value;
		}
		public Brush HeaderBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(HeaderBorderBrush)];
			set => _resources[_controlName + nameof(HeaderBorderBrush)] = value;
		}
		public Brush HeaderBorderPointerOverBrush
		{
			get => (Brush)_resources[_controlName + nameof(HeaderBorderPointerOverBrush)];
			set => _resources[_controlName + nameof(HeaderBorderPointerOverBrush)] = value;
		}
		public Brush HeaderBorderPressedBrush
		{
			get => (Brush)_resources[_controlName + nameof(HeaderBorderPressedBrush)];
			set => _resources[_controlName + nameof(HeaderBorderPressedBrush)] = value;
		}
		public Brush HeaderDisabledForeground
		{
			get => (Brush)_resources[_controlName + nameof(HeaderDisabledForeground)];
			set => _resources[_controlName + nameof(HeaderDisabledForeground)] = value;
		}
		public Brush HeaderDisabledBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(HeaderDisabledBorderBrush)];
			set => _resources[_controlName + nameof(HeaderDisabledBorderBrush)] = value;
		}
		public Thickness HeaderBorderThickness
		{
			get => (Thickness)_resources[_controlName + nameof(HeaderBorderThickness)];
			set => _resources[_controlName + nameof(HeaderBorderThickness)] = value;
		}
		public Brush ChevronBackground
		{
			get => (Brush)_resources[_controlName + nameof(ChevronBackground)];
			set => _resources[_controlName + nameof(ChevronBackground)] = value;
		}
		public Brush ChevronPointerOverBackground
		{
			get => (Brush)_resources[_controlName + nameof(ChevronPointerOverBackground)];
			set => _resources[_controlName + nameof(ChevronPointerOverBackground)] = value;
		}
		public Brush ChevronPressedBackground
		{
			get => (Brush)_resources[_controlName + nameof(ChevronPressedBackground)];
			set => _resources[_controlName + nameof(ChevronPressedBackground)] = value;
		}
		public Brush ChevronForeground
		{
			get => (Brush)_resources[_controlName + nameof(ChevronForeground)];
			set => _resources[_controlName + nameof(ChevronForeground)] = value;
		}
		public Brush ChevronPointerOverForeground
		{
			get => (Brush)_resources[_controlName + nameof(ChevronPointerOverForeground)];
			set => _resources[_controlName + nameof(ChevronPointerOverForeground)] = value;
		}
		public Brush ChevronPressedForeground
		{
			get => (Brush)_resources[_controlName + nameof(ChevronPressedForeground)];
			set => _resources[_controlName + nameof(ChevronPressedForeground)] = value;
		}
		public Brush ChevronBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(ChevronBorderBrush)];
			set => _resources[_controlName + nameof(ChevronBorderBrush)] = value;
		}
		public Brush ChevronBorderPointerOverBrush
		{
			get => (Brush)_resources[_controlName + nameof(ChevronBorderPointerOverBrush)];
			set => _resources[_controlName + nameof(ChevronBorderPointerOverBrush)] = value;
		}
		public Brush ChevronBorderPressedBrush
		{
			get => (Brush)_resources[_controlName + nameof(ChevronBorderPressedBrush)];
			set => _resources[_controlName + nameof(ChevronBorderPressedBrush)] = value;
		}
		public Thickness ChevronBorderThickness
		{
			get => (Thickness)_resources[_controlName + nameof(ChevronBorderThickness)];
			set => _resources[_controlName + nameof(ChevronBorderThickness)] = value;
		}
		public Brush ContentBackground
		{
			get => (Brush)_resources[_controlName + nameof(ContentBackground)];
			set => _resources[_controlName + nameof(ContentBackground)] = value;
		}
		public Brush ContentBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(ContentBorderBrush)];
			set => _resources[_controlName + nameof(ContentBorderBrush)] = value;
		}
		public double MinHeight
		{
			get => (double)_resources[_controlName + nameof(MinHeight)];
			set => _resources[_controlName + nameof(MinHeight)] = value;
		}
		public HorizontalAlignment HeaderHorizontalContentAlignment
		{
			get => (HorizontalAlignment)_resources[_controlName + nameof(HeaderHorizontalContentAlignment)];
			set => _resources[_controlName + nameof(HeaderHorizontalContentAlignment)] = value;
		}
		public VerticalAlignment HeaderVerticalContentAlignment
		{
			get => (VerticalAlignment)_resources[_controlName + nameof(HeaderVerticalContentAlignment)];
			set => _resources[_controlName + nameof(HeaderVerticalContentAlignment)] = value;
		}
		public Thickness HeaderPadding
		{
			get => (Thickness)_resources[_controlName + nameof(HeaderPadding)];
			set => _resources[_controlName + nameof(HeaderPadding)] = value;
		}
		public Thickness ChevronMargin
		{
			get => (Thickness)_resources[_controlName + nameof(ChevronMargin)];
			set => _resources[_controlName + nameof(ChevronMargin)] = value;
		}
		public string ChevronUpGlyph
		{
			get => (string)_resources[_controlName + nameof(ChevronUpGlyph)];
			set => _resources[_controlName + nameof(ChevronUpGlyph)] = value;
		}
		public string ChevronDownGlyph
		{
			get => (string)_resources[_controlName + nameof(ChevronDownGlyph)];
			set => _resources[_controlName + nameof(ChevronDownGlyph)] = value;
		}
		public double ChevronButtonSize
		{
			get => (double)_resources[_controlName + nameof(ChevronButtonSize)];
			set => _resources[_controlName + nameof(ChevronButtonSize)] = value;
		}
		public double ChevronGlyphSize
		{
			get => (double)_resources[_controlName + nameof(ChevronGlyphSize)];
			set => _resources[_controlName + nameof(ChevronGlyphSize)] = value;
		}
		public Thickness ContentPadding
		{
			get => (Thickness)_resources[_controlName + nameof(ContentPadding)];
			set => _resources[_controlName + nameof(ContentPadding)] = value;
		}
		public Thickness ContentDownBorderThickness
		{
			get => (Thickness)_resources[_controlName + nameof(ContentDownBorderThickness)];
			set => _resources[_controlName + nameof(ContentDownBorderThickness)] = value;
		}
		public Thickness ContentUpBorderThickness
		{
			get => (Thickness)_resources[_controlName + nameof(ContentUpBorderThickness)];
			set => _resources[_controlName + nameof(ContentUpBorderThickness)] = value;
		}
		public Style HeaderDownStyle
		{
			get => (Style)_resources[_controlName + nameof(HeaderDownStyle)];
			set => _resources[_controlName + nameof(HeaderDownStyle)] = value;
		}
		public Style HeaderUpStyle
		{
			get => (Style)_resources[_controlName + nameof(HeaderUpStyle)];
			set => _resources[_controlName + nameof(HeaderUpStyle)] = value;
		}
	}
}
