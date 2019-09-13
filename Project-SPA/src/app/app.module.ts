import { UsuarioService } from './_services/usuario/usuario.service';
import { LoginComponent } from './usuario/login/login.component';
import { CadastroComponent } from './usuario/cadastro/cadastro.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ProdutoComponent } from './produto/produto.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';

@NgModule({
   declarations: [
      AppComponent,
      NavMenuComponent,
      ProdutoComponent,
      HomeComponent,
      CadastroComponent,
      LoginComponent
   ],
   imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      ReactiveFormsModule,
      RouterModule.forRoot([
         {path: '', component: HomeComponent, pathMatch: 'full'},
         {path: 'produtos', component: ProdutoComponent, canActivate: [AuthGuard]},
         {path: 'login', component: LoginComponent},
         {path: 'cadastro', component: CadastroComponent}
      ])
   ],
   providers: [
      AuthGuard,
      UsuarioService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
