import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryPieChartComponentComponent } from './category-pie-chart-component.component';

describe('CategoryPieChartComponentComponent', () => {
  let component: CategoryPieChartComponentComponent;
  let fixture: ComponentFixture<CategoryPieChartComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CategoryPieChartComponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CategoryPieChartComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
