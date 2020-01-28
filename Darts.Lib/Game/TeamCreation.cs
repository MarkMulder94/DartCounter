using Darts.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Lib.Game
{
    public class TeamCreation
    {
        public List<TeamModel> MakeTeams(List<WantGamePlayerModel> players)
        {
            List<TeamModel> teams = new List<TeamModel>() { };
            TeamModel _team1 = new TeamModel() { Players = new List<WantGamePlayerModel>() };
            TeamModel _team2 = new TeamModel() { Players = new List<WantGamePlayerModel>() };
            if (players.Count <= 4 && players.Count > 1)
            {
                foreach (var player in players)
                {
                    switch (player.TeamNumber)
                    {
                        case 1:
                            {
                                _team1.Players.Add(player);
                            }          
                            break;     
                        case 2:        
                            {          
                                _team2.Players.Add(player);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                // error too many player or too few player
                throw new NotImplementedException();
            }
            teams.Add(_team1);
            teams.Add(_team2);
            return teams; 
        }
    }
}
