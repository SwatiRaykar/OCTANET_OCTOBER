import {animate, 
  style,
   transition,
    trigger,
    AnimationEvent
   } from '@angular/animations';
import { Component, Input } from '@angular/core';


interface Item{
  imagesSrc:string;
  imageAlt:string;
}
@Component({
  selector: 'app-gallary',
  templateUrl: './gallary.component.html',
  styleUrls: ['./gallary.component.css']
  // animations:[
  //   trigger('animation',[
  //     transition('void=>visible',[ 
  //     style({Transform:'scale(0.5)'}),
  //     animate('150ms',style({transform:'scale(1)'}))
  //   ]),
  //   transition('visible=>void',[
  //     style({Transform:'scale(1)'}),
  //     animate('150ms',style({transform:'scale(0.5)'}))
  //   ]),
  // ]),
  // trigger('animation2 ',[
  //   transition(':leave',[
  //     style({opacity:1}),
  //     animate('5000 ms',style({opacity:0.8}))
  //   ])
  // ])
  // ]
})
export class GallaryComponent {
@Input() galleryData:Item[]=[];
@Input() showCount=false;

previewImage=false;
showMask=false;
currentLightboxImage:Item=this.galleryData[0];
currentIndex=0;
controls=true;
totalImageCount=0;

constructor(){}
ngOnInit():void{
  this.totalImageCount=this.galleryData.length;

}
onPreviewImage(index:number):void{
  //shows images
  this.showMask=true;
  this.previewImage=true;
  this.currentIndex=index;
  this.currentLightboxImage=this.galleryData[index]; 
}

// onAnimationEnd(event:AnimationEvent){
//   if(event.toState==='void'){
//     this.showMask=false;
//   }
// }

onClosePreview(){
  this.previewImage=false;
  this.showMask=false;

}

next():void{
this.currentIndex=this.currentIndex+1;
if(this.currentIndex>this.galleryData.length-1){
  this.currentIndex=0;
}
this.currentLightboxImage=this.galleryData[this.currentIndex];
}


prev():void{
  this.currentIndex=this.currentIndex-1;
  if(this.currentIndex<0){
    this.currentIndex=this.galleryData.length-1;

  }
  this.currentLightboxImage=this.galleryData[this.currentIndex];
}
}
