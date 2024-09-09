import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

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
import { ValidatorsService } from '../../../shared/services/validators.service';

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
    empid:        new FormControl<number|null>(null, [ Validators.required ]),
    orderdate:    new FormControl<Date|null>(null, [ Validators.required ]),
    requireddate: new FormControl<Date|null>(null, [ Validators.required ]),
    shippeddate:  new FormControl<Date|null>(null, [ Validators.required ]),
    shipperid:    new FormControl<number|null>(null, [ Validators.required ]),
    freight:      new FormControl<number|null>(null, [ Validators.required, Validators.min(1) ]),
    shipname:     new FormControl('', [ Validators.required ]),
    shipaddress:    new FormControl('', [ Validators.required ]),
    shipcity:     new FormControl('', [ Validators.required ]),
    shipcountry:    new FormControl('', [ Validators.required ]),
    productid:    new FormControl<number|null>(null, [ Validators.required ]),
    unitprice:    new FormControl<number|null>(null, [ Validators.required, Validators.min(1) ]),
    qty:          new FormControl<number|null>(null, [ Validators.required, Validators.min(1) ]),
    discount:     new FormControl<number|null>(null, [ Validators.required, Validators.min(0), Validators.max(1), ]),

  });

  constructor(
    private employeeService:EmployeeService,
    private shipperService: ShipperService,
    private productService: ProductService,
    private orderService: OrderService,
    private validatorsService: ValidatorsService,
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

  isValidField( field: string ) {
    return this.validatorsService.isValidField( this.orderForm, field );
  }

  getFieldError( field: string ) {
    return this.validatorsService.getFieldError( this.orderForm, field );
  }

  onSubmit():void {

    if ( this.orderForm.invalid ) {
      this.orderForm.markAllAsTouched();
      return;
    }

    //console.log( this.currentOrder );
    this.orderService.addOrder( this.currentOrder )
      .subscribe(result => {
        this.showSnackbar(`Order ${result.data} created by ${this.saleDatePrediction.customerName}`);
        this.orderForm.reset();
        this.dialog.closeAll();
      });
  }

  onCloseDialog():void {
    this.dialog.closeAll();
  }

  showSnackbar( message: string ):void {
    this.snackbar.open( message, 'done', {
      duration: 3000,
    })
  }
}
