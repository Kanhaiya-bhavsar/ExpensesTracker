import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DelbuttonComponent } from './delbutton.component';

describe('DelbuttonComponent', () => {
  let component: DelbuttonComponent;
  let fixture: ComponentFixture<DelbuttonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DelbuttonComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DelbuttonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
