import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginWithEmailAndPasswordRequestModel} from "./models/LoginWithEmailAndPasswordRequestModel";
import {LoginResult} from "./models/LoginResult";
import {Observable} from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseUrl: string = 'https://localhost:7154/login';

  constructor( public httpClient: HttpClient) { }

  loginWithEmailAndPassword(request: LoginWithEmailAndPasswordRequestModel): Observable<LoginResult> {
    return this.httpClient.post <LoginResult> (this.baseUrl +'/LoginWithEmailAndPassword', request)
  }

  setSession(token: string) {

    localStorage.setItem('id_token', token);
  }

  logout() {
    localStorage.removeItem("id_token");
    localStorage.removeItem("expires_at");
  }

  public isLoggedIn(): boolean {
    // return moment().isBefore(this.getExpiration());
    return true;
  }

  isLoggedOut():boolean {
    return !this.isLoggedIn();
  }

  getExpiration() {
    const expiration = localStorage.getItem("expires_at");
    // const expiresAt = JSON.parse(expiration);
  }

}
