import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { UserService } from '../../services/user/user.service';
import {AdminUser, DoctorUser, NurseUser, User} from '../../models/user.model';
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  userId: string | null = null;
  userForm: FormGroup;
  isEditing = false;
  userType: 'base' | 'doctor' | 'nurse' | 'admin' = 'base';

  constructor(private fb: FormBuilder, private userService: UserService, private route: ActivatedRoute) {
    this.userForm = this.fb.group({
      id: ['', Validators.required],
      email: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      pesel: ['', Validators.required],
      role: ['', Validators.required],
      street: ['', Validators.required],
      city: ['', Validators.required],
      zipCode: ['', [Validators.required, Validators.pattern(/^\d{2}-\d{3}$/)]],
      country: ['', Validators.required],
      specialization: [''],
      licenseNumber: [''],
      department: [''],
      adminLevel: ['']
    });
    this.userForm.disable();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.userId = params.get('id');
      this.loadUserProfile();
    });
  }

  loadUserProfile(): void {
    const userObservable = this.userId
      ? this.userService.getUserById(this.userId)
      : this.userService.getCurrentUser();

    userObservable.subscribe({
      next: (user: User) => {
        this.userForm.patchValue({
          id: user.id,
          email: user.email,
          firstName: user.firstName,
          lastName: user.lastName,
          phoneNumber: user.phoneNumber,
          pesel: user.pesel,
          role: user.role,
          street: user.address.street,
          city: user.address.city,
          zipCode: user.address.zipCode,
          country: user.address.country
        });

        if (user.role === 'Doctor' || user.role === 'Physiotherapist') {
          this.userForm.patchValue({
            specialization: (user as any).specialization,
            licenseNumber: (user as any).licenseNumber
          });
          this.userType = 'doctor';
        } else if (user.role === 'Nurse') {
          this.userForm.patchValue({
            department: (user as any).department,
            licenseNumber: (user as any).licenseNumber
          });
          this.userType = 'nurse';
        } else if (user.role === 'OrganizationAdmin' || user.role === 'Admin') {
          this.userForm.patchValue({
            adminLevel: (user as any).adminLevel
          });
          this.userType = 'admin';
        }
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
      this.userForm.get('id')?.disable();
      this.userForm.get('pesel')?.disable();
      if (this.userType === 'doctor' || this.userType === 'nurse') {
        this.userForm.get('licenseNumber')?.disable();
      }
      if (this.userType === 'doctor') {
        this.userForm.get('specialization')?.disable();
      }
      if (this.userType === 'nurse') {
        this.userForm.get('department')?.disable();
      }
      if (this.userType === 'admin') {
        this.userForm.get('adminLevel')?.enable();
      }
    } else {
      this.userForm.disable();
    }
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      const formValue = this.userForm.getRawValue();
      const updatedUser: User = {
        id: formValue.id,
        firstName: formValue.firstName,
        lastName: formValue.lastName,
        phoneNumber: formValue.phoneNumber,
        pesel: formValue.pesel,
        role: formValue.role,
        email: this.userService.user.email, // Użyj aktualnego adresu e-mail
        createdAt: this.userService.user.createdAt, // Użyj aktualnej daty utworzenia
        lastLoginAt: this.userService.user.lastLoginAt, // Użyj aktualnej daty ostatniego logowania
        isActive: this.userService.user.isActive, // Użyj aktualnego statusu aktywności
        address: {
          street: formValue.street,
          city: formValue.city,
          zipCode: formValue.zipCode,
          country: formValue.country
        },
        userOrganizations: this.userService.user.userOrganizations // Użyj aktualnych organizacji użytkownika
      };

      // Dodaj pola specyficzne dla roli
      if (this.userType === 'doctor') {
        (updatedUser as DoctorUser).specialization = formValue.specialization;
        (updatedUser as DoctorUser).licenseNumber = formValue.licenseNumber;
      } else if (this.userType === 'nurse') {
        (updatedUser as NurseUser).department = formValue.department;
        (updatedUser as NurseUser).licenseNumber = formValue.licenseNumber;
      } else if (this.userType === 'admin') {
        (updatedUser as AdminUser).adminLevel = formValue.adminLevel;
      }

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
