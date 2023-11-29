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
}
