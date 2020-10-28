import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CatalogueRoutingModule } from './catalogue-routing.module';
import { CatalogueComponent } from './catalogue.component';
import { HomepageComponent } from './homepage/homepage.component';
import { ProductsComponent } from './products/products.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { OffersComponent } from './offers/offers.component';
import { PagesContainerModule } from 'src/app/shared/containers/pages/pages-container.module';


@NgModule({
  declarations: [CatalogueComponent, HomepageComponent, ProductsComponent, ProductDetailsComponent, OffersComponent],
  imports: [
    CommonModule,
    CatalogueRoutingModule,
    PagesContainerModule
  ]
})
export class CatalogueModule { }
