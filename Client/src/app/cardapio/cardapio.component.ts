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
  constructor(private service: AppHttpService) { }

  ngOnInit() {

  }

  changeLancheSelecionado(lanche: any) {
    this.lancheSelecionado = lanche;
    this.service
      .build('PedidoLanche/ValorFinal')
      .create(this.montaRequest())
      .subscribe((data) => {
        this.valor = data['valorFinal'];
      });
  }
  changeIngredienteSelecionado(ingrediente: any) {
    this.ingredientesSelecionados = ingrediente;
    this.service
      .build('PedidoLanche/ValorFinal')
      .create(this.montaRequest())
      .subscribe((data) => {
        this.valor = data['valorFinal'];
      });
  }

  save() {
    this.service
      .build('PedidoLanche')
      .create(this.montaRequest())
      .subscribe((data) => {
        this.valor = data['valorFinal'];
        alert('Inserido com sucesso');
      });
  }

  montaRequest() {
    const pedidoLanche = new PedidoLanche();
    pedidoLanche.idLanche = this.lancheSelecionado.id;
    pedidoLanche.lanche = this.lancheSelecionado;
    pedidoLanche.ingredientesAdicionais = new Array<IngredientesAdicional>();


    for (const item of this.ingredientesSelecionados) {
      const ingredienteAdicional = new IngredientesAdicional()
      ingredienteAdicional.ingredienteId = item.id;
      ingredienteAdicional.ingrediente = item;
      ingredienteAdicional.quantidade = item.quantidade;
      pedidoLanche.ingredientesAdicionais.push(ingredienteAdicional);
    }

    return pedidoLanche;
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

