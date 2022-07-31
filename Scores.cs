using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_5GrafickProject.Classes
{
    class Scores
    {
        Score[] _scores;
        Score swap;

        public Scores(Score score)
        {
            _scores = new Score[10];
            for (int i = 0; i < _scores.Length; i++)
            {
                if (_scores[i] == null)
                {
                    _scores[i] = score;
                    break;
                }
            }
            for (int j = _scores.Length-1; j>0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (_scores[i]._score>_scores[i+1]._score)
                    {
                        swap = _scores[i];
                        _scores[i] = _scores[i + 1];
                        _scores[i + 1] = swap;
                    }
                }
            }
        }
    }
}
