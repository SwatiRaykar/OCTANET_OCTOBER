import { Component, EventEmitter, Output } from '@angular/core';
import { FormGroup,Validators,FormBuilder, FormControl, } from '@angular/forms';
import ValidateForm from '../helpers/validateform';
import { AuthService } from '../APIServices/auth.service';
import { outputAst } from '@angular/compiler';
import { AppointmentService } from '../APIServices/appointment.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  Isclicked:boolean=false;
 
  openLogin(){
    this.Isclicked=true;
    return this.Isclicked;
  }


  passType:string='password';
  eyeIcon:string='fa-eye-slash'
  hideShowPass(){
    if(this.passType==='password'){
      this.passType='text';
     this.eyeIcon='fa-eye';
    }else{
      this.passType='password';
      this.eyeIcon='fa-eye-slash';

    }
  }

@Output() ClosedLogin=new EventEmitter<boolean>();
Closelogin:boolean=false;
  Oncloselog(){
    this.ClosedLogin.emit(true);
    //this.Closelogin=true;
  }

 
  //from Validation
loginForm!:FormGroup;//declare formgroup
constructor(private fb:FormBuilder,private auth:AuthService,private appointService: AppointmentService){} //inject form builder
 
ngOnInit():void{
  this.loginForm=this.fb.group({
    EmailId:['',Validators.required],
    Password:['',Validators.required]
  });
}

@Output()
WelcomeUser=new EventEmitter<string>();
UserName:string='';

@Output()
CustomerId=new EventEmitter<number>();
 UserId:number=0;

  onLogin()
  {
    if(this.loginForm.valid){
      console.log(this.loginForm.value)
      //send the object to db
      this.auth.login(this.loginForm.value)
       .subscribe({
        next:(res)=>{
          console.log(res.data.name);
          alert(res.data.name+" login successful")

          // alert('Loging Success')
             if(res.data.name!=null && res.data.name!=undefined){
              
                this.WelcomeUser.emit(res.data.name);

                this.CustomerId.emit(res.data.customerId);
             }
            //  send data to appointment component
          //  this.appointService.setData(res.data.name);
            
        },
        error:(err)=>{
          alert(err?.error.message)
        }
       })

    }else{
      console.log('form is not valid');
      console.log(this.loginForm)
      ValidateForm.validateAllFormFields(this.loginForm);
      alert('Invalid Username or Password ')
      //throw error using toaster and with required field
    }
  }

  
}
