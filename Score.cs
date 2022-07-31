using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_5GrafickProject.Classes
{
    class Score
    {
        public int _score { get; set; }
        string _name;

        public Score( PackMen player)
        {
            _score = player._point;
            
        }
    }
}
