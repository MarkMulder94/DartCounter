using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Darts.Lib.Models
{
    public class PlayerModel
    {
        [Key]
        public int player_Id { get; set; }

        // spelerinfo
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // spelerstatistieken

        [Column(TypeName = "decimal(5,2)")]
        public decimal AverageScore { get; set; } = 0;
        public int GamesPlayed { get; set; } = 0;
        public int HighestFinish { get; set; } = 0;
        public int ThrownDarts { get; set; } = 0;
        public int TotalScore { get; set; } = 0;

    }
}
