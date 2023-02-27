import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { UsersComponent } from './users/users.component';
import { PaymentDetailService } from './shared/payment-detail.service';
import { OrdersComponent } from './orders/orders.component';
import { ProductsComponent } from './products/products.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    UsersComponent,
        OrdersComponent,
        ProductsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
      FormsModule,
      //ToastrModule,
    RouterModule.forRoot([
        { path: '', component: UsersComponent, pathMatch: 'full'},
        { path: 'orders', component: OrdersComponent },
        { path: 'products', component: ProductsComponent },
    ])
  ],
    providers: [PaymentDetailService],
  bootstrap: [AppComponent]
})
export class AppModule { }
