import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';

import { CustomerService } from '../../services/customer.service';
import { SaleDatePrediction } from '../../interfaces/sale-date-prediction.interface';
import { MatTableDataSource } from '@angular/material/table';

import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';

import { OrdersDialogComponent } from '../../components/orders-dialog/orders-dialog.component';
import { NewOrderDialogComponent } from '../../components/new-order-dialog/new-order-dialog.component';

@Component({
  selector: 'customers-home-page',
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent implements AfterViewInit  {

  public resultsLength: number = 0;
  public pageSize = 10;
  public pageIndex = 0;
  public pageSizeOptions = [5, 10, 25];
  public showFirstLastButtons = true;
  public displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrderDate', 'options'];
  public dataSource: MatTableDataSource<SaleDatePrediction>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private customerService: CustomerService, private dialog: MatDialog) {
    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource();
  }


  ngAfterViewInit() {

    this.customerService.getSaleDatePredictionList('',this.pageIndex+1, this.pageSize)
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

    this.customerService.getSaleDatePredictionList('',this.pageIndex+1, this.pageSize)
    .subscribe(result => {
      this.dataSource = new MatTableDataSource(result?.data);
      this.dataSource.sort = this.sort;
      this.resultsLength = result!.totalCount;
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    let searchName = filterValue.trim().toLowerCase();

    this.customerService.getSaleDatePredictionList(searchName,this.pageIndex+1, this.pageSize)
    .subscribe(result => {
      this.dataSource = new MatTableDataSource(result?.data);
      this.dataSource.sort = this.sort;
      this.resultsLength = result!.totalCount;
    });

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }

  }

  onShowOrdersDialog( saleDatePrediction:SaleDatePrediction ){
    const dialogRef = this.dialog.open( OrdersDialogComponent, {
      data: saleDatePrediction,
        height: '400px',
        width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if ( !result ) return;
      console.log({ result });
    });
  }

  onShowNewOrderDialog( saleDatePrediction:SaleDatePrediction ){
    const dialogRef = this.dialog.open( NewOrderDialogComponent, {
        data: saleDatePrediction,
        height: '400px',
        width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if ( !result ) return;
      console.log({ result });
    });
  }
}


