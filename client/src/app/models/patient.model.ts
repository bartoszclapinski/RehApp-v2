export interface Address {
  street: string;
  city: string;
  zipCode: string;
  country: string;
}

export interface Patient {
  id: string;
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  conditionDescription: string;
  address: Address;
  pesel: string;
  phoneNumber: string;
  organizationId?: string;
  physiotherapistId?: string;
  doctorId?: string;
  nurseId?: string;
}
