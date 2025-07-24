
import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgChartsModule } from 'ng2-charts';

import { ChartConfiguration, ChartType } from 'chart.js';
import { ExpenseServiceService } from '../Services/expense-service.service'; 
import { CategoryTotalDto } from '../interfaces/CategoryTotalDto';


@Component({
  selector: 'app-category-pie-chart-component',
  imports: [NgChartsModule,CommonModule],
  templateUrl: './category-pie-chart-component.component.html',
  styleUrl: './category-pie-chart-component.component.css'
})
export class CategoryPieChartComponent implements OnInit {
  private expenseService = inject(ExpenseServiceService);

  pieChartLabels: string[] = [];
  pieChartData: number[] = [];
  pieChartType: ChartType = 'pie';

  pieChartOptions: ChartConfiguration['options'] = {
    responsive: true,
    plugins: {
      legend: {
        position: 'right',
      },
      tooltip: {
        callbacks: {
          label: (ctx) => `${ctx.label}: ${ctx.raw}%`
        }
      }
    }
  };

  ngOnInit(): void {
    this.expenseService.GetTotalCategorylog().subscribe({
      next: (data: CategoryTotalDto[]) => {
        const grandTotal = data.reduce((sum, c) => sum + c.total, 0);

        this.pieChartLabels = data.map(c => c.name);
        this.pieChartData = data.map(c => +((c.total / grandTotal) * 100).toFixed(2));
      },
      error: (err) => {
        console.error('Error fetching category totals:', err);
      }
    });
  }
}

