import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { GameComponent } from "./game-runner/Game/game.component";
import { GameRunnerComponent } from "./game-runner/game-runner.component";

const routes: Routes = [
  { path: "game", component: GameComponent },
  { path: "", component: GameRunnerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: "reload" })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
