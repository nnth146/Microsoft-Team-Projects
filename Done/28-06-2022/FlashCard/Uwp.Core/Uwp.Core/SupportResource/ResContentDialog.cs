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
		public double BorderWidth
		{
			get => (double)_resources[_controlName + nameof(BorderWidth)];
			set => _resources[_controlName + nameof(BorderWidth)] = value;
		}
		public Thickness Button1HostMargin
		{
			get => (Thickness)_resources[_controlName + nameof(Button1HostMargin)];
			set => _resources[_controlName + nameof(Button1HostMargin)] = value;
		}
		public Thickness Button2HostMargin
		{
			get => (Thickness)_resources[_controlName + nameof(Button2HostMargin)];
			set => _resources[_controlName + nameof(Button2HostMargin)] = value;
		}
		public Thickness ContentMargin
		{
			get => (Thickness)_resources[_controlName + nameof(ContentMargin)];
			set => _resources[_controlName + nameof(ContentMargin)] = value;
		}
		public Thickness ContentScrollViewerMargin
		{
			get => (Thickness)_resources[_controlName + nameof(ContentScrollViewerMargin)];
			set => _resources[_controlName + nameof(ContentScrollViewerMargin)] = value;
		}
		public Thickness CommandSpaceMargin
		{
			get => (Thickness)_resources[_controlName + nameof(CommandSpaceMargin)];
			set => _resources[_controlName + nameof(CommandSpaceMargin)] = value;
		}
		public Thickness TitleMargin
		{
			get => (Thickness)_resources[_controlName + nameof(TitleMargin)];
			set => _resources[_controlName + nameof(TitleMargin)] = value;
		}
		public Thickness Padding
		{
			get => (Thickness)_resources[_controlName + nameof(Padding)];
			set => _resources[_controlName + nameof(Padding)] = value;
		}
		public double MinWidth
		{
			get => (double)_resources[_controlName + nameof(MinWidth)];
			set => _resources[_controlName + nameof(MinWidth)] = value;
		}
		public double MaxWidth
		{
			get => (double)_resources[_controlName + nameof(MaxWidth)];
			set => _resources[_controlName + nameof(MaxWidth)] = value;
		}
		public double MinHeight
		{
			get => (double)_resources[_controlName + nameof(MinHeight)];
			set => _resources[_controlName + nameof(MinHeight)] = value;
		}
		public double MaxHeight
		{
			get => (double)_resources[_controlName + nameof(MaxHeight)];
			set => _resources[_controlName + nameof(MaxHeight)] = value;
		}
		public double ButtonMinWidth
		{
			get => (double)_resources[_controlName + nameof(ButtonMinWidth)];
			set => _resources[_controlName + nameof(ButtonMinWidth)] = value;
		}
		public double ButtonMaxWidth
		{
			get => (double)_resources[_controlName + nameof(ButtonMaxWidth)];
			set => _resources[_controlName + nameof(ButtonMaxWidth)] = value;
		}
		public double ButtonMinHeight
		{
			get => (double)_resources[_controlName + nameof(ButtonMinHeight)];
			set => _resources[_controlName + nameof(ButtonMinHeight)] = value;
		}
		public double ButtonHeight
		{
			get => (double)_resources[_controlName + nameof(ButtonHeight)];
			set => _resources[_controlName + nameof(ButtonHeight)] = value;
		}
		public double TitleMaxHeight
		{
			get => (double)_resources[_controlName + nameof(TitleMaxHeight)];
			set => _resources[_controlName + nameof(TitleMaxHeight)] = value;
		}
	}

}
