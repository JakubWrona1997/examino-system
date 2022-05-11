export interface User {
  _id: string;
  firstName: string;
  lastName: string;
  email: string;
  token: string;
}

export interface RegisterUser {
  firstName: string;
  lastName: string;
  pesel: string;
  email: string;
  password: string;
}

export interface LoginUser {
  email: string;
  password: string;
}
