import { Orders } from "./orders";

 export class SalesResponse {
    TotalOrderCount: string;
    TotalNotInvoicedCount: string;
    TotalUnreadCount: string;
    Orders: Orders[];
   
}