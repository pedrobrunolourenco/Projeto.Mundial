import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../_services/usuario.service';
import { ToastrService } from 'ngx-toastr';
import { ResultUsuario } from '../../_models/ResultUsuario';

@Component({
  selector: 'app-usuario-list',
  templateUrl: './usuario-list.component.html',
  styleUrl: './usuario-list.component.css'
})
export class UsuarioListComponent implements OnInit {

  constructor(private usuarioService: UsuarioService,
              private toastr: ToastrService) {}

  usuarios: any;

  ngOnInit(): void {
    this.usuarioService.listarUsuarios().subscribe((response: ResultUsuario) => {
      if(response.sucesso == true){
        this.usuarios = response.data;
      }
     }, (erro) => {
        this.toastr.error("Erro ao listar Usuários");
     });
  }


}
