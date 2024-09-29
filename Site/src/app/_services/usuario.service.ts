import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs';
import { ResultAuth } from '../_models/ResultAuth';
import { UserAuth } from '../_models/UserAuth';
import { ResultUsuario } from '../_models/ResultUsuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  listarUsuarios(){
    const headers = new HttpHeaders({
         'Authorization': `Bearer ${this.ObterToken()}`
    });
    return this.http.get<ResultUsuario>(this.baseUrl + 'Usuario/ObterUsuarios', {headers}).pipe(
      map( (response: ResultUsuario) => {
        return response;
      })
    );
  }

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

  ObterToken() {
    const tokenString = localStorage.getItem('token-mundial');
    if(tokenString)
    {
      const tokenJson = JSON.parse(tokenString);
      return tokenJson.token
    }
    return ""
	}


}
