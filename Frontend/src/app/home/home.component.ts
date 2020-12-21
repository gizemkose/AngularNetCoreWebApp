import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { User } from '../_models';
import { UserService } from '../_services';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SalesResponse } from '../_models/salesResponse';
import { Orders } from '../_models/orders';
import { OrderDetails } from '../_models/orderDetails';
import {TableModule} from 'primeng/table';
import { SaleList } from '../_models/saleList';
import { AUTO_STYLE } from '@angular/animations';

@Component({templateUrl: 'home.component.html'})
export class HomeComponent implements OnInit {
    users: User[] = [];
    getSalesForm: FormGroup;
    salesResponse: SalesResponse;
    orders:Orders[]=[];
    ordersDetail:OrderDetails[]=[];
    saleList:SaleList[]=[];
    constructor(private userService: UserService, private formBuilder: FormBuilder) {}

    ngOnInit() {
        this.getSalesForm = this.formBuilder.group({          
            storeId: ['', Validators.required],
            orderStatus: ['Completed',[] ],
            invoiceStatus: ['0',[] ]
        });
        const user= JSON.parse(window.localStorage.getItem('currentUser'));      
    }
    GetSales() {      
        const salesList=this.getSalesForm.value;
        this.userService.GetSales(salesList)
            .pipe(first())
            .subscribe(
                
                data => {   this.saleList=data;                                          
                },
                error => {                   
                });
    }
}