import { IDiscount } from './discount';

export interface IProduct{
    id: number;
    name: string;
    desc: string;
    details?: any;
    price: number;
    quantity: number;
    unit: string;
    discountResource?: IDiscount;
    photos: string[]; 
}