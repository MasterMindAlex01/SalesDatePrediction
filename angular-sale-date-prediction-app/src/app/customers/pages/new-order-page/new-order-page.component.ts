import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import { SaleDatePrediction } from '../../interfaces/sale-date-prediction.interface';
import { OrderService } from '../../services/order.service';
import { OrderDetailRequest, OrderRequest } from '../../interfaces/order-request.interface';
import { EmployeeService } from '../../services/employee.service';
import { EmployeeResponse } from '../../interfaces/employee-response.interface';
import { ShipperService } from '../../services/shipper.service';
import { ShipperResponse } from '../../interfaces/shipper-response.interface';
import { ProductService } from '../../services/product.service';
import { ProductResponse } from '../../interfaces/product.interface';

@Component({
  selector: 'customers-new-order-page',
  templateUrl: './new-order-page.component.html',
  styleUrl: './new-order-page.component.css'
})
export class NewOrderPageComponent implements OnInit {

  @Input()
  public saleDatePrediction!: SaleDatePrediction;

  public employeeList: EmployeeResponse[] = [];
  public shipperList:  ShipperResponse[] = [];
  public productList:  ProductResponse[] = [];

  public orderForm = new FormGroup({
    empid:        new FormControl<number>(0),
    orderdate:    new FormControl<Date>(new Date()),
    requireddate: new FormControl<Date>(new Date()),
    shippeddate:  new FormControl<Date>(new Date()),
    shipperid:    new FormControl<number>(0),
    freight:      new FormControl<number>(0),
    shipname:     new FormControl(''),
    shipaddress:    new FormControl(''),
    shipcity:     new FormControl(''),
    shipcountry:    new FormControl(''),
    productid:    new FormControl(0),
    unitprice:    new FormControl(0),
    qty:          new FormControl(0),
    discount:     new FormControl(0),

  });

  constructor(
    private employeeService:EmployeeService,
    private shipperService: ShipperService,
    private productService: ProductService,
    private orderService: OrderService,
    private snackbar: MatSnackBar,
    private dialog: MatDialog,
  ) {}

  ngOnInit(): void {
    if ( !this.saleDatePrediction ) throw Error('saleDatePrediction property is required');

    this.employeeService.getAllEmployeeList()
      .subscribe(result => {
        this.employeeList = result.data;
      });

    this.shipperService.getAllShipperList()
      .subscribe(result => {
        this.shipperList = result.data;
      });

    this.productService.getAllProductList()
      .subscribe(result => {
        this.productList = result.data;
      })
  }

  get currentOrder(): OrderRequest {
    const order = this.orderForm.value as OrderRequest;
    order.custid = this.saleDatePrediction.custid;

    const orderDetail = this.orderForm.value as OrderDetailRequest;
    order.orderDetails = [];
    order.orderDetails.push({
      discount: orderDetail!.discount,
      unitprice: orderDetail!.unitprice,
      productid: orderDetail!.productid,
      qty: orderDetail!.qty
     });
    return order;
  }

  onSubmit():void {

    if ( this.orderForm.invalid ) return;

    this.orderService.addOrder( this.currentOrder )
      .subscribe(result => {
        console.log(result);
      });
  }

  showSnackbar( message: string ):void {
    this.snackbar.open( message, 'done', {
      duration: 2500,
    })
  }
}
