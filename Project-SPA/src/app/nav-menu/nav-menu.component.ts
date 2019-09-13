import { UsuarioService } from './../_services/usuario/usuario.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  constructor(private router: Router, private usuarioService: UsuarioService) { }

  ngOnInit() {
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  usuarioLogado(): boolean {
    return this.usuarioService.usuarioAutenticado();
  }

  sair() {
    this.usuarioService.limparSessao();
    this.router.navigate(['/']);
  }

}
