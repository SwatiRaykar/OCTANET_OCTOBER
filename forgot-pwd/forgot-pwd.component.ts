import { Component } from '@angular/core';
import ValidateForm from '../helpers/validateform';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../APIServices/auth.service';

@Component({
  selector: 'app-forgot-pwd',
  templateUrl: './forgot-pwd.component.html',
  styleUrls: ['./forgot-pwd.component.css']
})
export class ForgotPWDComponent {

  Isclicked:boolean=false;
 
  openLogin(){
    this.Isclicked=true;
    return this.Isclicked;
  }

  Closelogin:boolean=false;
  Fclose(){
    this.Closelogin=true;
  }

   //from Validation
ForgotPWDForm!:FormGroup;//declare formgroup
constructor(private fb:FormBuilder,private auth:AuthService){} //inject form builder
 
ngOnInit():void{
  this.ForgotPWDForm=this.fb.group({
    EmailId:['',Validators.required],
  });
}

onForgotPWD()
  {
    if(this.ForgotPWDForm.valid){
      console.log(this.ForgotPWDForm.value)
      //send the object to db
      this.auth.ForgotPwD(this.ForgotPWDForm.value)
       .subscribe({
        next:(res)=>{
          console.log(res);
          alert(res.data)
          // alert('Loging Success')

        },
        error:(err)=>{
          alert(err?.error.message)
        }
       })

    }else{
      console.log('form is not valid');
      console.log(this.ForgotPWDForm)
      ValidateForm.validateAllFormFields(this.ForgotPWDForm);
      alert('please enter valid email ')
      //throw error using toaster and with required field
    }
  }

}
