import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DutyComponent } from './duty/duty.component';
import { LoginComponent } from './login/login.component';
import { LoginGuard } from './login/login.guard';

const routes: Routes = [
  { path: 'duty', component: DutyComponent, canActivate:[LoginGuard] },
  { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
