import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs';
import { ResultAuth } from '../_models/ResultAuth';
import { UserAuth } from '../_models/UserAuth';
import { ResultPerfil } from '../_models/ResultPerfil';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  listarPerfis(){
    const headers = new HttpHeaders({
         'Authorization': `Bearer ${this.ObterToken()}`
    });

    return this.http.get<ResultPerfil>(this.baseUrl + 'Perfil/ObterPerfis', {headers}).pipe(
      map( (response: ResultPerfil) => {
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
