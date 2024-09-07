export interface SaleDatePrediction {
  custid:                 number;
  customerName:           string;
  lastOrderDate:          Date;
  nextPredictedOrderDate: Date;
}
