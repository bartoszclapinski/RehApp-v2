import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Patient } from '../../models/patient.model';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  private apiUrl = 'https://localhost:7000/api';

  constructor(private http: HttpClient) { }

  getPatientsForOrganization(organizationId: string): Observable<Patient[]> {
    return this.http.get<Patient[]>(`${this.apiUrl}/patients/organization/${organizationId}`);
  }

  getPatientById(id: string): Observable<Patient> {
    return this.http.get<Patient>(`${this.apiUrl}/patients/${id}`);
  }

  createPatient(patientData: Patient): Observable<Patient> {
    return this.http.post<Patient>(`${this.apiUrl}/patients/create`, patientData);
  }

  updatePatient(patientData: Patient): Observable<Patient> {
    return this.http.put<Patient>(`${this.apiUrl}/patients/update`, patientData);
  }
}
