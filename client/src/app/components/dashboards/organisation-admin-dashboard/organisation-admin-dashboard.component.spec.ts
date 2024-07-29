import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganisationAdminDashboardComponent } from './organisation-admin-dashboard.component';

describe('OrganisationAdminDashboardComponent', () => {
  let component: OrganisationAdminDashboardComponent;
  let fixture: ComponentFixture<OrganisationAdminDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrganisationAdminDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrganisationAdminDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
