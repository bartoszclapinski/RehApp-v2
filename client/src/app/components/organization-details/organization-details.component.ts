import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { OrganizationService } from '../../services/organization/organization.service';
import { UserService } from '../../services/user/user.service';
import {UserOrganization, BaseUser, Organization} from '../../models/user.model';

@Component({
  selector: 'app-organization-details',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule, FormsModule, MatListModule],
  templateUrl: './organization-details.component.html',
  styleUrls: ['./organization-details.component.css']
})
export class OrganizationDetailsComponent implements OnInit {
  organization: Organization | null = null;
  administrators: BaseUser[] = [];
  isEditing = false;

  constructor(
    private route: ActivatedRoute,
    private organizationService: OrganizationService,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadOrganization(id);
      this.loadAdministrators(id);
    }
  }

  loadOrganization(id: string): void {
    this.organizationService.getOrganizationById(id).subscribe({
      next: (org) => this.organization = org,
      error: (err) => console.error('Failed to load organization', err)
    });
  }

  loadAdministrators(organizationId: string): void {
    this.organizationService.getOrganizationAdministrators(organizationId).subscribe({
      next: (admins) => this.administrators = admins,
      error: (err) => console.error('Failed to load administrators', err)
    });
  }

  toggleEdit(): void {
    this.isEditing = !this.isEditing;
  }

  saveChanges(): void {
    if (this.organization) {
      this.organizationService.updateOrganization(this.organization).subscribe({
        next: (updatedOrganization) => {
          this.organization = updatedOrganization;
          this.isEditing = false;
          console.log('Organization updated:', updatedOrganization);
        },
        error: (err) => console.error('Failed to update organization', err)
      });
    }
  }

  addAdministrator(): void {
    if (this.organization) {
      this.router.navigate(['/add-admin', this.organization.id]).then();
    }
  }

  addUsers(): void {
    if (this.organization) {
      console.log('Navigating to add users with id:', this.organization.id);
      this.router.navigate(['/organization/add-users', this.organization.id]).then();
    }
  }
}
