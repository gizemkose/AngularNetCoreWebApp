import { OrderDetails } from "./orderDetails";

 export class Orders {
    OrderId :number;					
    Name:string;				
    Surname :string;						
    PersonalIdentification:string;	
    Nickname :string;			
    OrderDate :Date;			
    IntegrationOrderCode:string;	
    OrderStatus :string;				
    Fullname:string;				
    Address :string;					
    Telephone:string;				
    TaxAuthority :string;			
    TaxNumber :string;				
    City :string;					
    Notes:string;				
    District :string;			
    PostalCode :string;			
    CompanyTitle:string;	
    OrderDetails: OrderDetails[] ;
    
   
}