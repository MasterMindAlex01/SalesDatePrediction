import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Result } from '../interfaces/result.interface';
import { ProductResponse } from '../interfaces/product.interface';
import { environments } from '../../../environments/environments';

@Injectable({providedIn: 'root'})
export class ProductService {

  private baseUrl: string = environments.baseUrl;

  constructor(private httpClient: HttpClient) { }

  getAllProductList():Observable<Result<ProductResponse[]>> {
    return this.httpClient.get<Result<ProductResponse[]>>(
      `${this.baseUrl}/api/Products/GetAllProductList`);
  }
}
