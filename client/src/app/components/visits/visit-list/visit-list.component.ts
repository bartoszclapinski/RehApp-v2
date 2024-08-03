import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { VisitService } from '../../../services/visit/visit.service';
import { UserService } from '../../../services/user/user.service';
import { Visit } from '../../../models/visit.model';
import { User } from '../../../models/user.model';

@Component({
  selector: 'app-visit-list',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatTableModule, MatButtonModule],
  templateUrl: './visit-list.component.html',
  styleUrls: ['./visit-list.component.css']
})
export class VisitListComponent implements OnInit {
  visits: Visit[] = [];
  displayedColumns: string[] = ['date', 'patient', 'createdBy', 'details'];
  organizationId: string = '';
  patientId: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private visitService: VisitService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.organizationId = this.route.snapshot.paramMap.get('id') || '';
    this.route.queryParams.subscribe(params => {
      this.patientId = params['patientId'];
      this.loadVisits();
    });
  }

  loadVisits(): void {
    this.userService.getCurrentUser().subscribe((user: User) => {
      if (this.patientId) {
        this.loadVisitsForPatient(user.id);
      } else if (user.role === 'OrganizationAdmin') {
        this.loadAllVisitsForOrganization();
      } else {
        this.loadVisitsForUser(user.id);
      }
    });
  }

  loadVisitsForPatient(userId: string): void {
    this.visitService.getVisitsByPatientIdForUser(this.patientId!, userId).subscribe({
      next: (visits) => {
        this.visits = visits;
      },
      error: (err) => console.error('Failed to load visits for patient', err)
    });
  }

  loadAllVisitsForOrganization(): void {
    this.visitService.getAllVisitsForOrganization(this.organizationId).subscribe({
      next: (visits) => {
        this.visits = visits;
      },
      error: (err) => console.error('Failed to load all visits for organization', err)
    });
  }

  loadVisitsForUser(userId: string): void {
    this.visitService.getVisitsByUserForOrganization(userId, this.organizationId).subscribe({
      next: (visits) => {
        this.visits = visits;
      },
      error: (err) => console.error('Failed to load visits for user', err)
    });
  }

  viewVisitDetails(visitId: string): void {
    this.router.navigate(['/visit/edit', visitId]);
  }
}