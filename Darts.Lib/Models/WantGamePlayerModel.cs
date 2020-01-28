using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Darts.Lib.Models
{

    public class WantGamePlayerModel
    {
        public int Id { get; set; }
        public int TeamNumber { get; set; }
        public int player_Id { get; set; }

        [ForeignKey("player_Id")]
        public PlayerModel PlayerModel { get; set; }

    }
}
