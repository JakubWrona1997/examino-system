export interface Raport {
  patientName: string;
  patientSurname: string;
  doctorName: string;
  doctorSurname: string;
  raport: {
    id: string;
    patientId: string;
    doctorId: string;
    raportTime: Date;
    symptoms: string;
    examination: string;
    diagnosis: string;
    recommendation: string;
    comment: string;
  };
  prescription: {
    id: string;
    raportId: string;
    medicines: string;
  };
}

export interface CreateRaport {
  patientId: string;
  doctorId: string;
  symptoms: string;
  examination: string;
  diagnosis: string;
  recommendation: string;
  comment: string;
}
