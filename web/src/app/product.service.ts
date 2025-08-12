import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

export interface Product {
  id: number;
  name: string;
  price: number;
  createdUtc: string;
}

@Injectable({ providedIn: 'root' })
export class ProductService {
  private http = inject(HttpClient);
  private base = environment.apiBase;

  list() {
    return this.http.get<Product[]>(`${this.base}/products`);
  }

  create(dto: { name: string; price: number }) {
    console.log(dto)
    return this.http.post<{ id: number }>(`${this.base}/products`, dto);
  }

  byId(id: number) {
    return this.http.get<Product>(`${this.base}/products/${id}`);
  }
}
