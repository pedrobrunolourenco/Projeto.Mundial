import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UsuarioService } from '../../_services/usuario.service';
import { ResultAuth } from '../../_models/ResultAuth';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {


   constructor(private toastr: ToastrService,
               private usuarioService: UsuarioService
   ) { }

  login: string = '';
  senha: string = '';

  ngOnInit(): void {
     localStorage.removeItem("user");
  }

  onSubmit() {
    this.Autenticar(this.login, this.senha);
  }

  Autenticar(login: string, senha: string){
    if(this.login.length == 0 || this.senha.length == 0){
      this.toastr.error("O obrigatório informar Usuario e Senha");
    }
    else
    {
      this.usuarioService.getToken(login,senha).subscribe((response: ResultAuth) => {
        if(response.sucesso == true){
          this.toastr.success("Usuário autenticado com sucesso!" );
        }
        if(response.sucesso == false){
          this.toastr.error(response.mensagens[0]);
        }
       }, (erro) => {
          this.toastr.error("Erro ao autenticar usuário");
       });
    }
  }
}




