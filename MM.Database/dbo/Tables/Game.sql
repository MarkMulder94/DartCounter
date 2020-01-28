CREATE TABLE [dbo].[Game]
(

	game_Id INT NOT NULL IDENTITY PRIMARY KEY,

	player1 INT not null, 
	player2 INT null,
	player3 INT, 
	player4 INT,
    player5 INT, 
	player6 INT,
	player7 INT, 
	player8 INT,
	[DateCreated] DATETIME2 NULL DEFAULT getutcdate(), 

	FOREIGN KEY (player1) REFERENCES Player(player_Id) On DELETE cascade,
    FOREIGN KEY (player2) REFERENCES Player(player_Id) On DELETE no action,
	FOREIGN KEY (player3) REFERENCES Player(player_Id) On DELETE no action,
	FOREIGN KEY (player4) REFERENCES Player(player_Id) On DELETE no action,
	FOREIGN KEY (player5) REFERENCES Player(player_Id) On DELETE no action,
	FOREIGN KEY (player6) REFERENCES Player(player_Id) On DELETE no action,
	FOREIGN KEY (player7) REFERENCES Player(player_Id) On DELETE no action,
	FOREIGN KEY (player8) REFERENCES Player(player_Id) On DELETE no action
	)
