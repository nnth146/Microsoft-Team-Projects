using FlashCard1.Model;
using FlashCard1.Pages.CardPage;
using FlashCard1.Pages.Topic.Dialog;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.HCore.Service.Database;
using Uwp.HCore.Service.Navigation;
using Windows.UI.Xaml.Controls;

namespace FlashCard1.Pages.Topic
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService _dataService;

        public MainPageViewModel(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;

            Topics = new ObservableCollection<TopicModel>
            {
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#D260E1",
                    amount= 12
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#E1432E",
                    amount= 90
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#0EE3D8",
                    amount= 9
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#49A84C",
                    amount= 11
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
                new TopicModel
                {
                    name = "Topic Name",
                    color = "#89CFF0",
                    amount= 13
                },
            };
            
        }

        public ObservableCollection<TopicModel> Topics { get; set; }

        private RelayCommand _mainPageLoadedCommand;

        public RelayCommand MainPageLoadedCommand => _mainPageLoadedCommand ?? (_mainPageLoadedCommand = new RelayCommand(() =>
        {
            
        }));


        private RelayCommand _openAddTopicDialogCommand;
        public RelayCommand OpenAddTopicDialogCommand => _openAddTopicDialogCommand ?? (_openAddTopicDialogCommand = new RelayCommand( async () =>
        {
            ContentDialog dialog = new AddTopicDialog();
            await dialog.ShowAsync();   
        }));


        private RelayCommand _openPremiumDialogCommand;
        public RelayCommand OpenPremiumDialogCommand => _openPremiumDialogCommand ?? (_openPremiumDialogCommand = new RelayCommand(async () =>
        {
            ContentDialog dialog = new PremiumDialog();
            await dialog.ShowAsync();
        }));


        private RelayCommand _selectionChangedCommand;
        public RelayCommand SelectionChangedCommand => _selectionChangedCommand ?? (_selectionChangedCommand = new RelayCommand(() =>
        {
            _navigationService.Navigate(typeof(MainCardPage));
        }));
    }
}
