import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { UserService } from '../../services/user/user.service';
import { User } from '../../models/user.model';
import {Router} from "@angular/router";

@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  user: User = {} as User;
  isEditing = false;

  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(): void {
    this.user = this.userService.user;
    if (!this.user) {
      this.loadUserProfile();
    }
  }

  loadUserProfile(): void {
    this.userService.getCurrentUser().subscribe({
      next: (user) => {
        this.user = user;
      },
      error: (err) => {
        console.error('Failed to load user profile', err);
      }
    });
  }

  toggleEdit(): void {
    this.isEditing = !this.isEditing;
  }

  saveProfile(): void {
    if (this.user) {
      this.userService.updateUserProfile(this.user).subscribe({
        next: (updatedUser) => {
          this.user = updatedUser;
          this.isEditing = false;
          console.log('Profile updated successfully');
          this.router.navigate(['/profile']).then();
        },
        error: (err) => {
          console.error('Failed to update profile', err);
        }
      });
    }
  }

  cancelEdit(): void {
    this.isEditing = false;
    this.loadUserProfile();
  }
}
