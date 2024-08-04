import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule, MatPaginator } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../../services/user/user.service';
import { OrganizationService } from '../../../services/organization/organization.service';
import { Organization } from '../../../models/user.model';
import { RouterModule } from "@angular/router";

@Component({
  selector: 'app-organization-list',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatTableModule, MatButtonModule, RouterModule, MatPaginatorModule, MatFormFieldModule, MatInputModule, FormsModule],
  templateUrl: './organization-list.component.html',
  styleUrls: ['./organization-list.component.css']
})
export class OrganizationListComponent implements OnInit {
  dataSource: MatTableDataSource<Organization>;
  displayedColumns: string[] = ['created', 'name', 'details'];
  filterValue: string = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private userService: UserService,
    private organizationService: OrganizationService
  ) {
    this.dataSource = new MatTableDataSource<Organization>();
  }

  ngOnInit(): void {
    this.loadOrganizations();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  loadOrganizations(): void {
    if (this.userService.user.role === 'Admin') {
      this.organizationService.getOrganizationsForAdmin().subscribe({
        next: (organizations) => this.dataSource.data = organizations,
        error: (err) => console.error('Failed to load organization-list', err)
      });
    } else {
      this.organizationService.getOrganizationsForUser(this.userService.user.id).subscribe({
        next: (organizations) => this.dataSource.data = organizations,
        error: (err) => console.error('Failed to load organization-list', err)
      });
    }
  }

  applyFilter() {
    this.dataSource.filter = this.filterValue.trim().toLowerCase();
  }
}
