// edit-visit.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VisitService } from '../../../services/visit/visit.service';
import { UserService } from '../../../services/user/user.service';
import {Visit, VisitUpdate} from '../../../models/visit.model';
import { User } from '../../../models/user.model';

@Component({
  selector: 'app-edit-visit',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  templateUrl: './edit-visit.component.html',
  styleUrls: ['./edit-visit.component.css']
})
export class EditVisitComponent implements OnInit {
  visitForm: FormGroup;
  visitId: string = '';
  visit: Visit | null = null;
  currentUser: User | null = null;
  isEditing = false;
  canEdit = false;

  constructor(
    private fb: FormBuilder,
    private visitService: VisitService,
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.visitForm = this.fb.group({
      visitDate: [{value: '', disabled: true}, Validators.required],
      description: [{value: '', disabled: true}, Validators.required],
      patientName: [{value: '', disabled: true}],
      createdByName: [{value: '', disabled: true}]
    });
  }

  ngOnInit() {
    this.visitId = this.route.snapshot.paramMap.get('id') || '';
    this.loadCurrentUser();
  }

  loadCurrentUser() {
    this.userService.getCurrentUser().subscribe({
      next: (user: User) => {
        this.currentUser = user;
        this.loadVisitData();
      },
      error: (err) => console.error('Failed to load current user', err)
    });
  }

  loadVisitData() {
    this.visitService.getVisitById(this.visitId).subscribe({
      next: (visit: Visit) => {
        this.visit = visit;
        console.log('Visit data loaded: ', visit);
        this.visitForm.patchValue({
          visitDate: visit.date,
          description: visit.description,
          patientName: `${visit.patient.firstName} ${visit.patient.lastName}`,
          createdByName: `${visit.user.firstName} ${visit.user.lastName}`
        });
        this.checkEditPermission();
      },
      error: (err) => console.error('Failed to load visit data', err)
    });
  }

  checkEditPermission() {
    this.canEdit = this.currentUser?.role === 'OrganizationAdmin' || this.visit?.user.id === this.currentUser?.id;
  }

  toggleEdit() {
    if (!this.canEdit) {
      console.log('You do not have permission to edit this visit.');
      return;
    }
    this.isEditing = !this.isEditing;
    if (this.isEditing) {
      this.visitForm.get('visitDate')?.enable();
      this.visitForm.get('description')?.enable();
    } else {
      this.visitForm.get('visitDate')?.disable();
      this.visitForm.get('description')?.disable();
    }
  }

  onSubmit() {
    if (this.visitForm.valid && this.visit) {
      const updatedVisit: VisitUpdate = {
        id: this.visit.id,
        date: new Date(this.visitForm.get('visitDate')?.value).toISOString(),
        description: this.visitForm.get('description')?.value
      };

      console.log('Updating visit: ', updatedVisit);

      this.visitService.updateVisit(updatedVisit).subscribe({
        next: () => {
          console.log('Visit updated successfully');
          this.toggleEdit();
          this.loadVisitData();
        },
        error: (error) => {
          console.error('Error updating visit', error);
        }
      });
    }
  }

  cancelEdit() {
    this.toggleEdit();
    this.loadVisitData();
  }
}
