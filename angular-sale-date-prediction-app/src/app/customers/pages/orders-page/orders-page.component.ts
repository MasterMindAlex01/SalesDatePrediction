import { AfterViewInit, Component, Input, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { OrderService } from '../../services/order.service';
import { OrderResponse } from '../../interfaces/order-response.interface';
import { SaleDatePrediction } from '../../interfaces/sale-date-prediction.interface';

@Component({
  selector: 'customers-orders-page',
  templateUrl: './orders-page.component.html',
  styleUrl: './orders-page.component.css'
})
export class OrdersPageComponent implements AfterViewInit {

  public resultsLength: number = 0;
  public pageSize = 10;
  public pageIndex = 0;
  public pageSizeOptions = [5, 10, 25];
  public showFirstLastButtons = true;
  public displayedColumns: string[] = [
    "orderId",
    "orderDate",
    "requiredDate",
    "shippedDate",
    "shipName",
    "shipAddress",
    "shipCity",
  ];
  public dataSource: MatTableDataSource<OrderResponse>;

  @Input()
  public saleDatePrediction!: SaleDatePrediction;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private orderService: OrderService) {
    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource();
  }

  ngAfterViewInit() {

    if ( !this.saleDatePrediction ) throw Error('saleDatePrediction property is required');

    this.orderService.getOrderListByCustId(this.saleDatePrediction.custid, this.pageIndex+1, this.pageSize)
      .subscribe(result => {
        this.dataSource = new MatTableDataSource(result?.data);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        this.resultsLength = result!.totalCount;
      });
  }

  handlePageEvent(event: PageEvent) {
    this.resultsLength = event.length;
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;

    this.orderService.getOrderListByCustId(this.saleDatePrediction.custid, this.pageIndex+1, this.pageSize)
    .subscribe(result => {
      this.dataSource = new MatTableDataSource(result?.data);
      this.dataSource.sort = this.sort;
      this.resultsLength = result!.totalCount;
    });
  }


}
