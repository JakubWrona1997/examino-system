import { useEffect } from "react";
import { Outlet, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../../app/store";
import { getRaports } from "../../../features/raportSlice";
import { getUserData, logoutUser } from "../../../features/userSlice";
import {
  FaHeartbeat,
  FaThLarge,
  FaFileAlt,
  FaClipboard,
  FaCalendarAlt,
  FaUserAlt,
  FaSignOutAlt,
} from "react-icons/fa";
import "./DoctorDashboardPage.scss";
import NavItem from "../../../components/layout/NavItem/NavItem";

const DoctorDashboardPage = () => {
  const { user } = useSelector((state: RootState) => state.user);
  const navigate = useNavigate();
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (user) {
      dispatch(getRaports());
      dispatch(getUserData());
    } else {
      navigate("/");
    }
  }, []);

  const handleLogout = () => {
    dispatch(logoutUser());
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
          <NavItem to="panel" label="Panel" icon={<FaThLarge />} />
          <NavItem to="history" label="Historia" icon={<FaCalendarAlt />} />
          <NavItem to="form" label="Formularz" icon={<FaFileAlt />} />
          <NavItem to="schedule" label="Terminarz" icon={<FaClipboard />} />
          <NavItem to="profile" label="Profil" icon={<FaUserAlt />} />
          <NavItem
            to="/"
            label="Wyloguj"
            icon={<FaSignOutAlt />}
            onClick={handleLogout}
          />
        </div>
      </div>
      <div className="dashboard-content">
        <Outlet />
      </div>
    </div>
  );
};

export default DoctorDashboardPage;
