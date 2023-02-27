import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PaymentOrderDetails, UserBill } from '../shared/payment-detail.model';
import { PaymentDetailService } from '../shared/payment-detail.service';

@Component({
    selector: 'app-orders-component',
    templateUrl: './orders.component.html' 
})
export class OrdersComponent {
    constructor(private service: PaymentDetailService) { }

    ItemsNew: UserBill[];
    PaymentOrderDetails: PaymentOrderDetails[];
    ChoseUser: boolean = false;


    ngOnInit(): void {
        debugger;
        this.onGet();

    }
    onGet() {
        debugger;
        this.service.refreshUserBill().subscribe(
            res => {
                this.ItemsNew = res;
                console.log(res)
            },

        );


    }
    GetDetails(id: number) {
        debugger;
        this.service.GetDetail(id).subscribe(
            res => {
                this.ChoseUser = true;

                this.PaymentOrderDetails = res
                console.log(res)

                 
            },
            err => { console.log(err); }
        );
    }
}
