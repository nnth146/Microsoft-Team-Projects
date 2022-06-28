using Microsoft.Toolkit.Mvvm.DependencyInjection;
using PlanNotes.ViewModel;

namespace PlanNotes.VML
{
    public class ViewModelLocator
    {
        public MainPageViewModel MainPage => Ioc.Default.GetService<MainPageViewModel>();
        public CompletedPageViewModel CompletedPage => Ioc.Default.GetService<CompletedPageViewModel>();
        public FolderPageViewModel FolderPage => Ioc.Default.GetService<FolderPageViewModel>();
        public NextWeekPageViewModel NextWeekPage => Ioc.Default.GetService<NextWeekPageViewModel>();
        public PlanePageViewModel PlanePage => Ioc.Default.GetService<PlanePageViewModel>();
        public TodayPageViewModel TodayPage => Ioc.Default.GetService<TodayPageViewModel>();
        public TomorrowPageViewModel TomorrowPage => Ioc.Default.GetService<TomorrowPageViewModel>();
        public AddFolderDialogViewModel AddFolderDialog => Ioc.Default.GetService<AddFolderDialogViewModel>();
        public AddNoteDialogViewModel AddNoteDialog => Ioc.Default.GetService<AddNoteDialogViewModel>();
        public AddPlaneDialogViewModel AddPlaneDialog => Ioc.Default.GetService<AddPlaneDialogViewModel>();
        public DeleteAllFolderDialogViewModel DeleteAllFolderDialog => Ioc.Default.GetService<DeleteAllFolderDialogViewModel>();
        public DeleteFolderDialogViewModel DeleteFolderDialog => Ioc.Default.GetService<DeleteFolderDialogViewModel>();
        public DeleteAllNoteDialogViewModel DeleteAllNoteDialog => Ioc.Default.GetService<DeleteAllNoteDialogViewModel>();
        public DeleteNoteDialogViewModel DeleteNoteDialog => Ioc.Default.GetService<DeleteNoteDialogViewModel>();
        public DeleteAllPlaneDialogViewModel DeleteAllPlaneDialog => Ioc.Default.GetService<DeleteAllPlaneDialogViewModel>();
        public DeletePlaneDialogViewModel DeletePlaneDialog => Ioc.Default.GetService<DeletePlaneDialogViewModel>();
        public EditFolderDialogViewModel EditFolderDialog => Ioc.Default.GetService<EditFolderDialogViewModel>();
        public EditPlaneDialogViewModel EditPlaneDialog => Ioc.Default.GetService<EditPlaneDialogViewModel>();
        public ViewAndEditNoteDialogViewModel ViewAndEditNoteDialog => Ioc.Default.GetService<ViewAndEditNoteDialogViewModel>();
        public AddCheckListDialogViewModel AddCheckListDialog => Ioc.Default.GetService<AddCheckListDialogViewModel>();
        public ShowNoteDialogViewModel ShowNoteDialog => Ioc.Default.GetService<ShowNoteDialogViewModel>();
        public AddNoteFolderDialogViewModel AddNoteFolderDialog => Ioc.Default.GetService<AddNoteFolderDialogViewModel>();
    }
}
