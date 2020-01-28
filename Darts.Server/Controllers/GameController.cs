using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Darts.Lib.DataAcces;
using Darts.Lib.Game;
using Darts.Lib.Models;
using Darts.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Darts.Server.Controllers
{



    [Route("api/MakeGame")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Entity/")]
        [HttpPost]
        public async Task<ActionResult<GameModel>> PostEntity(List<int> PlayerIdAndTeam)
        {
            List<WantGamePlayerModel> players = new List<WantGamePlayerModel>();
            List<TeamModel> teamsz = new List<TeamModel>();
            // Create PlayerModel
            for (int i = 0; i < PlayerIdAndTeam.Count; i+=2)
            {
                var playerModel = _context.UserModels.Where(x => x.player_Id == PlayerIdAndTeam[i]).FirstOrDefault();
                WantGamePlayerModel player = new WantGamePlayerModel()
                {
                    PlayerModel = playerModel,
                    player_Id = PlayerIdAndTeam[i],
                    TeamNumber = PlayerIdAndTeam[i + 1]
                };
                players.Add(player);
            }
            // create TeamModel
            var teamModels = new TeamCreation().MakeTeams(players);
            // create GameModel
            var gameModel = new GameModel() { TeamModel = teamModels };
            _context.Games.Add(gameModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGameModel", new { id = gameModel.Game_Id }, gameModel);
        }
    }
}
//[Route("dapper/")]
//[HttpPost]
//// TODO: AANPASSEN!
//// Lelijk, maar het werkt....
//public void PostDapper(List<PlayerModel> players)
//{
//    var Spelers = new MakeGame(players).Setup();
//    var LijstMetTeams = Spelers.Select(x => x.Team_Id).ToList();
//    StringBuilder VALUES = new StringBuilder("");
//    StringBuilder INTO = new StringBuilder("");

//    foreach (var id in LijstMetTeams)
//    {
//        VALUES.Append($"{ id }, ");
//    }
//    for (int i = 1; i < LijstMetTeams.Count + 1; i++)
//    {
//        INTO.Append($"[player{ i }], ");
//    }
//    var x = INTO.Remove(INTO.Length - 2, 2).ToString();
//    var z  = VALUES.Remove(VALUES.Length - 2, 2).ToString();


//    using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-OISNHO6;Initial Catalog=DartsDatabase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
//    {
//        string insertQuery = @$"INSERT INTO [dbo].[Game]({x}) VALUES ({z})";
//        string deleteQuery = $@"delete from Game
//                                where player1 = {LijstMetTeams[0]} or player2 = {LijstMetTeams[0]}
//                                or player1 = {LijstMetTeams[1]} or player2 = {LijstMetTeams[1]};";

//        string getMatchQuery = $@"select game_id from [dbo].[Game] 
//                                 where player1 = {LijstMetTeams.First()}";
//        db.Query(deleteQuery);
//        db.Execute(insertQuery);
//    }


//}