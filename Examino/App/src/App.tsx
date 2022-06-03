import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
  Outlet,
} from "react-router-dom";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import AuthenticationRoute from "./components/AuthenticationRoute/AuthenticationRoute";
import ProtectedRoute from "./components/ProtectedRoute/ProtectedRoute";
import LoginPage from "./pages/LoginPage/LoginPage";
import RegisterPage from "./pages/RegisterPage/RegisterPage";
import PatientDashboardPage from "./pages/DashboardPages/PatientDashboardPage/PatientDashboardPage";
import DoctorDashboardPage from "./pages/DashboardPages/DoctorDashboardPage/DoctorDashboardPage";
import PatientPanel from "./components/PatientDashboardComponents/PatientPanel/PatientPanel";
import PatientHistory from "./components/PatientDashboardComponents/PatientHistory/PatientHistory";
import PatientProfile from "./components/PatientDashboardComponents/PatientProfile/PatientProfile";
import RaportDetails from "./components/PatientDashboardComponents/RaportDetails/RaportDetails";
import PrescriptionDetails from "./components/PatientDashboardComponents/PrescriptionDetails/PrescriptionDetails";
import DoctorPanel from "./components/DoctorDashboardComponents/DoctorPanel/DoctorPanel";
import DoctorForm from "./components/DoctorDashboardComponents/DoctorForm/DoctorForm";

function App() {
  return (
    <AuthenticationRoute>
      <Router>
        <Routes>
          <Route element={<ProtectedRoute allowedRole="Patient" />}>
            <Route path="patient" element={<PatientDashboardPage />}>
              <Route index element={<Navigate to="panel" />} />
              <Route path="panel" element={<PatientPanel />} />
              <Route path="history" element={<Outlet />}>
                <Route index element={<PatientHistory />} />
                <Route path="raport/:id" element={<RaportDetails />} />
                <Route
                  path="prescription/:id"
                  element={<PrescriptionDetails />}
                />
              </Route>
              <Route path="profile" element={<PatientProfile />} />
            </Route>
          </Route>
          <Route element={<ProtectedRoute allowedRole="Doctor" />}>
            <Route path="doctor" element={<DoctorDashboardPage />}>
              <Route index element={<Navigate to="panel" />} />
              <Route path="panel" element={<DoctorPanel />} />
              <Route path="form" element={<DoctorForm />} />
            </Route>
          </Route>
          <Route path="register" element={<RegisterPage />} />
          <Route path="/" element={<LoginPage />} />
        </Routes>
        <ToastContainer />
      </Router>
    </AuthenticationRoute>
  );
}

export default App;
