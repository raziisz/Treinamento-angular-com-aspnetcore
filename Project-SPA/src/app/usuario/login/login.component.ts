import { UsuarioService } from './../../_services/usuario/usuario.service';
import { Usuario } from './../../models/usuario';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  usuario: Usuario;
  usuarioAutenticado: boolean;
  messageError: string;
  enderecoImage = '../../../assets/quick-logo.jpg';
  returnUrl: string;
  private ativarSpinner: boolean;

  constructor(private fb: FormBuilder, private router: Router,
     private activatedRoute: ActivatedRoute, private usuarioService: UsuarioService) {
  }

  ngOnInit() {
    this.usuario = new Usuario();
    this.returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl'];
    this.createForm();
  }

  entrar() {
    this.ativarSpinner = true;
    this.usuario = Object.assign({}, this.loginForm.value);
    this.usuarioService.verificarUsuario(this.usuario).subscribe(res => {
      this.usuarioService.usuario = res;
      if (this.returnUrl == null) {
        this.router.navigate(['/']);
      } else {
        this.router.navigate([this.returnUrl]);
      }
    }, error => {
      console.log(error.error);
      this.ativarSpinner = false;
      this.messageError = error.error;
    });
    // console.log(this.usuario);
    // if (this.usuario.email === 'leo@teste.com' && this.usuario.senha === 'abc123') {
    //   sessionStorage.setItem('usuario-autenticado', '1');
    //   this.router.navigate([this.returnUrl]);
    // }

  }

  createForm() {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', Validators.required]
    });
  }


}
