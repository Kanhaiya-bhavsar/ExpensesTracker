import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private apiUrl = 'https://localhost:7115/api/Auth/Register';
  private http = inject(HttpClient);

  registerUser(userData: { Username: string; Password: string; Roles: string[] }): Observable<string> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post<string>(this.apiUrl, userData, {
      headers: headers,
      responseType: 'text' as 'json' // To receive plain text response
    });
  }
}
