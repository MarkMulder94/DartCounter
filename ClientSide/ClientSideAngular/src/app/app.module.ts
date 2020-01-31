import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule, HttpClient } from "@angular/common/http";
import { FormsModule} from "@angular/forms"

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { GameRunnerComponent } from "./game-runner/game-runner.component";
import { GameComponent } from "./game-runner/Game/game.component";


@NgModule({
  declarations: [AppComponent, GameRunnerComponent, GameComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
