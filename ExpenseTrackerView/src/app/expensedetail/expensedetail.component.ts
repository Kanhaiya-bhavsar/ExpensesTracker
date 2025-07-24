import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CommonModule } from '@angular/common';
import { ClientSideRowModelModule, ModuleRegistry, ColDef } from 'ag-grid-community';                  
import { AgGridAngular } from 'ag-grid-angular';
import { AgGridModule } from 'ag-grid-angular';
import { ExpenseServiceService } from '../Services/expense-service.service';
                         
ModuleRegistry.registerModules([ClientSideRowModelModule]);
@Component({
  selector: 'app-expensedetail',
  standalone: true,
  imports: [  CommonModule,
    AgGridAngular,
    AgGridModule 
  ],
  templateUrl: './expensedetail.component.html',
  styleUrl: './expensedetail.component.css'
})
export class ExpensedetailComponent  implements OnInit {
  rowData: any[] = [];
  columnDefs: ColDef[] = [
    { field: 'description', headerName: 'Description' },
    { field: 'transactionDate', headerName: 'Date' },
    { field: 'value', headerName: 'Value' },
    { field: 'account.name', headerName: 'Account' },
    { field: 'category.name', headerName: 'Category' }
    
  ];
  private expenseService = inject(ExpenseServiceService);
  private route = inject(ActivatedRoute);

  id!: number;
  type!: 'account' | 'category';



  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      this.id = idParam ? +idParam : 0;

      if (this.route.snapshot.routeConfig?.path?.includes('account')) {
        this.type = 'account';
        this.expenseService.getExpensesByAccountId(this.id).subscribe(
          data => {
            this.rowData = data;
          }
        );
      } else if (this.route.snapshot.routeConfig?.path?.includes('category')) {
        this.type = 'category';
        this.expenseService.getExpensesByCategoryId(this.id).subscribe(
          data => {
            this.rowData = data;
          }
        );
      }
    });



 
  }
}
