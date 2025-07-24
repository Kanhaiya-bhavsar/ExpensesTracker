import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ClientSideRowModelModule, ModuleRegistry, ColDef } from 'ag-grid-community';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatOptionModule } from '@angular/material/core';

import { AgGridAngular } from 'ag-grid-angular';
import { AgGridModule } from 'ag-grid-angular';

import { ExpenseServiceService } from '../Services/expense-service.service';
import { AccountServiceService } from '../Services/account-service.service';
import { CategoryServiceService } from '../Services/category-service.service';

import { CaroselComponent } from '../carosel/carosel.component';
import { EditButtonComponent } from '../edit-button/edit-button.component';
import {ViewBillButtonComponentComponent} from '../view-bill-button-component/view-bill-button-component.component'
import { DelbuttonComponent } from '../delbutton/delbutton.component';
import { ExpenseSend } from '../interfaces/expense';

ModuleRegistry.registerModules([ClientSideRowModelModule]);

@Component({
  selector: 'app-home',
  standalone: true,
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  imports: [ViewBillButtonComponentComponent,
    CaroselComponent,
    CommonModule,
    AgGridAngular,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatCardModule,
    AgGridModule,
    MatOptionModule
  ]
})
export class HomeComponent implements OnInit {
  expenseForm!: FormGroup;
  rowData: any[] = [];
  accounts: any[] = [];
  categories: any[] = [];
  isFormVisible = true;
  isEditMode = false;
  editExpenseId: number | null = null;
  selectedFile: File | null = null;

  columnDefs: ColDef[] = [
    { field: 'description', headerName: 'Description' },
    { field: 'transactionDate', headerName: 'Date' },
    { field: 'value', headerName: 'Value' },
    { field: 'account.name', headerName: 'Account' },
    { field: 'category.name', headerName: 'Category' },
    {
      field: 'actions',
      headerName: 'Delete',
      cellRenderer: DelbuttonComponent,
      cellRendererParams: {
        deleteUser: this.deleteExpense.bind(this)
      }
    },
    {
      field: 'actions',
      headerName: 'Edit',
      cellRenderer: EditButtonComponent,
      cellRendererParams: {
        editUser: this.editExpense.bind(this)
      }
    },
  {
    headerName: 'Bill',
    field: 'billImgUrl',
    cellRenderer: ViewBillButtonComponentComponent
  },
  ];

  private fb = inject(FormBuilder);
  private expenseService = inject(ExpenseServiceService);
  private accountService = inject(AccountServiceService);
  private categoryService = inject(CategoryServiceService);

  ngOnInit(): void {
    this.expenseForm = this.fb.group({
      id: [0],  
      description: ['', Validators.required],
      transactionDate: ['', Validators.required],
      value: ['', Validators.required],
      accountId: [null, Validators.required],
      categoryId: [null, Validators.required],
      expenseTypeId: [1, Validators.required],
      billImage: ['']
    });

    this.loadExpenses();
    this.loadAccounts();
    this.loadCategories();
  }

  loadExpenses(): void {
    this.expenseService.getAllExpenses().subscribe({
      next: (data: any) => {
        this.rowData = data;
      },
      error: (err: any) => {
        console.error('Error loading expenses:', err);
      }
    });
  }

  loadAccounts(): void {
    this.accountService.getAllAccount().subscribe(data => {
      this.accounts = data;
    });
  }

  loadCategories(): void {
    this.categoryService.getAllCategory().subscribe(data => {
      this.categories = data;
    });
  }

  toggleForm(): void {
    this.resetForm(); // Reset when toggling to avoid leftover data
    this.isFormVisible = !this.isFormVisible;
  }

  editExpense(expense: ExpenseSend) {
    this.expenseForm.patchValue({
      id: expense.id,
      description: expense.description,
      transactionDate: expense.transactionDate,
      value: expense.value,
      accountId: expense.accountId,
      categoryId: expense.categoryId,
      expenseTypeId: expense.expenseTypeId
    });
    this.isEditMode = true;
    this.editExpenseId = expense.id;
  }

  onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    if (file) {
      this.selectedFile = file;
    }
  }

  addOrUpdateExpense() {
    if (this.expenseForm.invalid) return;

    const formData = new FormData();

    if (this.isEditMode && this.editExpenseId) {
      formData.append('Id', this.expenseForm.value.id.toString());
    }

    formData.append('description', this.expenseForm.value.description.trim());
    formData.append('transactionDate', this.expenseForm.value.transactionDate);
    formData.append('value', this.expenseForm.value.value);
    formData.append('accountId', this.expenseForm.value.accountId);
    formData.append('categoryId', this.expenseForm.value.categoryId);
    formData.append('expenseTypeId', this.expenseForm.value.expenseTypeId);

    if (this.selectedFile) {
      formData.append('billImage', this.selectedFile);
    }

    if (this.isEditMode && this.editExpenseId) {
      this.expenseService.updateExpense(this.editExpenseId, formData).subscribe({
        next: () => {
          this.loadExpenses();
          this.resetForm();
        },
        error: (err) => {
          console.error("Error updating expense with image:", err);
        }
      });
    } else {
      this.expenseService.addExpense(formData).subscribe({
        next: () => {
          this.loadExpenses();
          this.resetForm();
        },
        error: (err) => {
          console.error("Error adding expense with image:", err);
        }
      });
    }
  }

  deleteExpense(id: number) {
    this.expenseService.deleteExpense(id).subscribe({
      next: () => {
        this.loadExpenses();
      },
      error: (err) => {
        console.error("Error deleting expense:", err);
      }
    });
  }

  resetForm() {
    this.expenseForm.reset({
      id: 0,
      description: '',
      transactionDate: '',
      value: '',
      accountId: null,
      categoryId: null,
      expenseTypeId: 1,
      billImage: ''
    });
    this.isEditMode = false;
    this.editExpenseId = null;
    this.selectedFile = null;
  }
}
