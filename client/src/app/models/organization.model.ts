export interface CreateOrganizationDto {
  name: string;
  description: string;
  street: string;
  city: string;
  zipCode: string;
  country: string;
}

export type CreateOrganization = CreateOrganizationDto;
