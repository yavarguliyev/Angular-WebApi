import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CartComponent } from './cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { OrderPlacedComponent } from './order-placed/order-placed.component';
import { RequestProductComponent } from './request-product/request-product.component';


const routes: Routes = [
  {
    path: '',
    component: CartComponent,
    children: [
      { path: '', redirectTo: 'checkout' },
      { path: 'checkout', component: CheckoutComponent },
      { path: 'order-placed', component: OrderPlacedComponent },
      { path: 'request-product', component: RequestProductComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CartRoutingModule { }
