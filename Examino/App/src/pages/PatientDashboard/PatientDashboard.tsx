import { useEffect } from "react";
import { Outlet, useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../app/store";
import { getUser } from "../../features/userSlice";
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
import NavItem from "../../components/common/NavItem/NavItem";

const PatientDashboard = () => {
  const { user } = useSelector((state: RootState) => state.user);
  const navigate = useNavigate();
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (user) {
      dispatch(getRaports());
      dispatch(getUser());
    } else {
      navigate("/");
    }
  }, [user]);

  const handleLogout = () => {
    dispatch(logout());
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

export default PatientDashboard;
