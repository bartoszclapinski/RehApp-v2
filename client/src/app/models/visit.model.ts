import {Patient} from "./patient.model";
import {User} from "./user.model";

export interface VisitToAdd {
  id: string;
  date: Date;
  description: string;
  createdByUserId: string;
  patientId: string;
  organizationId: string;
}

export interface VisitUpdate {
  id: string;
  date: string;
  description: string;
}

export interface Visit {
  id: string;
  date: Date;
  description: string;
  patient: Patient;
  user: User;
}
