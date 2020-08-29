import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { StringdistanceComponent } from './stringdistance/stringdistance.component';
import { LoginComponent } from './login/login.component';
import { StringdistanceService } from './services/stringdistance.service';
import { LocalStorageService } from './localstorage';
import { AlphabetOnlyDirective } from './alphabet-only.directive';

@NgModule({
  declarations: [
    AppComponent,
    StringdistanceComponent,
    LoginComponent,
    AlphabetOnlyDirective    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [StringdistanceService, LocalStorageService],
  bootstrap: [AppComponent]
})
export class AppModule { }