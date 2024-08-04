import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {BaseUser, Organization, User, UserOrganization} from '../../models/user.model';
import {CreateOrganization, CreateOrganizationDto} from "../../models/organization.model";

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {
  private apiUrl = 'https://localhost:7000/api';

  constructor(private http: HttpClient) { }

  getOrganizationsForAdmin(): Observable<Organization[]> {
    return this.http.get<Organization[]>(`${this.apiUrl}/organizations`);
  }

  getOrganizationsForUser(userId: string): Observable<Organization[]> {
    return this.http.get<Organization[]>(`${this.apiUrl}/organizations/user/${userId}`);
  }

  getOrganizationById(id: string): Observable<Organization> {
    return this.http.get<Organization>(`${this.apiUrl}/organizations/${id}`);
  }

  getOrganizationAdministrators(organizationId: string): Observable<BaseUser[]> {
    return this.http.get<BaseUser[]>(`${this.apiUrl}/identity/for-admins/${organizationId}`);
  }

  updateOrganization(organization: Organization): Observable<Organization> {
    return this.http.patch<Organization>(`${this.apiUrl}/organizations/update`, organization);
  }

  createOrganization(organization: CreateOrganization): Observable<CreateOrganization> {
    console.log('Creating organization', organization);
    return this.http.post<CreateOrganization>(`${this.apiUrl}/organizations/create`, organization);
  }

  addUserToOrganization(userId: string, organizationId: string): Observable<UserOrganization> {
    console.log('Adding user to organization', userId, organizationId);
    return this.http.post<UserOrganization>(`${this.apiUrl}/organizations/add-user`, { userId, organizationId });
  }

  getAllUsersNotInOrganization(organizationId: string): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/organizations/users-not-in-organization/${organizationId}`);
  }
}
