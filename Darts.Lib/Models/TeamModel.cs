using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Darts.Lib.Models
{
    public class TeamModel
    {
        [Key]
        public int Team_Id { get; set; }
        public int CurrentScore { get; set; } = 501;
        public int Legs { get; set; } = 0;
        public int Sets { get; set; } = 0;
        public int ThrownDarts { get; set; } = 0; 
        public ICollection<WantGamePlayerModel> Players { get; set; }
    }
}
