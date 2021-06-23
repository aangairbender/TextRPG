using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Domain.Models
{
    public class Place
    {
        public string Name { get; private set; }

        public Place(string name)
        {
            Name = name;
        }
    }
}
