import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators, FormArray } from '@angular/forms'
import { StringdistanceService } from '../services/stringdistance.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
      private router: Router,
        public stringDistanceService: StringdistanceService) 
  { 
    this.loginForm = formBuilder.group({
      userName: ['', [Validators.required]],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void { }

  error: string;
  
  login(form) {
    const userName = form.value.userName;
    const password = form.value.password;
    const requestBody = { UserName: form.value.userName, Password: form.value.password };

    this.stringDistanceService.login(requestBody).subscribe(data => {
        localStorage.setItem('token', data.token);
        //Redirect to Calculator page, if login is successful
        this.router.navigate(['/stringdistance']);
    }, error => {
      console.log(error);
      this.error = error;
    })
  }
}