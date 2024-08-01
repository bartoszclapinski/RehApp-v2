export interface Address {
  street: string;
  city: string;
  zipCode: string;
  country: string;
}

export interface Organization {
  id: string;
  name: string;
  description: string;
  address: Address;
  createdAt: Date;
  phone: string;
  email: string;
  additionalInfo?: string;
  taxNumber: string;
}

export interface UserOrganization {
  userId: string;
  organizationId: string;
  organization: Organization;
  joinedAt: Date;
}

export interface BaseUser {
  id: string;
  email: string;
  role: string;
  firstName: string;
  lastName: string;
  pesel: string;
  phoneNumber: string;
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
