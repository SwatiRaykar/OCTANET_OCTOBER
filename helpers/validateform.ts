import { FormBuilder, FormGroup } from "@angular/forms";
//Commamn data from signup.ts and login.ts
export default class ValidateForm{
    static validateAllFormFields(formGroup:FormGroup){
        Object.keys(formGroup.controls).forEach(field=>{
         const control= formGroup.get(field);
         if(control instanceof FormBuilder){
           control.markAsDirty({onlySelf:true});
         }
         else if(control instanceof FormGroup){
           this.validateAllFormFields(control)
         }
        })
       }
}