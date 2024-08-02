export interface Address {
  street: string;
  city: string;
  zipCode: string;
  country: string;
}

export interface UpdateUser {
  id: string;
  email: string;
  firstName: string;
  lastName: string;
  role: string;
  phoneNumber: string;
  pesel: string;
  address: Address;
  specialization?: string;
  licenseNumber?: string;
  department?: string;
  adminLevel?: string;
}
