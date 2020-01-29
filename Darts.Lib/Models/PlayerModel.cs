using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Darts.Lib.Models
{
    public class PlayerModel
    {
        [Key]
        public int Player_Id { get; set; }

        // spelerinfo
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        // spelerstatistieken

        [DefaultValue(0)]
        public int GamesPlayed { get; set; }
        [DefaultValue(0)]
        public int HighestFinish { get; set; }
        [DefaultValue(0)]
        public int ThrownDarts { get; set; }
        [DefaultValue(0)]
        public int TotalScore { get; set; }

    }
}
