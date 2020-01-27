CREATE TABLE [dbo].[Game]
(

	game_Id INT NOT NULL IDENTITY PRIMARY KEY,

	Team1 INT not null, 
	Team2 INT not null,
	Team3 int not null,



	FOREIGN KEY (Team1) REFERENCES Team(team_Id),
	FOREIGN KEY (Team2) REFERENCES Team(team_Id)

)
