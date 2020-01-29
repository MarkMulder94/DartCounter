import { Component, OnInit } from "@angular/core";
import { GameService } from "src/app/Shared/game.service";

@Component({
  selector: "app-input",
  templateUrl: "./input.component.html",
  styleUrls: ["./input.component.css"]
})
export class InputComponent implements OnInit {
  speler1: string = "";
  mainText = "501";
  constructor(private service: GameService) {
    this.service.LoadData();
    this.speler1 = this.service.speler1;
  }

  ngOnInit() {}
}
