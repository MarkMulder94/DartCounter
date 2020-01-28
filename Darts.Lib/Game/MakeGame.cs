

using Darts.Lib.DataAcces;
using Darts.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Darts.Lib.Game
{
    public class MakeGame
    {
        private readonly int _gameId;
        private List<TeamModel> _teams;
        private List<WantGamePlayerModel> _competitors;

        public MakeGame(int gameId)
        {
            _gameId = gameId;
            _teams = GetTeams.GetTheTeamsOnExistingGame(_gameId);
        }

        public void CheckIfGameIsOver()
        {

            while (_teams.TrueForAll(x => x.CurrentScore != 0))
            {
                LegRunner.Turn(200, _teams[0].CurrentScore);
            }
        }

    }
}
