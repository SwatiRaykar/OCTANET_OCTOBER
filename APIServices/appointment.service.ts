import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor() { }

  // private sharedData:any;
 
  Sdata:number=0;
  setData(data:number) {
    // this.sharedData = data;
    this.Sdata= data;
    console.log("data set successfully:"+this.Sdata)
  }

  getData() {
    console.log("data get successfully:"+this.Sdata)
    return this.Sdata;

  }
}
