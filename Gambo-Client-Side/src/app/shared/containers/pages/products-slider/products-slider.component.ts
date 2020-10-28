import { IProduct } from './../../../models/product';
import { Component, Input, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-products-slider',
  templateUrl: './products-slider.component.html'
})
export class ProductsSliderComponent implements OnInit {

  public customOptions: OwlOptions = {
    items: 8,
    loop: true,
    margin: 10,
    nav: true,
    dots: false,
    navText: ["<i class=\'uil uil-angle-left\'></i>", "<i class=\'uil uil-angle-right\'></i>"],
    responsive: {
      0: {
        items: 1
      },
      600: {
        items: 2
      },
      1000: {
        items: 4
      },
      1200: {
        items: 6
      },
      1400: {
        items: 6
      }
    }
  };

  @Input() title: string;
  @Input() products: IProduct[];
  constructor() { }

  ngOnInit(): void {
  }

}
