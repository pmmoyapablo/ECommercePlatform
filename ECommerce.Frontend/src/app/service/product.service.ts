import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private dataUrl = 'http://localhost:6107/Product';

  constructor(private http: HttpClient) {}

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(
      this.dataUrl
    );
  }

  getOneProduct(id: string): Observable<Product> {
    return this.http.get<Product>(
      this.dataUrl + '/' + id
    );
  }

}