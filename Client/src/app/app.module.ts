import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppHttpService } from './app-http.service';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CardapioModule } from './cardapio/cardapio.module';
const appRoutes: Routes = [
  {path: '', redirectTo: '/cardapio', pathMatch: 'full'}
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CardapioModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [AppHttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
