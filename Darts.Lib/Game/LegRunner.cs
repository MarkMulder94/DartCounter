using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Lib.Game
{
    public class LegRunner
    {

        public static int Turn(int thrownPoints, int currentScore)
        {
            int newScore;
            if (thrownPoints > currentScore)
            {
                // dood 
                return currentScore;
            }
            else
            {
                newScore = currentScore - thrownPoints;
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
