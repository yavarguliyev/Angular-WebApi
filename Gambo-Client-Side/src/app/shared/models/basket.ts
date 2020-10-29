import { IProduct } from './product';
export interface IBasket {
    total: number;
    saving: number;
    charge: number;
    count: number;
    products: IProduct[];
}