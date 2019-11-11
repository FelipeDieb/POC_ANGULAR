import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GraphLineComponent } from './components/graph-line/graph-line.component';
import { GraphBarComponent } from './components/graph-bar/graph-bar.component';
import { GraphPieComponent } from './components/graph-pie/graph-pie.component';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    GraphLineComponent,
    GraphBarComponent,
    GraphPieComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ChartsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
