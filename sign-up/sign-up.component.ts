import { Component } from '@angular/core';
import { FormGroup,Validators,FormBuilder, FormControl, } from '@angular/forms';
import ValidateForm from '../helpers/validateform';
import { AuthService } from '../APIServices/auth.service';


@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent {
  Isclicked1:boolean=false;
 
  
 
  closedSignup:boolean=false;
  closeSignup(){
    this.closedSignup=true;
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
   signUpForm!:FormGroup;//declare formgroup
constructor(private fb:FormBuilder,private auth:AuthService){} //inject form builder
 
ngOnInit():void{
  this.signUpForm=this.fb.group({
    FirstName:['',Validators.required],
    lastname:['',Validators.required],
    EmailId:['',Validators.required],
    password:['',Validators.required],
    PhoneNumber:['',Validators.required]
  })
}

  onSignup(){
    if(this.signUpForm.valid){
      console.log(this.signUpForm.value)
      //send the object to db
    this.auth.signUp(this.signUpForm.value)
    .subscribe({
      next:(res=>{  
        console.log(res)
        alert(res.data)
        this.signUpForm.reset();
      })
      ,error:(err=>{
        alert(err?.error.message)
      })
    })
   
  
console.log(this.signUpForm.value)
    }else{
      console.log('form is not valid');
      console.log(this.signUpForm)
      ValidateForm.validateAllFormFields(this.signUpForm);
      alert('Invlid Signup Form ')
      //throw error using toaster and with required field
    }
  }

  


 
}
