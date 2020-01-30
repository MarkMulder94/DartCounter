import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Player } from "./player.model";
import { Game } from "./game.model";
import { Team } from "./team.model";

@Injectable({
  providedIn: "root"
})
export class GameService {
  readonly rootURL = "https://localhost:44323/";
  asyncResult: void;

  constructor(private http: HttpClient) {}

  async getAsyncGameData(id: number): Promise<Game> {
    var result = await this.http
      .get<Game>(this.rootURL + "Game/" + id)
      .toPromise();
    return result;
  }
}
