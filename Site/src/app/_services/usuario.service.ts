import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';
import { ResultAuth } from '../_models/ResultAuth';
import { UserAuth } from '../_models/UserAuth';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getToken(usuario: string, senha: string){

    localStorage.removeItem('token-mundial');

    const user: UserAuth = {
      usuario: usuario,
      senha: senha
    };

    return this.http.post<ResultAuth>(this.baseUrl + 'Usuario/Autenticar',user).pipe(
      map( (response: ResultAuth) => {
        if(response && response.sucesso) localStorage.setItem('token-mundial', JSON.stringify(response.data))
        return response;
      })
    );
  }

  // const dado = localStorage.getItem('meuDado');

}
