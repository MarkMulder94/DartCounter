import { Component, OnInit } from "@angular/core";
import { GameService } from "src/app/Shared/game.service";
import { Game } from "src/app/Shared/game.model";
import { HttpClient } from "@angular/common/http";
import { Team } from "src/app/Shared/team.model";
import { Player } from "src/app/Shared/player.model";
import { User } from "src/app/Shared/user.model";

@Component({
  selector: "app-game",
  templateUrl: "./Game.component.html",
  styleUrls: ["./Game.component.css"]
})
export class GameComponent implements OnInit {
  // #region Variable's
  private gameNumber: number = 2;
  AverageTeam1: number = 0;
  AverageTeam2: number = 0;
  // Game
  game: Game = new Game();
  // Teams
  team1: Team = new Team();
  team2: Team = new Team();
  player1: Player = new Player();
  player2: Player = new Player();
  //Speler op een team
  spelersTeam1: User[] = [];
  spelersTeam2: User[] = [];

  // setup variable's
  turnTeam1: boolean = true;
  mainText: string = "";
  errorMessage: string = "";
  currentScoreTeam1: number = 501;
  currentScoreTeam2: number = 501;
  lastThrowTeam1: number;
  lastThrowTeam2: number;
  //Array's (scoreLogging, throwLogging)
  currentLegScoresTeam1: number[] = [501];
  currentLegScoresTeam2: number[] = [501];

  thrownScoresTeam1: number[] = [];
  thrownScoresTeam2: number[] = [];
  //#endregion

  constructor(private service: GameService, private http: HttpClient) {}

  //#region LoadGameData From Api
  ngOnInit() {
    this.getAsyncGameData(this.gameNumber);
  }
  async getAsyncGameData(id: number) {
    this.game = await this.service.getAsyncGameData(id);
    this.team1 = this.game.teamModel[0];
    this.team2 = this.game.teamModel[1];
    this.team1.players.forEach(x => {
      this.spelersTeam1.push(x.playerModel);
    });
    this.team2.players.forEach(x => {
      this.spelersTeam2.push(x.playerModel);
    });
  }
  //#endregion
  //#region Calculations
  UpdateScore(turnTeam: boolean) {
    if (turnTeam) {
      // Methods

      this.insertScore(this.mainText, true);
      this.getAverage(this.thrownScoresTeam1, true);
      this.getLastThrow(this.currentLegScoresTeam1, true);
      // End Turn
      this.mainText = "";
      this.turnTeam1 = false;
    } else {
      // Methods
      this.insertScore(this.mainText, false);
      this.getAverage(this.thrownScoresTeam1, false);
      this.getLastThrow(this.currentLegScoresTeam2, false);
      // End Turn
      this.mainText = "";
      this.turnTeam1 = true;
    }
  }
  insertScore(points: string, team1: boolean) {
    if (team1) {
      if (points!) {
        this.team1.currentScore -= Number(points);
        this.thrownScoresTeam1.push(Number(points));

        this.currentLegScoresTeam1.push(this.team1.currentScore);
        this.currentScoreTeam1 = this.currentLegScoresTeam1[
          this.currentLegScoresTeam1.length - 1
        ];
      } else {
        this.errorMessage = "Je moet een score invullen!";
      }
    } else {
      if (points!) {
        this.team2.currentScore -= Number(points);
        this.thrownScoresTeam2.push(Number(points));
        this.currentLegScoresTeam2.push(this.team2.currentScore);
        this.currentScoreTeam2 = this.currentLegScoresTeam2[
          this.currentLegScoresTeam2.length - 1
        ];
      } else {
        this.errorMessage = "Je moet een score invullen!";
      }
    }
  }
  getAverage(arr: number[], team1: boolean) {
    let sum = arr.reduce((previous, current) => (current += previous));
    if (team1) {
      this.AverageTeam1 = sum / arr.length;
    } else {
      this.AverageTeam2 = sum / arr.length;
    }
  }
  getLastThrow(arr: number[], team1: boolean) {
    var score1 = arr[arr.length - 2];
    var score2 = arr[arr.length - 1];
    var thrown = score1 - score2;
    if (team1) {
      this.lastThrowTeam1 = thrown;
    } else {
      this.lastThrowTeam2 = thrown;
    }
  }
  //#endregion
  //#region Buttons
  pressKey(key: string) {
    if (this.mainText.length >= 3) {
      this.errorMessage = "3 cijfers is de max";
      return;
    } else {
      this.mainText += key;
    }
  }
  backspace() {
    this.mainText = this.mainText.slice(0, -1);
    this.errorMessage = "";
  }
  enter() {
    if (Number(this.mainText) > 180) {
      this.errorMessage = "Score kan niet hoger als 180 zijn";
    } else {
      this.errorMessage = "";
      this.UpdateScore(this.turnTeam1);
    }
  }

  //#endregion
}
