import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { UserService } from '../../../services/user/user.service';
import { Router } from '@angular/router';
import { CreateUserModel } from '../../../models/create-user.model';
import {NotificationService} from "../../../services/notification/notification.service";

@Component({
  selector: 'app-create-user',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatCardModule, MatFormFieldModule, MatInputModule, MatSelectModule,
    MatButtonModule],
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent {
  userForm: FormGroup;
  roles: string[] = ['Admin', 'Doctor', 'Nurse', 'Physiotherapist', 'OrganizationAdmin'];

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router,
    private notificationService: NotificationService
  ) {
    this.userForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
      confirmPassword: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userRole: ['', Validators.required],
      street: ['', Validators.required],
      city: ['', Validators.required],
      zipCode: ['', [Validators.required, Validators.pattern(/^\d{2}-\d{3}$/)]],
      country: ['', Validators.required],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^\+?[0-9]{9,}$/)]],
      pesel: ['', [Validators.required, Validators.pattern(/^[0-9]{11}$/)]]
    }, { validator: this.passwordMatchValidator });
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('password')?.value === g.get('confirmPassword')?.value
      ? null : {'mismatch': true};
  }

  onSubmit() {
    if (this.userForm.valid) {
      const userData: CreateUserModel = {
        email: this.userForm.get('email')?.value,
        password: this.userForm.get('password')?.value,
        firstName: this.userForm.get('firstName')?.value,
        lastName: this.userForm.get('lastName')?.value,
        street: this.userForm.get('street')?.value,
        city: this.userForm.get('city')?.value,
        zipCode: this.userForm.get('zipCode')?.value,
        country: this.userForm.get('country')?.value,
        phoneNumber: this.userForm.get('phoneNumber')?.value,
        pesel: this.userForm.get('pesel')?.value,
        userRole: this.userForm.get('userRole')?.getRawValue()
      };

      this.userService.createUser(userData).subscribe({
        next: () => {
          console.log('User created successfully');
          this.notificationService.showSuccess('User created successfully');
          this.router.navigate(['/all-users']).then();
        },
        error: (error) => {
          console.error('Error creating user', error);
          this.notificationService.showError('Error creating user');
        }
      });
    }
  }
}
