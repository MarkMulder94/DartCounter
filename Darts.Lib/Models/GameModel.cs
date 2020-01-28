using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Darts.Lib.Models
{
    public class GameModel
    {
        [Key]
        public int Game_Id { get; set; }
        public ICollection<TeamModel> TeamModel { get; set; }
    }
}
