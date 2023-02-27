import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ItemMangement, PaymentOrderDetails, UserBill } from './payment-detail.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {
    readonly baseURL = 'https://localhost:44312/api/ItemMangements'
    readonly baseURL2 = 'https://localhost:44312/api/PaymentOrderDetails'
    readonly baseURL3 = 'https://localhost:44312/api/UserBills'
    readonly baseURLFile = 'https://localhost:44312/api/ItemMangements/Upload'


  constructor(private http: HttpClient) { }
    



    formData: ItemMangement = new ItemMangement();

    list: ItemMangement[];


    postItemMangement(list: ItemMangement[]|any[]) {
        debugger;

        return this.http.post(this.baseURL, list);
  }

    putItemMangement() {
        debugger;
        this.formData.size.toString()

        return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }

    deleteItemMangement(Id: number) {
        debugger;
        return this.http.delete(`${this.baseURL}/${Id}`);
  }
    refreshListItemMangement(): Observable<ItemMangement[]> {
        return this.http.get<ItemMangement[]>(this.baseURL)
            .pipe(
            );
    }
    
      
  




    formDataUserBill: UserBill = new UserBill();

    listPayment: PaymentOrderDetails[];

    postPaymentDetail(form: PaymentOrderDetails[]) {
        return this.http.post(this.baseURL2,form);
    }


    GetDetail(id: number): Observable<PaymentOrderDetails[]> {
        return this.http.get<PaymentOrderDetails[]>(`${this.baseURL2}/${id}`);
    }

    refreshList() {
        this.http.get(this.baseURL)
            .toPromise()
            .then(res => this.listPayment = res as PaymentOrderDetails[]);
    }

    refreshUserBill(): Observable<UserBill[]> {
        return this.http.get<UserBill[]>(this.baseURL3)
            .pipe(
            );
    }
    upload(file): Observable<any> {
        debugger;
        // Create form data
        const formData = new FormData();

        // Store form name as "file" with file datade
        formData.append("file", file, file.name);

        // Make http post request over api
        // with formData as req
        return this.http.post(this.baseURLFile,formData)
    }

}
