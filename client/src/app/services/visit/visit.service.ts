// src/app/services/visit/visit.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Visit, VisitToAdd, VisitUpdate} from '../../models/visit.model';

@Injectable({
  providedIn: 'root'
})
export class VisitService {
  private apiUrl = 'https://localhost:7000/api';

  constructor(private http: HttpClient) { }

  createVisit(visit: VisitToAdd): Observable<VisitToAdd> {
    console.log("Adding visit: ", visit);
    return this.http.post<VisitToAdd>(`${this.apiUrl}/visits/add-visit`, visit);
  }

  getVisitsByUserForOrganization(userId: string, organizationId: string): Observable<Visit[]> {
    return this.http.get<Visit[]>(`${this.apiUrl}/visits/user/${userId}/organization/${organizationId}`);
  }

  updateVisit(visit: VisitUpdate): Observable<VisitUpdate> {
    console.log("Updating visit: ", visit);
    return this.http.put<VisitUpdate>(`${this.apiUrl}/visits/${visit.id}`, visit);
  }

  getVisitById(visitId: string): Observable<Visit> {
    return this.http.get<Visit>(`${this.apiUrl}/visits/${visitId}`);
  }

  getVisitsByPatientIdForUser(patientId: string, userId: string): Observable<Visit[]> {
    return this.http.get<Visit[]>(`${this.apiUrl}/visits/patient/${patientId}/user/${userId}`);
  }

  getAllVisitsForOrganization(organizationId: string): Observable<Visit[]> {
    return this.http.get<Visit[]>(`${this.apiUrl}/visits/organization/${organizationId}`);
  }

  deleteVisit(visitId: string): Observable<void> {
    console.log("Deleting visit: ", visitId);
    return this.http.delete<void>(`${this.apiUrl}/visits/${visitId}`);
  }
}
