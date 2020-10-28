import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CatalogueComponent } from './catalogue.component';
import { HomepageComponent } from './homepage/homepage.component';
import { OffersComponent } from './offers/offers.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductsComponent } from './products/products.component';


const routes: Routes = [
  {
    path: '',
    component: CatalogueComponent,
    children: [
      { path: '', redirectTo: 'homepage' },
      { path: 'homepage', component: HomepageComponent },
      { path: 'offers', component: OffersComponent },
      { path: 'products/:id', component: ProductsComponent },
      { path: 'product-details/:id', component: ProductDetailsComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatalogueRoutingModule { }
