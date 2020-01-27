using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Lib.Game
{
    public class LegRunner
    {
        private int _currentScore;

        public LegRunner(int currentScore)
        {
            _currentScore = currentScore;
        }

        public int Turn(int thrownPoints)
        {
            int newScore;
            if (thrownPoints > _currentScore)
            {
                // dood 
                return _currentScore;
            }
            else
            {
                newScore = _currentScore - thrownPoints;
            }
            if (newScore != 0)
            {
                return newScore;
            }
            else
            {
                // GameEnds
                throw new NotImplementedException();
            }

        }
    }
}
