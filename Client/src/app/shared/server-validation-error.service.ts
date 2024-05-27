import { Injectable } from '@angular/core';
import {AbstractControl, FormGroup} from "@angular/forms";
import {HttpErrorResponse} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ServerValidationErrorService {

  constructor() { }

  renderServerErrors(form: FormGroup, response: HttpErrorResponse) {
    let serverErrors = response.error.errors;
    for (let key in serverErrors) {
      let control = form.get(key.toLowerCase());
      if (control) {
        control.setErrors({serverError: serverErrors[key]});
      }
    }
  }

}
