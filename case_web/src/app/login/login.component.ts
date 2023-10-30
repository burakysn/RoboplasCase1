import { Component } from '@angular/core';
import { AccountService } from '../services/account.service';
import { User } from '../model/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
model:User = new User;
signUpModel: User = new User;
constructor(
  private accountServices : AccountService
){}

ngOnInit(){}

login(){
  this.accountServices.login(this.model)
}

singUp(){
  this.accountServices.singUp(this.signUpModel)
}
}
