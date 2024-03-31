import {Component, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {LoginService} from "./login.service";
import {LoginWithEmailAndPasswordRequestModel} from "./models/LoginWithEmailAndPasswordRequestModel";
import {LoginResult} from "./models/LoginResult";
import {ServerValidationErrorService} from "../shared/server-validation-error.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  serverErrors = {};

  loginForm = new FormGroup({
    userName: new FormControl('', [
      Validators.required,
      Validators.minLength(2)]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(2)])
  });

  constructor(private loginService: LoginService,
              private serverValidationErrorService: ServerValidationErrorService) {
  }

  ngOnInit(): void {
  }

  onSubmit() {
    this.loginService.loginWithEmailAndPassword(
      new LoginWithEmailAndPasswordRequestModel(
        <string>this.loginForm.get('userName')?.value,
        <string>this.loginForm.get('password')?.value
      )
    ).subscribe({
      next: (result: LoginResult) => this.onSubmitSuccess(result),
      error: (err: HttpErrorResponse) => this.onSubmitError(err)
    });
  }

  protected onSubmitSuccess(response: LoginResult) {
    this.loginService.setToken(response.token);

    // this.navigatorService.home();
  }

  protected onSubmitError(error: HttpErrorResponse) {
    const errors = { };
    for (const key in error.error.errors) {
      if (Object.prototype.hasOwnProperty.call(error.error.errors, key)){
        errors[key] = error.error.errors[key];
      }
    }
    this.serverValidationErrorService.renderServerErrors(this.loginForm, response);
  }
}
