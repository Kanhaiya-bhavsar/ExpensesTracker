import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../interfaces/expense'; // Ensure this is defined properly

@Injectable({
  providedIn: 'root'
})
export class CategoryServiceService {
  private apiUrl = 'https://localhost:7115/api/Category';
  private http = inject(HttpClient);

  constructor() {}

  // ✅ Prepare headers with JWT token
  private getHeaders(): HttpHeaders {
    const token = localStorage.getItem('token') ?? '';
    return new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });
  }

  // ✅ Get all categories
  getAllCategory(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl, { headers: this.getHeaders() });
  }

  // ✅ Get category by ID
  getCategoryById(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }

  // ✅ Add a new category
  addCategory(category: Category): Observable<Category> {
    return this.http.post<Category>(this.apiUrl, category, { headers: this.getHeaders() });
  }

  // ✅ Update an existing category
  updateCategory(id: number, category: Category): Observable<Category> {
    return this.http.put<Category>(`${this.apiUrl}/${id}`, category, { headers: this.getHeaders() });
  }

  // ✅ Delete a category
  deleteCategory(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }
}
