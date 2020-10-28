import { ICategory } from './../../../models/category';
import { Component, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { ApiService } from 'src/app/shared/services/api.service';

@Component({
  selector: 'app-categories-slider',
  templateUrl: './categories-slider.component.html'
})
export class CategoriesSliderComponent implements OnInit {

  public customOptions: OwlOptions = {
    loop: true,
    margin: 30,
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
  public categories: ICategory[];

  constructor(private apiService: ApiService) {
    this.getCategories();
  }

  ngOnInit(): void {
  }

  getCategories() {
    this.apiService.getCategories().subscribe(
      data => {
        this.categories = data;
      },
      error => { },
      () => { }
    )
  };
}
