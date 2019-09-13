import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Usuario } from './../../models/usuario';
import { UsuarioService } from './../../_services/usuario/usuario.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
  usuario: Usuario;
  cadForm: FormGroup;
  ativarSpinner: boolean;
  constructor(private usuarioService: UsuarioService, private fb: FormBuilder) { }

  ngOnInit() {
    this.usuario = new Usuario();
    this.createForm();
  }

  createForm() {
    this.cadForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmarSenha: ['', Validators.required],
      nome: ['', Validators.required],
      sobreNome: ['', Validators.required]
    }, {validator: this.passwordMatchValidator});
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('senha').value === g.get('confirmarSenha').value ? null : {'Senha diferente': true};
  }

  cadastrar() {
    if (this.cadForm.valid) {
      this.ativarSpinner = true;
      this.usuario = Object.assign({}, this.cadForm.value);
      this.usuarioService.cadastrarUsuario(this.usuario)
        .subscribe(res => {

        }, error => {

        });
    }
  }

}
