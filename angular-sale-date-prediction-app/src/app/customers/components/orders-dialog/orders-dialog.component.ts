import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SaleDatePrediction } from '../../interfaces/sale-date-prediction.interface';

@Component({
  selector: 'customers-orders-dialog',
  templateUrl: './orders-dialog.component.html',
  styleUrl: './orders-dialog.component.css'
})
export class OrdersDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<OrdersDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: SaleDatePrediction,
  ) {}


  onClose():void {
    this.dialogRef.close(true)
  }

}
