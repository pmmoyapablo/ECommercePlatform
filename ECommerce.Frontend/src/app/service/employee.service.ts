import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { ResponceObject } from '../models/response_object.model';
import { ResponceList } from '../models/response_list.model';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private dataUrl = 'http://localhost:8081/app/employees';

  constructor(private http: HttpClient) {}

  getAllEmployees(): Observable<ResponceList> {
    return this.http.get<ResponceList>(
      this.dataUrl
    );
  }

  getOneEmployee(id: string): Observable<ResponceObject> {
    return this.http.get<ResponceObject>(
      this.dataUrl + '/' + id
    );
  }

}