import { Component, OnInit, Input } from '@angular/core';
import { AppHttpService } from '../../app-http.service';


@Component({
  selector: 'app-ingredientes',
  templateUrl: './ingredientes.component.html',
  styleUrls: ['./ingredientes.component.css']
})
export class IngredientesComponent implements OnInit {
  public ingredientes: any = [];
  // tslint:disable-next-line:no-input-rename
  @Input("ingredientesSelecionados") ingredientesSelecionados: any = [];

  constructor(private service: AppHttpService) { }

  ngOnInit() {
    this.service.build('Ingredientes') 
      .list()
      .subscribe((data) => {
        this.updateData(data);
      });
  }

  checkboxHandle(isChecked, ingrediente) {
    if (isChecked.currentTarget.checked) {
      this.inserteIngrediente(ingrediente)
    } else {
      this.deleteIngrediente(ingrediente)
    }
  }


  inserteIngrediente(ingrediente) {
    this.ingredientesSelecionados.push(ingrediente);
  }
  deleteIngrediente(ingrediente) {
    const index: number = this.ingredientesSelecionados.indexOf(ingrediente);
    if (index !== -1) {
      this.ingredientesSelecionados.splice(index, 1);
    }
  }

  updateData(ingredientes) {
    this.ingredientes = ingredientes;
  }
}
