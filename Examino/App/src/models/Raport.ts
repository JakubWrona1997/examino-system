export interface Raport {
  Id: string;
  PatientId: string;
  DoctorId: string;
  RaportTime: Date;
  Symptoms: string;
  Examination: string;
  Diagnosis: string;
  Recommendation: string;
  Comment: string;
}

export interface CreateRaport {
  PatientId: string;
  Symptoms: string;
  Examination: string;
  Diagnosis: string;
  Recommendation: string;
  Comment: string;
}
