
export interface ExpenseSend {
    id: number;
    description: string;
    transactionDate: string; // ISO string format for DateTime
    value: number;
  
    accountId: number;
  
    categoryId: number;

  
    expenseTypeId: number;

  }

 // src/app/interfaces/expense.ts

export interface ExpenseReceive {
    id: number;
    description: string;
    transactionDate: string; // ISO string format for DateTime
    value: number;
  
    accountId: number;
    account: Account;
  
    categoryId: number;
    category: Category;
  
    expenseTypeId: number;
    expenseType: ExpenseType;
    billImgUrl?: string;
    
  }
  
  export interface Account {
    id: number;
    name: string;
    // Add other properties as per your .NET Account model4
  }
  
  export interface Category {
    id: number;
    name: string;
    // Add other properties as per your .NET Category model
  }
  
  export interface ExpenseType {
    id: number;
    name: string;
    // Add other properties as per your .NET ExpenseType model
  }
  
  
  
  


