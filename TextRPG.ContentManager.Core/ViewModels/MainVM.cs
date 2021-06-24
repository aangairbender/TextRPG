using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Domain.Models;

namespace TextRPG.ContentManager.Core.ViewModels
{
    public class MainVM : MvxViewModel<Story>
    {
        public Story Story { get; private set; }

        private Location _selectedLocation;
        public Location SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                _selectedLocation = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(RootPlaceAsList));
            }
        }

        public List<Place> RootPlaceAsList
        {
            get
            {
                if (SelectedLocation == null)
                    return null;
                
                return new List<Place>() { SelectedLocation.RootPlace };
            }
        }

        public override void Prepare(Story story)
        {
            Story = story;
        }
    }
}
