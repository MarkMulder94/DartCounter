import { Player } from "./player.model";

export class Team {
  team_Id: number;
  currentScore: number;
  legs: number;
  sets: number;
  thrownDarts: number;
  players: Player[];
}
