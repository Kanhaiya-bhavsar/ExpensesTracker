import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  http = inject(HttpClient);
  private baseUrl = 'https://localhost:7115/api/Auth/Login'; // API Endpoint

  loginUser(credentials: any): Observable<any> {
    return this.http.post(this.baseUrl, credentials);
  }
}
