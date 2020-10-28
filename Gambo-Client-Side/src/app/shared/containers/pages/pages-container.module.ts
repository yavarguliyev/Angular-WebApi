import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampaginSliderComponent } from './campagin-slider/campagin-slider.component';
import { CategoriesSliderComponent } from './categories-slider/categories-slider.component';
import { ProductsSliderComponent } from './products-slider/products-slider.component';
import { BestOffersComponent } from './best-offers/best-offers.component';



@NgModule({
  declarations: [CampaginSliderComponent, CategoriesSliderComponent, ProductsSliderComponent, BestOffersComponent],
  imports: [
    CommonModule
  ],
  exports: [
    CampaginSliderComponent,
    CategoriesSliderComponent,
    ProductsSliderComponent,
    BestOffersComponent
  ]
})
export class PagesContainerModule { }
