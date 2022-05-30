﻿using FocusTask.ViewModel;
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
        public CompletedPageViewModel CompletedPage => Ioc.Default.GetService<CompletedPageViewModel>();
        public DeleteDialogViewModel DeleteDialog => Ioc.Default.GetService<DeleteDialogViewModel>();
        public EditDialogViewModel EditDialog => Ioc.Default.GetService<EditDialogViewModel>();
        public ProjectPageViewModel ProjectPage => Ioc.Default.GetService<ProjectPageViewModel>();
        public MainPageViewMode MainPageViewMode => Ioc.Default.GetService<MainPageViewMode>();
        public MydayPageViewModel MydayPage => Ioc.Default.GetService<MydayPageViewModel>();
        public SomedayPageViewModel SomedayPage => Ioc.Default.GetService<SomedayPageViewModel>();
        public StaticPageViewModel StaticPage => Ioc.Default.GetService<StaticPageViewModel>();
        public TomorrowPageViewModel TomorrowPage => Ioc.Default.GetService<TomorrowPageViewModel>();
        public UpcomingPageViewModel UpcomingPage => Ioc.Default.GetService<UpcomingPageViewModel>();
    }
}