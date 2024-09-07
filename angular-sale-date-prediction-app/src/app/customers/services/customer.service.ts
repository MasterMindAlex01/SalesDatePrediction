import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError, Observable, of } from 'rxjs';

import { environments } from '../../../environments/environments';
import { PaginatedResult } from '../interfaces/paginated-result.interface';
import { SaleDatePrediction } from '../interfaces/sale-date-prediction.interface';

@Injectable({providedIn: 'root'})
export class CustomerService {

  private baseUrl: string = environments.baseUrl;

  constructor(private httpClient: HttpClient) { }


  getSaleDatePredictionList(searchName: string = '', pageNumber: number = 1, pageSize: number = 10 )
  : Observable<PaginatedResult<SaleDatePrediction[]>|undefined> {

    const params = new HttpParams()
    .set('searchName', searchName)
    .set('pageNumber', pageNumber)
    .set('PageSize', pageSize);

    return this.httpClient.get<PaginatedResult<SaleDatePrediction[]>>(
      `${this.baseUrl}/api/Customers/GetSaleDatePredictionList`, { params })
        .pipe(
          catchError( error => of(undefined) )
        );
  }
}
