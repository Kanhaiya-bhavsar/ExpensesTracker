import { Component, OnInit, inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RegisterService,  } from '../services/register.service';
import { RegisterRequestDto } from '../interfaces/RegisterRequestDto';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';


@Component({
  selector: 'app-register-page',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatCardModule,
    MatSelectModule,
  ],
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css'],
})
export class RegisterPageComponent implements OnInit {
  registerService = inject(RegisterService);
  router = inject(Router);
  formBuilder = inject(FormBuilder);

  registerForm!: FormGroup;
  isSubmitting = false;

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      roles: ['User']
    });
  }

  onRegister() {
    if (this.registerForm.invalid) return;

    this.isSubmitting = true;

    const requestData: RegisterRequestDto = {
      Username: this.registerForm.value.username,
      Password: this.registerForm.value.password,
      Roles: [this.registerForm.value.roles]
    };

    console.log('Calling Register API with:', requestData);

    this.registerService.registerUser(requestData).subscribe({
      next: (res) => {
        console.log('Registration success:', res);
        alert('User registered successfully!');
        this.router.navigate(['/']);
        this.isSubmitting = false;
      },
      error: (err) => {
        console.error('Registration error:', err);
        alert('Registration failed. Please check backend logs or CORS settings.');
        this.isSubmitting = false;
      }
    });
  }
}
