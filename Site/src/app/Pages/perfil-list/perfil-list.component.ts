import { Component, OnInit } from '@angular/core';
import { PerfilService } from '../../_services/perfil.servce';
import { ResultPerfil } from '../../_models/ResultPerfil';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-perfil-list',
  templateUrl: './perfil-list.component.html',
  styleUrl: './perfil-list.component.css'
})
export class PerfilListComponent implements OnInit {


  constructor(private perfilService: PerfilService,
              private toastr: ToastrService) {}

  perfis : any;

  ngOnInit(): void {
    this.perfilService.listarPerfis().subscribe((response: ResultPerfil) => {
      if(response.sucesso == true){
        this.perfis = response.data;
        console.log(this.perfis);
      }
     }, (erro) => {
        this.toastr.error("Erro ao listar Perfis");
     });
  }

}
