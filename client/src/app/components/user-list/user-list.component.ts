import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { UserService } from '../../services/user/user.service';
import { User } from '../../models/user.model';
import { Router, ActivatedRoute } from "@angular/router";
import { OrganizationService } from "../../services/organization/organization.service";

@Component({
  selector: 'app-users-list',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatTableModule, MatButtonModule],
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UsersListComponent implements OnInit {
  users: User[] = [];
  displayedColumns: string[] = ['name', 'email', 'role', 'details'];
  isAdmin: boolean = false;
  organizationId: string | null = null;
  mode: string | null = null;

  constructor(
    private userService: UserService,
    private organizationService: OrganizationService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.organizationId = params['organizationId'];
      this.mode = params['mode'];
      this.checkUserRoleAndLoadUsers();
    });
  }

  checkUserRoleAndLoadUsers(): void {
    this.userService.getCurrentUser().subscribe({
      next: (user) => {
        this.isAdmin = user.role === 'Admin';
        if (this.mode === 'employees' && this.organizationId) {
          this.loadUsersForOrganization(this.organizationId);
        } else if (this.isAdmin) {
          this.loadAllUsers();
        } else if (user.role === 'OrganizationAdmin') {
          this.loadUsersForOrganizationAdmin(user);
        } else {
          console.log('User is not authorized to view users list');
        }
      },
      error: (err) => console.error('Failed to load user', err)
    });
  }

  loadAllUsers(): void {
    this.userService.getAllUsers().subscribe({
      next: (users) => {
        this.users = users;
      },
      error: (err) => console.error('Failed to load users', err)
    });
  }

  loadUsersForOrganizationAdmin(currentUser: User): void {
    this.organizationService.getOrganizationsForUser(currentUser.id).subscribe({
      next: (organizations) => {
        if (organizations.length > 0) {
          const organizationId = organizations[0].id;
          this.loadUsersForOrganization(organizationId);
        } else {
          console.error('OrganizationAdmin does not have any associated organization');
        }
      },
      error: (err) => console.error('Failed to load organizations for user', err)
    });
  }

  loadUsersForOrganization(organizationId: string): void {
    this.userService.getUsersForOrganization(organizationId).subscribe({
      next: (users) => {
        this.users = users;
      },
      error: (err) => console.error('Failed to load users for organization', err)
    });
  }

  viewUserDetails(userId: string): void {
    this.router.navigate(['/user-profile', userId]).then();
  }
}
