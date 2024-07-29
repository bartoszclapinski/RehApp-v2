import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhysiotherapistDashboardComponent } from './physiotherapist-dashboard.component';

describe('PhysiotherapistDashboardComponent', () => {
  let component: PhysiotherapistDashboardComponent;
  let fixture: ComponentFixture<PhysiotherapistDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PhysiotherapistDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PhysiotherapistDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
