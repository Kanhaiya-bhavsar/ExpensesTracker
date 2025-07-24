import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';

import { AccountServiceService } from '../Services/account-service.service';
import { Account } from '../interfaces/account';

@Component({
  selector: 'app-account-page',
  standalone: true,
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.css'],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatDividerModule
  ]
})
export class AccountPageComponent implements OnInit {
  private accountService = inject(AccountServiceService);
  private fb = inject(FormBuilder);
  private router = inject(Router);

  accounts: Account[] = [];
  accountForm!: FormGroup;
  editingId: number | null = null;

  ngOnInit(): void {
    this.accountForm = this.fb.group({
      name: ['', Validators.required],
      balance: [0, [Validators.required]]
    });

    this.loadAccounts();
  }

  loadAccounts(): void {
    this.accountService.getAllAccount().subscribe((data) => {
      this.accounts = data;
    });
  }

  submitForm(): void {
    const { name, balance } = this.accountForm.value;

    if (this.editingId === null) {
      this.accountService.addAccount({ id: 0, name, balance }).subscribe(() => {
        this.accountForm.reset();
        this.loadAccounts();
      });
    } else {
      this.accountService.updateAccount(this.editingId, { id: this.editingId, name, balance }).subscribe(() => {
        this.editingId = null;
        this.accountForm.reset();
        this.loadAccounts();
      });
    }
  }

  editAccount(account: Account): void {
    this.editingId = account.id;
    this.accountForm.patchValue({ name: account.name, balance: account.balance });
  }

  deleteAccount(id: number): void {
    this.accountService.deleteAccount(id).subscribe(() => {
      this.loadAccounts();
    });
  }

  viewExpenses(accountId: number): void {
   
    this.router.navigate(['/expenses/account', accountId]);
  }
}
