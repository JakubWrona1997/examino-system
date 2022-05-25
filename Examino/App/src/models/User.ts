export interface User {
  name: string;
  role: string;
  token: string;
}
export interface UserData {
  gender: string;
  name: string;
  surname: string;
  phoneNumber: string;
  postalCode: string;
  city: string;
  address: string;
  dateOfBirth: string;
  pesel: string;
  height: string;
  weight: string;
  bloodType: string;
}

export interface RegisterUser {
  name: string;
  surname: string;
  pesel: string;
  email: string;
  password: string;
}

export interface LoginUser {
  email: string;
  password: string;
}

export interface RegisterError {
  Name: string[];
  Surname: string[];
  PESEL: string[];
  Email: string[];
  Password: string[];
}
