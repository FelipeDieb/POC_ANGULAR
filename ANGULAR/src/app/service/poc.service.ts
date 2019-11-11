import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PocService {

  constructor(private http: HttpClient) { }

  getEmployees(): Observable<any> {
    return this.http.get<any>(`https://localhost:5001/api/employees`);
  }

  getEmployeesPerDepartament(): Observable<any> {
    return this.http.get<any>(`https://localhost:5001/api/employees/per-departament`);
  }

  getEmployeesStartedJanAndjune(): Observable<any> {
    return this.http.get<any>(`https://localhost:5001/api/employees/started-between-january-and-june`);
  }
}
