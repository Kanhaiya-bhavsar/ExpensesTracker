import { Component, OnInit, inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { LoginService } from '../services/login.service';
import { RouterLink } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule
  ],
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  loginService = inject(LoginService);
  router = inject(Router);
  formBuilder = inject(FormBuilder);

  loginForm!: FormGroup;

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  // Method to handle login
  onLogin() {
    if (this.loginForm.invalid) return;

    const credentials = this.loginForm.value;
    console.log("🔹 Sending Login Request:", credentials);  // Debugging

    this.loginService.loginUser(credentials).subscribe({
      next: (res) => {
       
        if (res?.jwtToken ) {
          localStorage.setItem('token', res.jwtToken); // Store JWT toke
          this.router.navigate(['/home']);
        } else {
          console.error("❌ Login failed: Invalid response structure", res);
          alert('Invalid credentials. Please try again.');
        }
      },
      error: (err) => {
        console.error('❌ Login Error:', err);
        console.log('🔹 Response body:', err.error);
        alert(err.error || "Invalid login credentials");
      }
    });
  }
}
