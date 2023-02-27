import { Data } from "@angular/router";

export class ItemMangement {
    id: number=0;
    name: string = '';
    price: string = '';
    size: string='';
    attachement: string='';
}
export class PaymentOrderDetails {
    Id: number = 0;
    NameProduct: string = '';
    NumberProducts: number = 0;
    Price: number = 0;
    TotalPrice: number = 0;
    Total?: number = 0;
    Date?: Date
    OwnerName?: string = ''; Size: number = 0;
    PhoneNumber?: string = '';

;
}
export class SizeLevel {
    Id: number = 0;
    attachement: string = '';
    Price: number = 0;;
    Size: number = 0;;
    name: string = '';
}

export class UserBill {
    phoneNumber: string = '';
    totalPrice: number = 0;
    billNumber: number = 0;

    date: Date
    userName: string = '';

}