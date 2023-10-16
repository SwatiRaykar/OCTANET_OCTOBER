import { Component } from '@angular/core';
import ValidateForm from '../helpers/validateform';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../APIServices/auth.service';

@Component({
  selector: 'app-reset-pwd',
  templateUrl: './reset-pwd.component.html',
  styleUrls: ['./reset-pwd.component.css']
})
export class ResetPWDComponent {
  Isclicked1:boolean=false;
 
  
 
  closedResetPwd:boolean=false;
  closeResetPWD(){
    this.closedResetPwd=true;
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

   //from Validation
   resetPwdForm!:FormGroup;//declare formgroup
constructor(private fb:FormBuilder,private auth:AuthService){} //inject form builder
 
ngOnInit():void{
  this.resetPwdForm=this.fb.group({
    Token:['',Validators.required],
    EmailId:['',Validators.required],
    Newpassword:['',Validators.required]
    // confirmpassword:['',Validators.required]
  })
}

  onResetPWD(){
    if(this.resetPwdForm.valid){
      console.log(this.resetPwdForm.value)
      //send the object to db
    this.auth.ResetPwD(this.resetPwdForm.value)
    .subscribe({
      next:(res=>{  
        console.log(res)
        alert(res.data)
        this.resetPwdForm.reset();
      })
      ,error:(err=>{
        alert(err?.error.message)
      })
    })
   
  
console.log(this.resetPwdForm.value)
    }else{
      console.log('form is not valid');
      console.log(this.resetPwdForm)
      ValidateForm.validateAllFormFields(this.resetPwdForm);
      alert('Invlid Signup Form ')
      //throw error using toaster and with required field
    }
  }

  
}
