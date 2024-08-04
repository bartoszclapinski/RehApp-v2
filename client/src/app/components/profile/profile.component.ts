import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { UserService } from '../../services/user/user.service';
import {Organization, User, UserOrganization} from '../../models/user.model';
import { Router } from '@angular/router';
import {OrganizationService} from "../../services/organization/organization.service";
import {ConsoleLogger} from "@angular/compiler-cli";

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatListModule, MatIconModule, MatButtonModule],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  user: User | null = null;
  error: string | null = null;
  userOrganizations: Organization[] = [];
  allOrganizations: Organization[] = [];

  constructor(
    protected userService: UserService,
    protected router: Router,
    protected organizationService: OrganizationService
  ) { }

  ngOnInit(): void {
    this.loadUserProfile();
  }

  loadUserProfile(): void {
    this.userService.getCurrentUser().subscribe({
      next: (user: User) => {
        this.user = user;
        if (user.role === 'Admin') this.loadAllOrganizations();
        else this.loadOrganizationsForUser(user.id);
        this.redirectBasedOnRole(user.role);
      },
      error: (err) => {
        this.error = 'Failed to load user profile';
        console.error(err);
      }
    });
  }

  loadOrganizationsForUser(userId: string): void {
    this.organizationService.getOrganizationsForUser(userId).subscribe({
      next: (organizations) => {
        this.userOrganizations = organizations;
      },
      error: (err) => {
        console.error('Failed to load all organization-list', err);
      }
    });
  }

  loadAllOrganizations(): void {
    this.organizationService.getOrganizationsForAdmin().subscribe({
      next: (organizations) => {
        this.allOrganizations = organizations;
      },
      error: (err) => {
        console.error('Failed to load all organization-list', err);
      }
    });
  }

  private redirectBasedOnRole(role: string): void {
    switch (role) {
      case "Admin":
        this.router.navigate(['/admin-dashboard']);
        break;
      case "Doctor":
        this.router.navigate(['/doctor-dashboard']);
        break;
      case "Physiotherapist":
        this.router.navigate(['/physiotherapist-dashboard']);
        break;
      case "OrganizationAdmin":
        this.router.navigate(['/organization-admin-dashboard']);
        break;
      default:
        // Pozostań na stronie profilu dla innych ról
        break;
    }
  }
}
