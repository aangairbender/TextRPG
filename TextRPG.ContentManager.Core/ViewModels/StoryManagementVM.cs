using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using TextRPG.ContentManager.Core.Services;
using TextRPG.Domain.Models;
using TextRPG.Domain.Validators;

namespace TextRPG.ContentManager.Core.ViewModels
{
    public class StoryManagementVM : MvxViewModel
    {
        private readonly IDialogService _dialogService;

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

        public StoryManagementVM(IDialogService dialogService)
        {
            _dialogService = dialogService;

            _story = new Story { Name = "" };
            
            CreateStoryCommand = new MvxCommand(CreateStoryCommandHandler, () => _isStoryValid);
            LoadStoryCommand = new MvxCommand(LoadStoryCommandHandler);
            SelectStoryFileCommand = new MvxCommand(SelectStoryFileCommandHandler);
        }

        private void CreateStoryCommandHandler()
        {
            _dialogService.ShowMessage($"{StoryName} {StoryFilename}");
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
