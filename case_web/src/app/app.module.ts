import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http'
import { NavComponent } from './nav/nav.component';
import { DutyComponent } from './duty/duty.component';
import { AddDutyComponent } from './duty/add-duty/add-duty.component';
import { FormsModule } from '@angular/forms';
import { AccountService } from './services/account.service';
import { LoginGuard } from './login/login.guard';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavComponent,
    DutyComponent,
    AddDutyComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [AccountService,LoginGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
