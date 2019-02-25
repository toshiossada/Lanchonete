import { Component, OnInit } from '@angular/core';
import { AppHttpService } from '../app-http.service';


@Component({
  selector: 'app-cardapio',
  templateUrl: './cardapio.component.html',
  styleUrls: ['./cardapio.component.css']
})


export class CardapioComponent implements OnInit {
  public valor = 0;
  lancheSelecionado: any = {};
  ingredientesSelecionados: any = [];
  public pedidoLanche: PedidoLanche;
  constructor(private service: AppHttpService) { }

  ngOnInit() {

  }

  changeLancheSelecionado(lanche: any){
    this.lancheSelecionado = lanche;
  }
  changeIngredienteSelecionado(ingrediente: any){
    this.ingredientesSelecionados = ingrediente;
  }

  save() {
    this.pedidoLanche = new PedidoLanche();
    this.pedidoLanche.idLanche = this.lancheSelecionado.id;
    this.pedidoLanche.lanche = this.lancheSelecionado;
    this.pedidoLanche.ingredientesAdicionais = new Array<IngredientesAdicional>();


    for (const item of this.ingredientesSelecionados) {
      const ingredienteAdicional = new IngredientesAdicional()
      ingredienteAdicional.ingredienteId = item.id;
      ingredienteAdicional.ingrediente = item;
      ingredienteAdicional.quantidade = item.quantidade;
      this.pedidoLanche.ingredientesAdicionais.push(ingredienteAdicional);
    }

    

    this.service
      .build('PedidoLanche')
      .create(this.pedidoLanche)
      .subscribe((data) => {
        this.valor = data['valorFinal'];
        alert('Inserido com sucesso');
      });
  }

}

export class PedidoLanche {
  id: number;
  idLanche: number;
  valorFinal: number;
  lanche: object;
  ingredientesAdicionais: Array<IngredientesAdicional>;
}
export class IngredientesAdicional {
  pedidoLancheId: number;
  ingredienteId: number;
  ingrediente: object;
  quantidade: number;
}

