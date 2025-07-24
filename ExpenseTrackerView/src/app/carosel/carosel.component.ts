import { Component } from '@angular/core';
import {  OnInit} from '@angular/core';
@Component({
  selector: 'app-carosel',
  standalone:true,
  imports: [],
  templateUrl: './carosel.component.html',
  styleUrl: './carosel.component.css'
})
export class CaroselComponent implements OnInit {
  images: string[] = [
    'https://uschamber-co.imgix.net/https%3A%2F%2Fs3.us-east-1.amazonaws.com%2Fco-assets%2Fassets%2Fimages%2Femployee_expense_apps_Twenty47studio.jpg?auto=compress%2Cformat&crop=focalpoint&fit=crop&fm=jpg&fp-x=0.4301&fp-y=0.3064&h=600&q=80&w=1200&s=56f3ff0735df2086e5de2f48d8349d40',
  ];
  currentImageIndex = 0;

  ngOnInit(): void {
  //   setInterval(() => {
  //     this.currentImageIndex =
  //       (this.currentImageIndex + 1) % this.images.length;
  //   }, 3000); // change every 3 seconds
   }
}