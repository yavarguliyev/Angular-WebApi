import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampaginSliderComponent } from './campagin-slider/campagin-slider.component';
import { CategoriesSliderComponent } from './categories-slider/categories-slider.component';
import { ProductsSliderComponent } from './products-slider/products-slider.component';
import { BestOffersComponent } from './best-offers/best-offers.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { HelperComponentsModule } from '../../components/helper/helper-components.module';

@NgModule({
  declarations: [CampaginSliderComponent, CategoriesSliderComponent, ProductsSliderComponent, BestOffersComponent],
  imports: [
    CommonModule,
    CarouselModule,
    RouterModule,
    HelperComponentsModule
  ],
  exports: [
    CampaginSliderComponent,
    CategoriesSliderComponent,
    ProductsSliderComponent,
    BestOffersComponent
  ]
})
export class PagesContainerModule { }
