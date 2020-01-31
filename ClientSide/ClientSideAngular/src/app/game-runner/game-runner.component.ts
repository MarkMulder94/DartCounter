import { Component, OnInit } from "@angular/core";
import { GameService } from "../Shared/game.service";
import { HttpClient } from "@angular/common/http";
import { User } from "../Shared/Models/user.model";

@Component({
  selector: "app-game-runner",
  templateUrl: "./game-runner.component.html",
  styleUrls: ["./game-runner.component.css"]
})
export class GameRunnerComponent implements OnInit {
  noErrors: boolean = false;
  loaded: Promise<boolean>;
  private ready: boolean = false;
  constructor(private service: GameService, private http: HttpClient) {}
  private players = [];
  gameMaker: number[] = [];
  team1: number;
  team2: number;
  errorMessage: string = "";
  result: number[] = [];
  gameId: number = 0;

  ngOnInit() {
    this.LoadPlayers();
  }
  makeGame() {
    this.ErrorCheck(this.team1, this.team2);
    this.postGame(this.team1, this.team2);
  }
  async postGame(team1: number, team2: number) {
    if (this.noErrors) {
      this.result.push(this.team1);
      this.result.push(1);
      this.result.push(this.team2);
      this.result.push(2);
      var result = this.http
        .post(this.service.rootURL + "Game/Create", this.result)
        .toPromise();
      this.service.gameId = Number(await result).valueOf();
      this.ready = true;
    }
  }
  ErrorCheck(team1: number, team2: number) {
    this.errorMessage = "";
    if (team1 == null || team2 == null) {
      this.errorMessage = "Selecteer twee spelers..";
    } else if (team1 == this.team2) {
      this.errorMessage =
        "Speler kunnen niet hetzelfde zijn, selecteer twee verschillende spelers";
    } else {
      this.errorMessage = "Aangemaakt";
      this.noErrors = true;
    }
  }
  addGameId(id: string) {
    var x = Number(id);
    this.service.putGameId(x);
  }
  LoadPlayers() {
    this.http
      .get<User[]>(this.service.rootURL + "players")
      .subscribe(result => {
        this.players = result;
        return this.players;
      });
  }
}
