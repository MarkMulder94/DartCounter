using Dapper;
using Darts.Lib.Intern.DataAcces;
using Darts.Lib.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Darts.Lib.DataAcces
{
    public class GetTeams
    {
        public static List<TeamModel> GetTheTeamsOnExistingGame(int gameId)
        {
            using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-OISNHO6;Initial Catalog=DartCounter;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string teams = $@"select * from games
                                    inner join Teams on teams.GameModelGame_Id = games.Game_Id
                                    where games.Game_Id = {gameId}";

                var result = db.Query<TeamModel>(teams).AsList();
                return result;

            }
        }        
    }
}

