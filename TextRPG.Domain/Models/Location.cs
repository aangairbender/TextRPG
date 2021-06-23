using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Domain.Tagging;

namespace TextRPG.Domain.Models
{
    public class Location : ISupportTagging
    {
        public string Name { get; private set; }

        public Location(string name)
        {
            Name = name;
        }

        #region ISupportTagging
        public ICollection<Tag> Tags { get; } = new List<Tag>();
        #endregion
    }
}
