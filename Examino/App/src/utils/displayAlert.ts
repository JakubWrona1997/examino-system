import { toast } from "react-toastify";
import { AlertViewModel } from "../models/Alert/AlertViewModel";

const displayAlert = (alert: AlertViewModel) => {
  switch (alert.type) {
    case "info":
      toast.info(alert.message);
      break;
    case "success":
      toast.success(alert.message);
      break;
    case "warning":
      toast.warning(alert.message);
      break;
    case "error":
      toast.error(alert.message);
      break;
    default:
      break;
  }
};

export default displayAlert;
