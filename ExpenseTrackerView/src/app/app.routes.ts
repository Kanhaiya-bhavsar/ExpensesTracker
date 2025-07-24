import { Routes } from '@angular/router';
import { ExpensedetailComponent } from './expensedetail/expensedetail.component';

export const routes: Routes = [
  { path: '',
  loadComponent: () => import('./login-page/login-page.component').then(m => m.LoginPageComponent)
   }, // Default route
   { path: 'register',
  loadComponent: () => import('./register-page/register-page.component').then(m => m.RegisterPageComponent)
   },
  {
    path: 'home',
    loadComponent: () => import('./home/home.component').then(m => m.HomeComponent)
  },
  {
    path: 'about',
    loadComponent: () => import('./about-page/about-page.component').then(m => m.AboutPageComponent)
  },
  {
    path: 'category',
    loadComponent: () => import('./category-page/category-page.component').then(m => m.CategoryPageComponent)
  },
  {
    path: 'account',
    loadComponent: () => import('./account-page/account-page.component').then(m => m.AccountPageComponent)
  },
  {
    path: 'graph',
    loadComponent: () => import('./category-pie-chart-component/category-pie-chart-component.component').then(m => m.CategoryPieChartComponent)
  },
  {
    path:'expenses/account/:id',
    loadComponent: () =>import('./expensedetail/expensedetail.component').then(m=>m.ExpensedetailComponent)
  },
  {
    path:'expenses/category/:id',
    loadComponent: () =>import('./expensedetail/expensedetail.component').then(m=>m.ExpensedetailComponent)
  },

 
];
