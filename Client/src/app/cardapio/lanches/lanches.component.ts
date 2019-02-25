import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AppHttpService } from '../../app-http.service';

@Component({
  selector: 'app-lanches',
  templateUrl: './lanches.component.html',
  styleUrls: ['./lanches.component.css']
})
export class LanchesComponent implements OnInit {
  public lanches: any = [];
  // tslint:disable-next-line:no-input-rename
  lancheSelecionado: any = {};
  @Output() lancheSelecionadoE = new EventEmitter<any>();

  constructor(private service: AppHttpService) { }

  ngOnInit() {
    this.service.build('Lanches')
      .list()
      .subscribe((data) => {
        this.updateData(data);
      });
  }

  public selecionarLanche(lanche) {
    this.lancheSelecionado = lanche;
    this.lancheSelecionadoE.emit(this.lancheSelecionado);
  }

  getDescricao(lanche){
    debugger;
    return lanche.lancheIngredientes.map(e => e.ingrediente.descricao).join(', ');
  }
  getPrice(lanche) {
    return lanche.lancheIngredientes.map(e => e.ingrediente.valor).reduce((a, b) => a + b);
  }

  updateData(lanches) {
    this.lanches = lanches;
  }
}
