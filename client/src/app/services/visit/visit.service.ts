// src/app/services/visit/visit.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Visit } from '../../models/visit.model';

@Injectable({
  providedIn: 'root'
})
export class VisitService {
  private apiUrl = 'https://localhost:7000/api';

  constructor(private http: HttpClient) { }

  createVisit(visit: Visit): Observable<Visit> {
    console.log("Adding visit: ", visit);
    return this.http.post<Visit>(`${this.apiUrl}/visits/add-visit`, visit);
  }

  getVisitsByPatientId(patientId: string): Observable<Visit[]> {
    return this.http.get<Visit[]>(`${this.apiUrl}/visits/patient/${patientId}`);
  }

  getVisitById(visitId: string): Observable<Visit> {
    return this.http.get<Visit>(`${this.apiUrl}/visits/${visitId}`);
  }

  updateVisit(visit: Visit): Observable<Visit> {
    return this.http.put<Visit>(`${this.apiUrl}/visits/${visit.id}`, visit);
  }

  deleteVisit(visitId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/visits/${visitId}`);
  }

  getVisitsByOrganizationId(organizationId: string): Observable<Visit[]> {
    return this.http.get<Visit[]>(`${this.apiUrl}/visits/organization/${organizationId}`);
  }

  getVisitsByUserId(userId: string): Observable<Visit[]> {
    return this.http.get<Visit[]>(`${this.apiUrl}/visits/user/${userId}`);
  }
}
