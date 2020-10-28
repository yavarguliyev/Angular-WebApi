import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MyOrdersComponent } from './my-orders/my-orders.component';
import { MyRewardsComponent } from './my-rewards/my-rewards.component';
import { MyWalletComponent } from './my-wallet/my-wallet.component';
import { ShoppingWhislistComponent } from './shopping-whislist/shopping-whislist.component';
import { MyAddressComponent } from './my-address/my-address.component';


@NgModule({
  declarations: [AccountComponent, DashboardComponent, MyOrdersComponent, MyRewardsComponent, MyWalletComponent, ShoppingWhislistComponent, MyAddressComponent],
  imports: [
    CommonModule,
    AccountRoutingModule
  ]
})
export class AccountModule { }
