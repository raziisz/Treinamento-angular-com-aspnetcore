import { Injectable } from '@angular/core';
import { HttpClient,  } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { Usuario } from '../../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  baseUrl = environment.urlApi + '/usuarios';
  private _usuario: Usuario;

  get usuario(): Usuario {
    const usuarioJson = sessionStorage.getItem('usuario-autenticado');
    this._usuario = JSON.parse(usuarioJson);
    return this._usuario;
  }

  set usuario(usuario: Usuario) {
    sessionStorage.setItem('usuario-autenticado', JSON.stringify(usuario));
    this._usuario = usuario;
  }

  public usuarioAutenticado(): boolean {
    return this._usuario != null && (this._usuario.email !== '' && this._usuario.senha !== '');
  }

  public limparSessao() {
    sessionStorage.setItem('usuario-autenticado', '');
    this._usuario = null;
  }

  constructor(private http: HttpClient) { }

  public verificarUsuario(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.baseUrl}/verificarusuario`, usuario);
  }

  cadastrarUsuario(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.baseUrl}`, usuario);
  }

}
