import jwt_decode from "jwt-decode";
import { TokenViewModel } from "../models/Token/TokenViewModel";
import { UserViewModel } from "../models/Users/UserViewModel";

const tokenDecode = (token: string): UserViewModel => {
  const decoded: TokenViewModel = jwt_decode(token);

  return {
    name: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
    role: decoded[
      "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
    ],
    token,
  };
};

export default tokenDecode;
