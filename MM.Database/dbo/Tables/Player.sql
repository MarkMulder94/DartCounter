CREATE TABLE [dbo].[Player]
(
	player_Id INT NOT NULL IDENTITY PRIMARY KEY,
	firstName nvarchar(50) not null,
	lastName nvarchar(50) not null,
	gamesCount int DEFAULT 0 NOT NULL,
	avgScore decimal(5, 2) default 0 NOT NULL,
	highestFinish int default 0 NOT NULL,
	thrownDarts int default 0 not null, 
    [totalScore] INT NOT NULL DEFAULT 0
)
