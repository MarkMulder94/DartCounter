import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Player } from "./models/player.model";
import { Game } from "./models/game.model";
import { log } from "util";
import { promise } from "protractor";
import { User } from "./Models/user.model";

@Injectable({
  providedIn: "root"
})
export class GameService {
  readonly rootURL = "https://localhost:44323/";
  asyncResult: void;
  players: Player[] = [];
  public gameId: number = 1;

  constructor(private http: HttpClient) {}

  async getAsyncGameData(): Promise<Game> {
    var result = await this.http
      .get<Game>(this.rootURL + "Game/" + this.gameId)
      .toPromise();
    return result;
  }
  putGameId(id: number) {
    this.gameId = id;
  }
  async LoadPlayers(): Promise<User> {
    return await this.http.get<User>(this.rootURL + "players/").toPromise();
  }
}
