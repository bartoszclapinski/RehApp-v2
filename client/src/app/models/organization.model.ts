export interface CreateOrganizationDto {
  name: string;
  description: string;
  street: string;
  city: string;
  zipCode: string;
  country: string;
  phone: string;
  email: string;
  additionalInfo?: string;
  taxNumber: string;
}

export type CreateOrganization = CreateOrganizationDto;
