using _4sTodo.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4sTodo.VML
{
    public class ViewModelLocator
    {
        public MainPageViewModel Main => Ioc.Default.GetService<MainPageViewModel>();
        public HomePageViewModel HomePage => Ioc.Default.GetService<HomePageViewModel>();
        public ReportPageViewModel ReportPage => Ioc.Default.GetService<ReportPageViewModel>();
        public WattingPageViewModel WattingPage => Ioc.Default.GetService<WattingPageViewModel>();
        public AddTaskDialogViewModel AddTaskDialog => Ioc.Default.GetService<AddTaskDialogViewModel>();
        public TaskPageViewModel TaskPage => Ioc.Default.GetService<TaskPageViewModel>();
        public SubTaskPageViewModel SubTaskPage => Ioc.Default.GetService<SubTaskPageViewModel>();
        public AddSubTaskDialogViewModel AddSubTaskDialog => Ioc.Default.GetService<AddSubTaskDialogViewModel>();

    }
}
