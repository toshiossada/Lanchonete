import { Component, OnInit, Input } from '@angular/core';
import { AppHttpService } from '../../app-http.service';

@Component({
  selector: 'app-lanches',
  templateUrl: './lanches.component.html',
  styleUrls: ['./lanches.component.css']
})
export class LanchesComponent implements OnInit {
  public lanches: any = [];
  // tslint:disable-next-line:no-input-rename
  @Input('lancheSelecionado') lancheSelecionado: any = {};
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
  }

  updateData(lanches) {
    this.lanches = lanches;
  }
}
