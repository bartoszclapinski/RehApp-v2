import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { UserService } from '../../services/user/user.service';
import { OrganizationService } from '../../services/organization/organization.service';
import { UserOrganization } from '../../models/user.model';
import {RouterModule} from "@angular/router";

@Component({
  selector: 'app-organizations',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatTableModule, MatButtonModule, RouterModule],
  templateUrl: './organizations.component.html',
  styleUrls: ['./organizations.component.css']
})
export class OrganizationsComponent implements OnInit {
  organizations: UserOrganization[] = [];
  displayedColumns: string[] = ['created', 'name', 'details'];

  constructor(
    private userService: UserService,
    private organizationService: OrganizationService
  ) {}

  ngOnInit(): void {

    this.loadOrganizations();
  }

  loadOrganizations(): void {
    if (this.userService.user.role === 'Admin') {
      this.organizationService.getOrganizationsForAdmin().subscribe({
        next: (organizations) => this.organizations = organizations,
        error: (err) => console.error('Failed to load organizations', err)
      });
    } else {
      this.organizationService.getOrganizationsForUser(this.userService.user.id).subscribe({
        next: (organizations) => this.organizations = organizations,
        error: (err) => console.error('Failed to load organizations', err)
      });
    }
  }
}
