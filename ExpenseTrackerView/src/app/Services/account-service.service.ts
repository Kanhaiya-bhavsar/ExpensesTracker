import { Injectable, inject } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Account } from '../interfaces/account';  // ✅ Use only Account interface

@Injectable({
  providedIn: 'root'
})
export class AccountServiceService {
  private getHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');  // Get token from localStorage
    return new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });
  }
  private apiUrl = 'https://localhost:7115/api/Account';
  private http = inject(HttpClient);

  constructor() {}

  // ✅ Fetch all accounts
  getAllAccount(): Observable<Account[]> {
    return this.http.get<Account[]>(this.apiUrl, { headers: this.getHeaders() });
  }

  // ✅ Get account by ID
  getAccountById(id: number): Observable<Account> {
    return this.http.get<Account>(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }

  // ✅ Add a new account
  addAccount(account: Account): Observable<Account> {
    return this.http.post<Account>(this.apiUrl, account, { headers: this.getHeaders() });
  }

  // ✅ Update an existing account
  updateAccount(id: number, account: Account): Observable<Account> {
    return this.http.put<Account>(`${this.apiUrl}/${id}`, account, { headers: this.getHeaders() });
  }

  // ✅ Delete an account
  deleteAccount(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }
}
