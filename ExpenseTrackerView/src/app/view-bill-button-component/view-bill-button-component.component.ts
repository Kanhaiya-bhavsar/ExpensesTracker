import { Component } from '@angular/core';

  import { ICellRendererAngularComp } from 'ag-grid-angular';
@Component({
  selector: 'app-view-bill-button-component',
  standalone:true,
  imports: [],
  templateUrl: './view-bill-button-component.component.html',
  styleUrl: './view-bill-button-component.component.css'
})
export class ViewBillButtonComponentComponent implements ICellRendererAngularComp {

  
  
    private params: any;
  
    agInit(params: any): void {
      this.params = params;
    }
  
    refresh(): boolean {
      return false;
    }
  
    viewBill(): void {
      const url = this.params.data.billImgUrl;
      if (url) {
        window.open(url, '_blank');
      } else {
        alert('No bill image available.');
      }
    }
  }
  

