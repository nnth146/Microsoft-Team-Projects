using FocusTask.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusTask.VML
{
    public class ViewModelLocator
    {
        public AddDialogViewModel AddDialog => Ioc.Default.GetService<AddDialogViewModel>();
        public MainPageViewMode MainPageViewMode => Ioc.Default.GetService<MainPageViewMode>();
        public MydayPageViewModel MydayPage => Ioc.Default.GetService<MydayPageViewModel>();
        public StaticPageViewModel StaticPage => Ioc.Default.GetService<StaticPageViewModel>();
        public EditDialogViewModel EditDialog => Ioc.Default.GetService<EditDialogViewModel>();
        public DeleteDialogViewModel DeleteDialog => Ioc.Default.GetService<DeleteDialogViewModel>();
    }
}
