using Darts.Lib.Game;
using Darts.Lib.Models;
using System;
using System.Collections.Generic;

class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.WriteLine("Hello World!");
        }
    public static void Test()
    {
        var playerList = new List<PlayerModel>();

        var player1 = new PlayerModel() { firstName = "Mark", lastName = "Mulder", Team_Id = 1 };
        var player2 = new PlayerModel() { firstName = "Kelly", lastName = "Schinkel", Team_Id = 1 };
        var player3 = new PlayerModel() { firstName = "Frank", lastName = "Mulder", Team_Id = 2 };
        var player4 = new PlayerModel() { firstName = "Jermaine", lastName = "Schinkel", Team_Id = 2 };

        playerList.Add(player1);
        playerList.Add(player2);
        playerList.Add(player3);
        playerList.Add(player4);
    }


}

