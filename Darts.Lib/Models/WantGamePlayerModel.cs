using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Darts.Lib.Models
{

    public class WantGamePlayerModel
    {
        public WantGamePlayerModel(PlayerModel playerModel, int teamNumber, int player_id)
        {
            PlayerModel = playerModel;
            TeamNumber = teamNumber;
            player_Id = player_id;
        }

        public int Id { get; set; }
        public int TeamNumber { get; set; }
        public int player_Id { get; set; }

        [ForeignKey("player_Id")]
        public PlayerModel PlayerModel { get; set; }

    }
}
