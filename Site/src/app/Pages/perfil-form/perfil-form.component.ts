import { Component } from '@angular/core';

@Component({
  selector: 'app-perfil-form',
  templateUrl: './perfil-form.component.html',
  styleUrl: './perfil-form.component.css'
})
export class PerfilFormComponent {

  perfil = {
    idPerfil: null,
    nome: ''
  };

  gravarPerfil() {

  }

}
