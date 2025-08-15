import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';


    // <!-- public int Id { get; set; }
    // public required string Name { get; set; }
    // public required string Email { get; set; }
    // public bool IsActive { get; set; } = true;
    // public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    // public DateTime? UpdatedUtc { get; set; } -->

    export interface User {
      id : number,
      name : string,
      email :string,
      isActive : boolean,
      createdUtc : Date,
      updatedUtc : Date
    }


@Injectable({
  providedIn: 'root'
})
export class UserService {

    private http = inject(HttpClient);
  private base = 'http://localhost:8080/api/Users'; // adjust if you use env

  list(opts?: { search?: string; page?: number; pageSize?: number }) {
    let params = new HttpParams();
    if (opts?.search)  params = params.set('search', opts.search);
    if (opts?.page)    params = params.set('page', String(opts.page));
    if (opts?.pageSize)params = params.set('pageSize', String(opts.pageSize));
    return this.http.get<User[]>(this.base, { params });
  }

  byId(id: number) {
    return this.http.get<User>(`${this.base}/${id}`);
  }

  create(dto: { name: string; email: string; isActive?: boolean }) {
    return this.http.post<number>(this.base, dto);
  }

  update(dto: { id: number; name: string; email: string; isActive: boolean }) {
    return this.http.put<void>(`${this.base}/${dto.id}`, dto);
  }

  delete(id: number) {
    return this.http.delete<void>(`${this.base}/${id}`);
  }

  
}
