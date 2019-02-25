import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CardapioComponent } from './cardapio.component';
import { IngredientesComponent } from './ingredientes/ingredientes.component';
import { LanchesComponent } from './lanches/lanches.component';
import { FormsModule } from '@angular/forms';

const appRoutes: Routes = [
  { path: 'cardapio', component: CardapioComponent },
];

@NgModule({
  declarations: [CardapioComponent, IngredientesComponent, LanchesComponent],
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
  ]
})
export class CardapioModule { }
