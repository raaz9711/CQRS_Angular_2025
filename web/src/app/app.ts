import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Product, ProductService } from './product.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CommonModule,FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  private api = inject(ProductService);
  products = signal<Product[]>([]);
  name = '';
  price: number | null = null;

  constructor() {
    this.load();
  }

  load() {
    this.api.list().subscribe(p => this.products.set(p));
  }

  add() {
    if (!this.name || this.price == null) return;
    this.api.create({ name: this.name, price: this.price }).subscribe(_ => {
      this.name = ''; this.price = null; this.load();
    });
  }
}
