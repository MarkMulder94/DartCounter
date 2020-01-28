

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

        public void ThrowTurn(int score)
        {
            int teamTurn = 0;
            RegisterThrow(teamTurn, score);
            if (teamTurn == 0)
            {
                teamTurn++;
            }
            else { teamTurn--; }
        }
        public void RegisterThrow(int teamTurn, int thrownScore)
        {
            switch (teamTurn)
            {
                case 0:
                    _teams[0].CurrentScore -= thrownScore;
                    break;
                case 1:
                    _teams[1].CurrentScore -= thrownScore;
                    break;
                default:
                    break;
            }

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
    }
}
