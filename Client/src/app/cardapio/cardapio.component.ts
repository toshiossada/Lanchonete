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
  ingredienteAdicional = new IngredientesAdicional();
  constructor(private service: AppHttpService) { }

  ngOnInit() {

  }

  save() {
    this.pedidoLanche = new PedidoLanche();
    this.pedidoLanche.id = this.lancheSelecionado.id;
    this.pedidoLanche.idLanche = this.lancheSelecionado.id;
    this.pedidoLanche.lanche = this.lancheSelecionado
    this.pedidoLanche.ingredientesAdicionais = new Array<IngredientesAdicional>();


    for (const item of this.ingredientesSelecionados) {
      this.ingredienteAdicional.ingredienteId = 0;
      this.ingredienteAdicional.ingrediente = item;
      this.ingredienteAdicional.quantidade = item.quantidade;
      this.pedidoLanche.ingredientesAdicionais.push(this.ingredienteAdicional);
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

