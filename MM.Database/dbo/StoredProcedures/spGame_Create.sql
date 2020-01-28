CREATE PROCEDURE [dbo].[spGame_Create]
	@PlayerId int
as
begin
set nocount on; 
insert into 
dbo.Game
(player1, player2)
values(@PlayerId)
end
