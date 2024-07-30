import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { ProfileComponent } from '../../profile/profile.component';
import { UserService } from '../../../services/user/user.service';
import { OrganizationService } from '../../../services/organization/organization.service';
import {Router, RouterModule} from "@angular/router";
import { UserOrganization } from '../../../models/user.model';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatListModule, MatIconModule, MatButtonModule, RouterModule],
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent extends ProfileComponent {

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

  get totalOrganizations(): number {
    return this.allOrganizations.length;
  }

  get totalUsers(): number {
    return 10;
  }

  createOrganization(): void {
    this.router.navigate(['/organization/create']).then();
  }

  addUser(): void {

  }
}
