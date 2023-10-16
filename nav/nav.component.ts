import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import {  AppointmentService  } from '../APIServices/appointment.service';


// declare const openPopup:any;
// declare const closePopup:any;

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit{

constructor(private route:Router,private activatedRoute:ActivatedRoute,private  AppointService :  AppointmentService ){
  //send UserId to AppointmentComponent
  // const UserId = this.UserId;
  // this.AppointService.setData(UserId);
}
UserId:number=0;
// get userId from login  
OnSendUserId(Id:number){
  this.UserId=Id;
  console.log(this.UserId+"  user Id in nav");
  this.AppointService.setData(this.UserId);
}
 ngOnInit(): void {
  // send UserId to AppointmentComponent
  // this.AppointService.setData(this.UserId);
 }
 
 isclicked:boolean=false;
  navigateToLogin(){
 this.isclicked=true;

   // this.route.navigate(['login'],{relativeTo:this.activatedRoute}); 
//  OR  this.route.navigateByUrl('login')
  }
  OnCloseLogin(hide:boolean){
    this.isclicked=false;

  }

  isLoggedIn = false;
 applyclass=false;
 
   WelcomeUserName:string='LOGIN';
   OnAddedUsername(User: string){
    this.isLoggedIn =true;
    this.isclicked=false;
    this.WelcomeUserName=User;
    console.log(this.WelcomeUserName+" username");
    
   }
 
}
