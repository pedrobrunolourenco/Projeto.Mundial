import { Component, OnInit } from '@angular/core';
import { PerfilService } from '../../_services/perfil.servce';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UsuarioService } from '../../_services/usuario.service';
import { UsuarioRequest } from '../../_models/UsuarioRequest';
import { ResultPerfil } from '../../_models/ResultPerfil';
import { ResultUsuario } from '../../_models/ResultUsuario';

@Component({
  selector: 'app-usuario-form',
  templateUrl: './usuario-form.component.html',
  styleUrl: './usuario-form.component.css'
})
export class UsuarioFormComponent implements OnInit  {

  constructor(private perfilService: PerfilService,
              private usuarioService: UsuarioService,
              private toastr: ToastrService,
              private router: Router){}

  perfis : any;

  usuario: UsuarioRequest = {
    id:0,
    idPerfil: 0,
    nome: '',
    email: '',
    senha: ''
  };

  ngOnInit(): void {
     this.carregarPerfis();
  }

  carregarPerfis(){
    this.perfilService.listarPerfis().subscribe((response: ResultPerfil) => {
      if(response.sucesso == true){
        this.perfis = response.data;
      }
     }, (erro) => {
        this.toastr.error("Erro ao listar Perfis");
     });
  }

  gravarUsuario() {
    this.usuarioService.gravarUsuario(this.usuario).subscribe((response: ResultUsuario) => {
      if(response.sucesso == true){
        this.toastr.success("Usuário gravado com sucesso!" );
        this.router.navigate(['/usuario/list']);
      }
      if(response.sucesso == false){
        response.mensagens.forEach(mensagem => {
          this.toastr.error(mensagem);
        });
      }
     }, (erro) => {
        this.toastr.error("Erro ao gravar usuário");
     });
  }


}
