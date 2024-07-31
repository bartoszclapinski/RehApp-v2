import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { UserService } from '../../services/user/user.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  userForm: FormGroup;
  isEditing = false;

  constructor(private fb: FormBuilder, private userService: UserService) {
    this.userForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      role: ['', Validators.required],
      street: ['', Validators.required],
      city: ['', Validators.required],
      zipCode: ['', [Validators.required, Validators.pattern(/^\d{2}-\d{3}$/)]],
      country: ['', Validators.required]
    });
    this.userForm.disable();
  }

  ngOnInit(): void {
    this.loadUserProfile();
  }

  loadUserProfile(): void {
    this.userService.getCurrentUser().subscribe({
      next: (user: User) => {
        this.userForm.patchValue({
          email: user.email,
          firstName: user.firstName,
          lastName: user.lastName,
          role: user.role,
          street: user.address.street,
          city: user.address.city,
          zipCode: user.address.zipCode,
          country: user.address.country
        });
      },
      error: (err) => console.error('Failed to load user profile', err)
    });
  }

  toggleEdit(): void {
    this.isEditing = !this.isEditing;
    if (this.isEditing) {
      this.userForm.enable();
      this.userForm.get('email')?.disable();
      this.userForm.get('role')?.disable();
    } else {
      this.userForm.disable();
    }
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      const updatedUser = {
        ...this.userForm.value,
        address: {
          street: this.userForm.value.street,
          city: this.userForm.value.city,
          zipCode: this.userForm.value.zipCode,
          country: this.userForm.value.country
        }
      };
      this.userService.updateUserProfile(updatedUser).subscribe({
        next: () => {
          console.log('Profile updated successfully');
          this.toggleEdit();
        },
        error: (err) => console.error('Failed to update profile', err)
      });
    }
  }

  cancelEdit(): void {
    this.toggleEdit();
    this.loadUserProfile();
  }
}
