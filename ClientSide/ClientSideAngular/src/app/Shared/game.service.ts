import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class GameService {
  constructor() {}
  speler1 = "Speler 1"; // The text that should appear in the sub-display
  speler2 = "Speler 2"; // The text that should appear in the sub-display
  currentScore1 = "501"; // The text that should appear in the main display
  currentScore2 = "501"; // The text that should appear in the main display
  LoadData() {
    this.speler1 = "401"; // The text that should appear in the sub-display
    this.speler2 = "Speler 2"; // The text that should appear in the sub-display
    this.currentScore1 = "401"; // The text that should appear in the main display
    this.currentScore2 = "501"; // The text that should appear in the main display
  }
}
