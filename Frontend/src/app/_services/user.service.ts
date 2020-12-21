import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../_models';
import { Sales } from '../_models/sales';
import { Observable } from 'rxjs';
import { SalesResponse } from '../_models/salesResponse';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }
  
    GetSales(getSales:Sales):Observable<any>{
    return this.http.post<any>(`${config.apiUrl}/users/GetSales`, getSales);
    }
}