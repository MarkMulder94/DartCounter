using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Lib.Models
{
    public class PlayerModel
    {
        public int player_Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int gamesCount { get; set; }
        public decimal avgScore { get; set; }
        public int highestFinish { get; set; }
        public int thrownDarts { get; set; }
        public int totalScore { get; set; }
    }
}
