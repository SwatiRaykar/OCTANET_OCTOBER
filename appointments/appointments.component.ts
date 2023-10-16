import { Component,Input } from '@angular/core';
import ValidateForm from '../helpers/validateform';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../APIServices/auth.service';
import { AppointmentService } from '../APIServices/appointment.service';

interface Option {
  label: string;
  value: any;
}


@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent {
  Isclicked1:boolean=false;

//Checkboxes
SalonServicesArray:string[]=['Haircut','Waxing','Threading','Make-up','Nail treatments','Tanning','massage',' Facials and skin care treatments.','Complementary care such as aromatherapy','Other']

//Recieve userId
 UserId:number;


  
   //from Validation
   appointmentForm!:FormGroup;//declare formgroup
constructor(private fb:FormBuilder,private auth:AuthService,private appointService: AppointmentService){
  this.UserId = this.appointService.getData();
    console.log(this.UserId+" UserId from Appointment Component");
} //inject form builder

ngOnInit():void{
  this.appointmentForm=this.fb.group({
    Name:['',Validators.required],
    Address:['',Validators.required],
    EmailId:['',Validators.required],
    PhoneNumber:['',Validators.required],
    Date:['',Validators.required],
    Services:this.fb.array([])
  })
  
}
// services Checkbox method
objectAsString: string='';
onChange(e:any){
  const checkedValue=e.target.value;
  const checked=e.target.checked;
console.log(checkedValue,checked);
const checkedArray=this.appointmentForm.get('Services') as FormArray;
if(checked){
  checkedArray.push(new FormControl(checkedValue));
  
}
else{
  let i:number=0;
  checkedArray.controls.forEach((item)=>{
    if(item.value==checkedValue){
      checkedArray.removeAt(i);
    }
    i++;
  });
}
}
onAppointmSubmit(){
  //first check if user has loged in or not
 // if(this.UserId!==0 && this.UserId!==undefined){
    
    if(this.appointmentForm.valid){
      console.log(this.appointmentForm.value)
      //send the object to db
      this.auth.BookAppointment(this.appointmentForm.value)
     .subscribe({
           next:(res=>{  
           console.log(res)
           alert(res.data)
           console.log(this.UserId+" UserId from Appointment Component");
           this.appointmentForm.reset();
          })
        ,error:(err=>{
         alert(err?.error.message)
        })
      })
      console.log(this.appointmentForm.value)
    }else{
      console.log('form is not valid');
      console.log(this.appointmentForm)
      ValidateForm.validateAllFormFields(this.appointmentForm);
      alert('Invlid Signup Form ')
      //throw error using toaster and with required field
    }
 // }
  // else{
  //   alert('Please login first');
  // }
 }
}
