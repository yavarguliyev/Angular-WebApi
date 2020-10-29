import { IBasket } from './../models/basket';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { IProduct } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  private basket: IBasket = {
    total: 0,
    saving: 0,
    charge: 0,
    count: 0,
    products: []
  };
  public basketInfo: BehaviorSubject<IBasket> = new BehaviorSubject<IBasket>(this.basket);
  constructor() {
    if (localStorage.getItem('basket')) {
      this.basket = JSON.parse(localStorage.getItem('basket'));

      this.basketInfo.next(this.basket);
    }
  }

  public addItem(product: IProduct) {
    this.basket.count++;
    this.basket.total += product.price - (product.price*product.discountResource.percentage/100);
    this.basket.charge += product.price/100;
    this.basket.saving += product.price - (product.price - (product.price*product.discountResource.percentage/100));
    this.basket.products.push(product);

    this.basketInfo.next(this.basket)

    localStorage.setItem('basket', JSON.stringify(this.basket));
  }
}
