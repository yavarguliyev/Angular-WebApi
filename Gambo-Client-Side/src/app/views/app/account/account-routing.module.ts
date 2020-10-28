import { DashboardComponent } from './dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountComponent } from './account.component';
import { MyAddressComponent } from './my-address/my-address.component';
import { MyOrdersComponent } from './my-orders/my-orders.component';
import { MyWalletComponent } from './my-wallet/my-wallet.component';
import { MyRewardsComponent } from './my-rewards/my-rewards.component';
import { ShoppingWhislistComponent } from './shopping-whislist/shopping-whislist.component';


const routes: Routes = [
  {
    path: '',
    component: AccountComponent,
    children: [
      { path: '', redirectTo: 'dashboard' },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'my-address', component: MyAddressComponent },
      { path: 'my-orders', component: MyOrdersComponent },
      { path: 'my-rewards', component: MyRewardsComponent },
      { path: 'my-wallet', component: MyWalletComponent },
      { path: 'shopping-whislist', component: ShoppingWhislistComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
