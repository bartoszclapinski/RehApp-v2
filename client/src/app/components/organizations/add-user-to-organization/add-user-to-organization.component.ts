
import {Component, Inject, OnInit, ViewChild} from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginatorModule, MatPaginator } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../../services/user/user.service';
import { OrganizationService } from '../../../services/organization/organization.service';
import { User } from '../../../models/user.model';
import {ConfirmDialogComponent} from "../../common/confirm-dialog.component";

@Component({
  selector: 'app-add-user-to-organization',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatTableModule, MatButtonModule, MatDialogModule, MatPaginatorModule, MatFormFieldModule, MatInputModule, FormsModule],
  templateUrl: './add-user-to-organization.component.html',
  styleUrls: ['./add-user-to-organization.component.css']
})
export class AddUserToOrganizationComponent implements OnInit {
  dataSource: MatTableDataSource<User>;
  organizationId: string = '';
  organizationName: string = '';
  displayedColumns: string[] = ['name', 'email', 'role', 'add'];
  filterValue: string = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private userService: UserService,
    private organizationService: OrganizationService,
    private route: ActivatedRoute,
    private router: Router,
    private dialog: MatDialog
  ) {
    this.dataSource = new MatTableDataSource<User>();
  }

  ngOnInit(): void {
    this.organizationId = this.route.snapshot.paramMap.get('id') || '';
    this.loadUsers();
    this.loadOrganizationName();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  loadUsers(): void {
    this.organizationService.getAllUsersNotInOrganization(this.organizationId).subscribe({
      next: (users) => {
        this.dataSource.data = users;
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
      data: {
        title: 'Confirm Action',
        message: `Are you sure you want to add ${user.firstName} ${user.lastName} to ${this.organizationName}?`
      }
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

  applyFilter() {
    this.dataSource.filter = this.filterValue.trim().toLowerCase();
  }
}
