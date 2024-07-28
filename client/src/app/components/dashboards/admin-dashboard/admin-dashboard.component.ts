import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { ProfileComponent } from '../../profile/profile.component';
import { UserService } from '../../../services/user/user.service';
import {Router} from "@angular/router";

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatListModule, MatIconModule, MatButtonModule],
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent extends ProfileComponent {
  totalOrganizations: number = 0;
  totalUsers: number = 0;

  constructor(protected override userService: UserService, protected override router: Router) {
    super(userService, router);
  }

  override ngOnInit(): void {
    super.ngOnInit();
    this.loadAdminDashboardData();
  }

  loadAdminDashboardData(): void {
    // Tu dodaj logikę do pobierania danych dla admina
    // Na razie używamy mocowanych danych
    this.totalOrganizations = 10;
    this.totalUsers = 100;
  }

  createOrganization(): void {
    console.log('Creating new organization');
    // Implementacja tworzenia organizacji
  }

  addOrganizationAdmin(): void {
    console.log('Adding new organization admin');
    // Implementacja dodawania admina organizacji
  }
}
