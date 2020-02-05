using Darts.Lib.Game;
using Darts.Lib.Models;
using Darts.Server.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darts.Server.Services
{
    public class MakeStartGame

    {
        private readonly ApplicationDbContext _context;
        public MakeStartGame(ApplicationDbContext context)
        {
            _context = context;
        }

        public GameModel MakeTheGame(List<int> PlayerIdAndTeam)
        {
            List<WantGamePlayerModel> players = new List<WantGamePlayerModel>();
            List<TeamModel> teamsz = new List<TeamModel>();
            // Create PlayerModel
            for (int i = 0; i < PlayerIdAndTeam.Count; i += 2)
            {
                var playerModel = _context.UserModels.Where(x => x.Player_Id == PlayerIdAndTeam[i]).FirstOrDefault();
                WantGamePlayerModel player = new WantGamePlayerModel() { player_Id = PlayerIdAndTeam[i], PlayerModel = playerModel, TeamNumber = PlayerIdAndTeam[i+1] };
                players.Add(player);
            }
            // create TeamModel
            var teamModels = new TeamCreation().MakeTeams(players);
            // create GameModel
            var gameModel = new GameModel() { TeamModel = teamModels };
            return gameModel;
        }
    }
}
