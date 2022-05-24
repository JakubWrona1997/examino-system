import { useEffect } from "react";
import { NavLink, Outlet, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../app/store";
import { getRaports } from "../../features/raportSlice";
import { logout } from "../../features/userSlice";
import {
  FaHeartbeat,
  FaThLarge,
  FaCalendarAlt,
  FaUserAlt,
  FaSignOutAlt,
} from "react-icons/fa";
import "./PatientDashboard.scss";

const PatientDashboard = () => {
  const { token } = useSelector((state: RootState) => state.user);
  const navigate = useNavigate();
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (token) {
      dispatch(getRaports());
    } else {
      navigate("/");
    }
  }, [token]);

  const handleLogout = () => {
    dispatch(logout());
    navigate("/");
  };

  return (
    <div className="dashboard">
      <div className="dashboard-navigation">
        <div className="dashboard-navigation-logo">
          <FaHeartbeat />
          &nbsp;Examino
        </div>
        <div className="dashboard-navigation-links">
          <NavLink
            to="panel"
            className={(navData) => (navData.isActive ? "link active" : "link")}
          >
            <span className="link-icon">
              <FaThLarge />
            </span>
            Panel
          </NavLink>
          <NavLink
            to="history"
            className={(navData) => (navData.isActive ? "link active" : "link")}
          >
            <span className="link-icon">
              <FaCalendarAlt />
            </span>
            Historia
          </NavLink>
          <NavLink
            to="profile"
            className={(navData) => (navData.isActive ? "link active" : "link")}
          >
            <span className="link-icon">
              <FaUserAlt />
            </span>
            Profil
          </NavLink>
          <button type="button" className="link" onClick={handleLogout}>
            <span className="link-icon">
              <FaSignOutAlt />
            </span>
            Wyloguj
          </button>
        </div>
      </div>
      <div className="dashboard-content">
        <Outlet />
      </div>
    </div>
  );
};

export default PatientDashboard;
