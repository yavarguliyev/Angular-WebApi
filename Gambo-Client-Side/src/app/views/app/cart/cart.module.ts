import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CartRoutingModule } from './cart-routing.module';
import { CartComponent } from './cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { OrderPlacedComponent } from './order-placed/order-placed.component';
import { RequestProductComponent } from './request-product/request-product.component';


@NgModule({
  declarations: [CartComponent, CheckoutComponent, OrderPlacedComponent, RequestProductComponent],
  imports: [
    CommonModule,
    CartRoutingModule
  ]
})
export class CartModule { }
