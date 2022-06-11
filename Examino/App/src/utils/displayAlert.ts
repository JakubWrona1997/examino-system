import { toast } from "react-toastify";
import { AlertViewModel } from "../models/Alert/AlertViewModel";

const displayAlert = (alert: AlertViewModel, autoClose?: number | false) => {
  switch (alert.type) {
    case "info":
      toast.info(alert.message, { autoClose });
      break;
    case "success":
      toast.success(alert.message, { autoClose });
      break;
    case "warning":
      toast.warning(alert.message, { autoClose });
      break;
    case "error":
      toast.error(alert.message, { autoClose });
      break;
    default:
      break;
  }
};

export default displayAlert;
