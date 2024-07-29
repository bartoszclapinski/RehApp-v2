import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserOrganization } from '../../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {
  private apiUrl = 'https://localhost:7000/api';

  constructor(private http: HttpClient) { }

  getOrganizationsForAdmin(): Observable<UserOrganization[]> {
    return this.http.get<UserOrganization[]>(`${this.apiUrl}/organizations`);
  }

  getOrganizationsForUser(): Observable<UserOrganization[]> {
    return this.http.get<UserOrganization[]>(`${this.apiUrl}/organizations/for-user`);
  }

  getOrganizationById(id: string): Observable<UserOrganization> {
    return this.http.get<UserOrganization>(`${this.apiUrl}/organizations/${id}`);
  }
}
