import { Produto } from './../models/produto';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {
  produto = new Produto();

  constructor() { }

  ngOnInit() {
    this.produto.nome = 'Feijão'
  }

}
