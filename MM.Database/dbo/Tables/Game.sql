CREATE TABLE [dbo].[Game]
(

	game_Id INT NOT NULL IDENTITY PRIMARY KEY,

	player1 INT not null, 
	player2 INT not null,
	player3 INT, 
	player4 INT,
    player5 INT, 
	player6 INT,
	player7 INT, 
	player8 INT 

	FOREIGN KEY (player1) REFERENCES Player(player_Id) On DELETE set null,
	FOREIGN KEY (player2) REFERENCES Player(player_Id) On DELETE set null,
	FOREIGN KEY (player3) REFERENCES Player(player_Id) On DELETE set null,
	FOREIGN KEY (player4) REFERENCES Player(player_Id) On DELETE set null,
	FOREIGN KEY (player5) REFERENCES Player(player_Id) On DELETE set null,
	FOREIGN KEY (player6) REFERENCES Player(player_Id) On DELETE set null,
	FOREIGN KEY (player7) REFERENCES Player(player_Id) On DELETE set null,
	FOREIGN KEY (player8) REFERENCES Player(player_Id) On DELETE set null
	)
