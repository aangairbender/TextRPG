using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using TextRPG.ContentManager.Core.Services;
using TextRPG.Domain.Models;
using TextRPG.Domain.Validators;

namespace TextRPG.ContentManager.Core.ViewModels
{
    public class StoryManagementVM : MvxViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IMvxNavigationService _navigationService;

        private readonly Story _story;
        private bool _isStoryValid = false;

        public string StoryName
        {
            get => _story.Name;
            set
            {
                if (string.Equals(_story.Name, value))
                    return;

                _story.Name = value;
                RaisePropertyChanged(() => StoryName);

                ValidateStory();
            }
        }

        public ObservableCollection<string> StoryNameValidationFailures { get; } = new ObservableCollection<string>();

        private string _storyFilename;
        public string StoryFilename
        {
            get => _storyFilename;
            set => SetProperty(ref _storyFilename, value);
        }

        public IMvxCommand CreateStoryCommand { get; private set; }
        public IMvxCommand LoadStoryCommand { get; private set; }
        public IMvxCommand SelectStoryFileCommand { get; private set; }

        public StoryManagementVM(IDialogService dialogService, IMvxNavigationService navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;

            _story = new Story("");
            
            CreateStoryCommand = new MvxCommand(CreateStoryCommandHandler, () => _isStoryValid);
            LoadStoryCommand = new MvxCommand(LoadStoryCommandHandler);
            SelectStoryFileCommand = new MvxCommand(SelectStoryFileCommandHandler);
        }

        private async void CreateStoryCommandHandler()
        {
            var location1 = new Location("Деревня");
            location1.RootPlace.AddChild(new Place(location1, "Колодец"));
            var place1 = new Place(location1, "Мельница");
            place1.AddChild(new Place(location1, "Амбар"));
            location1.RootPlace.AddChild(place1);
            location1.RootPlace.AddChild(new Place(location1, "Поле"));
            var location2 = new Location("Лес");
            location2.RootPlace.AddChild(new Place(location2, "Алтарь"));
            location2.RootPlace.AddChild(new Place(location2, "Тропинка"));
            var location3 = new Location("Река");
            location3.RootPlace.AddChild(new Place(location3, "Вымостка"));
            location3.RootPlace.AddChild(new Place(location3, "Каменистый берег"));
            _story.AddLocation(location1);
            _story.AddLocation(location2);
            _story.AddLocation(location3);
            await _navigationService.Navigate<MainVM, Story>(_story);
        }

        private void LoadStoryCommandHandler()
        {

        }

        private void SelectStoryFileCommandHandler()
        {
            var res = _dialogService.SaveFileDialog("Выберите файл для хранения сюжета", "Файл сюжета (*.story)|*.story", out var filename);
            if (res)
            {
                StoryFilename = filename;
            }
        }

        private void ValidateStory()
        {
            StoryNameValidationFailures.Clear();

            var validator = new StoryValidator();
            var result = validator.Validate(_story);
            _isStoryValid = result.IsValid;

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    switch (failure.PropertyName)
                    {
                        case nameof(_story.Name):
                            StoryNameValidationFailures.Add(failure.ErrorMessage);
                            break;
                    }
                }
            }

            CreateStoryCommand.RaiseCanExecuteChanged();
        }
    }
}
