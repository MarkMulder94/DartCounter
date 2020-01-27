using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Lib.Models
{
    public class GameModel
    {

        public GameModel(int game_Id, List<List<PlayerModel>> players)
        {
            Game_Id = game_Id;
            Players = players;

        }
        public int Game_Id { get; set; }

        public List<List<PlayerModel>> Players { get; set; }


    }
}
