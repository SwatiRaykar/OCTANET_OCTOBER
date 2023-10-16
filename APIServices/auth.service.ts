import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
// import { Http,Response } from '@agular/http';
// import { Observable } from 'rxjs/Observable';
// import 'rxjs/add/operator/map';
// import 'rxjs/add/operator/catch';
// import 'rxjs/add/operator/throw';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
private baseUrl:string="https://localhost:44311/api/Customer/"
//private baseUrl:string="https://localhost:44311/api/Customer/"


  constructor(private http:HttpClient) {} 

  signUp(userObj:any){
return this.http.post<any>(`${this.baseUrl}RegisterCustomer`,userObj)

// .map((response:Response)=>response.json()).catch(this.errorHandler);

  }
  login(loginObj:any){
    return this.http.post<any>(`${this.baseUrl}CustomerLogin`,loginObj)
  }

  ForgotPwD(forgotObj:any){
    return this.http.post<any>(`${this.baseUrl}ForgotPassword`,forgotObj)
  }

  ResetPwD(ResetObj:any){
    return this.http.post<any>(`${this.baseUrl}ResetPassword`,ResetObj)
  }

  BookAppointment(AppObj:any){
    return this.http.post<any>(`${this.baseUrl}BookAppointment`,AppObj)
  }
  ContactUs(AppObj:any){
    return this.http.post<any>(`${this.baseUrl}ContactUs`,AppObj)
  }

}


