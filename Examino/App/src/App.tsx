import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import Register from "./pages/Register/Register";
import Login from "./pages/Login/Login";
import PatientDashboard from "./pages/PatientDashboard/PatientDashboard";
import PatientDashboardPanel from "./components/PatientDashboardPanel/PatientDashboardPanel";
import PatientDashboardHistory from "./components/PatientDashboardHistory/PatientDashboardHistory";
import PatientDashboardProfile from "./components/PatientDashboardProfile/PatientDashboardProfile";

function App() {
  return (
    <Router>
      <main>
        <Routes>
          <Route path="dashboard" element={<PatientDashboard />}>
            <Route index element={<Navigate to="panel" />} />
            <Route path="panel" element={<PatientDashboardPanel />} />
            <Route path="history" element={<PatientDashboardHistory />} />
            <Route path="profile" element={<PatientDashboardProfile />} />
          </Route>
          <Route path="register" element={<Register />} />
          <Route path="/" element={<Login />} />
        </Routes>
      </main>
    </Router>
  );
}

export default App;
