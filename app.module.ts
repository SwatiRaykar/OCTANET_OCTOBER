import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule,Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ContainerComponent } from './container/container.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { ServicesComponent } from './services/services.component';
import { CardsComponent } from './cards/cards.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { LoginComponent } from './login/login.component';
import { ErrorComponent } from './error/error.component';
import { HttpClientModule } from '@angular/common/http';
import { FooterComponent } from './footer/footer.component';
import { ForgotPWDComponent } from './forgot-pwd/forgot-pwd.component';
import { ResetPWDComponent } from './reset-pwd/reset-pwd.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { GallaryComponent } from './gallary/gallary.component';
import { GalleryLightboxComponent } from './gallery-lightbox/gallery-lightbox.component';
import { PricesComponent } from './prices/prices.component';
import { ContactUsComponent } from './contact-us/contact-us.component';

const appRoute:Routes=[  
  // {path:'',component:HomeComponent},
  //{path:'',redirectTo:'container',pathMatch:'full'},
  {path:'',redirectTo:'home',pathMatch:'full'},
  {path:'container',component:ContainerComponent},
 {path:'reset-pwd',component:ResetPWDComponent},
  {path:'sign-up',component:SignUpComponent},
  // {path:'login',component:LoginComponent},
  {path:'forgot-pwd',component:ForgotPWDComponent},
  {path:'home',component:HomeComponent},
  {path:'contact-us',component:ContactUsComponent},
  {path:'prices',component:PricesComponent},
  {path:'services',component:ServicesComponent},
  {path:'gallery',component:GalleryLightboxComponent},
  {path:'Appointments',component:AppointmentsComponent},
  
  {path:'**',component:ErrorComponent}
];
@NgModule({
  declarations: [
    AppComponent,
    ContainerComponent,
    NavComponent,
    HomeComponent,
    ServicesComponent,
    CardsComponent,
    SignUpComponent,
    LoginComponent,
    ErrorComponent,
    FooterComponent,
    ForgotPWDComponent,
    ResetPWDComponent,
    AppointmentsComponent,
    GallaryComponent,
    GalleryLightboxComponent,
    PricesComponent,
    ContactUsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        RouterModule.forRoot(appRoute)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
