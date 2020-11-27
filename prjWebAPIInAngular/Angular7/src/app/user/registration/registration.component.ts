import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService, private toastr:ToastrService) { }

  ngOnInit(){
  }
  onSubmit(){
    this.service.register().subscribe(
      (res: any) =>{
        if(res.succeeded){
          this.service.formModel.reset();
          this.toastr.success('使用者已新增','註冊成功')
        }else{
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('用戶名已存在','註冊失敗')
                //UserName is already taken
                break;
            
              default:
                this.toastr.error(element.description,'註冊失敗')
                //Registration failed
                break;
            }
          });
        }
      },
      err=>{
        console.log(err);
      }
    );
  }
}
