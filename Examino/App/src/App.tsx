import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import Register from "./pages/Register/Register";
import Login from "./pages/Login/Login";
import PatientDashboard from "./pages/PatientDashboard/PatientDashboard";
import PatientPanel from "./components/PatientPanel/PatientPanel";
import PatientHistory from "./components/PatientHistory/PatientHistory";
import PatientProfile from "./components/PatientProfile/PatientProfile";
import RaportDetails from "./components/RaportDetails/RaportDetails";
import PrescriptionDetails from "./components/PrescriptionDetails/PrescriptionDetails";
import ProtectedRoute from "./components/ProtectedRoute/ProtectedRoute";

function App() {
  return (
    <Router>
      <main>
        <Routes>
          <Route element={<ProtectedRoute allowedRole="Patient" />}>
            <Route path="patient" element={<PatientDashboard />}>
              <Route index element={<Navigate to="panel" />} />
              <Route path="panel" element={<PatientPanel />} />
              <Route path="history" element={<PatientHistory />} />
              <Route
                path="history/raports/:id/details"
                element={<RaportDetails />}
              />
              <Route
                path="history/prescription/:id/details"
                element={<PrescriptionDetails />}
              />
              <Route path="profile" element={<PatientProfile />} />
            </Route>
          </Route>
          <Route path="register" element={<Register />} />
          <Route path="/" element={<Login />} />
        </Routes>
      </main>
    </Router>
  );
}

export default App;
