using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Lib.Models
{
    public class TeamModel
    {
        public int team_Id { get; set; }

        public PlayerModel player1 { get; set; }
        public PlayerModel player2 { get; set; }
        public PlayerModel player3 { get; set; }
        public PlayerModel player4 { get; set; }

    }
}
