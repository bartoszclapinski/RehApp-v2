import { Component } from '@angular/core';
import {ProfileComponent} from "../../profile/profile.component";
import { MatCardModule} from "@angular/material/card";
import {UserService} from "../../../services/user/user.service";
import {Router} from "@angular/router";
import {OrganizationService} from "../../../services/organization/organization.service";
import {CommonModule} from "@angular/common";
import {MatListModule} from "@angular/material/list";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";

@Component({
  selector: 'app-organization-admin-dashboard',
  standalone: true,
  imports: [ CommonModule, MatCardModule, MatListModule, MatIconModule, MatButtonModule ],
  templateUrl: './organisation-admin-dashboard.component.html',
  styleUrl: '../doctor-dashboard/doctor-dashboard.component.css'
})

export class OrganisationAdminDashboardComponent extends ProfileComponent{
  constructor(
    protected override userService: UserService,
    protected override router: Router,
    protected override organizationService: OrganizationService
  ) {
    super(userService, router, organizationService);
  }

  override ngOnInit(): void {
    super.ngOnInit();
  }

  get totalPatients(): number {
    return 10;
  }

  get totalVisits(): number {
    return 10;
  }
}
