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
