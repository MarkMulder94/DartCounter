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

        int playerTurn = 0; 

        // Spelers onderverdelen over twee teams.
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
            if (_team1.Count != _team2.Count)
            {
                // TODO: Foutmelding, oneven teams.
                // Idee: Bot toevoegen suggestie?
                throw new Exception();
            }
            else
            {
                teams.Add(_team1);
                teams.Add(_team2);
            }

            return teams;     
        }
        // Starting the game
        public List<PlayerCurrentLegModel> Setup()
        {
            var teams = DividePlayersIntoTeams();
            List<PlayerCurrentLegModel> players = new List<PlayerCurrentLegModel>();
            // Maak een lijst van de player_id's 
            foreach (var team in teams)
            {
                foreach (var player in team)
                {
                    players.Add(new PlayerCurrentLegModel { Player_Id = player.player_Id, Team_Id = player.Team_Id });
                }
            }
            return players;
        // Start het spel
        }
        public void PlayerThrow(int thrownPoints, int playerTurn)
        {
            foreach (var player in Setup())
            {
                int score = player.CurrentScore;
                var newScore = new LegRunner(score).Turn(thrownPoints);
            }
        }
    }
}
