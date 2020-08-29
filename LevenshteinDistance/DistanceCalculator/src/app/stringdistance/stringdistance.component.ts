import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators, FormArray } from '@angular/forms'
import { StringdistanceService } from '../services/stringdistance.service';

@Component({
  selector: 'app-stringdistance',
  templateUrl: './stringdistance.component.html',
  styleUrls: ['./stringdistance.component.scss']
})
export class StringdistanceComponent implements OnInit {

  stringDistanceForm: FormGroup;
  
  constructor(
    private formBuilder: FormBuilder,
      public stringDistanceService: StringdistanceService)
  { 
    this.stringDistanceForm = formBuilder.group({
      source: ['', [Validators.required]],
      target: ['', Validators.required]
    });
  }

  ngOnInit(): void { }

  result: string;
  error: string;
  calculateDistance(form) {
    const source = form.value.source;
    const target = form.value.target;

    this.stringDistanceService.getDistance(source, target).subscribe(data => {
      this.result = 'Levenshtein Distance: ' + data;
      //Store final result in local storage
      localStorage.setItem('distance', data.toString());
    }, error => {
      console.log(error);
      this.error = error;
  })
  }
}