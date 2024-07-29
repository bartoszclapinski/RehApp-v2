import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { OrganizationService } from '../../services/organization/organization.service';
import { UserOrganization } from '../../models/user.model';

@Component({
  selector: 'app-organization-details',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule, FormsModule],
  templateUrl: './organization-details.component.html',
  styleUrls: ['./organization-details.component.css']
})
export class OrganizationDetailsComponent implements OnInit {
  organization: UserOrganization | null = null;
  isEditing = false;

  constructor(
    private route: ActivatedRoute,
    private organizationService: OrganizationService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadOrganization(id);
    }
  }

  loadOrganization(id: string): void {
    this.organizationService.getOrganizationById(id).subscribe({
      next: (org) => this.organization = org,
      error: (err) => console.error('Failed to load organization', err)
    });
  }

  toggleEdit(): void {
    this.isEditing = !this.isEditing;
  }

  saveChanges(): void {
    // Implementacja zapisu zmian będzie dodana później
    console.log('Saving changes:', this.organization);
    this.isEditing = false;
  }
}
