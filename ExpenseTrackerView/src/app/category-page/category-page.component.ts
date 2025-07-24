import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

// Angular Material Modules
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';

// Services and Models
import { CategoryServiceService } from '../Services/category-service.service';
import { Category } from '../interfaces/expense';

@Component({
  selector: 'app-category-page',
  standalone: true,
  templateUrl: './category-page.component.html',
  styleUrls: ['./category-page.component.css'],
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
export class CategoryPageComponent implements OnInit {
  private categoryService = inject(CategoryServiceService);
  private fb = inject(FormBuilder);
  private router = inject(Router);

  categories: Category[] = [];
  categoryForm!: FormGroup;
  editingId: number | null = null;

  ngOnInit(): void {
    this.categoryForm = this.fb.group({
      name: ['', Validators.required]
    });

    this.loadCategories();
  }

  loadCategories(): void {
    this.categoryService.getAllCategory().subscribe((data) => {
      this.categories = data;
    });
  }

  submitForm(): void {
    const name = this.categoryForm.value.name;

    if (this.editingId === null) {
      this.categoryService.addCategory({ id: 0, name }).subscribe(() => {
        this.categoryForm.reset();
        this.loadCategories();
      });
    } else {
      this.categoryService.updateCategory(this.editingId, { id: this.editingId, name }).subscribe(() => {
        this.editingId = null;
        this.categoryForm.reset();
        this.loadCategories();
      });
    }
  }

  editCategory(category: Category): void {
    this.editingId = category.id;
    this.categoryForm.patchValue({ name: category.name });
  }

  deleteCategory(id: number): void {
    this.categoryService.deleteCategory(id).subscribe(() => {
      this.loadCategories();
    });
  }

  viewExpenses(categoryId: number): void {
    this.router.navigate(['/expenses/category', categoryId]);
    
    
  }
}
