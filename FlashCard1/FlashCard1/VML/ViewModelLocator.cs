using FlashCard1.Pages.CardPage;
using FlashCard1.Pages.Topic;
using FlashCard1.Pages.Topic.Dialog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.HCore.Service.Database;
using Uwp.HCore.Service.Navigation;

namespace FlashCard1.VML
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            Ioc.Default.ConfigureServices(new ServiceCollection().
                AddSingleton<INavigationService, NavigationService>()
                .AddSingleton<IDataService, DataService>().AddTransient<MainPageViewModel>()
                .AddSingleton<IDataService, DataService>().AddTransient<AddTopicDialogViewModel>()
                .AddSingleton<INavigationService, NavigationService>().AddTransient<MainCardPageViewModel>()
                .BuildServiceProvider());
        }

        public MainPageViewModel Main => Ioc.Default.GetService<MainPageViewModel>();

        public AddTopicDialogViewModel AddTopicDialog => Ioc.Default.GetService<AddTopicDialogViewModel>();

        public MainCardPageViewModel CardPage => Ioc.Default.GetService<MainCardPageViewModel>();

    }
}
