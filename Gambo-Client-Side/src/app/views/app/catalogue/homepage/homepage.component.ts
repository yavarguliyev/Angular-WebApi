import { IProduct } from './../../../../shared/models/product';
import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/shared/services/api.service';
import { error } from 'protractor';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html'
})
export class HomepageComponent implements OnInit {

  public featuredProducts: IProduct[];
  constructor(private apiService: ApiService) { 
    this.getFeatureProducts()
  }

  ngOnInit(): void {
  }

  getFeatureProducts() : void{
    this.apiService.getFeaturedProducts(1).subscribe(
      data => {
        this.featuredProducts = data;
      },
      error => {},
      () => {}
    )
  };
}
