using System.Collections.Generic;
using System.Linq;

namespace TextRPG.Domain.Tagging
{
    public class TagRegistry
    {
        private readonly List<Tag> _tags;

        public TagRegistry()
        {
            _tags = new List<Tag>();
        }

        public Tag AddOrGet(string name)
        {
            var existingTag = _tags.FirstOrDefault(t => t.Name == name);
            if (existingTag != null)
            {
                return existingTag;
            } else
            {
                var tag = new Tag(name);
                _tags.Add(tag);
                return tag;
            }
        }

        public void Remove(Tag tag)
        {
            _tags.Remove(tag);
        }

        public IEnumerable<Tag> Search(string name)
        {
            return _tags.Where(t => t.Name.Contains(name));
        }
    }
}
