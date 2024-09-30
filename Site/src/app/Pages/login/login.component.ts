import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UsuarioService } from '../../_services/usuario.service';
import { ResultAuth } from '../../_models/ResultAuth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {


   constructor(private toastr: ToastrService,
               private usuarioService: UsuarioService,
               private router: Router
   ) { }

  usuario: string = '';
  senha: string = '';

  ngOnInit(): void {
     localStorage.removeItem("token-mundial");
  }

  onSubmit() {
    this.Autenticar(this.usuario, this.senha);
  }

  Autenticar(usuario: string, senha: string){
    if(usuario.length == 0 || senha.length == 0){
      this.toastr.error("O obrigatório informar Usuario e Senha");
    }
    else
    {
      this.usuarioService.getToken(usuario,senha).subscribe((response: ResultAuth) => {
        if(response.sucesso == true){
          this.toastr.success("Usuário autenticado com sucesso!" );
          this.router.navigate(['home']);
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




