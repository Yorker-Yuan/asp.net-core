import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from "./user/login/login.component";
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { ForbiddenPanelComponent } from './forbidden-panel/forbidden-panel.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';

const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},
  {
    path:'user',component: UserComponent,
    children:[
      {path:'registration',component: RegistrationComponent},
      {path:'login',component: LoginComponent }
    ]
  },
  {path:'home',component:HomeComponent,canActivate: [AuthGuard]},
  {path:'forbidden',component:ForbiddenPanelComponent},
  {path:'adminpanel',component:AdminPanelComponent,canActivate: [AuthGuard],data : {permittedRoles: ['Admin']}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
