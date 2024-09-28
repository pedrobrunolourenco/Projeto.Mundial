import { Component } from '@angular/core';
import { PerfilRequest } from '../../_models/PerfilRequest';
import { PerfilService } from '../../_services/perfil.servce';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ResultPerfil } from '../../_models/ResultPerfil';

@Component({
  selector: 'app-perfil-form',
  templateUrl: './perfil-form.component.html',
  styleUrl: './perfil-form.component.css'
})
export class PerfilFormComponent {

  constructor(private perfilService: PerfilService,
              private toastr: ToastrService,
              private router: Router
  ) {
  }

  perfil: PerfilRequest = {
    idPerfil: 0,
    nome: ''
  };

  gravarPerfil() {
     console.log(this.perfil);
     this.perfilService.gravarPerfil(this.perfil).subscribe((response: ResultPerfil) => {
      if(response.sucesso == true){
        this.toastr.success("Usuário gravado com sucesso!" );
        this.router.navigate(['/perfil/list']);
      }
      if(response.sucesso == false){
        response.mensagens.forEach(mensagem => {
          this.toastr.error(mensagem);
        });
      }
     }, (erro) => {
        this.toastr.error("Erro ao autenticar usuário");
     });
  }

}
