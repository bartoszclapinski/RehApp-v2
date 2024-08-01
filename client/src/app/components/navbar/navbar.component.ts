import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, MatToolbarModule, MatButtonModule, MatIconModule, RouterModule],
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  userRole: string = '';

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadUserRole();
  }

  loadUserRole() {
    this.userService.getCurrentUser().subscribe({
      next: (user) => {
        this.userRole = user.role;
      },
      error: (err) => console.error('Failed to load user role', err)
    });
  }

  canViewUsers(): boolean {
    return this.userRole === 'Admin' || this.userRole === 'OrganizationAdmin';
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']).then();
  }

  goToUserProfile(){
    this.router.navigate(['/user-profile']).then();
  }

  goToOrganizations() {
    this.router.navigate(['/organizations']).then();
  }

  goToUsers() {
    this.router.navigate(['/all-users']).then();
  }
}
