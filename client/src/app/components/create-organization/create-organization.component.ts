import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { OrganizationService } from '../../services/organization/organization.service';
import {CreateOrganization} from "../../models/organization.model";

@Component({
  selector: 'app-create-organization',
  standalone: true,
  imports: [CommonModule, FormsModule, MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './create-organization.component.html',
  styleUrls: ['./create-organization.component.css']
})
export class CreateOrganizationComponent {
  newOrganization: CreateOrganization = {
    name: '',
    description: '',
    street: '',
    city: '',
    zipCode: '',
    country: ''
  };


  constructor(
    private organizationService: OrganizationService,
    private router: Router
  ) {}

  createOrganization(): void {
    this.organizationService.createOrganization(this.newOrganization).subscribe({
      next: (createdOrg) => {
        console.log('Organization created:', createdOrg);
        this.router.navigate(['/profile']);
      },
      error: (err) => console.error('Failed to create organization', err)
    });
  }
}
