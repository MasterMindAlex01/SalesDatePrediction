export interface OrderRequest {
   custid:         number;
   empid:         number;
   orderdate:     Date;
   requireddate:  Date;
   shippeddate?:  Date;
   shipperid:     number;
   freight:       number;
   shipname:      string;
   shipaddress:   string;
   shipcity:      string;
   shipcountry:   string;
   orderDetails:  OrderDetailRequest[];
}

export interface OrderDetailRequest {
   productid:   number;
   unitprice:   number;
   qty:         number;
   discount:    number;
}
