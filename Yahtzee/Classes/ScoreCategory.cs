using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.Classes
{
    public class ScoreCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ScoreCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
