import { IProduct } from './../models/product';
import { ICategory } from './../models/category';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  public getCategories() {
    return this.http.get<ICategory[]>(environment.apiUrl + '/catalogue/categories');
  }

  public getFeaturedProducts(branchId: number) {
    return this.http.get<IProduct[]>(environment.apiUrl + '/catalogue/featured-products?branchId=' + branchId);
  }
}
