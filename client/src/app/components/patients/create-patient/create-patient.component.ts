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

@Component({
  selector: 'app-create-patient',
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
  templateUrl: './create-patient.component.html',
  styleUrls: ['./create-patient.component.css']
})
export class CreatePatientComponent implements OnInit {
  patientForm: FormGroup;
  doctors: User[] = [];
  nurses: User[] = [];
  physiotherapists: User[] = [];
  organizationId: string = '';

  constructor(
    private fb: FormBuilder,
    private patientService: PatientService,
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.patientForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      conditionDescription: ['', Validators.required],
      street: ['', Validators.required],
      city: ['', Validators.required],
      zipCode: ['', [Validators.required, Validators.pattern(/^\d{2}-\d{3}$/)]],
      country: ['', Validators.required],
      pesel: ['', [Validators.required, Validators.pattern(/^[0-9]{11}$/)]],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^\+?[0-9]{9,}$/)]],
      physiotherapistId: [''],
      doctorId: [''],
      nurseId: ['']
    });
  }

  ngOnInit() {
    this.organizationId = this.route.snapshot.paramMap.get('id') || '';
    this.loadUsers();
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

  onSubmit() {
    if (this.patientForm.valid) {
      const formValue = this.patientForm.value;
      formValue.dateOfBirth = new Date(formValue.dateOfBirth).toISOString();
      const patientData = {
        ...formValue,
        dateOfBirth: formValue.dateOfBirth,
        organizationId: this.organizationId
      };

      if (patientData.physiotherapistId === '') delete patientData.physiotherapistId;
      if (patientData.doctorId === '') delete patientData.doctorId;
      if (patientData.nurseId === '') delete patientData.nurseId;

      this.patientService.createPatient(patientData).subscribe({
        next: () => {
          console.log('Patient created successfully');
          this.router.navigate(['/organization/details', this.organizationId]).then();
        },
        error: (error) => {
          console.error('Error creating patient', error);
        }
      });
    }
  }
}
