using Darts.Lib.Game;
using Darts.Lib.Models;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace UnitTests.Core.Game.GameRunnerTests
{
    public class GameLoopTests
    {
        public List<PlayerModel> SamplePlayersData()
        {
            var playerList = new List<PlayerModel>();

            var player1 = new PlayerModel() { firstName = "Mark", lastName = "Mulder", Team_Id = 1, player_Id = 1};
            var player2 = new PlayerModel() { firstName = "Kelly", lastName = "Schinkel", Team_Id = 2, player_Id = 4};
            var player3 = new PlayerModel() { firstName = "Frank", lastName = "Mulder", Team_Id = 2, player_Id = 3};
            var player4 = new PlayerModel() { firstName = "Jermaine", lastName = "Schinkel", Team_Id = 1, player_Id =2  };

            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            playerList.Add(player4);

            return playerList;

        }
        [Fact]
        public void ReturnTeamsSorted_GivenPlayers()
        {
            var result = new GameLoop(SamplePlayersData()).DividePlayersIntoTeams();
            result.Should().NotBeNull();   
        }

        [Theory]
        [InlineData(401, 501, 100)]
        public void ReturnNewScore_GivenCurrentAndThrow(int expected, int currentScore, int thrownPoints)
        {
            var result = new GameLoop(SamplePlayersData()).StartGame();
  
            Assert.Equal(expected, new LegRunner(currentScore).Turn(thrownPoints));
        }







    }




}

