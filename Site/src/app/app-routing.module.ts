import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './Pages/login/login.component';
import { AuthGuard } from './auth.guard';
import { PerfilListComponent } from './Pages/perfil-list/perfil-list.component';
import { PerfilFormComponent } from './Pages/perfil-form/perfil-form.component';
import { UsuarioListComponent } from './Pages/usuario-list/usuario-list.component';
import { UsuarioFormComponent } from './Pages/usuario-form/usuario-form.component';


const routes: Routes = [
  {path: '', component: LoginComponent },
  {path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  {path: 'perfil/list', component: PerfilListComponent, canActivate: [AuthGuard] },
  {path: 'perfil/novo', component: PerfilFormComponent, canActivate: [AuthGuard] },
  {path: 'usuario/list', component: UsuarioListComponent, canActivate: [AuthGuard] },
  {path: 'usuario/novo', component: UsuarioFormComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
