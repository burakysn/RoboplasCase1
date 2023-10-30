import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { dutyModel } from 'src/app/model/duty';
import { HttpService } from 'src/app/services/http.service';
import { DutyComponent } from '../duty.component';

@Component({
  selector: 'app-add-duty',
  templateUrl: './add-duty.component.html',
  styleUrls: ['./add-duty.component.css']
})
export class AddDutyComponent {
  dutyRequest: dutyModel = new dutyModel();
  constructor(
    private _http: HttpService
  ){}


  post(): void {
    this.dutyRequest.userId = localStorage.getItem("isLogged1");
    if(this.dutyRequest.id == null){
      this._http.post(this.dutyRequest).subscribe(data => {
        window.alert("Kayıt Başarılı");
      },
      err => {
        window.alert(err);
      });
    }
    else{
      this.put()
    }
    
  }
  put(): void {
    this._http.put(this.dutyRequest).subscribe(data => {
      window.alert("Güncelleme Başarılı");
    },
    err => {
      window.alert(err.errorMesages);
    });
  }
  getById(id: any): void {
    if(id){
      this._http.getById(id).subscribe(data => {
        this.dutyRequest = data.data;
      },
      err => {
        window.alert(err.errorMesages);
      });
    }
  }

}
