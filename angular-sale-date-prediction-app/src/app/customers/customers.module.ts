import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { MaterialModule } from '../material/material.module';

import { LayoutPageComponent } from './pages/layout-page/layout-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { CustomersRoutingModule } from './customers-routing.module';
import { OrdersPageComponent } from './pages/orders-page/orders-page.component';
import { NewOrderPageComponent } from './pages/new-order-page/new-order-page.component';
import { OrdersDialogComponent } from './components/orders-dialog/orders-dialog.component';
import { NewOrderDialogComponent } from './components/new-order-dialog/new-order-dialog.component';


@NgModule({
  declarations: [
    LayoutPageComponent,
    HomePageComponent,
    OrdersPageComponent,
    NewOrderPageComponent,

    OrdersDialogComponent,
    NewOrderDialogComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CustomersRoutingModule,
    MaterialModule
  ],
  exports: [
    OrdersPageComponent,
    NewOrderPageComponent
  ]
})
export class CustomersModule { }
