import { Component, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-campagin-slider',
  templateUrl: './campagin-slider.component.html'
})
export class CampaginSliderComponent implements OnInit {

  public customOptions: OwlOptions ={
    loop: true,
    margin: 30,
    nav: false,
    dots: false,
    autoplay: true,
    autoplayTimeout: 3000,
    autoplayHoverPause: true,
    responsive: {
      0: {
        items: 1
      },
      600: {
        items: 2
      },
      1000: {
        items: 3
      },
      1200: {
        items: 4
      },
      1400: {
        items: 5
      }
    }
  };
  constructor() { }

  ngOnInit(): void {
  }

}
