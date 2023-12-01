import {Component, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {LoginService} from "./login.service";
import {LoginWithEmailAndPasswordRequestModel} from "./models/LoginWithEmailAndPasswordRequestModel";
import {LoginResult} from "./models/LoginResult";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  errors = [];

  loginForm = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });

  constructor(private loginService: LoginService) {
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
      next: (result) => {},
      error: (err) => this.errors = err.errors.message
    });
  }
}
