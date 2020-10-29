import { BasketService } from './../../../services/basket.service';
import { IProduct } from './../../../models/product';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html'
})
export class ProductItemComponent implements OnInit {
  @Input() product: IProduct;
  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
  }

  addToBasket(): void{
    this.basketService.addItem(this.product);
  }
}
