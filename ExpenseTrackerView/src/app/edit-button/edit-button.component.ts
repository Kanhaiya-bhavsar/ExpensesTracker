import { Component } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';

@Component({
  selector: 'app-edit-button',
  imports: [],
  standalone: true,
  templateUrl: './edit-button.component.html',
  styleUrl: './edit-button.component.css'
})
export class EditButtonComponent implements ICellRendererAngularComp {
  params: any;

  // ✅ AG Grid will call this function to pass row data
  agInit(params: any): void {
    this.params = params;
  }

  oneditClick(){
    this.params.editUser(this.params.data);
  }

  refresh(): boolean {
    return false; // No need to refresh
  }
}
