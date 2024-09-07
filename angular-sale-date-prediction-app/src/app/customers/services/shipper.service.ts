import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environments } from '../../../environments/environments';
import { ShipperResponse } from '../interfaces/shipper-response.interface';
import { Result } from '../interfaces/result.interface';

@Injectable({providedIn: 'root'})
export class ShipperService {

  private baseUrl: string = environments.baseUrl;

  constructor(private httpClient: HttpClient) { }

  getAllShipperList():Observable<Result<ShipperResponse[]>>{
    return this.httpClient.get<Result<ShipperResponse[]>>(
      `${this.baseUrl}/api/Shippers/GetAllShipperList`);
  }
}
