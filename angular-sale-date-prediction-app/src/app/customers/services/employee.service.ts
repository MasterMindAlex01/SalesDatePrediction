import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Result } from '../interfaces/result.interface';
import { EmployeeResponse } from '../interfaces/employee-response.interface';
import { environments } from '../../../environments/environments';

@Injectable({providedIn: 'root'})
export class EmployeeService {

  private baseUrl: string = environments.baseUrl;

  constructor(private httpClient: HttpClient) { }

  getAllEmployeeList():Observable<Result<EmployeeResponse[]>>{
    return this.httpClient.get<Result<EmployeeResponse[]>>(
      `${this.baseUrl}/api/Employees/GetAllEmployeeList`);
  }
}
