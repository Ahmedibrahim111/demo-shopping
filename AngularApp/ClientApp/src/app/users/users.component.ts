import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

import { NgForm } from '@angular/forms'; 
import { ItemMangement, SizeLevel } from '../shared/payment-detail.model';
import { PaymentDetailService } from '../shared/payment-detail.service';
@Component({
    selector: 'app-users-component',
    templateUrl: './users.component.html', 
})
export class UsersComponent {
    AddNewSize: boolean = false;
     ItemsNew: ItemMangement[];
    public ItemNew: ItemMangement|any = {};
    addList: SizeLevel[]=[];

    size: ItemMangement;
    public data = {};
    public formDataList = [];

    shortLink: string = "";
    loading: boolean = false; // Flag variable
    file: File = null;

    constructor(private service: PaymentDetailService) { }
  
  
    ngOnInit(): void {
        this.onGet();
        
        }
    ModalTitle: string;
    ActivateAddEditEmpComp: boolean = false;
    emp: any;

    onGet() {
        this.service.refreshListItemMangement().subscribe(
            res => {
                this.ItemsNew = res;
                console.log(res) 
            },
           
        );
         
       
    }


    addItem($item) {
        debugger;

        this.addList.push($item)

        this.ItemNew = {};
    }

   

    removeItem($item) {
        debugger;

        this.addList.splice(this.formDataList.indexOf($item), 1)


    }
    populateForm(selectedRecord: ItemMangement) {
        debugger;
        this.service.formData.attachement = "";
        this.ItemNew = Object.assign({}, selectedRecord);

        this.service.formData = Object.assign({}, selectedRecord);

        this.ModalTitle = "Edit Product";
        this.ActivateAddEditEmpComp = true;
    }
    addClick() {
        debugger;
        this.formDataList.push(1);
        this.AddNewSize = true;
        this.service.formData = {
            id: 0, 
            name: "",
            price: '', size: '',
            attachement:''
        } 
        this.ModalTitle = "Add Product";
        this.ActivateAddEditEmpComp = true;

    }


    onSubmit(form: NgForm) {
        debugger;
        if (this.service.formData.id == 0)
            this.insertRecord(form);
        else
            this.updateRecord(form);
    }

    insertRecord(form: NgForm) {
        debugger;
        if (this.file != null) {
        var resselt = this.onUpload();

        }
        console.log(resselt)
        debugger;
        if (this.addList.length > 0) {

            this.addList.forEach((x => x.name = form.value.name))
            if (this.file != null) {
                this.addList.forEach((x => x.attachement = "/Images/" + this.file.name))
                this.ItemNew.attachement = "/Images/" + this.file.name;
                this.ItemNew.name = form.value.name;

                this.addList.push(this.ItemNew)
            }
            else {
            this.ItemNew.name = form.value.name;
                this.addList.push(this.ItemNew)
            }
        }
        else {
            this.ItemNew.name = form.value.name;

            if (this.file != null) {
                this.ItemNew.attachement = "/Images/" + this.file.name;
                this.addList.push(this.ItemNew)

            }
            else {
        this.addList.push(this.ItemNew)
}}
        this.service.postItemMangement(this.addList).subscribe(
            res => {
                window.location.reload();
                this.resetForm(form);
                this.onGet();
               

            },
            err => { console.log(err); }
        );
    }

    updateRecord(form: NgForm) {
        debugger;
        if (this.file != null) {
            let reselt = this.onUpload();
            this.service.formData.attachement = "/Images/" + this.file.name;
            this.service.formData.size = String(this.ItemNew.size);
            this.service.formData.price = String(this.ItemNew.price);
        }
        else {
        this.service.formData.size = String(this.ItemNew.size);
        this.service.formData.price = String(this.ItemNew.price);
}
        this.service.putItemMangement().subscribe(
            res => {
                window.location.reload();
                this.resetForm(form);
                this.onGet();
                this.service.refreshList();
                this.formDataList.push(1)

                this.ActivateAddEditEmpComp = false;

            },
            err => { console.log(err); }
        );
    }


    resetForm(form: NgForm) {
        form.form.reset();
        this.service.formData = new ItemMangement();
    }
    onDelete(id: number) {
        debugger;
      
            this.service.deleteItemMangement(id)
                .subscribe(
                    res => { 
                        debugger;
                        this.onGet(); 
                        console.log(res);
                       
                    },
                    err => { console.log(err) }
            )
        }
    onChange(event) {
        debugger;

        this.file = event.target.files[0];
    }
    onUpload() {
        debugger;
        console.log(this.file);
        this.service.upload(this.file).subscribe(
            (event: any) => {
                if (typeof (event) === 'object') {

                    // Short link via api response
                    this.shortLink = event.link;

                    this.loading = false; // Flag variable 
                }
            }
        );
    }
}
 

