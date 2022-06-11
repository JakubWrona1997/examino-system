import { TypeOptions } from "react-toastify";

export interface AlertViewModel {
  type: TypeOptions;
  message: React.ReactNode;
}
