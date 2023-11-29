import {Component, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {LoginService} from "./login.service";
import {LoginWithEmailAndPasswordRequestModel} from "./models/LoginWithEmailAndPasswordRequestModel";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  loading: boolean = false;
  success: boolean = false;
  isError: boolean = false;
  errorMessage: string = "";
  notFountError: boolean = false;

  loginForm = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });

  constructor(private loginService: LoginService) {
  }
  ngOnInit(): void {
  }

  onSubmit() {
    this.loading = true;
    this.success = false;
    this.isError = false;
    this.errorMessage = "";
    // let serviceUuid = this.progressSpinnerService.showSpinner();
    this.loginService.loginWithEmailAndPassword(
      new LoginWithEmailAndPasswordRequestModel(
        <string>this.loginForm.get('userName')?.value,
        <string>this.loginForm.get('password')?.value
      )
      ).subscribe(result => {

          this.loading = false;
          this.success = true;
          // this.progressSpinnerService.closeSpinner(serviceUuid);
        },
        error => {
          // this.progressSpinnerService.closeSpinner(serviceUuid);
          this.loading = false;
          this.success = false;
          this.isError = true;
          if (error.status === 0) {
            this.errorMessage = "დაფიქსირდა ქსელური პრობლემა";
          } else if (error.status === 500) {
            this.errorMessage = "დაფიქსირდა შიდა სერვერული პრობლემა";
          } else {
            this.errorMessage = error.error;
          }
        });
  }

}
