using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Uwp.Core.Helper;
using Uwp.Core.Service;
using Uwp.Messenger;
using Uwp.SQLite.Model;
using Windows.UI.Xaml.Controls;

namespace PlanNotes.ViewModel
{
    public class PlanePageViewModel : ViewModelBase
    {
        public PlanePageViewModel(IDataService dataService, INavigationService navigationService, IDialogService dialogService) : base(dataService, navigationService, dialogService)
        {
            Plan = WeakReferenceMessenger.Default.Send<PlanRequestMessage>().Response;
            SelectedFolder = null;
        }

        public Plan Plan { get; set; }
        public Frame Frame { get; set; }
        public Folder SelectedFolder { get; set; }

        private RelayCommand _seletedFolderCommand;
        public RelayCommand SeletedFolderCommand => _seletedFolderCommand ?? (_seletedFolderCommand = new RelayCommand(() =>
        {
            if (SelectedFolder != null)
            {
                WeakReferenceMessenger.Default.Send(new ChangeMessageFolder(SelectedFolder));
            }
        }));

        private RelayCommand _addFolderCommand;
        public RelayCommand AddFolderCommand => _addFolderCommand ?? (_addFolderCommand = new RelayCommand(async () =>
        {
            WeakReferenceMessenger.Default.Register<PlanRequestMessage>(this, (r, m) =>
            {
                m.Reply(Plan);
            });
            await dialogService.showAsync(typeof(AddFolderDialogViewModel));
            WeakReferenceMessenger.Default.Unregister<PlanRequestMessage>(this);
        }));

        private RelayCommand<Folder> _editFolderCommand;
        public RelayCommand<Folder> EditFolderCommand => _editFolderCommand ?? (_editFolderCommand = new RelayCommand<Folder>(async (selectedFolder) =>
        {
            if (selectedFolder != null)
            {
                WeakReferenceMessenger.Default.Register<PlanRequestMessage>(this, (r, m) =>
                {
                    m.Reply(Plan);
                });
                WeakReferenceMessenger.Default.Register<FolderRequestMessage>(this, (r, m) =>
                {
                    m.Reply(selectedFolder);
                });
                await dialogService.showAsync(typeof(EditFolderDialogViewModel));
                WeakReferenceMessenger.Default.Unregister<PlanRequestMessage>(this);
                WeakReferenceMessenger.Default.Unregister<FolderRequestMessage>(this);
            }
        }));

        private RelayCommand<Folder> _deleteFolderCommand;
        public RelayCommand<Folder> DeleteFolderCommand => _deleteFolderCommand ?? (_deleteFolderCommand = new RelayCommand<Folder>(async (selectedFolder) =>
        {
            if (selectedFolder != null)
            {
                WeakReferenceMessenger.Default.Register<PlanRequestMessage>(this, (r, m) =>
                {
                    m.Reply(Plan);
                });
                WeakReferenceMessenger.Default.Register<FolderRequestMessage>(this, (r, m) =>
                {
                    m.Reply(selectedFolder);
                });
                await dialogService.showAsync(typeof(DeleteFolderDialogViewModel));
                WeakReferenceMessenger.Default.Unregister<PlanRequestMessage>(this);
                WeakReferenceMessenger.Default.Unregister<FolderRequestMessage>(this);
            }
        }));
    }
}
