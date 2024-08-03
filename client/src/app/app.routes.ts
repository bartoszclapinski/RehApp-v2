import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AdminDashboardComponent } from './components/dashboards/admin-dashboard/admin-dashboard.component';
import { authGuard } from './guards/auth.guard';
import { UserProfileComponent } from "./components/user-profile/user-profile.component";
import {DoctorDashboardComponent} from "./components/dashboards/doctor-dashboard/doctor-dashboard.component";
import {
  PhysiotherapistDashboardComponent
} from "./components/dashboards/physiotherapist-dashboard/physiotherapist-dashboard.component";
import {NurseDashboardComponent} from "./components/dashboards/nurse-dashboard/nurse-dashboard.component";
import {
  OrganisationAdminDashboardComponent
} from "./components/dashboards/organisation-admin-dashboard/organisation-admin-dashboard.component";
import {OrganizationsComponent} from "./components/organizations/organizations.component";
import {OrganizationDetailsComponent} from "./components/organization-details/organization-details.component";
import {CreateOrganizationComponent} from "./components/create-organization/create-organization.component";
import {CreateUserComponent} from "./components/create-user/create-user.component";
import {UsersListComponent} from "./components/user-list/user-list.component";
import {AddUserToOrganizationComponent} from "./components/add-user-to-organization/add-user-to-organization.component";
import {CreatePatientComponent} from "./components/patients/create-patient/create-patient.component";
import {PatientListComponent} from "./components/patients/patient-list/patient-list.component";
import {EditPatientComponent} from "./components/patients/edit-patient/edit-patient.component";
import {AddVisitComponent} from "./components/visits/add-visit/add-visit.component";
import {VisitListComponent} from "./components/visits/visit-list/visit-list.component";
import {EditVisitComponent} from "./components/visits/edit-visit/edit-visit.component";

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [authGuard] },
  { path: 'admin-dashboard', component: AdminDashboardComponent, canActivate: [authGuard] },
  { path: 'doctor-dashboard', component: DoctorDashboardComponent, canActivate: [authGuard] },
  { path: 'physiotherapist-dashboard', component: PhysiotherapistDashboardComponent, canActivate: [authGuard] },
  { path: 'nurse-dashboard', component: NurseDashboardComponent, canActivate: [authGuard] },
  { path: 'organization-admin-dashboard', component: OrganisationAdminDashboardComponent, canActivate: [authGuard] },
  { path: 'organizations', component: OrganizationsComponent, canActivate: [authGuard] },
  { path: 'organization/details/:id', component: OrganizationDetailsComponent, canActivate: [authGuard] },
  { path: 'organization/create', component: CreateOrganizationComponent, canActivate: [authGuard] },
  { path: 'organization/add-users/:id', component: AddUserToOrganizationComponent,canActivate: [authGuard] },
  { path: 'organization/patient/create/:id', component: CreatePatientComponent, canActivate: [authGuard] },
  { path: 'organization/:id/patients', component: PatientListComponent },
  { path: 'organization/:id/visits', component: VisitListComponent },
  { path: 'patient/edit/:id', component: EditPatientComponent },
  { path: 'visit/add', component: AddVisitComponent },
  { path: 'visit/edit/:id', component: EditVisitComponent },
  { path: 'create-user', component: CreateUserComponent, canActivate: [authGuard] },
  { path: 'user-profile', component: UserProfileComponent, canActivate: [authGuard] },
  { path: 'user-profile/:id', component: UserProfileComponent, canActivate: [authGuard] },
  { path: 'all-users', component: UsersListComponent, canActivate: [authGuard] },
  { path: '', redirectTo: '/profile', pathMatch: 'full' },
  { path: '**', redirectTo: '/profile' }
];
