import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { PatientService } from '../../../services/patient/patient.service';
import { ActivatedRoute, Router } from "@angular/router";
import { DatePipe } from '@angular/common';
import { Patient } from '../../../models/patient.model';

@Component({
  selector: 'app-patient-list',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatTableModule, MatButtonModule],
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css'],
  providers: [DatePipe]
})
export class PatientListComponent implements OnInit {
  patients: Patient[] = [];
  displayedColumns: string[] = ['lastName', 'firstName', 'pesel', 'dateOfBirth', 'details'];
  organizationId: string | null = null;

  constructor(
    private patientService: PatientService,
    private router: Router,
    private route: ActivatedRoute,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    this.organizationId = this.route.snapshot.paramMap.get('id');
    if (this.organizationId) {
      this.loadPatients(this.organizationId);
    }
  }

  loadPatients(organizationId: string): void {
    this.patientService.getPatientsForOrganization(organizationId).subscribe({
      next: (patients) => {
        this.patients = patients.map(patient => ({
          ...patient,
          dateOfBirth: this.datePipe.transform(patient.dateOfBirth, 'dd-MM-yyyy') || patient.dateOfBirth
        }));
      },
      error: (err) => console.error('Failed to load patients', err)
    });
  }

  viewPatientDetails(patientId: string): void {
    this.router.navigate(['/patient/edit', patientId]).then();
  }
}
