using Darts.Lib.Game;
using Darts.Lib.Models;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;
using Darts.Lib.DataAcces;

namespace UnitTests.Core.Game.GameRunnerTests
{
    public class GameLoopTests
    {
        public List<PlayerModel> SeedUsers()
        {
            var playerList = new List<PlayerModel>();

            var player1 = new PlayerModel("Mark", "Mulder") { Player_Id = 1 };
            var player2 = new PlayerModel("Kelly", "Schinkel") { Player_Id = 2 };
            var player3 = new PlayerModel("Iemand", "Mulder") { Player_Id = 3 };
            var player4 = new PlayerModel("Test", "Mulder") { Player_Id = 4 };

            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            playerList.Add(player4);

            return playerList;
        }
        public List<WantGamePlayerModel> SeedPlayers(int idPlayer1, int idPlayer2)
        {
            var userList = SeedUsers();
            var playerList = new List<WantGamePlayerModel>();
            

            var player1 = new WantGamePlayerModel() { player_Id = idPlayer1, TeamNumber = 2 };
            var player2 = new WantGamePlayerModel() { player_Id = idPlayer2, TeamNumber = 2 };

            playerList.Add(player1);
            playerList.Add(player2);

            return playerList;
        }
        [Fact]
        public void PlayerListNotEmpty()
        {
            var result = SeedPlayers(2, 3);

            result.Should().NotBeEmpty();
        }
        [Fact]
        public void GiveBackTeams_GivenGameId()
        {
            var result = GetTeams.GetTheTeamsOnExistingGame(11);
            result.Should().HaveCount(2);
        }
        //[Theory]
        //[InlineData(20, 481)]
        //public void GiveBackNewScore_GivenCurrentThrow(int score, int expected)
        //{
        //    List<int> StartScores = new List<int>() { 501, 501 };
        //    var game = new GameRunner(5);
        //    var ScoresBeforeThrow = game.Scores();
        //    game.ThrowTurn(score);
        //    var ScoresAfterThrow = game.Scores();
        //    Assert.Equal(StartScores, ScoresBeforeThrow);
        //    Assert.Equal(expected, ScoresAfterThrow[0]);
        //}
        [Theory]
        [InlineData(30, 51)]
        public void GiveBackThrownDarts_GivenNothing(int expected, int thrown)
        {
            var game = new GameRunner(11);
            int x = game.StartLeg(thrown);
            Assert.Equal(expected, x);
        }









    }




}

