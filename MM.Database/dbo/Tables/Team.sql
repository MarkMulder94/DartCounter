CREATE TABLE [dbo].[Team]
(
	team_Id INT NOT NULL IDENTITY PRIMARY KEY,

	player1 INT not null, 
	player2 INT, 


	[player3] INT NULL, 
    [player4] INT NULL, 
	FOREIGN KEY (player1) REFERENCES Player(player_Id),
    FOREIGN KEY (player2) REFERENCES Player(player_Id),
	FOREIGN KEY (player3) REFERENCES Player(player_Id),
	FOREIGN KEY (player4) REFERENCES Player(player_Id)
)

