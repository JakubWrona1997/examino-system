import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
  Outlet,
} from "react-router-dom";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import AuthenticationRoute from "./components/Routes/AuthenticationRoute/AuthenticationRoute";
import ProtectedRoute from "./components/Routes/ProtectedRoute/ProtectedRoute";
import LoginPage from "./pages/LoginPage/LoginPage";
import RegisterPage from "./pages/RegisterPage/RegisterPage";
import PatientDashboardPage from "./pages/DashboardPages/PatientDashboardPage/PatientDashboardPage";
import DoctorDashboardPage from "./pages/DashboardPages/DoctorDashboardPage/DoctorDashboardPage";
import AdminDashboardPage from "./pages/DashboardPages/AdminDashboardPage/AdminDashboardPage";
import RaportDetails from "./components/RaportDetails/RaportDetails";
import PrescriptionDetails from "./components/PrescriptionDetails/PrescriptionDetails";
import PatientPanel from "./components/PatientDashboardComponents/PatientPanel/PatientPanel";
import PatientHistory from "./components/PatientDashboardComponents/PatientHistory/PatientHistory";
import PatientProfile from "./components/PatientDashboardComponents/PatientProfile/PatientProfile";
import DoctorPanel from "./components/DoctorDashboardComponents/DoctorPanel/DoctorPanel";
import DoctorHistory from "./components/DoctorDashboardComponents/DoctorHistory/DoctorHistory";
import DoctorForm from "./components/DoctorDashboardComponents/DoctorForm/DoctorForm";
import DoctorSchedule from "./components/DoctorDashboardComponents/DoctorSchedule/DoctorSchedule";
import DoctorProfile from "./components/DoctorDashboardComponents/DoctorProfile/DoctorProfile";
import DoctorsRecord from "./components/AdminDashboardComponents/DoctorsRecord/DoctorsRecord";
import RegisterDoctorForm from "./components/AdminDashboardComponents/RegisterDoctorForm/RegisterDoctorForm";
import AdminProfile from "./components/AdminDashboardComponents/AdminProfile/AdminProfile";

function App() {
  return (
    <AuthenticationRoute>
      <Router>
        <Routes>
          <Route element={<ProtectedRoute allowedRole="patient" />}>
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
          <Route element={<ProtectedRoute allowedRole="doctor" />}>
            <Route path="doctor" element={<DoctorDashboardPage />}>
              <Route index element={<Navigate to="panel" />} />
              <Route path="panel" element={<DoctorPanel />} />
              <Route path="history" element={<Outlet />}>
                <Route index element={<DoctorHistory />} />
                <Route path="raport/:id" element={<RaportDetails />} />
                <Route
                  path="prescription/:id"
                  element={<PrescriptionDetails />}
                />
              </Route>
              <Route path="form" element={<DoctorForm />} />
              <Route path="schedule" element={<DoctorSchedule />} />
              <Route path="profile" element={<DoctorProfile />} />
            </Route>
          </Route>
          <Route element={<ProtectedRoute allowedRole="admin" />}>
            <Route path="admin" element={<AdminDashboardPage />}>
              <Route index element={<Navigate to="doctors" />} />
              <Route path="doctors" element={<DoctorsRecord />} />
              <Route path="form" element={<RegisterDoctorForm />} />
              <Route path="profile" element={<AdminProfile />} />
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
