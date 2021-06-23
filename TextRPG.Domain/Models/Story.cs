using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Domain.Models
{
    public class Story
    {
        private readonly List<Location> _locations;

        public string Name { get; set; }
        public IReadOnlyCollection<Location> Locations => _locations;

        public Story(string name)
        {
            _locations = new List<Location>();
            Name = name;
        }

        public void AddLocation(Location location)
        {
            _locations.Add(location);
        }

        public void RemoveLocation(Location location)
        {
            _locations.Remove(location);
        }
    }
}
