import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { GameRunnerComponent } from "./game-runner/game-runner.component";
import { InputComponent } from "./game-runner/input/input.component";

@NgModule({
  declarations: [AppComponent, GameRunnerComponent, InputComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
