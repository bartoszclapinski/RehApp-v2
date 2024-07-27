export interface Address {
  street: string;
  city: string;
  zipCode: string;
  country: string;
}

export interface UserOrganization {
  organizationId: string;
  organizationName: string;
}

export interface BaseUser {
  id: string;
  email: string;
  role: string;
  firstName: string;
  lastName: string;
  createdAt: Date;
  lastLoginAt: Date | null;
  isActive: boolean;
  address: Address;
  userOrganizations: UserOrganization[];
}

export interface DoctorUser extends BaseUser {
  specialization: string;
  licenseNumber: string;
}

export interface NurseUser extends BaseUser {
  department: string;
  licenseNumber: string;
}

export interface AdminUser extends BaseUser {
  adminLevel: string;
}

export type User = BaseUser | DoctorUser | NurseUser | AdminUser;
