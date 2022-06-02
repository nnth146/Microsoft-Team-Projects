using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Uwp.Core.SR
{
	public class ResContentDialog : DependencyObject
	{
		public ResContentDialog()
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
		private const string _controlName = "ContentDialog";
		public double ContentDialogBorderWidth
		{
			get => (double)_resources[_controlName + nameof(ContentDialogBorderWidth)];
			set => _resources[_controlName + nameof(ContentDialogBorderWidth)] = value;
		}
		public Thickness ContentDialogButton1HostMargin
		{
			get => (Thickness)_resources[_controlName + nameof(ContentDialogButton1HostMargin)];
			set => _resources[_controlName + nameof(ContentDialogButton1HostMargin)] = value;
		}
		public Thickness ContentDialogButton2HostMargin
		{
			get => (Thickness)_resources[_controlName + nameof(ContentDialogButton2HostMargin)];
			set => _resources[_controlName + nameof(ContentDialogButton2HostMargin)] = value;
		}
		public Thickness ContentDialogContentMargin
		{
			get => (Thickness)_resources[_controlName + nameof(ContentDialogContentMargin)];
			set => _resources[_controlName + nameof(ContentDialogContentMargin)] = value;
		}
		public Thickness ContentDialogContentScrollViewerMargin
		{
			get => (Thickness)_resources[_controlName + nameof(ContentDialogContentScrollViewerMargin)];
			set => _resources[_controlName + nameof(ContentDialogContentScrollViewerMargin)] = value;
		}
		public Thickness ContentDialogCommandSpaceMargin
		{
			get => (Thickness)_resources[_controlName + nameof(ContentDialogCommandSpaceMargin)];
			set => _resources[_controlName + nameof(ContentDialogCommandSpaceMargin)] = value;
		}
		public Thickness ContentDialogTitleMargin
		{
			get => (Thickness)_resources[_controlName + nameof(ContentDialogTitleMargin)];
			set => _resources[_controlName + nameof(ContentDialogTitleMargin)] = value;
		}
		public Thickness ContentDialogPadding
		{
			get => (Thickness)_resources[_controlName + nameof(ContentDialogPadding)];
			set => _resources[_controlName + nameof(ContentDialogPadding)] = value;
		}
		public double ContentDialogMinWidth
		{
			get => (double)_resources[_controlName + nameof(ContentDialogMinWidth)];
			set => _resources[_controlName + nameof(ContentDialogMinWidth)] = value;
		}
		public double ContentDialogMaxWidth
		{
			get => (double)_resources[_controlName + nameof(ContentDialogMaxWidth)];
			set => _resources[_controlName + nameof(ContentDialogMaxWidth)] = value;
		}
		public double ContentDialogMinHeight
		{
			get => (double)_resources[_controlName + nameof(ContentDialogMinHeight)];
			set => _resources[_controlName + nameof(ContentDialogMinHeight)] = value;
		}
		public double ContentDialogMaxHeight
		{
			get => (double)_resources[_controlName + nameof(ContentDialogMaxHeight)];
			set => _resources[_controlName + nameof(ContentDialogMaxHeight)] = value;
		}
		public double ContentDialogButtonMinWidth
		{
			get => (double)_resources[_controlName + nameof(ContentDialogButtonMinWidth)];
			set => _resources[_controlName + nameof(ContentDialogButtonMinWidth)] = value;
		}
		public double ContentDialogButtonMaxWidth
		{
			get => (double)_resources[_controlName + nameof(ContentDialogButtonMaxWidth)];
			set => _resources[_controlName + nameof(ContentDialogButtonMaxWidth)] = value;
		}
		public double ContentDialogButtonMinHeight
		{
			get => (double)_resources[_controlName + nameof(ContentDialogButtonMinHeight)];
			set => _resources[_controlName + nameof(ContentDialogButtonMinHeight)] = value;
		}
		public double ContentDialogButtonHeight
		{
			get => (double)_resources[_controlName + nameof(ContentDialogButtonHeight)];
			set => _resources[_controlName + nameof(ContentDialogButtonHeight)] = value;
		}
		public double ContentDialogTitleMaxHeight
		{
			get => (double)_resources[_controlName + nameof(ContentDialogTitleMaxHeight)];
			set => _resources[_controlName + nameof(ContentDialogTitleMaxHeight)] = value;
		}
	}

}
