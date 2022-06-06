export interface RaportCreateViewModel {
  patientId: string;
  symptoms: string;
  examination: string;
  diagnosis: string;
  recommendation: string;
  comment: string;
  prescription: {
    medicines: string;
  };
}
