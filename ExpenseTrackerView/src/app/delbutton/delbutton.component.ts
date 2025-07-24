import { Component } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';

@Component({
  selector: 'app-delbutton',
  standalone: true,
  templateUrl: './delbutton.component.html',
  styleUrls: ['./delbutton.component.css']
})
export class DelbuttonComponent implements ICellRendererAngularComp {
  params: any;

  // ✅ AG Grid will call this function to pass row data
  agInit(params: any): void {
    this.params = params;
  }

  onDeleteClick() {
   
    this.params.deleteUser(this.params.data.id); // ✅ Call deleteUser with ID
  }

  refresh(): boolean {
    return false; // No need to refresh
  }
}
