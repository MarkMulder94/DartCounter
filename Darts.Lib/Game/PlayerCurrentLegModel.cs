using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Lib.Game
{
    public class PlayerCurrentLegModel
    {
        public int Player_Id { get; set; }
        public int Team_Id { get; set; }
        public decimal AvgThisLeg { get; set; } = 0;
        public int ThrowDarts { get; set; } = 0;
        public int CurrentScore { get; set; } = 501; 

    }
}
