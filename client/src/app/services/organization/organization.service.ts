import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {BaseUser, UserOrganization} from '../../models/user.model';
import {CreateOrganization} from "../../models/organization.model";

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {
  private apiUrl = 'https://localhost:7000/api';

  constructor(private http: HttpClient) { }

  getOrganizationsForAdmin(): Observable<UserOrganization[]> {
    return this.http.get<UserOrganization[]>(`${this.apiUrl}/organizations`);
  }

  getOrganizationsForUser(userId: string): Observable<UserOrganization[]> {
    return this.http.get<UserOrganization[]>(`${this.apiUrl}/organizations/user/${userId}`);
  }

  getOrganizationById(id: string): Observable<UserOrganization> {
    return this.http.get<UserOrganization>(`${this.apiUrl}/organizations/${id}`);
  }

  getOrganizationAdministrators(organizationId: string): Observable<BaseUser[]> {
    return this.http.get<BaseUser[]>(`${this.apiUrl}/identity/for-admins/${organizationId}`);
  }

  updateOrganization(organization: UserOrganization): Observable<UserOrganization> {
    return this.http.patch<UserOrganization>(`${this.apiUrl}/organizations/update`, organization);
  }

  createOrganization(organization: CreateOrganization): Observable<UserOrganization> {
    return this.http.post<UserOrganization>(`${this.apiUrl}/organizations/create`, organization);
  }
}
