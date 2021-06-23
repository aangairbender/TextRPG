using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Domain.Tagging
{
    public class Tag
    {
        public string Name { get; set; }

        internal Tag(string name)
        {
            Name = name;
        }
    }
}
