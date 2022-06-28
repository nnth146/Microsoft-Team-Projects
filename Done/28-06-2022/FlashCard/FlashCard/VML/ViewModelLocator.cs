using FlashCard.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace FlashCard.VML
{
    public class ViewModelLocator
    {
        public AddAndEditCardViewModel AddAndEditCard => Ioc.Default.GetService<AddAndEditCardViewModel>();
        public CardPageViewModel CardPage => Ioc.Default.GetService<CardPageViewModel>();
        public FolderPageViewModel FolderPage => Ioc.Default.GetService<FolderPageViewModel>();
        public HomePageViewModel HomePage => Ioc.Default.GetService<HomePageViewModel>();
        public ViewStudyViewModel ViewStudy => Ioc.Default.GetService<ViewStudyViewModel>();
        public EmptyFlashCardViewModel EmptyFlashCard => Ioc.Default.GetService<EmptyFlashCardViewModel>();
        public AddFolderDialogViewModel AddFolderDialog => Ioc.Default.GetService<AddFolderDialogViewModel>();
        public AddStudyDialogViewModel AddStudyDialog => Ioc.Default.GetService<AddStudyDialogViewModel>();
        public EditFolderDialogViewModel EditFolderDialog => Ioc.Default.GetService<EditFolderDialogViewModel>();
        public EditStudyDialogViewModel EditStudyDialog => Ioc.Default.GetService<EditStudyDialogViewModel>();
        public DeleteAllFolderDialogViewModel DeleteAllFolderDialog => Ioc.Default.GetService<DeleteAllFolderDialogViewModel>();
        public DeleteFolderDialogViewModel DeleteFolderDialog => Ioc.Default.GetService<DeleteFolderDialogViewModel>();
        public DeleteStudyDialogViewModel DeleteStudyDialog => Ioc.Default.GetService<DeleteStudyDialogViewModel>();
        public DeleteAllStudyDialogViewModel DeleteAllStudyDialog => Ioc.Default.GetService<DeleteAllStudyDialogViewModel>();
        public DeleteTopicDialogViewModel DeleteTopicDialog => Ioc.Default.GetService<DeleteTopicDialogViewModel>();
        public DeleteAllCardDialogViewModel DeleteAllCardDialog => Ioc.Default.GetService<DeleteAllCardDialogViewModel>();
        public SettingPageViewModel SettingPage => Ioc.Default.GetService<SettingPageViewModel>();
    }
}
