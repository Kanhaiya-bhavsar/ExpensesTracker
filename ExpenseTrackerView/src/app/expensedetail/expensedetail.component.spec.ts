import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpensedetailComponent } from './expensedetail.component';

describe('ExpensedetailComponent', () => {
  let component: ExpensedetailComponent;
  let fixture: ComponentFixture<ExpensedetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExpensedetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExpensedetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
