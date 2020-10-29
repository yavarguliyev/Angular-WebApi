import { IBasket } from './../../../models/basket';
import { BasketService } from './../../../services/basket.service';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html'
})
export class MenuComponent implements OnInit {
  public basket: IBasket;

  @ViewChild('cartSideBar') cartSideBar: ElementRef;

  public cartShowed: boolean = false;

  constructor(private basketService: BasketService) {
    this.basketService.basketInfo.subscribe(
      basket => {
        this.basket = basket;
      }
    );
  }

  ngOnInit(): void {
  }

  openCartSideBar(event: any): void {
    event.preventDefault();
    this.cartSideBar.nativeElement.classList.toggle('ml-0');
    this.cartShowed = !this.cartShowed;
  }

  closeCardSideBar(): void {
    this.cartSideBar.nativeElement.classList.toggle('ml-0');
    this.cartShowed = !this.cartShowed;
  }
}
