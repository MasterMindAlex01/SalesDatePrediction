export interface OrderResponse {
  orderId:      number;
  orderDate:    Date;
  requiredDate: Date;
  shippedDate:  Date;
  shipName:     string;
  shipAddress:  string;
  shipCity:     string;
}
