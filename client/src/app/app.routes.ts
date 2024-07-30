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
  { path: 'create-user', component: CreateUserComponent, canActivate: [authGuard] },
  { path: 'user-profile', component: UserProfileComponent, canActivate: [authGuard] },
  { path: 'all-users', component: UsersListComponent, canActivate: [authGuard] },
  { path: '', redirectTo: '/profile', pathMatch: 'full' },
  { path: '**', redirectTo: '/profile' }
];
