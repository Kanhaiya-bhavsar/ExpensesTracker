import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewBillButtonComponentComponent } from './view-bill-button-component.component';

describe('ViewBillButtonComponentComponent', () => {
  let component: ViewBillButtonComponentComponent;
  let fixture: ComponentFixture<ViewBillButtonComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewBillButtonComponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewBillButtonComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
