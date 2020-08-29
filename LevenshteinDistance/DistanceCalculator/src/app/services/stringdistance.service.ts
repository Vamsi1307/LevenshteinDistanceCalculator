import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { LocalStorageService } from '../localstorage';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StringdistanceService {

  constructor(
    private httpClient : HttpClient,
      public localStorage: LocalStorageService) { }

  public authToken: any;

  login(requestBody): Observable<any> {
    var httpHeaders = new HttpHeaders({
          'Content-Type': 'application/json'      
        });
    const url = 'https://localhost:44313/api/Login';

    return this.httpClient.post<any>(url, requestBody, { headers: httpHeaders })
                          .pipe(catchError(this.handleLoginError))
  }

  handleLoginError(error){
    //Throw some generic error for demo. In reality, we display customized error based on Http Response
    return throwError("Login was unsuccessful. Please try again.")
  }

  token: string;

  getDistance(sourceValue, targetValue): Observable<any> {
    this.token = localStorage.getItem("token");
    let httpHeaders = new HttpHeaders({
      'content-type': 'application/json',
      'Authorization': 'Bearer ' + this.token
    });    
    const httpParams = new HttpParams({
      fromObject: {
        source : sourceValue,
        target: targetValue
      }
    });
    const url = 'https://localhost:44313/api/Calculator';

    return this.httpClient.get<any>(url, {headers: httpHeaders, params: httpParams })
                          .pipe(catchError(this.handleCalcError))
  }

  handleCalcError(error){
    //Throw some generic error for demo. In reality, we display customized error based on Http Response
    return throwError("There is a problem. Please try to sign in again.");
  }
}
