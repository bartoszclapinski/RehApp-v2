
import {Component, Inject, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import {MatDialogModule, MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../services/user/user.service';
import { OrganizationService } from '../../services/organization/organization.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-add-user-to-organization',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatTableModule, MatButtonModule, MatDialogModule],
  templateUrl: './add-user-to-organization.component.html',
  styleUrls: ['./add-user-to-organization.component.css']
})
export class AddUserToOrganizationComponent implements OnInit {
  users: User[] = [];
  organizationId: string = '';
  organizationName: string = '';
  displayedColumns: string[] = ['name', 'email', 'role', 'add'];

  constructor(
    private userService: UserService,
    private organizationService: OrganizationService,
    private route: ActivatedRoute,
    private router: Router,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.organizationId = this.route.snapshot.paramMap.get('id') || '';
    this.loadUsers();
    this.loadOrganizationName();
  }

  loadUsers(): void {
    this.organizationService.getAllUsersNotInOrganization(this.organizationId).subscribe({
      next: (users) => {
        this.users = users;
      },
      error: (err) => console.error('Failed to load users', err)
    });
  }

  loadOrganizationName(): void {
    this.organizationService.getOrganizationById(this.organizationId).subscribe({
      next: (org) => {
        this.organizationName = org.name;
      },
      error: (err) => console.error('Failed to load organization name', err)
    });
  }

  addUser(user: User): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { userName: `${user.firstName} ${user.lastName}`, organizationName: this.organizationName }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.organizationService.addUserToOrganization(user.id, this.organizationId).subscribe({
          next: () => {
            console.log('User added to organization successfully');
            this.router.navigate(['/organization/details', this.organizationId]);
          },
          error: (err) => console.error('Failed to add user to organization', err)
        });
      }
    });
  }
}

// Komponent dialogu potwierdzenia
@Component({
  selector: 'app-confirm-dialog',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
  template: `
    <h2 mat-dialog-title>Confirm Action</h2>
    <mat-dialog-content>
      Are you sure you want to add {{data.userName}} to {{data.organizationName}}?
    </mat-dialog-content>
    <mat-dialog-actions>
      <button mat-button [mat-dialog-close]="false">No</button>
      <button mat-button [mat-dialog-close]="true">Yes</button>
    </mat-dialog-actions>
  `,
})
export class ConfirmDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: {userName: string, organizationName: string}) {}
}
