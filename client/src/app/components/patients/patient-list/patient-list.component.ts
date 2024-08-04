import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule, MatPaginator } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { PatientService } from '../../../services/patient/patient.service';
import { ActivatedRoute, Router } from "@angular/router";
import { Patient } from '../../../models/patient.model';

@Component({
  selector: 'app-patient-list',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatTableModule,
    MatButtonModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule
  ],
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})

export class PatientListComponent implements OnInit {
  dataSource: MatTableDataSource<Patient>;
  displayedColumns: string[] = ['lastName', 'firstName', 'pesel', 'dateOfBirth', 'details'];
  organizationId: string | null = null;
  filterValue: string = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private patientService: PatientService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.dataSource = new MatTableDataSource<Patient>();
  }

  ngOnInit(): void {
    this.organizationId = this.route.snapshot.paramMap.get('id');
    if (this.organizationId) {
      this.loadPatients(this.organizationId);
    }
  }

  loadPatients(organizationId: string): void {
    this.patientService.getPatientsForOrganization(organizationId).subscribe({
      next: (patients) => {
        const formattedPatients = patients.map(patient => ({
          ...patient,
          dateOfBirth: this.formatDate(patient.dateOfBirth)
        }));
        this.dataSource.data = formattedPatients;
        this.dataSource.paginator = this.paginator;
      },
      error: (err) => console.error('Failed to load patients', err)
    });
  }

  viewPatientDetails(patientId: string): void {
    this.router.navigate(['/patient/edit', patientId]).then();
  }

  applyFilter() {
    this.dataSource.filter = this.filterValue.trim().toLowerCase();
  }

  private formatDate(date: string): string {
    return new DatePipe('en-US').transform(date, 'dd-MM-yyyy') || date;
  }
}
