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
		public Brush ExpanderHeaderBackground
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderHeaderBackground)];
			set => _resources[_controlName + nameof(ExpanderHeaderBackground)] = value;
		}
		public Brush ExpanderHeaderForeground
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderHeaderForeground)];
			set => _resources[_controlName + nameof(ExpanderHeaderForeground)] = value;
		}
		public Brush ExpanderHeaderForegroundPointerOver
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderHeaderForegroundPointerOver)];
			set => _resources[_controlName + nameof(ExpanderHeaderForegroundPointerOver)] = value;
		}
		public Brush ExpanderHeaderForegroundPressed
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderHeaderForegroundPressed)];
			set => _resources[_controlName + nameof(ExpanderHeaderForegroundPressed)] = value;
		}
		public Brush ExpanderHeaderBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderHeaderBorderBrush)];
			set => _resources[_controlName + nameof(ExpanderHeaderBorderBrush)] = value;
		}
		public Brush ExpanderHeaderBorderPointerOverBrush
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderHeaderBorderPointerOverBrush)];
			set => _resources[_controlName + nameof(ExpanderHeaderBorderPointerOverBrush)] = value;
		}
		public Brush ExpanderHeaderBorderPressedBrush
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderHeaderBorderPressedBrush)];
			set => _resources[_controlName + nameof(ExpanderHeaderBorderPressedBrush)] = value;
		}
		public Brush ExpanderHeaderDisabledForeground
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderHeaderDisabledForeground)];
			set => _resources[_controlName + nameof(ExpanderHeaderDisabledForeground)] = value;
		}
		public Brush ExpanderHeaderDisabledBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderHeaderDisabledBorderBrush)];
			set => _resources[_controlName + nameof(ExpanderHeaderDisabledBorderBrush)] = value;
		}
		public Thickness ExpanderHeaderBorderThickness
		{
			get => (Thickness)_resources[_controlName + nameof(ExpanderHeaderBorderThickness)];
			set => _resources[_controlName + nameof(ExpanderHeaderBorderThickness)] = value;
		}
		public Brush ExpanderChevronBackground
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderChevronBackground)];
			set => _resources[_controlName + nameof(ExpanderChevronBackground)] = value;
		}
		public Brush ExpanderChevronPointerOverBackground
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderChevronPointerOverBackground)];
			set => _resources[_controlName + nameof(ExpanderChevronPointerOverBackground)] = value;
		}
		public Brush ExpanderChevronPressedBackground
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderChevronPressedBackground)];
			set => _resources[_controlName + nameof(ExpanderChevronPressedBackground)] = value;
		}
		public Brush ExpanderChevronForeground
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderChevronForeground)];
			set => _resources[_controlName + nameof(ExpanderChevronForeground)] = value;
		}
		public Brush ExpanderChevronPointerOverForeground
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderChevronPointerOverForeground)];
			set => _resources[_controlName + nameof(ExpanderChevronPointerOverForeground)] = value;
		}
		public Brush ExpanderChevronPressedForeground
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderChevronPressedForeground)];
			set => _resources[_controlName + nameof(ExpanderChevronPressedForeground)] = value;
		}
		public Brush ExpanderChevronBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderChevronBorderBrush)];
			set => _resources[_controlName + nameof(ExpanderChevronBorderBrush)] = value;
		}
		public Brush ExpanderChevronBorderPointerOverBrush
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderChevronBorderPointerOverBrush)];
			set => _resources[_controlName + nameof(ExpanderChevronBorderPointerOverBrush)] = value;
		}
		public Brush ExpanderChevronBorderPressedBrush
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderChevronBorderPressedBrush)];
			set => _resources[_controlName + nameof(ExpanderChevronBorderPressedBrush)] = value;
		}
		public Thickness ExpanderChevronBorderThickness
		{
			get => (Thickness)_resources[_controlName + nameof(ExpanderChevronBorderThickness)];
			set => _resources[_controlName + nameof(ExpanderChevronBorderThickness)] = value;
		}
		public Brush ExpanderContentBackground
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderContentBackground)];
			set => _resources[_controlName + nameof(ExpanderContentBackground)] = value;
		}
		public Brush ExpanderContentBorderBrush
		{
			get => (Brush)_resources[_controlName + nameof(ExpanderContentBorderBrush)];
			set => _resources[_controlName + nameof(ExpanderContentBorderBrush)] = value;
		}
		public double ExpanderMinHeight
		{
			get => (double)_resources[_controlName + nameof(ExpanderMinHeight)];
			set => _resources[_controlName + nameof(ExpanderMinHeight)] = value;
		}
		public HorizontalAlignment ExpanderHeaderHorizontalContentAlignment
		{
			get => (HorizontalAlignment)_resources[_controlName + nameof(ExpanderHeaderHorizontalContentAlignment)];
			set => _resources[_controlName + nameof(ExpanderHeaderHorizontalContentAlignment)] = value;
		}
		public VerticalAlignment ExpanderHeaderVerticalContentAlignment
		{
			get => (VerticalAlignment)_resources[_controlName + nameof(ExpanderHeaderVerticalContentAlignment)];
			set => _resources[_controlName + nameof(ExpanderHeaderVerticalContentAlignment)] = value;
		}
		public Thickness ExpanderHeaderPadding
		{
			get => (Thickness)_resources[_controlName + nameof(ExpanderHeaderPadding)];
			set => _resources[_controlName + nameof(ExpanderHeaderPadding)] = value;
		}
		public Thickness ExpanderChevronMargin
		{
			get => (Thickness)_resources[_controlName + nameof(ExpanderChevronMargin)];
			set => _resources[_controlName + nameof(ExpanderChevronMargin)] = value;
		}
		public string ExpanderChevronUpGlyph
		{
			get => (string)_resources[_controlName + nameof(ExpanderChevronUpGlyph)];
			set => _resources[_controlName + nameof(ExpanderChevronUpGlyph)] = value;
		}
		public string ExpanderChevronDownGlyph
		{
			get => (string)_resources[_controlName + nameof(ExpanderChevronDownGlyph)];
			set => _resources[_controlName + nameof(ExpanderChevronDownGlyph)] = value;
		}
		public double ExpanderChevronButtonSize
		{
			get => (double)_resources[_controlName + nameof(ExpanderChevronButtonSize)];
			set => _resources[_controlName + nameof(ExpanderChevronButtonSize)] = value;
		}
		public double ExpanderChevronGlyphSize
		{
			get => (double)_resources[_controlName + nameof(ExpanderChevronGlyphSize)];
			set => _resources[_controlName + nameof(ExpanderChevronGlyphSize)] = value;
		}
		public Thickness ExpanderContentPadding
		{
			get => (Thickness)_resources[_controlName + nameof(ExpanderContentPadding)];
			set => _resources[_controlName + nameof(ExpanderContentPadding)] = value;
		}
		public Thickness ExpanderContentDownBorderThickness
		{
			get => (Thickness)_resources[_controlName + nameof(ExpanderContentDownBorderThickness)];
			set => _resources[_controlName + nameof(ExpanderContentDownBorderThickness)] = value;
		}
		public Thickness ExpanderContentUpBorderThickness
		{
			get => (Thickness)_resources[_controlName + nameof(ExpanderContentUpBorderThickness)];
			set => _resources[_controlName + nameof(ExpanderContentUpBorderThickness)] = value;
		}
		public Style ExpanderHeaderDownStyle
		{
			get => (Style)_resources[_controlName + nameof(ExpanderHeaderDownStyle)];
			set => _resources[_controlName + nameof(ExpanderHeaderDownStyle)] = value;
		}
		public Style ExpanderHeaderUpStyle
		{
			get => (Style)_resources[_controlName + nameof(ExpanderHeaderUpStyle)];
			set => _resources[_controlName + nameof(ExpanderHeaderUpStyle)] = value;
		}
	}
}
