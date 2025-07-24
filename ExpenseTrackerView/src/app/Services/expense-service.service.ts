import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExpenseReceive, ExpenseSend } from '../interfaces/expense';
import { CategoryTotalDto } from '../interfaces/CategoryTotalDto';

@Injectable({
  providedIn: 'root'
})
export class ExpenseServiceService {
  private apiUrl = 'https://localhost:7115/api/Expense';
  private http = inject(HttpClient);

  constructor() {}

  // 🔒 Get headers with JWT token
  private getHeaders(): HttpHeaders {
    const token = localStorage.getItem('token') ?? '';
    return new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });
  }

  // ✅ Get all expenses
  getAllExpenses(): Observable<ExpenseReceive[]> {
    return this.http.get<ExpenseReceive[]>(this.apiUrl, { headers: this.getHeaders() });
  }

  // ✅ Get single expense by ID
  getExpenseById(id: number): Observable<ExpenseReceive> {
    return this.http.get<ExpenseReceive>(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }

  // ✅ Add new expense
  addExpense(formData: FormData): Observable<ExpenseReceive> {
    const token = localStorage.getItem('token') ?? '';
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
      // ❌ Do NOT set Content-Type for FormData
    });
  
    return this.http.post<ExpenseReceive>(this.apiUrl, formData, { headers });
  }

  

  updateExpense(id: number, formData: FormData): Observable<ExpenseReceive> {
    const token = localStorage.getItem('token') ?? '';
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
      // ❌ DO NOT set 'Content-Type' here for FormData
    });
  
    return this.http.put<ExpenseReceive>(`${this.apiUrl}/${id}`, formData, { headers });
  }
  
  // ✅ Delete expense
  deleteExpense(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }

  // ✅ Get expenses by category
  getExpensesByCategoryId(id: number): Observable<ExpenseReceive[]> {
    return this.http.get<ExpenseReceive[]>(`https://localhost:7115/api/Category/expenses/${id}`, { headers: this.getHeaders() });
  }

  // ✅ Get expenses by account
  getExpensesByAccountId(id: number): Observable<ExpenseReceive[]> {
    return this.http.get<ExpenseReceive[]>(`https://localhost:7115/api/Account/expenses/${id}`, { headers: this.getHeaders() });
  }

  // ✅ Get category-wise expense totals
  GetTotalCategorylog(): Observable<CategoryTotalDto[]> {
    return this.http.get<CategoryTotalDto[]>(`https://localhost:7115/api/Category/totals`, { headers: this.getHeaders() });
  }
}
