import { Component, ViewChild } from '@angular/core';
import { HttpService } from '../services/http.service';
import { dutyModel } from '../model/duty';
import { AddDutyComponent } from './add-duty/add-duty.component';

@Component({
  selector: 'app-duty',
  templateUrl: './duty.component.html',
  styleUrls: ['./duty.component.css']
})
export class DutyComponent {
  @ViewChild(AddDutyComponent, { static: false }) getAddDutyComponent!: AddDutyComponent;
  constructor(
    private _http: HttpService
  ) { }

  duty: dutyModel[] = [{
    title: "", description: "", lastDate: new Date(), status: false
  }]

  getId(Id: any) {
    this.getAddDutyComponent.getById(Id)
  }
  get(): void {
    this._http.get(localStorage.getItem("isLogged1")).subscribe(data => {
      if (data) {
        this.duty = data.data;
      }
    },
      err => {
        window.alert(err);
      });
  }
  delete(id: any) {
    this._http.delete(id).subscribe(data => {
      this.get();
    },
    err => {
      window.alert(err);
    });
  }
  statusUpdate(id: any) {
    this._http.statusUpdate(id).subscribe(data=>{
      window.alert("Durum Güncellendi");
      this.get();
    },
    err => {
      window.alert(err);
    });
  }
  ngOnInit() {
    this.get();
  }
}
