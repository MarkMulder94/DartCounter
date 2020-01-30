import { Component, OnInit } from "@angular/core";
import { GameService } from "../Shared/game.service";
import { Player } from "../Shared/player.model";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-game-runner",
  templateUrl: "./game-runner.component.html",
  styleUrls: ["./game-runner.component.css"]
})
export class GameRunnerComponent implements OnInit {
  constructor(private service: GameService, private http: HttpClient) {}
  private players = [];
  gameMaker: number[] = [];

  ngOnInit() {}

  trackByFn(index, item) {
    return item.id;
  }
  addGameId(id: string) {
    var x = Number(id);
    this.service.putGameId(x);
  }
}
