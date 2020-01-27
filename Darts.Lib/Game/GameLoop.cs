using Darts.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Lib.Game
{
    public class GameLoop
    {
        private readonly List<PlayerModel> _players = new List<PlayerModel>();

        public GameLoop(List<PlayerModel> players)
        {
            _players = players;
        }

        public List<List<PlayerModel>> DividePlayersIntoTeams()
        {
            List<List<PlayerModel>> teams = new List<List<PlayerModel>>();

            List<PlayerModel> _team1 = new List<PlayerModel>();
            List<PlayerModel> _team2 = new List<PlayerModel>();

            foreach (var player in _players)
            {
                switch (player.Team_Id)
                {
                    case 1:
                    {
                        _team1.Add(player);
                    }
                    break;
                    case 2:
                    {
                        _team2.Add(player);
                    }
                    break;
                    default:
                        break;
                    
                }
            }
            teams.Add(_team1);
            teams.Add(_team2);
            return teams;     
        }
        public List<int> StartGame()
        {
            var teams = DividePlayersIntoTeams();
            int AantalSpelers = 0; 
            List<int> playerid = new List<int>();

            foreach (var team in teams)
            {
                AantalSpelers += team.Count;
                foreach (var player in team)
                {
                    playerid.Add(player.player_Id);
                }

            }
            return playerid;
        }
    }
}
