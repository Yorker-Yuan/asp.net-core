import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHandler, HttpHeaders } from "@angular/common/http";

@Injectable({
     providedIn: 'root'
    })
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
readonly BaseURI = "http://localhost:49821/api";

  formModel = this.fb.group({
    UserName: ['',Validators.required],
    Email: ['',Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required,Validators.minLength(4)]],
      ConfirmPassword: ['',Validators.required]
    },{ validator : this.comparePasswords})
  });

  comparePasswords(fb: FormGroup){
    let ConfirmPsdCtrl = fb.get('ConfirmPassword');
    //passwordMismatch
    //confirmPsdCtrl.errors=(passwordMismatch:true)
    if (ConfirmPsdCtrl.errors == null || 'passwordMismatch' in ConfirmPsdCtrl.errors){
      if (fb.get('Password').value != ConfirmPsdCtrl.value) 
      {
        ConfirmPsdCtrl.setErrors({ passwordMismatch:true });
      }
      else
      {
        ConfirmPsdCtrl.setErrors(null);
      }
    }
  }

  register(){
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI+'/ApplicationUser/Register',body);
  }

  login(formData) {
    return this.http.post(this.BaseURI + '/ApplicationUser/Login', formData);
  }

  getUserProfile() {
    return this.http.get(this.BaseURI + '/UserProfile');
  }
}
