import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { PatientService } from '../../../services/patient/patient.service';
import { UserService } from '../../../services/user/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../../../models/user.model';
import { Patient } from '../../../models/patient.model';
import {NotificationService} from "../../../services/notification/notification.service";

@Component({
  selector: 'app-edit-patient',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  templateUrl: './edit-patient.component.html',
  styleUrls: ['./edit-patient.component.css']
})
export class EditPatientComponent implements OnInit {
  patientForm: FormGroup;
  doctors: User[] = [];
  nurses: User[] = [];
  physiotherapists: User[] = [];
  patientId: string = '';
  organizationId: string = '';
  isEditing: boolean = false;
  currentUser: User | null = null;
  canEdit: false | boolean | undefined = false;
  canAddVisit: boolean = false;

  constructor(
    private fb: FormBuilder,
    private patientService: PatientService,
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private notificationService: NotificationService
  ) {
    this.patientForm = this.fb.group({
      firstName: [{value: '', disabled: true}, Validators.required],
      lastName: [{value: '', disabled: true}, Validators.required],
      dateOfBirth: [{value: '', disabled: true}, Validators.required],
      conditionDescription: [{value: '', disabled: true}, Validators.required],
      street: [{value: '', disabled: true}, Validators.required],
      city: [{value: '', disabled: true}, Validators.required],
      zipCode: [{value: '', disabled: true}, [Validators.required, Validators.pattern(/^\d{2}-\d{3}$/)]],
      country: [{value: '', disabled: true}, Validators.required],
      pesel: [{value: '', disabled: true}, [Validators.required, Validators.pattern(/^[0-9]{11}$/)]],
      phoneNumber: [{value: '', disabled: true}, [Validators.required, Validators.pattern(/^\+?[0-9]{9,}$/)]],
      physiotherapistId: [{value: '', disabled: true}],
      doctorId: [{value: '', disabled: true}],
      nurseId: [{value: '', disabled: true}]
    });
  }

  ngOnInit() {
    this.patientId = this.route.snapshot.paramMap.get('id') || '';
    this.loadCurrentUser();

  }

  loadCurrentUser() {
    this.userService.getCurrentUser().subscribe({
      next: (user: User) => {
        this.currentUser = user;
        this.loadPatientData();
      },
      error: (err) => console.error('Failed to load current user', err)
    });
  }

  loadPatientData() {
    this.patientService.getPatientById(this.patientId).subscribe({
      next: (patient: Patient) => {
        this.patientForm.patchValue({
          ...patient,
          street: patient.address.street,
          city: patient.address.city,
          zipCode: patient.address.zipCode,
          country: patient.address.country
        });
        this.organizationId = patient.organizationId || '';
        this.checkEditPermission();
        this.loadUsers();
        this.checkAddVisitPermission();
      },
      error: (err) => console.error('Failed to load patient data', err)
    });
  }

  checkEditPermission() {
    this.canEdit = this.currentUser?.role === 'OrganizationAdmin' &&
      this.currentUser?.userOrganizations.some(org => org.organizationId === this.organizationId);
    if (!this.canEdit) {
      this.patientForm.disable();
    }
  }

  loadUsers(){
    this.userService.getUsersForOrganization(this.organizationId).subscribe({
      next: (users) => {
        this.doctors = users.filter(u => u.role === 'Doctor');
        this.nurses = users.filter(u => u.role === 'Nurse');
        this.physiotherapists = users.filter(u => u.role === 'Physiotherapist');
      },
      error: (err) => console.error('Failed to load users', err)
    });
  }

  toggleEdit() {
    if (!this.canEdit) {
      console.log('You do not have permission to edit this patient.');
      return;
    }
    this.isEditing = !this.isEditing;
    if (this.isEditing) {
      this.patientForm.enable();
    } else {
      this.patientForm.disable();
    }
  }

  onSubmit() {
    if (this.patientForm.valid) {
      const formValue = this.patientForm.value;
      const patientData: Patient = {
        id: this.patientId,
        firstName: formValue.firstName,
        lastName: formValue.lastName,
        dateOfBirth: new Date(formValue.dateOfBirth).toISOString(),
        conditionDescription: formValue.conditionDescription,
        address: {
          street: formValue.street,
          city: formValue.city,
          zipCode: formValue.zipCode,
          country: formValue.country
        },
        pesel: formValue.pesel,
        phoneNumber: formValue.phoneNumber,
        organizationId: this.organizationId,
        physiotherapistId: formValue.physiotherapistId || undefined,
        doctorId: formValue.doctorId || undefined,
        nurseId: formValue.nurseId || undefined
      };

      this.patientService.updatePatient(patientData).subscribe({
        next: () => {
          console.log('Patient updated successfully');
          this.notificationService.showSuccess('Patient updated successfully');
          this.toggleEdit();
          this.loadPatientData();
        },
        error: (error) => {
          console.error('Error updating patient', error);
          this.notificationService.showError('Failed to update patient');
        }
      });
    }
  }

  checkAddVisitPermission() {
    const allowedRoles = ['Doctor', 'Nurse', 'Physiotherapist'];
    this.canAddVisit = allowedRoles.includes(this.currentUser?.role || '');
  }

  addVisit() {
    if (this.canAddVisit) {
      this.router.navigate(['/visit/add'], {
        queryParams: {
          patientId: this.patientId,
          organizationId: this.organizationId
        }
      });
    }
  }

  allVisits() {
    this.router.navigate(['/organization', this.organizationId, 'visits'], {
      queryParams: { patientId: this.patientId }
    });
  }

  cancelEdit() {
    this.toggleEdit();
    this.loadPatientData();
  }
}
