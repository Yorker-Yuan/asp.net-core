import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {

formModel = {
  UserName : '',
  Password : ''
}

  constructor(private service: UserService,private router: Router,private toastr: ToastrService) { }

  ngOnInit(){
    //若是已登入狀態則返回主頁
    if(localStorage.getItem('token') != null)
    this.router.navigateByUrl('/home');
  }

  onSubmit(form: NgForm){
    this.service.login(form.value).subscribe(
      (res: any)=>{
        localStorage.setItem('token',res.token);
        this.router.navigateByUrl('/home');
      },
      err=>{
        if(err.status == 400)
          this.toastr.error('使用者名稱或密碼錯誤','Authentication failed');
          else
          console.log(err);
      }
    );
  }
}
