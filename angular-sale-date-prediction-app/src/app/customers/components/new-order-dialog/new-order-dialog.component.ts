import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SaleDatePrediction } from '../../interfaces/sale-date-prediction.interface';

@Component({
  selector: 'customers-new-order-dialog',
  templateUrl: './new-order-dialog.component.html',
  styleUrl: './new-order-dialog.component.css'
})
export class NewOrderDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<NewOrderDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: SaleDatePrediction,
  ) {}


  onClose():void {
    this.dialogRef.close(true)
  }

}
