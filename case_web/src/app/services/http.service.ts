import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from'@angular/common/http'
import { dutyModel } from '../model/duty';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  api: string = environment.api;
  constructor(
    private _http: HttpClient
  ) { }
  
   post(dt: dutyModel): Observable<any> {
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem("isLogged")}`
     });
    return this._http.post<any>(`${this.api}/Duty/Save`, dt, { headers: headers });
  }
  put(dt: any): Observable<any> {
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem("isLogged")}`
     });
    return this._http.put<any>(`${this.api}/Duty/Put`, dt, { headers: headers });
  }
  get(userId: any): Observable<any>{
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem("isLogged")}`
     });
    return this._http.get<any>(`${this.api}/Duty/GetByUserId/${userId}`, { headers: headers });
  }
  getById(id?: number): Observable<any>{
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem("isLogged")}`
     });
    return this._http.get<any>(`${this.api}/Duty/${id}`, { headers: headers });
  }
  delete(id?: number): Observable<any>{
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem("isLogged")}`
     });
    return this._http.delete<any>(`${this.api}/Duty/${id}`, { headers: headers });
  }
  statusUpdate(id: any): Observable<any> {
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem("isLogged")}`
     });
    return this._http.put<any>(`${this.api}/Duty/UpdateStatus?id=${id}`, "", { headers: headers });
  }
  logIn(userName:string, password:string): Observable<any>{
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem("isLogged")}`
     });
    return this._http.get<any>(`${this.api}/Authentication/logIn?userName=${userName}&password=${password}`, { headers: headers });
  }
  signUp(user: any): Observable<any>{
    const headers = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem("isLogged")}`
     });
    return this._http.post<any>(`${this.api}/Authentication`, user, { headers: headers });
  }
  
}