import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PaymentDetailService } from '../shared/payment-detail.service';
import { ItemMangement, PaymentOrderDetails, SizeLevel } from '../shared/payment-detail.model';

@Component({
    selector: 'app-products-component',
    templateUrl: './products.component.html'
})
export class ProductsComponent {
    constructor(private service: PaymentDetailService) { }
    ItemsNew: ItemMangement[];
    public PaymentOrder: PaymentOrderDetails[] = [];

    public Total = 0;
    public OwnerName = '';
    public PhoneNumber = '';

    ngOnInit(): void {
        this.onGet();

    }
    onGet() {
        debugger;
        this.service.refreshListItemMangement().subscribe(
            res => {
                this.ItemsNew = res;
                console.log(res)
            },

        );


    }
    onSubmit() {
        debugger;
        let change = this.PaymentOrder[0];
        change.OwnerName = this.OwnerName;
        change.PhoneNumber = this.PhoneNumber;
        change.Total = this.Total;

        this.paymentClick(this.PaymentOrder);
        
    }
    paymentClick(PaymentOrder: PaymentOrderDetails[]) {
        debugger;
        this.service.postPaymentDetail(PaymentOrder).subscribe(
            res => {
                window.location.reload();
                    this.onGet();
                    this.service.refreshList();

                    this.service.refreshList();

                },
                err => { console.log(err); }
            );
        }

    
    addClick() {

        this.ChoseUser = true;

    }
    ChoseUser: boolean = false;


    public decrementCounter(form: SizeLevel) {
        debugger;
        var list = this.PaymentOrder.find((x => x.Id == form.Id && x.Price == form.Price && x.Price == form.Price))
        if (list.NumberProducts > 1) {
            list.NumberProducts--;
            list.TotalPrice = list.NumberProducts * list.Price
            this.Total -= form.Price
        }
        else {
            this.PaymentOrder= this.PaymentOrder.filter((x => x.Id != list.Id))
            this.Total -= form.Price
        }

    }
    public Remove(form: SizeLevel) {
        debugger;
        var list = this.PaymentOrder.find((x => x.Id == form.Id && x.Price == form.Price && x.Price == form.Price))
            this.PaymentOrder = this.PaymentOrder.filter((x => x.Id != list.Id))
        this.Total -= list.TotalPrice
        

    }
    public incrementCounter(form: ItemMangement) {
        debugger;
        if (this.PaymentOrder.length>0&&this.PaymentOrder.find((x => x.Id == form.id && x.Price.toString() == form.price && x.Price.toString() == form.price))) {
            var py = this.PaymentOrder.find((x => x.Id == form.id && x.Price.toString() == form.price && x.Price.toString() == form.price))
            py.NumberProducts++;
            py.TotalPrice = py.NumberProducts * py.Price
            let price1 = parseInt(form.price);

            this.Total += price1
        }
        else {
            this.PaymentOrder.push({ Id: form.id, NameProduct: form.name, Price: parseInt(form.price), Size: parseInt(form.size), NumberProducts: 1, OwnerName: "", PhoneNumber: "", TotalPrice: parseInt(form.price),Total:0 })
            let price2 = parseInt(form.price);
            this.Total += price2 
        }
       
    }
}