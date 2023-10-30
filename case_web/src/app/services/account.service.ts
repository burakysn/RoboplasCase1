import { Injectable } from '@angular/core';
import { User } from '../model/user';
import { HttpService } from './http.service';

@Injectable()
export class AccountService {

  constructor(
    private _http: HttpService
  ) { }

  loggedIn = false;

  login(user: User): void {
    this._http.logIn(user.userName, user.password).subscribe(data => {
      console.log("data",data)
      if (data != null) {
        this.loggedIn = true;
        localStorage.setItem("isLogged",data.data.token);
        localStorage.setItem("isLogged1",data.data.id);
      }
    });
  }

  singUp(user: User): void {
    this._http.signUp(user).subscribe(data => {
    });
  }

  isLoggedIn(){
    return this.loggedIn;
  }

  logOut(){
    localStorage.removeItem("isLogged");
  }
}
