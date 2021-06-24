using System.Collections.Generic;

namespace TextRPG.Domain.Models
{
    public class Place
    {
        private readonly List<Place> _children = new List<Place>();

        public string Name { get; private set; }
        public Place Parent { get; private set; }
        public Location Location { get; private set; }
        public IReadOnlyCollection<Place> Children => _children;

        public Place(Location location, string name)
        {
            Location = location;
            Name = name;
        }

        public Place(Location location, string name, Place parent) : this(location, name)
        {
            Parent = parent;
        }

        public void AddChild(Place place)
        {
            _children.Add(place);
        }

        public void RemoveChild(Place place)
        {
            _children.Remove(place);
        }
    }
}
