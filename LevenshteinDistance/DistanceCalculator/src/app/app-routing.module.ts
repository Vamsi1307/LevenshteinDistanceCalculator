import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StringdistanceComponent } from './stringdistance/stringdistance.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path:'', redirectTo:'login', pathMatch:'full' },
  { path: 'login', component: LoginComponent },
  { path: 'stringdistance', component: StringdistanceComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }