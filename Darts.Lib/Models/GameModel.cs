using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Lib.Models
{
    public class GameModel
    {
        public int game_Id { get; set; }

        public TeamModel team1 { get; set; }
        public TeamModel team2 { get; set; }

    }
}
