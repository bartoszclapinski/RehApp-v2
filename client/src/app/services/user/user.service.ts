import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map, Observable} from 'rxjs';
import {AdminUser, BaseUser, DoctorUser, NurseUser, User} from '../../models/user.model';
import {tap} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://localhost:7000/api';
  private _user: User = {} as User;

  constructor(private http: HttpClient) { }

  get user(): User {
    return this._user;
  }

  getCurrentUser(): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/identity/current`).pipe(
      map(user => this.mapUser(user)),
      tap(user => this._user = user)
    );
  }

  updateUserProfile(user: User): Observable<User> {
    console.log('Sending to api user profile:', user);
    return this.http.patch<User>(`${this.apiUrl}/identity/update`, user).pipe(
      tap(updatedUser => this._user = updatedUser)
    );
  }

  private mapUser(user: User): User {
    switch (user.role) {
      case 'Doctor':
        return {...user} as DoctorUser;
      case 'Physiotherapist':
        return {...user} as DoctorUser;
      case 'Nurse':
        return {...user} as NurseUser;
      case 'OrganizationAdmin':
        return {...user} as AdminUser;
      default:
        return user as BaseUser;
    }
  }
}
