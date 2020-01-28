

using Darts.Lib.DataAcces;
using Darts.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Darts.Lib.Game
{
    public class GameRunner
    {
        private readonly int _gameId;
        private List<TeamModel> _teams;
        private List<WantGamePlayerModel> _competitors;

        public GameRunner(int gameId)
        {
            _gameId = gameId;
            _teams = GetTeams.GetTheTeamsOnExistingGame(_gameId);
        }
        public List<int> Scores()
        {
            List<int> scores = new List<int>();
            foreach (var team in _teams)
            {
                scores.Add(team.CurrentScore);
            }
            return scores;
        }
        public int StartLeg(int thrown)
        {
            List<int> test = Scores();
            int teamTurn = 0;
            int thrownScore = thrown;
            while (_teams.All(x => x.CurrentScore > 0))
            {
                PlayerThrow(thrownScore);
                _teams[teamTurn].ThrownDarts += 3;
            }
            return _teams[teamTurn].ThrownDarts;
            void PlayerThrow(int score)
            {
                RegisterThrow(teamTurn, score);
                if (teamTurn == 0)
                {
                    teamTurn++;
                }
                else { teamTurn--; }
            }
            void RegisterThrow(int team, int scoredPoints)
            {
                switch (teamTurn)
                {
                    case 0:
                        _teams[team].CurrentScore -= scoredPoints;
                        break;
                    case 1:
                        _teams[team].CurrentScore -= scoredPoints;
                        break;
                    default:
                        break;
                }

            }

        }



    }
}
