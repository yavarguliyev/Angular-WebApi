import { IProduct } from './../../../models/product';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html'
})
export class ProductItemComponent implements OnInit {
  @Input() product: IProduct;
  constructor() { }

  ngOnInit(): void {
  }

}
